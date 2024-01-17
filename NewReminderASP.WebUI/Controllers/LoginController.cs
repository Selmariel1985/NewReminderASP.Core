using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.WebUI.Controllers
{
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
                _logger.InfoFormat("User authenticated successfully. Assigned roles: {0}", string.Join(", ", roleNames));

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

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    _logger.InfoFormat("User authenticated successfully. Redirecting to: {0}", returnUrl);
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login or password");
                _logger.WarnFormat("Authentication failed for user with login: {0}", login);
                return View();
            }
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut(); // Signs the user out
            return
                RedirectToAction("Index",
                    "Home"); // Redirect to the home page or any other suitable page after sign out
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AuthenticateUser(string login, string password)
        //{
        //    _logger.InfoFormat("Received authentication request for user with login: {0}", login);

        //    var user = _provider.GetUserByPasswordAndLogin(password, login);


        //        if (user == null)
        //        {
        //            _logger.Warn("Authentication failed: invalid login or password");
        //            ModelState.AddModelError("", "Invalid login or password");
        //            return View();
        //        }

        //        _logger.Info("User successfully authenticated");

        //    FormsAuthentication.SetAuthCookie(user.Login, false);

        //    if (User.IsInRole("Admin"))
        //    {
        //        
        //        return RedirectToAction("Index");
        //    }
        //    else if (User.IsInRole("User"))
        //    {
        //       
        //        return RedirectToAction("Register");
        //    }
        //    else
        //    {
        //       
        //        return RedirectToAction("Details");
        //    }
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AuthenticateUser(string login, string password)
        //{
        //    _logger.InfoFormat("Received authentication request for user with login: {0}", login);

        //    if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
        //    {
        //        var user = _provider.GetUserByPasswordAndLogin(password, login);

        //        if (user == null)
        //        {
        //            _logger.Warn("Authentication failed: invalid login or password");
        //            ModelState.AddModelError("", "Invalid login or password");
        //            return View();
        //        }

        //        var roles = user.UserRoles.Select(r => r.Role.Name).ToArray();

        //        var identity = new GenericIdentity(user.Login);
        //        var principal = new GenericPrincipal(identity, roles);

        //        System.Threading.Thread.CurrentPrincipal = principal;
        //        if (System.Web.HttpContext.Current != null)
        //        {
        //            System.Web.HttpContext.Current.User = principal;
        //        }

        //        if (User.IsInRole("Admin"))
        //        {
        //            _logger.Info("User is in Admin role. Redirecting to Index action.");
        //            _logger.Debug("User roles: " + string.Join(", ", roles));
        //            return RedirectToAction("Index", "User");
        //        }
        //        else if (User.IsInRole("User"))
        //        {
        //            _logger.Info("User is in User role. Redirecting to Register action.");
        //            _logger.Debug("User roles: " + string.Join(", ", roles));
        //            return RedirectToAction("Register", "User");
        //        }
        //        else
        //        {
        //            _logger.Info("User is in neither Admin nor User role. Redirecting to Details action.");
        //            _logger.Debug("User roles: " + string.Join(", ", roles));
        //            return RedirectToAction("Details", "User", new { id = 2 });
        //        }
        //    }

        //    _logger.Warn("User did not provide login or password");
        //    return View();
        // }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AuthenticateUser(string login, string password)
        //{
        //    _logger.InfoFormat("Received authentication request for user with login: {0}", login);

        //    var user = _provider.GetUserByPasswordAndLogin(password, login);


        //        if (user == null)
        //        {
        //            _logger.Warn("Authentication failed: invalid login or password");
        //            ModelState.AddModelError("", "Invalid login or password");
        //            return View();
        //        }

        //        _logger.Info("User successfully authenticated");

        //    FormsAuthentication.SetAuthCookie(user.Login, false);

        //    if (User.IsInRole("Admin"))
        //    {
        //        
        //        return RedirectToAction("Index");
        //    }
        //    else if (User.IsInRole("User"))
        //    {
        //       
        //        return RedirectToAction("Register");
        //    }
        //    else
        //    {
        //       
        //        return RedirectToAction("Details");
        //    }
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AuthenticateUser(string login, string password)
        //{
        //    _logger.InfoFormat("Received authentication request for user with login: {0}", login);

        //    if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
        //    {
        //        var user = _provider.GetUserByPasswordAndLogin(password, login);

        //        if (user == null)
        //        {
        //            _logger.Warn("Authentication failed: invalid login or password");
        //            ModelState.AddModelError("", "Invalid login or password");
        //            return View();
        //        }

        //        var roles = user.UserRoles.Select(r => r.Role.Name).ToArray();

        //        var identity = new GenericIdentity(user.Login);
        //        var principal = new GenericPrincipal(identity, roles);

        //        System.Threading.Thread.CurrentPrincipal = principal;
        //        if (System.Web.HttpContext.Current != null)
        //        {
        //            System.Web.HttpContext.Current.User = principal;
        //        }

        //        if (User.IsInRole("Admin"))
        //        {
        //            _logger.Info("User is in Admin role. Redirecting to Index action.");
        //            _logger.Debug("User roles: " + string.Join(", ", roles));
        //            return RedirectToAction("Index", "User");
        //        }
        //        else if (User.IsInRole("User"))
        //        {
        //            _logger.Info("User is in User role. Redirecting to Register action.");
        //            _logger.Debug("User roles: " + string.Join(", ", roles));
        //            return RedirectToAction("Register", "User");
        //        }
        //        else
        //        {
        //            _logger.Info("User is in neither Admin nor User role. Redirecting to Details action.");
        //            _logger.Debug("User roles: " + string.Join(", ", roles));
        //            return RedirectToAction("Details", "User", new { id = 2 });
        //        }
        //    }

        //    _logger.Warn("User did not provide login or password");
        //    return View();
        //}

        //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
        //public class CustomAuthorizeAttribute : AuthorizeAttribute
        //{
        //    public CustomAuthorizeAttribute(params string[] roles)
        //    {
        //        Roles = string.Join(",", roles);
        //    }


        //}
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
        //        // Если пользователь не аутентифицирован, перенаправлять на страницу входа
        //        filterContext.Result = new HttpUnauthorizedResult();
        //    else
        //        // Если пользователь аутентифицирован, но у него нет доступа, отображать сообщение об ошибке
        //        filterContext.Result = new ViewResult
        //        {
        //            ViewName = "AccessDenied"
        //        };
        //}
    }
}