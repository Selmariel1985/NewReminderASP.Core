using Autofac;
using log4net;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace NewReminderASP.WebUI.Areas.EventsArea.Controllers
{
    public class EventController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IEventProvider _provider;
        private readonly IUserProvider _userProvider;


        public EventController(IEventProvider provider, IUserProvider userProvider)
        {
            _provider = provider;
            _userProvider = userProvider;

        }
        public ActionResult SignOut()
        {
            return SignOutAndRedirectToLogin("LoginArea");
        }

        //public ActionResult GetCalendarEvents()
        //{
        //    var events = _provider.GetEvents().Select(e => new {
        //        title = e.Title,
        //        start = e.Date.ToString("yyyy-MM-dd"),
        //        allDay = true
        //    }).ToList();

        //    return Json(events, JsonRequestBehavior.AllowGet); // Ensure that allowing GET is safe for this data.
        //}

        public ActionResult Index(string orderBy, string sortOrder, int page = 1)
        {

           

           
            var events = _provider.GetEvents().AsQueryable();
            const int pageSize = 10;

            var paginatEdevents = DynamicSortAndPaginate(events, orderBy, sortOrder, page, pageSize).ToList();


            int totalEvents = events.Count();
            int totalPages = (int)Math.Ceiling((double)totalEvents / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatEdevents);
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
            events.Login = User.Identity.Name;
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

        public ActionResult GetEventTypes(string orderBy, string sortOrder, int page = 1)
        {
            var eventsTypes = _provider.GetEventTypes().AsQueryable();
            const int pageSize = 10;

            var paginatedEventsTypes = DynamicSortAndPaginate(eventsTypes, orderBy, sortOrder, page, pageSize).ToList();


            int totalEventsTypes = eventsTypes.Count();
            int totalPages = (int)Math.Ceiling((double)totalEventsTypes / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedEventsTypes);
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

        public ActionResult GetEventRecurrences(string orderBy, string sortOrder, int page = 1)
        {
            var eventRecurrences = _provider.GetEventRecurrences().AsQueryable();
            const int pageSize = 10;

            var paginatedEventRecurrences = DynamicSortAndPaginate(eventRecurrences, orderBy, sortOrder, page, pageSize).ToList();


            int totalEventRecurrences = eventRecurrences.Count();
            int totalPages = (int)Math.Ceiling((double)totalEventRecurrences / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedEventRecurrences);
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

        public ActionResult GetEventDetails(string orderBy, string sortOrder, int page = 1)
        {
            var eventDetail = _provider.GetEventDetails().AsQueryable();
            const int pageSize = 10;

            var paginatedEventDetail = DynamicSortAndPaginate(eventDetail, orderBy, sortOrder, page, pageSize).ToList();


            int totalEventDetail = eventDetail.Count();
            int totalPages = (int)Math.Ceiling((double)totalEventDetail / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedEventDetail);
        }




        public ActionResult EditEventDetails(int id)
        {
            var model = _provider.GetEventDetail(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            model.EventsId = _provider.GetEvents();

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


            eventDetail.EventsId = _provider.GetEvents();
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
            model.EventsId = _provider.GetEvents();


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


            eventDetail.EventsId = _provider.GetEvents();




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