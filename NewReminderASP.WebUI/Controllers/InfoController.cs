using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace NewReminderASP.WebUI.Controllers
{
    public class InfoController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IPersonalInformationProvider _provider;


        public InfoController(IPersonalInformationProvider provider)
        {
            _provider = provider;
        }


        public ActionResult Index()
        {
            var tt = _provider.GetPersonalInfos();
            return View(tt);
        }

        public ActionResult Edit(int id)
        {
            var personalInfo = _provider.GetPersonalInfo(id);
            if (personalInfo == null) return HttpNotFound();
            return View(personalInfo);
        }

        // POST: User/Edit/5
        [HttpPost]

        public ActionResult Edit(PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdatePersonalInfo(personalInfo);
                return RedirectToAction("Index");
            }

            return View(personalInfo);
        }
        public ActionResult Details(int id)
        {
            var personalInfo = _provider.GetPersonalInfo(id);
            if (personalInfo == null) return HttpNotFound();
            return View(personalInfo);
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                _provider.AddPersonalInfo(personalInfo);
                return RedirectToAction("Index");
            }

            return View(personalInfo);
        }

        public ActionResult Delete(int id)
        {
            var personalInfo = _provider.GetPersonalInfo(id);
            if (personalInfo == null) return HttpNotFound();
            return View(personalInfo);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeletePersonalInfo(id);
            return RedirectToAction("Index");
        }
    }
}