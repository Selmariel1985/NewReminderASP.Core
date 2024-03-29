﻿using System.Web.Mvc;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddressController : Controller
    {
        private readonly IAddressProvider _provider;

        public AddressController(IAddressProvider provider)
        {
            _provider = provider;
        }


        public ActionResult Index()
        {
            var tt = _provider.GetAddresses();
            return View(tt);
        }

        public ActionResult Details(int id)
        {
            var addreess = _provider.GetAddress(id);
            if (addreess == null) return HttpNotFound();
            return View(addreess);
        }

        public ActionResult Edit(int id)
        {
            var addreess = _provider.GetAddress(id);
            if (addreess == null) return HttpNotFound();
            return View(addreess);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address addreess)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateCountry(addreess);
                return RedirectToAction("Index");
            }

            return View(addreess);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address addreess)
        {
            if (ModelState.IsValid)
            {
                _provider.AddAddress(addreess);
                return RedirectToAction("Index");
            }

            return View(addreess);
        }

        public ActionResult Delete(int id)
        {
            var addreess = _provider.GetAddress(id);
            if (addreess == null) return HttpNotFound();
            return View(addreess);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeleteAddress(id);
            return RedirectToAction("Index");
        }
    }
}