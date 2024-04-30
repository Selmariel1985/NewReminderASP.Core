using log4net;
using Microsoft.Extensions.Caching.Memory;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.RegisterArea.Controllers
{
    [RouteArea("RegisterArea")]
    [RoutePrefix("Register")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IUserProvider _userProvider;
        private readonly IMemoryCache _cache;
        private readonly EmailService _emailService;

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

        public bool IsLoginUnique(string login)
        {
            var existingUser = _userProvider.GetUserByLogin(login);
            return existingUser == null;
        }

        private bool IsEmailUnique(string email)
        {
            var existingUser = _userProvider.GetUserByEmail(email);
            return existingUser == null;
        }

        public ActionResult Register()
        {
            var user = new RegisterViewModel
            {
                User = new User(),
            };
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!IsLoginUnique(model.User.Login) || !IsEmailUnique(model.User.Email))
                {
                    // Return with error message
                    return View(model);
                }

                var token = GenerateToken();
                // Сохранение большего количества данных пользователя в кэше
                _cache.Set(token, model.User, TimeSpan.FromMinutes(20)); // Adjust expiration as necessary

                string confirmationUrl = Url.Action("ConfirmEmail", "Register", new { token }, Request.Url.Scheme);
                _emailService.SendConfirmationEmail(model.User.Email, confirmationUrl);
                return View("RegistrationPending");
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult ConfirmEmail(string token)
        {
            if (_cache.TryGetValue(token, out User cachedUser)) // Retrieving the whole user object from the cache
            {
                try
                {
                    // Activate the user as their email has been confirmed
                    cachedUser.IsActive = true;
                    _userProvider.AddUser(cachedUser);
                    // Adding the user into the database
                    
                        _cache.Remove(token); // Removing the token from cache after successful registration
                        return View("ConfirmationSuccess"); // Displaying the successful confirmation
                    
                }
                catch (Exception ex)
                {
                    _logger.Error("An error occurred during user confirmation", ex);
                    return View("ConfirmationFailed"); // Displaying the confirmation error page
                }
            }

            return View("ConfirmationFailed"); // Handling invalid or expired tokens or issues in fetching the data
        }


    }
}