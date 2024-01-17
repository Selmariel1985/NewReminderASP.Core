using System.Reflection;
using System.Web.Mvc;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private static readonly ILog _logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUserProvider _provider;


        public RegisterController(IUserProvider provider)
        {
            _provider = provider;
        }

        public ActionResult Register()
        {
            return View();
        }

        public bool IsLoginUnique(string login)
        {
            var existingUser = _provider.GetUserByLogin(login);
            return existingUser == null;
        }

        private bool IsEmailUnique(string email)
        {
            var existingUser = _provider.GetUserByEmail(email);
            return existingUser == null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (!IsLoginUnique(user.Login))
                {
                    ModelState.AddModelError("Login", "This login is already in use.");
                    return View(user);
                }

                if (!IsEmailUnique(user.Email))
                {
                    ModelState.AddModelError("Email", "This email address is already registered.");
                    return View(user);
                }


               
                _provider.AddUser(user);

                return RedirectToAction("Index", "user");
            }


            return View(user);
        }
    }
}