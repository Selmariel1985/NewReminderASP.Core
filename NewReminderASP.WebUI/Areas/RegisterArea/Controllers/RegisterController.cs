using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
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





        public RegisterController(IUserProvider userProvider)
        {
            _userProvider = userProvider;


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
                // Check if login and email are unique as before
                if (!IsLoginUnique(model.User.Login))
                {
                    ModelState.AddModelError("Login", "This login is already in use.");
                    return View();
                }

                if (!IsEmailUnique(model.User.Email))
                {
                    ModelState.AddModelError("Email", "This email address is already registered.");
                    return View();
                }

                if (model.User.Password != model.User.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "The password and confirm password do not match");
                    return View();
                }

                if (ModelState.IsValid)
                {



                    _userProvider.AddUser(model.User);



                    return RedirectToAction("Login", "Login", new { area = "LoginArea" });
                }
            }



            return View(model);
        }
    }
}