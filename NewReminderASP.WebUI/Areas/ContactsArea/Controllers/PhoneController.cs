using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
using System.Reflection;
using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.ContactsArea.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Phone
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IPhoneProvider _provider;
        private readonly IUserProvider _userProvider;
        private readonly ICountryProvider _countryProvider;


        public PhoneController(IPhoneProvider provider, IUserProvider userProvider, ICountryProvider countryProvider)
        {
            _provider = provider;
            _userProvider = userProvider;
            _countryProvider = countryProvider;

        }


        public ActionResult Index()
        {
            var tt = _provider.GetUserPhones();
            return View(tt);
        }
        public ActionResult Edit(int id)
        {

            var model = _provider.GetUserPhone(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            model.Countries = _countryProvider.GetCountries();
            model.PhonesTypes = _provider.GetPhoneTypes();
            return View(model);

        }

        // POST: User/Edit/5
        [HttpPost]

        public ActionResult Edit(UserPhone userPhone)
        {

            if (ModelState.IsValid)
            {
                _provider.UpdateUserPhone(userPhone);
                return RedirectToAction("Index");
            }

            userPhone.PhonesTypes = _provider.GetPhoneTypes();
            userPhone.Countries = _countryProvider.GetCountries(); // Ensure Countries property is populated
            return View(userPhone);

        }
        public ActionResult Details(int id)
        {
            var userPhone = _provider.GetUserPhone(id);
            if (userPhone == null) return HttpNotFound();
            return View(userPhone);
        }
        public ActionResult Create()
        {
            var model = new UserPhone();
            model.PhonesTypes = _provider.GetPhoneTypes();
            model.Users = _userProvider.GetUsers();
            model.Countries = _countryProvider.GetCountries();


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserPhone userPhone)
        {
            if (ModelState.IsValid)
            {
                _provider.AddUserPhoneRegister(userPhone);
                return RedirectToAction("Index");
            }

            userPhone.Users = _userProvider.GetUsers();
            userPhone.Countries = _countryProvider.GetCountries();
            userPhone.PhonesTypes = _provider.GetPhoneTypes();
            return View(userPhone);

        }

        public ActionResult Delete(int id)
        {
            var userPhone = _provider.GetUserPhone(id);
            if (userPhone == null) return HttpNotFound();
            return View(userPhone);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeleteUserPhone(id);
            return RedirectToAction("Index");
        }


        public ActionResult GetPhoneType()
        {
            var tt = _provider.GetPhoneTypes();
            return View(tt);
        }
        public ActionResult EditPhoneType(int id)
        {
            var phoneType = _provider.GetPhoneType(id);
            if (phoneType == null) return HttpNotFound();
            return View(phoneType);
        }


        [HttpPost]

        public ActionResult EditPhoneType(PhoneType phoneType)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdatePhoneType(phoneType);
                return RedirectToAction("GetPhoneType");
            }

            return View(phoneType);
        }
        public ActionResult DetailsPhoneType(int id)
        {
            var phoneType = _provider.GetPhoneType(id);
            if (phoneType == null) return HttpNotFound();
            return View(phoneType);
        }
        public ActionResult CreatePhoneType()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePhoneType(PhoneType phoneType)
        {
            if (ModelState.IsValid)
            {
                _provider.AddPhoneType(phoneType);
                return RedirectToAction("GetPhoneType");
            }

            return View();
        }

        public ActionResult DeletePhoneType(int id)
        {
            var phoneType = _provider.GetPhoneType(id);
            if (phoneType == null) return HttpNotFound();
            return View(phoneType);
        }


        [HttpPost]
        [ActionName("DeletePhoneType")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPhoneType(int id)
        {
            _provider.DeletePhoneType(id);
            return RedirectToAction("GetPhoneType");
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