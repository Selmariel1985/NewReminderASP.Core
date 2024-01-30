using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using NewReminderASP.Core.Provider;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.WebUI.Controllers
{
    public class UserController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IUserProvider _provider;


        public UserController(IUserProvider provider)
        {
            _provider = provider;
        }


        [Authorize]
        public ActionResult SomeAction()
        {
            var userId = User.Identity.GetUserName();
            var user = _provider.GetUserByLogin(userId);

            if (User.IsInRole("Admin"))
            {
                _logger.InfoFormat("User {0} is an Admin", user.Login);
            }
            else
            {
                _logger.InfoFormat("User {0} is not an Admin", user.Login);
                // Handle unauthorized access here
                return View("Unauthorized");
            }

            _logger.Info("SomeAction method executed");

            var users = _provider.GetUsers(); // assuming Provider is your user data provider

            _logger.Info("Retrieved user data from the provider");

            return View();
        }


        public ActionResult Index()
        {
            var users = _provider.GetUsers();


            var currentUser = HttpContext.User;


            return View(new Tuple<IEnumerable<User>, ClaimsPrincipal>(users, (ClaimsPrincipal)currentUser));
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
            if (ModelState.IsValid)
            {
                _provider.UpdateUser(user);
                return RedirectToAction("Index");
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
            if (ModelState.IsValid)
            {
                _provider.AddUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
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


        public ActionResult UserRole()
        {
            var userRoles = _provider.GetUsersRoles();
            return View(userRoles);
        }
       

        public ActionResult CreateUserRoleById()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserRoleById(UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _provider.AddUserRole(userRole); // Assuming userRole contains UserId, RoleId, and Roles
                return RedirectToAction("Index");
            }

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
                _provider.AddUserRoleNormal(userLogin, roleName); // Assuming userRole contains UserId, RoleId, and Roles
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}