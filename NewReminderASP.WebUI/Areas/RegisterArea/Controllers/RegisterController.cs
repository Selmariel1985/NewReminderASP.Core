using System.Reflection;
using System.Web.Mvc;
using Autofac;
using log4net;
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

        private readonly IUserProvider _userProvider;
        private readonly IPhoneProvider _phoneProvider;
        private readonly IAddressProvider _addressProvider;
        private readonly IPersonalInformationProvider _personalInfoProvider;
        private readonly ICountryProvider _countryProvider;




        public RegisterController(IUserProvider userProvider, IPhoneProvider phoneProvider, IAddressProvider addressProvider,
            IPersonalInformationProvider personalInfoProvider, ICountryProvider countryProvider)
        {
            _userProvider = userProvider;
            _phoneProvider = phoneProvider;
            _addressProvider = addressProvider;
            _personalInfoProvider = personalInfoProvider;
            _countryProvider = countryProvider;

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
                Address = new Address(),
                PersonalInfo = new PersonalInfo(),
                UserPhone = new UserPhone(),
                PhoneTypes = _phoneProvider.GetPhoneTypes(),
                Countries = _countryProvider.GetCountries()
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
                   
                    model.Address.Login = model.User.Login;
                    model.UserPhone.Login = model.User.Login;
                    model.Address.CountryID = model.UserPhone.CountryID;
                    model.PersonalInfo.Login = model.User.Login;
                    
                    _userProvider.AddUser(model.User);

                    _phoneProvider.AddUserPhoneRegister(model.UserPhone);
                   
                    
                    _addressProvider.AddAddressRegister(model.Address);
                    _personalInfoProvider.AddPersonalInfo(model.PersonalInfo.Login, model.PersonalInfo);

                    return RedirectToAction("Login", "Login", new { area = "LoginArea" });
                }
            } 

           model.Countries = _countryProvider.GetCountries();
           model.PhoneTypes = _phoneProvider.GetPhoneTypes();

            return View(model);
        }
    }
}