using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.AddressArea.Controllers
{

    public class AddressController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAddressProvider _provider;
        private readonly IUserProvider _userProvider;
        private readonly ICountryProvider _countryProvider;

        public AddressController(IAddressProvider provider, IUserProvider userProvider, ICountryProvider countryProvider)
        {
            _provider = provider;
            _userProvider = userProvider;
            _countryProvider = countryProvider;

        }


        public ActionResult Index(string orderBy, string sortOrder, int page = 1)
        {
            var addresses = _provider.GetAddresses().AsQueryable();
            const int pageSize = 10;

            var paginatedAddresses = DynamicSortAndPaginate(addresses, orderBy, sortOrder, page, pageSize).ToList();

            
            int totalAddresses = addresses.Count();
            int totalPages = (int)Math.Ceiling((double)totalAddresses / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedAddresses);
        }

        public ActionResult Details(int id)
        {
            var address = _provider.GetAddress(id);
            if (address == null) return HttpNotFound();
            return View(address);
        }

        public ActionResult Edit(int id)
        {
            var model = _provider.GetAddressByID(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            model.Countries = _countryProvider.GetCountries();

            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateAddress(address);
                return RedirectToAction("Index");
            }


            address.Countries = _countryProvider.GetCountries(); 
            return View(address);
        }

        public ActionResult Create()
        {
            var model = new Address();
            model.Users = _userProvider.GetUsers();
            model.Countries = _countryProvider.GetCountries();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _provider.AddAddressRegister(address);
                return RedirectToAction("Index");
            }


            address.Users = _userProvider.GetUsers(); 
            address.Countries = _countryProvider.GetCountries(); 
            return View(address);
        }

        public ActionResult Delete(int id)
        {
            var address = _provider.GetAddress(id);
            if (address == null) return HttpNotFound();
            return View(address);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeleteAddress(id);
            return RedirectToAction("Index");
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