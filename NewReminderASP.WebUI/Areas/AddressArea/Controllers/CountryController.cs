using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.AddressArea.Controllers
{
    public class CountryController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ICountryProvider _provider;

        public CountryController(ICountryProvider provider)
        {
            _provider = provider;
        }

        
        public ActionResult IndexCountry(string orderBy, string sortOrder, int page = 1)
        {
            var countries = _provider.GetCountries().AsQueryable();
            const int pageSize = 10;

            var paginatedCountries = DynamicSortAndPaginate(countries, orderBy, sortOrder, page, pageSize).ToList();

            
            int totalСountries = countries.Count();
            int totalPages = (int)Math.Ceiling((double)totalСountries / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedCountries);
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