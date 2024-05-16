using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.AccountsArea.Controllers
{
    [RouteArea("AccountsArea")]
    [RoutePrefix("User")]
    public class UserController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAddressProvider _addressProvider;
        private readonly IPersonalInformationProvider _personalInfoProvider;
        private readonly IPhoneProvider _phoneProvider;
        private readonly IUserProvider _provider;

        public UserController(IUserProvider userProvider, IAddressProvider addressProvider,
            IPhoneProvider phoneProvider, IPersonalInformationProvider personalInfoProvider)
        {
            _provider = userProvider;
            _addressProvider = addressProvider;
            _phoneProvider = phoneProvider;
            _personalInfoProvider = personalInfoProvider;
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut(); // Очистить аутентификацию
            return RedirectToAction("Login", "Login", new { area = "LoginArea" }); // Перенаправление на страницу входа
        }

        [Authorize]
        public ActionResult Index(string orderBy, string sortOrder, int page = 1)
        {
            var users = _provider.GetUsers().AsQueryable();
            const int pageSize = 10;

            var paginatedUsers = DynamicSortAndPaginate(users, orderBy, sortOrder, page, pageSize).ToList();

            var totalUsers = users.Count();
            var totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

            var currentUser = HttpContext.User;
            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(new Tuple<IEnumerable<User>, ClaimsPrincipal>(paginatedUsers, (ClaimsPrincipal)currentUser));
        }
        [Authorize]
        public ActionResult DetailsAdmin(int id)
        {
            var user = _provider.GetUser(id);
            if (user == null) return HttpNotFound();

            var addresses = _addressProvider.GetAddressesByUserId(id);
            var phone = _phoneProvider.GetUserPhonesByUserId(id);
            var personalInfo = _personalInfoProvider.GetPersonalInfo(id);

            var viewModel = new UserDetailsViewModel
            {
                User = user,
                Addresses = addresses,
                Phones = phone,
                PersonalInformation = personalInfo
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Details(string userName)
        {
            var user = _provider.GetUserByLogin(userName);
            if (user == null) return HttpNotFound();

            var userId = user.Id; // Получаем числовой идентификатор пользователя из объекта user

            var addresses = _addressProvider.GetAddressesByUserId(userId);
            var phones = _phoneProvider.GetUserPhonesByUserId(userId);
            var personalInfo = _personalInfoProvider.GetPersonalInfo(userId);

            var viewModel = new UserDetailsViewModel
            {
                User = user,
                Addresses = addresses,
                Phones = phones,
                PersonalInformation = personalInfo
            };

            if (User.IsInRole("Admin") || user.Login == User.Identity.Name)
                return View(viewModel);
            return new HttpUnauthorizedResult();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditUserRole(int id)
        {
            var userRoles = _provider.GetUserRoles(id);
            var roles = _provider.GetRoles();

            if (userRoles == null || roles == null) return HttpNotFound();

            var userRoleModel = new UserRole
            {
                UserId = userRoles.UserId,
                SelectedRoleIds = userRoles.SelectedRoleIds,
                Roles = roles
            };

            return View(userRoleModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserRole(UserRole userRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _provider.UpdateUserRoles(userRole.UserId, string.Join(",", userRole.SelectedRoleIds));

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.Error("An error occurred in EditUserRole()", ex);
                return View("Error");
            }

            return View(userRole);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditUserAndRoles(int id)
        {
            var user = _provider.GetUser(id);

            var roles = _provider.GetRoles();

            if (user != null)
            {
                var userAndRolesModel = new UserAndRolesModel
                {
                    User = user,
                    UserRole = new UserRole
                    {
                        Roles = roles
                    }
                };

                return View(userAndRolesModel);
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserAndRoles(UserAndRolesModel model, int[] SelectedRoles)
        {
            var roles = _provider.GetRoles();
            model.UserRole = model.UserRole ?? new UserRole();
            model.UserRole.Roles = roles;

            if (!ModelState.IsValid) return View(model);

            if (string.IsNullOrEmpty(model.User.Password))
            {
                ModelState.AddModelError("User.Password", "Введите пароль");
                return View(model);
            }

            try
            {
                _provider.UpdateUser(model.User);

                if (SelectedRoles != null && SelectedRoles.Any())
                    _provider.UpdateUserRoles(model.User.Id, string.Join(",", SelectedRoles));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.Error("An error occurred in EditUserAndRoles()", ex);
                ModelState.AddModelError("", "Произошла ошибка при обновлении пользователя и ролей.");
                return View(model);
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var user = _provider.GetUser(id);

            if (user == null || (!User.IsInRole("Admin") && user.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingUser = _provider.GetUser(id);

                    if (existingUser != null && (User.IsInRole("Admin") || existingUser.Login == User.Identity.Name))
                    {
                        // Update the user with the provided user object
                        _provider.UpdateUser(user);
                        return RedirectToAction("Login", "Login", new { area = "LoginArea" });
                    }

                    return new HttpUnauthorizedResult();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.Error("An error occurred in Edit()", ex);

                return View("Error");
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (user.Password == user.ConfirmPassword)
                    {
                        _provider.AddUser(user);
                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError("ConfirmPassword", "The password and confirm password do not match");
                }

                return View(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.Error("An error occurred in Index()", ex);


                return View("Error");
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var user = _provider.GetUser(id);
            if (user == null || (!User.IsInRole("Admin") && user.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();
            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var events = _provider.GetUser(id);


            if (events == null || (!User.IsInRole("Admin") && events.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            _provider.DeleteUser(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Role(string orderBy, string sortOrder, int page = 1)
        {
            var role = _provider.GetRoles().AsQueryable();
            const int pageSize = 10;

            var paginatedRole = DynamicSortAndPaginate(role, orderBy, sortOrder, page, pageSize).ToList();


            var totalRole = role.Count();
            var totalPages = (int)Math.Ceiling((double)totalRole / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedRole);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult DetailsRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                _provider.AddRole(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditRole(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _provider.UpdateRole(role);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.Error("An error occurred in Index()", ex);


                return View("Error");
            }

            return View(role);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleConfirmed(int id)
        {
            _provider.RemoveRole(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UserRole(string orderBy, string sortOrder, int page = 1)
        {
            var userRoles = _provider.GetUsersRoles().AsQueryable();
            const int pageSize = 10;

            var paginatedUserRole = DynamicSortAndPaginate(userRoles, orderBy, sortOrder, page, pageSize).ToList();


            var totalUserRole = userRoles.Count();
            var totalPages = (int)Math.Ceiling((double)totalUserRole / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedUserRole);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateUserRoleById()
        {
            var model = new UserRole
            {
                Users = _provider.GetUsers(),
                Roles = _provider.GetRoles()
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserRoleById(UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _provider.AddUserRole(userRole);
                return RedirectToAction("Index");
            }


            userRole.Users = _provider.GetUsers();
            userRole.Roles = _provider.GetRoles();
            return View(userRole);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateUserRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserRole(string userLogin, string roleName)
        {
            if (ModelState.IsValid)
            {
                _provider.AddUserRoleNormal(userLogin,
                    roleName);


                return RedirectToAction("Index");
            }

            return View();
        }


        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    if (!filterContext.ExceptionHandled)
        //    {
        //        _logger.Error("An unhandled exception occurred", filterContext.Exception);
        //        filterContext.Result = new ViewResult
        //        {
        //            ViewName = "Error"
        //        };
        //        filterContext.ExceptionHandled = true;
        //    }
        //}
    }
}