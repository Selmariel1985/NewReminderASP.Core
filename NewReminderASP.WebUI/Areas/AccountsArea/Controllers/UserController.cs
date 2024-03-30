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
        private readonly IUserProvider _provider;


        public UserController(IUserProvider provider)
        {
            _provider = provider;
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut(); // Signs the user out
            return
                RedirectToAction("Login", "Login", new { area = "LoginArea" });
        }


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


        public ActionResult Details(int id)
        {
            var user = _provider.GetUser(id);
            if (user == null) return HttpNotFound();
            return View(user);
        }


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

        public ActionResult EditUserAndRoles(int id)
        {
            var user = _provider.GetUser(id);
            var userRoles = _provider.GetUserRoles(id);
            var roles = _provider.GetRoles();
            var userAndRolesModel = new UserAndRolesModel
            {
                User = user,
                UserRole = new UserRole
                {
                    UserId = userRoles?.UserId ?? 0,
                    SelectedRoleIds = userRoles?.SelectedRoleIds,
                    Roles = roles
                }
            };


            return View(userAndRolesModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserAndRoles(UserAndRolesModel model, int[] SelectedRoles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _provider.UpdateUser(model.User);
                    if (SelectedRoles != null)
                        _provider.UpdateUserRoles(model.User.Id, string.Join(",", SelectedRoles));
                    else
                        return RedirectToAction("CreateUserRoleById");

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.Error("An error occurred in EditUserAndRoles()", ex);
                return View();
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var user = _provider.GetUser(id);
            if (user == null) return HttpNotFound();
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _provider.UpdateUser(user);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.Error("An error occurred in Index()", ex);


                return View("Error");
            }

            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

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


        public ActionResult Delete(int id)
        {
            var user = _provider.GetUser(id);
            if (user == null) return HttpNotFound();
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult Role(string orderBy, string sortOrder, int page = 1)
        {
            var role = _provider.GetRoles().AsQueryable();
            const int pageSize = 10;

            var paginatedRole = DynamicSortAndPaginate(role, orderBy, sortOrder, page, pageSize).ToList();


            int totalRole = role.Count();
            int totalPages = (int)Math.Ceiling((double)totalRole / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedRole);
        }

      

        public ActionResult DetailsRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        public ActionResult CreateRole()
        {
            return View();
        }

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

        public ActionResult EditRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        // POST: User/Edit/5
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


        public ActionResult DeleteRole(int id)
        {
            var role = _provider.GetRolesByID(id);
            if (role == null) return HttpNotFound();
            return View(role);
        }

        [HttpPost]
        [ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleConfirmed(int id)
        {
            _provider.RemoveRole(id);
            return RedirectToAction("Index");
        }

        public ActionResult UserRole(string orderBy, string sortOrder, int page = 1)
        {
            var userRoles = _provider.GetUsersRoles().AsQueryable();
            const int pageSize = 10;

            var paginatedUserRole = DynamicSortAndPaginate(userRoles, orderBy, sortOrder, page, pageSize).ToList();


            int totalUserRole = userRoles.Count();
            int totalPages = (int)Math.Ceiling((double)totalUserRole / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedUserRole);
        }
        

        public ActionResult CreateUserRoleById()
        {
            var model = new UserRole
            {
                Users = _provider.GetUsers(),
                Roles = _provider.GetRoles()
            };
            return View(model);
        }

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


        public ActionResult CreateUserRole()
        {
            return View();
        }

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