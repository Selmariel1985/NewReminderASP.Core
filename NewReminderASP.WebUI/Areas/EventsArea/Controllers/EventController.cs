using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using NewReminderASP.Core.Provider;
using NewReminderASP.Domain.Entities;

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
        [Authorize]
        public ActionResult Index(string orderBy, string sortOrder, int page = 1)
        {
            var events = _provider.GetEvents().AsQueryable();
            const int pageSize = 10;

            var paginatEdevents = DynamicSortAndPaginate(events, orderBy, sortOrder, page, pageSize).ToList();


            var totalEvents = events.Count();
            var totalPages = (int)Math.Ceiling((double)totalEvents / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatEdevents);
        }


        [AllowAnonymous]
        public ActionResult IndexAnon(string orderBy, string sortOrder, int page = 1)
        {
            var events = _provider.GetEvents().AsQueryable();
            const int pageSize = 10;

            var paginatEdevents = DynamicSortAndPaginate(events, orderBy, sortOrder, page, pageSize).ToList();


            var totalEvents = events.Count();
            var totalPages = (int)Math.Ceiling((double)totalEvents / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatEdevents);
        }




        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = _provider.GetEvent(id);
            if (model == null || (!User.IsInRole("Admin") && model.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            model.Users = _userProvider.GetUsers();
            model.EventsTypes = _provider.GetEventTypes();
            model.EventRecurrences = _provider.GetEventRecurrences();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                var existingEvent = _provider.GetEvent(events.ID);
                if (existingEvent != null && (User.IsInRole("Admin") || existingEvent.Login == User.Identity.Name))
                {
                    _provider.UpdateEvent(events);
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Details", "Event", new { area = "EventsArea", userName = User.Identity.Name });
                    }
                }

                return new HttpUnauthorizedResult();
            }

            events.Users = _userProvider.GetUsers();
            events.EventsTypes = _provider.GetEventTypes();
            events.EventRecurrences = _provider.GetEventRecurrences();
            return View(events);
        }

        [Authorize]
        public ActionResult GetEventsByUserID(int id)
        {


            if (!User.IsInRole("Admin") && User.Identity.GetUserId() == id.ToString())
                return new HttpUnauthorizedResult();


            var userEvent = _provider.GetEventsForID(id).ToList();

            if (userEvent == null || !userEvent.Any()) return HttpNotFound($"No event found for user ID: {id}");

            return View(userEvent);
        }
        [Authorize]
        public ActionResult Details(string userName)
        {
            var user = _userProvider.GetUserByLogin(userName);

            if (user == null)
            {
                return HttpNotFound();
            }

            var userId = user.Id;
            var userEvents = _provider.GetEventsForID(userId);

            var viewModel = new EventDetailsViewModel
            {
                User = user,
                Events = userEvents
            };

            // Проверка авторизации пользователя
            if (User.IsInRole("Admin") || user.Login == User.Identity.Name)
            {
                return View(viewModel);
            }

            return new HttpUnauthorizedResult();
        }


        [Authorize]
        public ActionResult EventDetails(int id)
        {
            var events = _provider.GetEvent(id);


            if (events == null) return HttpNotFound();


            if (User.IsInRole("Admin") || events.Login == User.Identity.Name)
                return View(events);
            return new HttpUnauthorizedResult();
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new Event();
            model.Users = _userProvider.GetUsers();
            model.EventsTypes = _provider.GetEventTypes();
            model.EventRecurrences = _provider.GetEventRecurrences();


            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
                _provider.AddEvent(events);
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Details", "Event", new { area = "EventsArea", userName = User.Identity.Name });
                }
            }


            events.Users = _userProvider.GetUsers();
            events.EventsTypes = _provider.GetEventTypes();
            events.EventRecurrences = _provider.GetEventRecurrences();


            return View(events);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdminEvent()
        {
            var model = new Event();
            model.Users = _userProvider.GetUsers();
            model.EventsTypes = _provider.GetEventTypes();
            model.EventRecurrences = _provider.GetEventRecurrences();


            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdminEvent(Event events)
        {
            if (ModelState.IsValid)
            {
                _provider.AddAdminEvent(events);
                return RedirectToAction("Index");
            }


            events.Users = _userProvider.GetUsers();
            events.EventsTypes = _provider.GetEventTypes();
            events.EventRecurrences = _provider.GetEventRecurrences();


            return View(events);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var events = _provider.GetEvent(id);


            if (events == null || (!User.IsInRole("Admin") && events.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            return View(events);
        }

        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var events = _provider.GetEvent(id);


            if (events == null || (!User.IsInRole("Admin") && events.Login != User.Identity.Name))
                return new HttpUnauthorizedResult();

            _provider.DeleteEvent(id);
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Details", "Event", new { area = "EventsArea", userName = User.Identity.Name });
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetEventTypes(string orderBy, string sortOrder, int page = 1)
        {
            var eventsTypes = _provider.GetEventTypes().AsQueryable();
            const int pageSize = 10;

            var paginatedEventsTypes = DynamicSortAndPaginate(eventsTypes, orderBy, sortOrder, page, pageSize).ToList();


            var totalEventsTypes = eventsTypes.Count();
            var totalPages = (int)Math.Ceiling((double)totalEventsTypes / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;


            return View(paginatedEventsTypes);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditEventTypes(int id)
        {
            var eventsTypes = _provider.GetEventType(id);
            if (eventsTypes == null) return HttpNotFound();
            return View(eventsTypes);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsEventTypes(int id)
        {
            var eventsTypes = _provider.GetEventType(id);
            if (eventsTypes == null) return HttpNotFound();
            return View(eventsTypes);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateEventTypes()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEventType(int id)
        {
            var eventsTypes = _provider.GetEventType(id);
            if (eventsTypes == null) return HttpNotFound();
            return View(eventsTypes);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("DeleteEventType")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventTypesConfirmed(int id)
        {
            _provider.DeleteEventType(id);
            return RedirectToAction("GetEventTypes");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetEventRecurrences(string orderBy, string sortOrder, int page = 1)
        {
            var eventRecurrences = _provider.GetEventRecurrences().AsQueryable();
            const int pageSize = 10;

            var paginatedEventRecurrences =
                DynamicSortAndPaginate(eventRecurrences, orderBy, sortOrder, page, pageSize).ToList();


            var totalEventRecurrences = eventRecurrences.Count();
            var totalPages = (int)Math.Ceiling((double)totalEventRecurrences / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedEventRecurrences);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditEventRecurrences(int id)
        {
            var eventRecurrences = _provider.GetEventRecurrence(id);
            if (eventRecurrences == null) return HttpNotFound();
            return View(eventRecurrences);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEventRecurrence(int id)
        {
            var eventRecurrences = _provider.GetEventRecurrence(id);
            if (eventRecurrences == null) return HttpNotFound();
            return View(eventRecurrences);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("DeleteEventRecurrence")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEventRecurrencesConfirmed(int id)
        {
            _provider.DeleteEventRecurrence(id);
            return RedirectToAction("GetEventRecurrences");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetEventDetails(string orderBy, string sortOrder, int page = 1)
        {
            var eventDetail = _provider.GetEventDetails().AsQueryable();
            const int pageSize = 10;

            var paginatedEventDetail = DynamicSortAndPaginate(eventDetail, orderBy, sortOrder, page, pageSize).ToList();


            var totalEventDetail = eventDetail.Count();
            var totalPages = (int)Math.Ceiling((double)totalEventDetail / pageSize);

            ViewBag.OrderBy = orderBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedEventDetail);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult EditEventDetails(int id)
        {
            var model = _provider.GetEventDetail(id);
            if (model == null) return HttpNotFound();

            model.EventsId = _provider.GetEvents();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsEventDetails(int id)
        {
            var eventDetail = _provider.GetEventDetail(id);
            if (eventDetail == null) return HttpNotFound();
            return View(eventDetail);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateEventDetails()
        {
            var model = new EventDetail();
            model.EventsId = _provider.GetEvents();


            return View(model);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEventDetail(int id)
        {
            var eventDetail = _provider.GetEventDetail(id);
            if (eventDetail == null) return HttpNotFound();
            return View(eventDetail);
        }

        [Authorize(Roles = "Admin")]
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