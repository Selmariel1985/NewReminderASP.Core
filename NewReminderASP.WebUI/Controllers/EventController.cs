using log4net;
using Microsoft.Extensions.Logging;
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
    public class EventController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IEventProvider _provider;


        public EventController(IEventProvider provider)
        {
            _provider = provider;
        }


        public ActionResult Index()
        {
            var tt = _provider.GeEvents();
            return View(tt);
        }
        public ActionResult Edit(int id)
        {
            var events = _provider.GetEvent(id);
            if (events == null) return HttpNotFound();
            return View(events);
        }

        // POST: User/Edit/5
        [HttpPost]

        public ActionResult Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateEvent(events);
                return RedirectToAction("Index");
            }

            return View(events);
        }
        public ActionResult Details(int id)
        {
            var events = _provider.GetEvent(id);
            if (events == null) return HttpNotFound();
            return View(events);
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
                _provider.AddEvent(events);
                return RedirectToAction("Index");
            }

            return View(events);
        }

        public ActionResult Delete(int id)
        {
            var events = _provider.GetEvent(id);
            if (events == null) return HttpNotFound();
            return View(events);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _provider.DeleteEvent(id);
            return RedirectToAction("Index");
        }
    }
}