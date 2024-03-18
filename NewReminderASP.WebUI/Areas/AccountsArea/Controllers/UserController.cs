using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;

namespace NewReminderASP.WebUI.Areas.AccountsArea.Controllers
{
    [RouteArea("AccountsArea")]
    [RoutePrefix("User")]
    public class UserController : Controller
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


        public ActionResult Index()
        {
            try
            {
                var users = _provider.GetUsers();


                var currentUser = HttpContext.User;


                return View(new Tuple<IEnumerable<User>, ClaimsPrincipal>(users, (ClaimsPrincipal)currentUser));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.Error("An error occurred in Index()", ex);
                return View("Error");
            }
        }


        public ActionResult Details(int id)
        {
            var user = _provider.GetUser(id);
            if (user == null) return HttpNotFound();
            return View(user);
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

                return View(user); // Return the view with the user object to display validation errors
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


        public ActionResult Role()
        {
            var tt = _provider.GetRoles();
            return View(tt);
        }

        public ActionResult CreateRole()
        {

            return View();
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



        public ActionResult UserRole()
        {
            var userRoles = _provider.GetUsersRoles();
            return View(userRoles);
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

            // If the model state is not valid, return the view with the invalid model
            userRole.Users = _provider.GetUsers(); // Ensure Users property is populated
            userRole.Roles = _provider.GetRoles(); // Ensure Roles property is populated
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
                    roleName); // Assuming userRole contains UserId, RoleId, and Roles


                return RedirectToAction("Index");
            }

            return View();
        }

        //public ActionResult RoleDetails(int id)
        //{
        //    var userRole = _provider.GetUserRoles(id);
        //    if (userRole == null) return HttpNotFound();
        //    return View(userRole);
        //}

        //public ActionResult RoleEdit(int id)
        //{
        //    var model = _provider.GetAddressByID(id);
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    model.Countries = _countryProvider.GetCountries();

        //    return View(model);
        //}

        //// POST: User/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RoleEdit(Address address)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _provider.UpdateAddress(address);
        //        return RedirectToAction("Index");
        //    }


        //    address.Countries = _countryProvider.GetCountries(); // Ensure Countries property is populated
        //    return View(address);
        //}
        //public ActionResult RoleDelete(int id)
        //{
        //    var address = _provider.GetAddress(id);
        //    if (address == null) return HttpNotFound();
        //    return View(address);
        //}


        //[HttpPost]
        //[ActionName("RoleDelete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult RoleDeleteConfirmed(int id)
        //{
        //    _provider.DeleteAddress(id);
        //    return RedirectToAction("Index");
        //}


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