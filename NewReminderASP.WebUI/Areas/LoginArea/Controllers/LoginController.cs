using System;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Net.PeerToPeer;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Autofac;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.LoginArea.Controllers
{
    [AllowAnonymous]
    [RouteArea("LoginArea")]
    [RoutePrefix("Login")]
    public class LoginController : Controller
    {
        private static readonly ILog _logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUserProvider _provider;
       



        public LoginController(IUserProvider provider)
        {
            _provider = provider;
           
        }


        


        public ActionResult Login()
        {
            _logger.Info("Rendering AuthenticateUser view");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string password, string returnUrl)
        {
            _logger.InfoFormat("Attempting user authentication for login: {0}", login);

            var user = _provider.GetUserByLogin(login);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                FormsAuthentication.SetAuthCookie(login, false);

                var roleNames = user.UserRoles.Select(ur => ur.Role.Name).ToList();

                _provider.AssignRolesToUser(user, roleNames);
                _logger.InfoFormat("User authenticated successfully. Assigned roles: {0}",
                    string.Join(", ", roleNames));

                var authTicket = new FormsAuthenticationTicket(
                    1,
                    login,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    string.Join(",", roleNames)
                );

                var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                if (roleNames.Contains("Admin"))
                {
                    return RedirectToAction("Index", "User", new { area = "AccountsArea" });
                }

                else if(roleNames.Contains("User"))
                {
                    return Redirect(Url.Action("Details", "Event", new { area = "EventsArea", userName = login }));
                }

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    _logger.InfoFormat("User authenticated successfully. Redirecting to: {0}", returnUrl);
                    return Redirect(returnUrl);
                }
                

                return Redirect(Url.Action("Index", "Event", new { area = "EventsArea" }));
            }

            ModelState.AddModelError("", "Invalid login or password");
            _logger.WarnFormat("Authentication failed for user with login: {0}", login);
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
    }
}