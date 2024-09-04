using System.Collections.Generic;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Repository class for handling event-related data operations through the event client.
    /// </summary>
    public class EventRepository : IEventRepository
    {
        private readonly IEventClient _eventClient;

        /// <summary>
        ///     Constructor for EventRepository that initializes the event client.
        /// </summary>
        /// <param name="eventClient">The event client to be used for data operations</param>
        public EventRepository(IEventClient eventClient)
        {
            _eventClient = eventClient;
        }

        #region Event Methods

        /// <summary>
        ///     Get all events.
        /// </summary>
        /// <returns></returns>
        public List<Event> GetEvents()
        {
            return _eventClient.GetEvents();
        }

        /// <summary>
        ///     Get events for a specific user.
        /// </summary>
        /// <param name="userName">The username of the user</param>
        /// <returns></returns>
        public List<Event> GetEventsForUser(string userName)
        {
            return _eventClient.GetEventsForUser(userName);
        }

        /// <summary>
        ///     Get events with a specific ID.
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <returns></returns>
        public List<Event> GetEventsForID(int id)
        {
            return _eventClient.GetEventsForID(id);
        }

        /// <summary>
        ///     Get a specific event by ID.
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <returns></returns>
        public Event GetEvent(int id)
        {
            return _eventClient.GetEvent(id);
        }

        /// <summary>
        ///     Update an existing event.
        /// </summary>
        /// <param name="updatedEvent">The updated event object</param>
        public void UpdateEvent(Event updatedEvent)
        {
            _eventClient.UpdateEvent(updatedEvent);
        }

        /// <summary>
        ///     Add a new event.
        /// </summary>
        /// <param name="events">The event to be added</param>
        public void AddEvent(Event events)
        {
            _eventClient.AddEvent(events);
        }

        /// <summary>
        ///     Add a new event with admin privileges.
        /// </summary>
        /// <param name="events">The event to be added</param>
        public void AddAdminEvent(Event events)
        {
            _eventClient.AddAdminEvent(events);
        }

        /// <summary>
        ///     Delete an event by ID.
        /// </summary>
        /// <param name="id">The ID of the event to delete</param>
        public void DeleteEvent(int id)
        {
            _eventClient.DeleteEvent(id);
        }

        #endregion

        #region Event Detail Methods

        /// <summary>
        ///     Get all event details.
        /// </summary>
        /// <returns></returns>
        public List<EventDetail> GetEventDetails()
        {
            return _eventClient.GetEventDetails();
        }

        /// <summary>
        ///     Retrieve the event detail record by its ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public EventDetail GetEventDetail(int eventId)
        {
            return _eventClient.GetEventDetail(eventId);
        }

        /// <summary>
        ///     Update an existing event detail.
        /// </summary>
        /// <param name="updatedEventDetail">The updated event detail object</param>
        public void UpdateEventDetail(EventDetail updatedEventDetail)
        {
            _eventClient.UpdateEventDetail(updatedEventDetail);
        }

        /// <summary>
        ///     Add a new event detail.
        /// </summary>
        /// <param name="eventDetail">The event detail to be added</param>
        public void AddEventDetail(EventDetail eventDetail)
        {
            _eventClient.AddEventDetail(eventDetail);
        }

        /// <summary>
        ///     Delete an event detail by event ID.
        /// </summary>
        /// <param name="eventId">The ID of the event whose detail needs to be deleted</param>
        public void DeleteEventDetail(int eventId)
        {
            _eventClient.DeleteEventDetail(eventId);
        }

        #endregion

        #region Event Recurrence Methods

        /// <summary>
        ///     Get all event recurrences.
        /// </summary>
        /// <returns></returns>
        public List<EventRecurrence> GetEventRecurrences()
        {
            return _eventClient.GetEventRecurrences();
        }

        /// <summary>
        ///     Get event recurrence by ID.
        /// </summary>
        /// <param name="id">The ID of the event recurrence</param>
        /// <returns></returns>
        public EventRecurrence GetEventRecurrence(int id)
        {
            return _eventClient.GetEventRecurrence(id);
        }

        /// <summary>
        ///     Update an existing event recurrence.
        /// </summary>
        /// <param name="updatedEventRecurrence">The updated event recurrence object</param>
        public void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence)
        {
            _eventClient.UpdateEventRecurrence(updatedEventRecurrence);
        }

        /// <summary>
        ///     Add a new event recurrence.
        /// </summary>
        /// <param name="eventRecurrence">The event recurrence to be added</param>
        public void AddEventRecurrence(EventRecurrence eventRecurrence)
        {
            _eventClient.AddEventRecurrence(eventRecurrence);
        }

        /// <summary>
        ///     Delete an event recurrence by ID.
        /// </summary>
        /// <param name="id">The ID of the event recurrence to delete</param>
        public void DeleteEventRecurrence(int id)
        {
            _eventClient.DeleteEventRecurrence(id);
        }

        #endregion

        #region Event Type Methods

        /// <summary>
        ///     Get all event types.
        /// </summary>
        /// <returns></returns>
        public List<EventType> GetEventTypes()
        {
            return _eventClient.GetEventTypes();
        }

        /// <summary>
        ///     Get event type by ID.
        /// </summary>
        /// <param name="id">The ID of the event type</param>
        /// <returns></returns>
        public EventType GetEventType(int id)
        {
            return _eventClient.GetEventType(id);
        }

        /// <summary>
        ///     Update an existing event type.
        /// </summary>
        /// <param name="updatedEventType">The updated event type object</param>
        public void UpdateEventType(EventType updatedEventType)
        {
            _eventClient.UpdateEventType(updatedEventType);
        }

        /// <summary>
        ///     Add a new event type.
        /// </summary>
        /// <param name="eventType">The event type to be added</param>
        public void AddEventType(EventType eventType)
        {
            _eventClient.AddEventType(eventType);
        }

        /// <summary>
        ///     Delete an event type by ID.
        /// </summary>
        /// <param name="id">The ID of the event type to delete</param>
        public void DeleteEventType(int id)
        {
            _eventClient.DeleteEventType(id);
        }

        #endregion
    }
}