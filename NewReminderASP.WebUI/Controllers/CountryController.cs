using System.Web.Mvc;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryProvider _provider;

        public CountryController(ICountryProvider provider)
        {
            _provider = provider;
        }


        public ActionResult Index()
        {
            var tt = _provider.GetCountries();
            return View(tt);
        }

        public ActionResult Details(int id)
        {
            var country = _provider.GetCountry(id);
            if (country == null) return HttpNotFound();
            return View(country);
        }

        public ActionResult Edit(int id)
        {
            var country = _provider.GetCountry(id);
            if (country == null) return HttpNotFound();
            return View(country);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateCountry(country);
                return RedirectToAction("Index");
            }

            return View(country);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _provider.AddCountry(country);
                return RedirectToAction("Index");
            }

            return View(country);
        }

        public ActionResult Delete(int id)
        {
            var country = _provider.GetCountry(id);
            if (country == null) return HttpNotFound();
            return View(country);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeleteCountry(id);
            return RedirectToAction("Index");
        }
    }
}