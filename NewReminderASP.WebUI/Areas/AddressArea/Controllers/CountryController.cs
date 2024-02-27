using System.Reflection;
using System.Web.Mvc;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.AddressArea.Controllers
{
    public class CountryController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ICountryProvider _provider;

        public CountryController(ICountryProvider provider)
        {
            _provider = provider;
        }


        public ActionResult IndexCountry()
        {
            var tt = _provider.GetCountries();
            return View(tt);
        }

        public ActionResult DetailsCountry(int id)
        {
            var country = _provider.GetCountry(id);
            if (country == null) return HttpNotFound();
            return View(country);
        }

        public ActionResult EditCountry(int id)
        {
            var country = _provider.GetCountry(id);
            if (country == null) return HttpNotFound();
            return View(country);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateCountry(country);
                return RedirectToAction("IndexCountry");
            }

            return View(country);
        }

        public ActionResult CreateCountry()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                _provider.AddCountry(country);
                return RedirectToAction("IndexCountry");
            }

            return View(country);
        }

        public ActionResult DeleteCountry(int id)
        {
            var country = _provider.GetCountry(id);
            if (country == null) return HttpNotFound();
            return View(country);
        }


        [HttpPost]
        [ActionName("DeleteCountry")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeleteCountry(id);
            return RedirectToAction("IndexCountry");
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