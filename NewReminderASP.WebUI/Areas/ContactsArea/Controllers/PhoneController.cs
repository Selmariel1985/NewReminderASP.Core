﻿using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.ContactsArea.Controllers
{
    public class PhoneController : BaseController
    {
        // GET: Phone
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private readonly ICountryProvider _countryProvider;
        private readonly IPhoneProvider _provider;
        private readonly IUserProvider _userProvider;


        public PhoneController(IPhoneProvider provider, IUserProvider userProvider, ICountryProvider countryProvider)
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
            var userPhones = _provider.GetUserPhones().AsQueryable();
            const int pageSize = 10;

            var paginatedUserPhones = DynamicSortAndPaginate(userPhones, orderBy, sortOrder, page, pageSize).ToList();


            var totalUserPhones = userPhones.Count();
            var totalPages = (int)Math.Ceiling((double)totalUserPhones / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedUserPhones);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = _provider.GetUserPhone(id);
            if (model == null || (!User.IsInRole("Admin") && model.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            model.Countries = _countryProvider.GetCountries();
            model.PhonesTypes = _provider.GetPhoneTypes();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(UserPhone userPhone)
        {
            var existingUserPhone = _provider.GetUserPhone(userPhone.ID);
            if (existingUserPhone != null && (User.IsInRole("Admin") || existingUserPhone.Login == User.Identity.Name))
            {
                _provider.UpdateUserPhone(userPhone);
                if (User.IsInRole("Admin"))
                    return RedirectToAction("DetailsAdmin", "User",
                        new { area = "AccountsArea", id = existingUserPhone.UserID });
                return RedirectToAction("Details", "User",
                    new { area = "AccountsArea", userName = User.Identity.Name });
            }

            return new HttpUnauthorizedResult();


          
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var userPhone = _provider.GetUserPhone(id);
            if (userPhone == null) return HttpNotFound();


            if (User.IsInRole("Admin") || userPhone.Login == User.Identity.Name)
                return View(userPhone);
            return new HttpUnauthorizedResult();
        }

        [Authorize]
        public ActionResult GetUserPhonesByUserId(int id)
        {
            if (!User.IsInRole("Admin") && User.Identity.GetUserId() == id.ToString())
                return new HttpUnauthorizedResult();


            var userPhone = _provider.GetUserPhonesByUserId(id).ToList();

            if (userPhone == null || !userPhone.Any()) return HttpNotFound($"No phone found for user ID: {id}");

            return View(userPhone);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new UserPhone();
            model.PhonesTypes = _provider.GetPhoneTypes();
            model.Users = _userProvider.GetUsers();
            model.Countries = _countryProvider.GetCountries();
            model.Login = User.Identity.Name;


            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserPhone userPhone)
        {
            if (ModelState.IsValid)
            {
                _provider.AddUserPhoneRegister(userPhone);
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Index");
                return RedirectToAction("Details", "User",
                    new { area = "AccountsArea", userName = User.Identity.Name });
            }

            userPhone.Users = _userProvider.GetUsers();
            userPhone.Countries = _countryProvider.GetCountries();
            userPhone.PhonesTypes = _provider.GetPhoneTypes();
            return View(userPhone);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdmin()
        {
            var model = new UserPhone();
            model.PhonesTypes = _provider.GetPhoneTypes();
            model.Users = _userProvider.GetUsers();
            model.Countries = _countryProvider.GetCountries();


            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(UserPhone userPhone)
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

        [Authorize]
        public ActionResult Delete(int id)
        {
            var userPhone = _provider.GetUserPhone(id);
            if (userPhone == null || (!User.IsInRole("Admin") && userPhone.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            return View(userPhone);
        }

        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userPhone = _provider.GetUserPhone(id);


            if (userPhone == null || (!User.IsInRole("Admin") && userPhone.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            _provider.DeleteUserPhone(id);
            if (User.IsInRole("Admin"))
                return RedirectToAction("DetailsAdmin", "User", new { area = "AccountsArea", id = userPhone.UserID });
            return RedirectToAction("Details", "User", new { area = "AccountsArea", userName = User.Identity.Name });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetPhoneType(string orderBy, string sortOrder, int page = 1)
        {
            var phoneType = _provider.GetPhoneTypes().AsQueryable();
            const int pageSize = 10;

            var paginatedPhoneType = DynamicSortAndPaginate(phoneType, orderBy, sortOrder, page, pageSize).ToList();


            var totalPhoneType = phoneType.Count();
            var totalPages = (int)Math.Ceiling((double)totalPhoneType / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedPhoneType);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult EditPhoneType(int id)
        {
            var phoneType = _provider.GetPhoneType(id);
            if (phoneType == null) return HttpNotFound();
            return View(phoneType);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsPhoneType(int id)
        {
            var phoneType = _provider.GetPhoneType(id);
            if (phoneType == null) return HttpNotFound();
            return View(phoneType);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreatePhoneType()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DeletePhoneType(int id)
        {
            var phoneType = _provider.GetPhoneType(id);
            if (phoneType == null) return HttpNotFound();
            return View(phoneType);
        }

        [Authorize(Roles = "Admin")]
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