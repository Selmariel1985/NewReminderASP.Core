using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Interface for accessing and managing event-related data.
    /// </summary>
    public interface IEventRepository
    {
        #region Event Methods

        /// <summary>
        ///     Get all events.
        /// </summary>
        /// <returns></returns>
        List<Event> GetEvents();

        /// <summary>
        ///     Get events for a specific user.
        /// </summary>
        /// <param name="userName">The username of the user</param>
        /// <returns></returns>
        List<Event> GetEventsForUser(string userName);

        /// <summary>
        ///     Get events with a specific ID.
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <returns></returns>
        List<Event> GetEventsForID(int id);

        /// <summary>
        ///     Get a specific event by ID.
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <returns></returns>
        Event GetEvent(int id);

        /// <summary>
        ///     Update an existing event.
        /// </summary>
        /// <param name="updatedEvent">The updated event object</param>
        void UpdateEvent(Event updatedEvent);

        /// <summary>
        ///     Add a new event.
        /// </summary>
        /// <param name="events">The event to be added</param>
        void AddEvent(Event events);

        /// <summary>
        ///     Add a new event with admin privileges.
        /// </summary>
        /// <param name="events">The event to be added</param>
        void AddAdminEvent(Event events);

        /// <summary>
        ///     Delete an event by ID.
        /// </summary>
        /// <param name="id">The ID of the event to delete</param>
        void DeleteEvent(int id);

        #endregion

        #region Event Detail Methods

        /// <summary>
        ///     Get all event details.
        /// </summary>
        /// <returns></returns>
        List<EventDetail> GetEventDetails();

        /// <summary>
        ///     Get event detail by ID.
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        /// <returns></returns>
        EventDetail GetEventDetail(int eventId);

        /// <summary>
        ///     Update an existing event detail.
        /// </summary>
        /// <param name="updatedEventDetail">The updated event detail object</param>
        void UpdateEventDetail(EventDetail updatedEventDetail);

        /// <summary>
        ///     Add a new event detail.
        /// </summary>
        /// <param name="eventDetail">The event detail to be added</param>
        void AddEventDetail(EventDetail eventDetail);

        /// <summary>
        ///     Delete an event detail by ID.
        /// </summary>
        /// <param name="eventId">The ID of the event</param>
        void DeleteEventDetail(int eventId);

        #endregion

        #region Event Recurrence Methods

        /// <summary>
        ///     Get all event recurrences.
        /// </summary>
        /// <returns></returns>
        List<EventRecurrence> GetEventRecurrences();

        /// <summary>
        ///     Get event recurrence by ID.
        /// </summary>
        /// <param name="id">The ID of the event recurrence</param>
        /// <returns></returns>
        EventRecurrence GetEventRecurrence(int id);

        /// <summary>
        ///     Update an existing event recurrence.
        /// </summary>
        /// <param name="updatedEventRecurrence">The updated event recurrence object</param>
        void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence);

        /// <summary>
        ///     Add a new event recurrence.
        /// </summary>
        /// <param name="eventRecurrence">The event recurrence to be added</param>
        void AddEventRecurrence(EventRecurrence eventRecurrence);

        /// <summary>
        ///     Delete an event recurrence by ID.
        /// </summary>
        /// <param name="id">The ID of the event recurrence to delete</param>
        void DeleteEventRecurrence(int id);

        #endregion

        #region Event Type Methods

        /// <summary>
        ///     Get all event types.
        /// </summary>
        /// <returns></returns>
        List<EventType> GetEventTypes();

        /// <summary>
        ///     Get event type by ID.
        /// </summary>
        /// <param name="id">The ID of the event type</param>
        /// <returns></returns>
        EventType GetEventType(int id);

        /// <summary>
        ///     Update an existing event type.
        /// </summary>
        /// <param name="updatedEventType">The updated event type object</param>
        void UpdateEventType(EventType updatedEventType);

        /// <summary>
        ///     Add a new event type.
        /// </summary>
        /// <param name="eventType">The event type to be added</param>
        void AddEventType(EventType eventType);

        /// <summary>
        ///     Delete an event type by ID.
        /// </summary>
        /// <param name="id">The ID of the event type to delete</param>
        void DeleteEventType(int id);

        #endregion
    }
}