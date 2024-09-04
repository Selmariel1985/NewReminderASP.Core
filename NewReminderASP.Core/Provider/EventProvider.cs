using System.Collections.Generic;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Provider class for event-related functionality by interacting with the event repository.
    /// </summary>
    public class EventProvider : IEventProvider
    {
        private readonly IEventRepository _eventRepository;

        public EventProvider(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        #region Event Methods

        /// <summary>
        ///     Get a list of all events.
        /// </summary>
        /// <returns></returns>
        public List<Event> GetEvents()
        {
            return _eventRepository.GetEvents();
        }

        /// <summary>
        ///     Get events associated with a specific user.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<Event> GetEventsForUser(string userName)
        {
            return _eventRepository.GetEventsForUser(userName);
        }

        /// <summary>
        ///     Get events with a specific ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Event> GetEventsForID(int id)
        {
            return _eventRepository.GetEventsForID(id);
        }

        /// <summary>
        ///     Get an event by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Event GetEvent(int Id)
        {
            return _eventRepository.GetEvent(Id);
        }

        /// <summary>
        ///     Update the provided event information.
        /// </summary>
        /// <param name="updatedEvent"></param>
        public void UpdateEvent(Event updatedEvent)
        {
            _eventRepository.UpdateEvent(updatedEvent);
        }

        /// <summary>
        ///     Add a new event.
        /// </summary>
        /// <param name="events"></param>
        public void AddEvent(Event events)
        {
            _eventRepository.AddEvent(events);
        }

        /// <summary>
        ///     Add a new event with admin privileges.
        /// </summary>
        /// <param name="events"></param>
        public void AddAdminEvent(Event events)
        {
            _eventRepository.AddAdminEvent(events);
        }

        /// <summary>
        ///     Delete an event by its ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEvent(int id)
        {
            _eventRepository.DeleteEvent(id);
        }

        #endregion

        #region Event Detail Methods

        /// <summary>
        ///     Get all event details.
        /// </summary>
        /// <returns></returns>
        public List<EventDetail> GetEventDetails()
        {
            return _eventRepository.GetEventDetails();
        }

        /// <summary>
        ///     Get event detail by its ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public EventDetail GetEventDetail(int eventId)
        {
            return _eventRepository.GetEventDetail(eventId);
        }

        /// <summary>
        ///     Update the provided event detail information.
        /// </summary>
        /// <param name="updatedEventDetail"></param>
        public void UpdateEventDetail(EventDetail updatedEventDetail)
        {
            _eventRepository.UpdateEventDetail(updatedEventDetail);
        }

        /// <summary>
        ///     Add a new event detail.
        /// </summary>
        /// <param name="eventDetail"></param>
        public void AddEventDetail(EventDetail eventDetail)
        {
            _eventRepository.AddEventDetail(eventDetail);
        }

        /// <summary>
        ///     Delete an event detail by its ID.
        /// </summary>
        /// <param name="eventId"></param>
        public void DeleteEventDetail(int eventId)
        {
            _eventRepository.DeleteEventDetail(eventId);
        }

        #endregion

        #region Event Recurrence Methods

        /// <summary>
        ///     Get all event recurrences.
        /// </summary>
        /// <returns></returns>
        public List<EventRecurrence> GetEventRecurrences()
        {
            return _eventRepository.GetEventRecurrences();
        }

        /// <summary>
        ///     Get event recurrence by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EventRecurrence GetEventRecurrence(int id)
        {
            return _eventRepository.GetEventRecurrence(id);
        }

        /// <summary>
        ///     Update the provided event recurrence information.
        /// </summary>
        /// <param name="updatedEventRecurrence"></param>
        public void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence)
        {
            _eventRepository.UpdateEventRecurrence(updatedEventRecurrence);
        }

        /// <summary>
        ///     Add a new event recurrence.
        /// </summary>
        /// <param name="eventRecurrence"></param>
        public void AddEventRecurrence(EventRecurrence eventRecurrence)
        {
            _eventRepository.AddEventRecurrence(eventRecurrence);
        }

        /// <summary>
        ///     Delete an event recurrence by its ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEventRecurrence(int id)
        {
            _eventRepository.DeleteEventRecurrence(id);
        }

        #endregion

        #region Event Type Methods

        /// <summary>
        ///     Get all event types.
        /// </summary>
        /// <returns></returns>
        public List<EventType> GetEventTypes()
        {
            return _eventRepository.GetEventTypes();
        }

        /// <summary>
        ///     Get event type by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EventType GetEventType(int id)
        {
            return _eventRepository.GetEventType(id);
        }

        /// <summary>
        ///     Update the provided event type information.
        /// </summary>
        /// <param name="updatedEventType"></param>
        public void UpdateEventType(EventType updatedEventType)
        {
            _eventRepository.UpdateEventType(updatedEventType);
        }

        /// <summary>
        ///     Add a new event type.
        /// </summary>
        /// <param name="eventType"></param>
        public void AddEventType(EventType eventType)
        {
            _eventRepository.AddEventType(eventType);
        }

        /// <summary>
        ///     Delete an event type by its ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEventType(int id)
        {
            _eventRepository.DeleteEventType(id);
        }

        #endregion
    }
}