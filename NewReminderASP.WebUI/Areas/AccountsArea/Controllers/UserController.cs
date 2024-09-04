using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;
using log4net;
using Microsoft.Extensions.Caching.Memory;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.AccountsArea.Controllers
{   // Define the UserController class inheriting from BaseController
    [RouteArea("AccountsArea")]
    [RoutePrefix("User")]
    public class UserController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAddressProvider _addressProvider;
        private readonly IMemoryCache _cache;
        private readonly EmailService _emailService;
        private readonly IPersonalInformationProvider _personalInfoProvider;
        private readonly IPhoneProvider _phoneProvider;
        private readonly IUserProvider _provider;

        // Constructor to initialize dependencies using dependency injection

        public UserController(IUserProvider userProvider, IAddressProvider addressProvider,
            IPhoneProvider phoneProvider, IPersonalInformationProvider personalInfoProvider, IMemoryCache cache,
            EmailService emailService)
        {
            _provider = userProvider;
            _addressProvider = addressProvider;
            _phoneProvider = phoneProvider;
            _personalInfoProvider = personalInfoProvider;
            _cache = cache;
            _emailService = emailService;
        }

        /// <summary>
        ///   Clear authentication and redirect to login page
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut(); 
            return RedirectToAction("Login", "Login", new { area = "LoginArea" }); 
        }

        // Display a list of users with pagination and sorting
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

        // Display detailed user information for admin role

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

        // Display detailed user information for authorized users

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

        // Edit user roles for admin role

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

        // Process user role editing

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

        // The following code handles editing user roles based on the user's ID

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

        // Process the edited user roles data

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

        // Check if a login is unique

        private bool IsLoginUnique(string login)
        {
            return _provider.GetUserByLogin(login) == null;
        }

        // Check if an email is unique

        private bool IsEmailUnique(string email)
        {
            return _provider.GetUserByEmail(email) == null;
        }

        // Edit user details based on the user's ID

        [Authorize]
        public ActionResult Edit(int id)
        {
            var user = _provider.GetUser(id);

            if (user == null || (!User.IsInRole("Admin") && user.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();
            return View(user);
        }

        // Process the edited user data

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
                        if (user.Login != existingUser.Login && !IsLoginUnique(user.Login))
                        {
                            ModelState.AddModelError("Login", "This username is already in use.");
                            return View(user);
                        }

                        if (user.Email != existingUser.Email && !IsEmailUnique(user.Email))
                        {
                            ModelState.AddModelError("User.Email", "This email is already registered.");
                            return View(user);
                        }

                        if (user.Password != user.ConfirmPassword)
                        {
                            ModelState.AddModelError("confirmPassword",
                                "The password and confirmation password do not match.");
                            return View(user);
                        }

                        if (user.Email != user.ConfirmEmail)
                        {
                            ModelState.AddModelError("confirmEmail", "The email and confirmation email do not match.");
                            return View(user);
                        }


                        if (user.Email != existingUser.Email && !string.IsNullOrEmpty(user.Email))
                        {
                            _provider.UpdateUser(user);
                            _emailService.SendEmailChangeNotification(user.Email);
                            return RedirectToAction("Login", "Login", new { area = "LoginArea" });
                        }

                        _provider.UpdateUser(user);
                        return RedirectToAction("Login", "Login", new { area = "LoginArea" });
                    }

                    return new HttpUnauthorizedResult();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("An error occurred in Edit()", ex);
                return View("Error");
            }

            return View(user);
        }

        // Allow admin to create a new user

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // Process the creation of a new user

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (!IsLoginUnique(user.Login))
                    ModelState.AddModelError("User.Login", "This login is already in use.");

                if (!IsEmailUnique(user.Email))
                    ModelState.AddModelError("User.Email", "This email is already registered.");


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

        // Allow authorized users to view and delete a user

        [Authorize]
        public ActionResult Delete(int id)
        {
            var user = _provider.GetUser(id);
            if (user == null || (!User.IsInRole("Admin") && user.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();
            return View(user);
        }

        // Process the deletion of a user

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

        // Display a paginated list of roles

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

        // Display details of a specific role

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        // Allow admin to create a new role

        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole()
        {
            return View();
        }

        // Process the creation of a new role

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

        // Allow admin to edit a role

        [Authorize(Roles = "Admin")]
        public ActionResult EditRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        // Process the editing of a role

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

        // Allow admin to delete a role

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        // Process the deletion of a role

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleConfirmed(int id)
        {
            _provider.RemoveRole(id);
            return RedirectToAction("Index");
        }

        // Display a paginated list of user roles

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

        // Allow admin to assign roles to specific users

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

        // Process the assignment of roles to specific users

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

        // Allow admin to create user roles

        [Authorize(Roles = "Admin")]
        public ActionResult CreateUserRole()
        {
            return View();
        }

            // Process the creation of user roles

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


        // Handle unhandled exceptions

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


