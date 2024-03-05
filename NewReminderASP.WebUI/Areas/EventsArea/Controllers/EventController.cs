﻿using System.Reflection;
using System.Web.Mvc;
using Autofac;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas.EventsArea.Controllers
{
    public class EventController : Controller
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IEventProvider _provider;
        private readonly IUserProvider _userProvider;


        public EventController(IEventProvider provider, IUserProvider userProvider)
        {
            _provider = provider;
            _userProvider = userProvider;

        }


        public ActionResult Index()
        {
            var tt = _provider.GeEvents();
            return View(tt);
        }
        
        public ActionResult Edit(int id)
        {
            var model = _provider.GetEvent(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            model.Users = _userProvider.GetUsers();
            model.EventsTypes = _provider.GetEventTypes();
            model.EventRecurrences = _provider.GetEventRecurrences();

            return View(model);
           
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


            events.Users = _userProvider.GetUsers();
            events.EventsTypes = _provider.GetEventTypes();
            events.EventRecurrences = _provider.GetEventRecurrences();
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
            var model = new Event();
            model.Users = _userProvider.GetUsers();
            model.EventsTypes = _provider.GetEventTypes();
            model.EventRecurrences = _provider.GetEventRecurrences();


            return View(model);
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


            events.Users = _userProvider.GetUsers();
            events.EventsTypes = _provider.GetEventTypes();
            events.EventRecurrences = _provider.GetEventRecurrences();

            
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

        public ActionResult GetEventTypes()
        {
            var tt = _provider.GetEventTypes();
            return View(tt);
        }
        public ActionResult EditEventTypes(int id)
        {
            var eventsTypes = _provider.GetEventType(id);
            if (eventsTypes == null) return HttpNotFound();
            return View(eventsTypes);
        }

        // POST: User/Edit/5
        [HttpPost]

        public ActionResult EditEventTypes(EventType eventsTypes)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateEventType(eventsTypes);
                return RedirectToAction("GetEventTypes");
            }

            return View(eventsTypes);
        }
        public ActionResult DetailsEventTypes(int id)
        {
            var eventsTypes = _provider.GetEventType(id);
            if (eventsTypes == null) return HttpNotFound();
            return View(eventsTypes);
        }
        public ActionResult CreateEventTypes()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEventTypes(EventType eventsTypes)
        {
            if (ModelState.IsValid)
            {
                _provider.AddPEventType(eventsTypes);
                return RedirectToAction("GetEventTypes");
            }

            return View(eventsTypes);
        }

        public ActionResult DeleteEventType(int id)
        {
            var eventsTypes = _provider.GetEventType(id);
            if (eventsTypes == null) return HttpNotFound();
            return View(eventsTypes);
        }


        [HttpPost]
        [ActionName("DeleteEventType")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventTypesConfirmed(int id)
        {
            _provider.DeleteEventType(id);
            return RedirectToAction("GetEventTypes");
        }

        public ActionResult GetEventRecurrences()
        {
            var tt = _provider.GetEventRecurrences();
            return View(tt);
        }
        public ActionResult EditEventRecurrences(int id)
        {
            var eventRecurrences = _provider.GetEventRecurrence(id);
            if (eventRecurrences == null) return HttpNotFound();
            return View(eventRecurrences);
        }

        // POST: User/Edit/5
        [HttpPost]

        public ActionResult EditEventRecurrences(EventRecurrence eventRecurrences)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateEventRecurrence(eventRecurrences);
                return RedirectToAction("GetEventRecurrences");
            }

            return View(eventRecurrences);
        }
        public ActionResult DetailsEventRecurrences(int id)
        {
            var eventRecurrences = _provider.GetEventRecurrence(id);
            if (eventRecurrences == null) return HttpNotFound();
            return View(eventRecurrences);
        }
        public ActionResult CreateEventRecurrences()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEventRecurrences(EventRecurrence eventRecurrences)
        {
            if (ModelState.IsValid)
            {
                _provider.AddEventRecurrence(eventRecurrences);
                return RedirectToAction("GetEventRecurrences");
            }

            return View(eventRecurrences);
        }

        public ActionResult DeleteEventRecurrence(int id)
        {
            var eventRecurrences = _provider.GetEventRecurrence(id);
            if (eventRecurrences == null) return HttpNotFound();
            return View(eventRecurrences);
        }


        [HttpPost]
        [ActionName("DeleteEventRecurrence")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventRecurrencesConfirmed(int id)
        {
            _provider.DeleteEventRecurrence(id);
            return RedirectToAction("GetEventRecurrences");
        }

        public ActionResult GetEventDetails()
        {
            var ttt = _provider.GetEventDetails();
            return View(ttt);
        }
        
        
        public ActionResult EditEventDetails(int id)
        {
            var model = _provider.GetEventDetail(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            model.EventsId = _provider.GeEvents();

            return View(model);
           
        }

        // POST: User/Edit/5
        [HttpPost]

        public ActionResult EditEventDetails(EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                _provider.UpdateEventDetail(eventDetail);
                return RedirectToAction("GetEventDetails");
            }


            eventDetail.EventsId = _provider.GeEvents();
            return View(eventDetail);
            
        }

        public ActionResult DetailsEventDetails(int id)
        {
            var eventDetail = _provider.GetEventDetail(id);
            if (eventDetail == null) return HttpNotFound();
            return View(eventDetail);
        }
       

        public ActionResult CreateEventDetails()
        {
            var model = new EventDetail();
            model.EventsId = _provider.GeEvents();
            

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEventDetails(EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {

                _provider.AddEventDetail(eventDetail);
                return RedirectToAction("GetEventDetails");
            }


            eventDetail.EventsId = _provider.GeEvents();
            
            


            return View(eventDetail);
        }

        public ActionResult DeleteEventDetail(int id)
        {
            var eventDetail = _provider.GetEventDetail(id);
            if (eventDetail == null) return HttpNotFound();
            return View(eventDetail);
        }


        [HttpPost]
        [ActionName("DeleteEventDetail")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventDetailsConfirmed(int id)
        {
            _provider.DeleteEventDetail(id);
            return RedirectToAction("GetEventDetails");
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