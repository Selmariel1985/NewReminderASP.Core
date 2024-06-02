using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.AddressArea.Controllers
{
    public class AddressController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ICountryProvider _countryProvider;
        private readonly IAddressProvider _provider;
        private readonly IUserProvider _userProvider;

        public AddressController(IAddressProvider provider, IUserProvider userProvider,
            ICountryProvider countryProvider)
        {
            _provider = provider;
            _userProvider = userProvider;
            _countryProvider = countryProvider;
        }

        public ActionResult SignOut()
        {
            return SignOutAndRedirectToLogin("LoginArea");
        }

        [Authorize]
        public ActionResult Index(string orderBy, string sortOrder, int page = 1)
        {
            var addresses = _provider.GetAddresses();

            const int pageSize = 10;
            var paginatedAddresses = DynamicSortAndPaginate(addresses.AsQueryable(), orderBy, sortOrder, page, pageSize)
                .ToList();

            var totalAddresses = addresses.Count();
            var totalPages = (int)Math.Ceiling((double)totalAddresses / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedAddresses);
        }

        [Authorize]
        public ActionResult GetAddressesByUserID(int id)
        {
            if (!User.IsInRole("Admin") && User.Identity.GetUserId() == id.ToString())
                return new HttpUnauthorizedResult();

            var addresses = _provider.GetAddressesByUserId(id).ToList();


            if (addresses == null || !addresses.Any()) return HttpNotFound($"No addresses found for user ID: {id}");

            return View(addresses);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var address = _provider.GetAddress(id);
            if (address == null) return HttpNotFound();

            if (User.IsInRole("Admin") || address.Login == User.Identity.Name)
                return View(address);
            return new HttpUnauthorizedResult();
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var address = _provider.GetAddress(id);
            if (address == null || (!User.IsInRole("Admin") && address.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            address.Countries = _countryProvider.GetCountries();

            return View(address);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                var existingAddress = _provider.GetAddress(address.ID);
                if (existingAddress != null && (User.IsInRole("Admin") || existingAddress.Login == User.Identity.Name))
                {
                    _provider.UpdateAddress(address);
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("DetailsAdmin", "User", new { area = "AccountsArea", id = existingAddress.UserID });
                    }
                    else
                    {
                        return RedirectToAction("Details", "User", new { area = "AccountsArea", userName = User.Identity.Name });
                    }
                }

                return new HttpUnauthorizedResult();
            }


            address.Countries = _countryProvider.GetCountries();
            return View(address);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new Address();
            model.Login = User.Identity.Name;
            model.Users = _userProvider.GetUsers();
            model.Countries = _countryProvider.GetCountries();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                 _provider.AddAddressRegister(address);

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "User", new { area = "AccountsArea"});
                }
                else
                {
                    return RedirectToAction("Details", "User", new { area = "AccountsArea", userName = User.Identity.Name });
                }
            }


            address.Users = _userProvider.GetUsers();
            address.Countries = _countryProvider.GetCountries();
            return View(address);
        }

        [Authorize]
        public ActionResult CreateAdmin()
        {
            var model = new Address();
            model.Users = _userProvider.GetUsers();
            model.Countries = _countryProvider.GetCountries();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(Address address)
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

        [Authorize]
        public ActionResult Delete(int id)
        {
            var address = _provider.GetAddress(id);
            if (address == null || (!User.IsInRole("Admin") && address.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            return View(address);
        }

        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var address = _provider.GetAddress(id);


            if (address == null || (!User.IsInRole("Admin") && address.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();
            _provider.DeleteAddress(id);
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("DetailsAdmin", "User", new { area = "AccountsArea", id = address.UserID });
            }
            else
            {
                return RedirectToAction("Details", "User", new { area = "AccountsArea", userName = User.Identity.Name });
            }
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    if (!filterContext.ExceptionHandled)
        //    {
        //        _logger.Error("An unhandled exception occurred", filterContext.Exception);
        //        filterContext.Result = new ViewResult
        //        {
        //            ViewName = "Error"
        //        };
        //        filterContext.ExceptionHandled = true;
        //    }
        //}
    }
}