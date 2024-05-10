using System;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using Microsoft.Extensions.Caching.Memory;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.RegisterArea.Controllers
{
    [RouteArea("RegisterArea")]
    [RoutePrefix("Register")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMemoryCache _cache;
        private readonly EmailService _emailService;
        private readonly IUserProvider _userProvider;

        public RegisterController(IUserProvider userProvider, IMemoryCache cache, EmailService emailService)
        {
            _userProvider = userProvider;
            _cache = cache;
            _emailService = emailService;
        }

        private string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }

        private bool IsLoginUnique(string login)
        {
            return _userProvider.GetUserByLogin(login) == null;
        }

        private bool IsEmailUnique(string email)
        {
            return _userProvider.GetUserByEmail(email) == null;
        }

        public ActionResult Register()
        {
            return View(new RegisterViewModel { User = new User() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!IsLoginUnique(model.User.Login))
                    ModelState.AddModelError("User.Login", "This login is already in use.");

                if (!IsEmailUnique(model.User.Email))
                    ModelState.AddModelError("User.Email", "This email is already registered.");

                if (!ModelState.IsValid) return View(model);

                var token = GenerateToken();
                _cache.Set(token, model.User, TimeSpan.FromMinutes(60));

                var confirmationUrl = Url.Action("ConfirmEmail", "Register", new { token }, Request.Url.Scheme);
                _emailService.SendConfirmationEmail(model.User.Email, confirmationUrl);
                return View("RegistrationPending");
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult ConfirmEmail(string token)
        {
            if (_cache.TryGetValue(token, out User cachedUser))
                try
                {
                    cachedUser.IsActive = true;
                    _userProvider.AddUser(cachedUser);
                    _userProvider.AddUserRoleNormal(cachedUser.Login, "User");

                    _cache.Remove(token);
                    return View("ConfirmationSuccess");
                }
                catch (Exception ex)
                {
                    _logger.Error("An error occurred during user confirmation", ex);
                    return View("ConfirmationFailed");
                }

            return View("ConfirmationFailed");
        }
    }
}