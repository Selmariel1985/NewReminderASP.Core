using System.Collections.Generic;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Provider class for event-related functionality by interacting with the event repository.
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
        /// Get a list of all events.
        /// </summary>
        public List<Event> GetEvents()
        {
            return _eventRepository.GetEvents();
        }

        /// <summary>
        /// Get events associated with a specific user.
        /// </summary>
        public List<Event> GetEventsForUser(string userName)
        {
            return _eventRepository.GetEventsForUser(userName);
        }

        /// <summary>
        /// Get events with a specific ID.
        /// </summary>
        public List<Event> GetEventsForID(int id)
        {
            return _eventRepository.GetEventsForID(id);
        }

        /// <summary>
        /// Get an event by its ID.
        /// </summary>
        public Event GetEvent(int Id)
        {
            return _eventRepository.GetEvent(Id);
        }

        /// <summary>
        /// Update the provided event information.
        /// </summary>
        public void UpdateEvent(Event updatedEvent)
        {
            _eventRepository.UpdateEvent(updatedEvent);
        }

        /// <summary>
        /// Add a new event.
        /// </summary>
        public void AddEvent(Event events)
        {
            _eventRepository.AddEvent(events);
        }

        /// <summary>
        /// Add a new event with admin privileges.
        /// </summary>
        public void AddAdminEvent(Event events)
        {
            _eventRepository.AddAdminEvent(events);
        }

        /// <summary>
        /// Delete an event by its ID.
        /// </summary>
        public void DeleteEvent(int id)
        {
            _eventRepository.DeleteEvent(id);
        }

        #endregion

        #region Event Detail Methods

        /// <summary>
        /// Get all event details.
        /// </summary>
        public List<EventDetail> GetEventDetails()
        {
            return _eventRepository.GetEventDetails();
        }

        /// <summary>
        /// Get event detail by its ID.
        /// </summary>
        public EventDetail GetEventDetail(int eventId)
        {
            return _eventRepository.GetEventDetail(eventId);
        }

        /// <summary>
        /// Update the provided event detail information.
        /// </summary>
        public void UpdateEventDetail(EventDetail updatedEventDetail)
        {
            _eventRepository.UpdateEventDetail(updatedEventDetail);
        }

        /// <summary>
        /// Add a new event detail.
        /// </summary>
        public void AddEventDetail(EventDetail eventDetail)
        {
            _eventRepository.AddEventDetail(eventDetail);
        }

        /// <summary>
        /// Delete an event detail by its ID.
        /// </summary>
        public void DeleteEventDetail(int eventId)
        {
            _eventRepository.DeleteEventDetail(eventId);
        }

        #endregion

        #region Event Recurrence Methods

        /// <summary>
        /// Get all event recurrences.
        /// </summary>
        public List<EventRecurrence> GetEventRecurrences()
        {
            return _eventRepository.GetEventRecurrences();
        }

        /// <summary>
        /// Get event recurrence by its ID.
        /// </summary>
        public EventRecurrence GetEventRecurrence(int id)
        {
            return _eventRepository.GetEventRecurrence(id);
        }

        /// <summary>
        /// Update the provided event recurrence information.
        /// </summary>
        public void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence)
        {
            _eventRepository.UpdateEventRecurrence(updatedEventRecurrence);
        }

        /// <summary>
        /// Add a new event recurrence.
        /// </summary>
        public void AddEventRecurrence(EventRecurrence eventRecurrence)
        {
            _eventRepository.AddEventRecurrence(eventRecurrence);
        }

        /// <summary>
        /// Delete an event recurrence by its ID.
        /// </summary>
        public void DeleteEventRecurrence(int id)
        {
            _eventRepository.DeleteEventRecurrence(id);
        }

        #endregion

        #region Event Type Methods

        /// <summary>
        /// Get all event types.
        /// </summary>
        public List<EventType> GetEventTypes()
        {
            return _eventRepository.GetEventTypes();
        }

        /// <summary>
        /// Get event type by its ID.
        /// </summary>
        public EventType GetEventType(int id)
        {
            return _eventRepository.GetEventType(id);
        }

        /// <summary>
        /// Update the provided event type information.
        /// </summary>
        public void UpdateEventType(EventType updatedEventType)
        {
            _eventRepository.UpdateEventType(updatedEventType);
        }

        /// <summary>
        /// Add a new event type.
        /// </summary>
        public void AddEventType(EventType eventType)
        {
            _eventRepository.AddEventType(eventType);
        }

        /// <summary>
        /// Delete an event type by its ID.
        /// </summary>
        public void DeleteEventType(int id)
        {
            _eventRepository.DeleteEventType(id);
        }

        #endregion
    }
}
