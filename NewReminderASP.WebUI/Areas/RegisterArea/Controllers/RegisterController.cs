using System;
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
            if (!IsLoginUnique(model.User.Login))
            {
                ModelState.AddModelError("User.Login", "This login is already in use.");
            }

            if (!IsEmailUnique(model.User.Email))
            {
                ModelState.AddModelError("User.Email", "This email address is already registered.");
            }

            if (!ModelState.IsValid)
            {
                var user = new RegisterViewModel
                {
                    User = model.User,
                    Address = model.Address,
                    PersonalInfo = model.PersonalInfo,
                    UserPhone = model.UserPhone,
                    PhoneTypes = _phoneProvider.GetPhoneTypes(),
                    Countries = _countryProvider.GetCountries()
                };
                return View(user);
            }

            try
            {
                _userProvider.AddUser(model.User);
                _phoneProvider.AddUserPhoneRegister(model.UserPhone);
                _addressProvider.AddAddressRegister(model.Address);
                _personalInfoProvider.AddPersonalInfo(model.PersonalInfo.Login, model.PersonalInfo);
            }
            catch (Exception ex)
            {
                _logger.Error("An error occurred while registering new user", ex);
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
                
                var user = new RegisterViewModel
                {
                    User = model.User,
                    Address = model.Address,
                    PersonalInfo = model.PersonalInfo,
                    UserPhone = model.UserPhone,
                    PhoneTypes = _phoneProvider.GetPhoneTypes(),
                    Countries = _countryProvider.GetCountries()
                };
                return View("Error");
            }

            return RedirectToAction("Index", "user", new { area = "AccountsArea" });
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                _logger.Error("An unhandled exception occurred", filterContext.Exception);
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
