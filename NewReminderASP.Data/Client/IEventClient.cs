using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    ///     Interface for interacting with event-related data.
    /// </summary>
    public interface IEventClient
    {
        // Event methods
        /// <summary>
        ///     Retrieve a list of all events.
        /// </summary>
        /// <returns></returns>
        List<Event> GetEvents();

        /// <summary>
        ///     Retrieve a list of all events by its userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<Event> GetEventsForUser(string userName);

        /// <summary>
        ///     Retrieve a list of all events by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Event> GetEventsForID(int id);

        /// <summary>
        ///     Retrieve an event by its id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Event GetEvent(int Id);

        /// <summary>
        ///     Update an existing event with new information.
        /// </summary>
        /// <param name="updatedEvent"></param>
        void UpdateEvent(Event updatedEvent);

        /// <summary>
        ///     Add a new event.
        /// </summary>
        /// <param name="events"></param>
        void AddEvent(Event events);

        /// <summary>
        ///     Add a new event for admin
        /// </summary>
        /// <param name="events"></param>
        void AddAdminEvent(Event events);

        /// <summary>
        ///     Delete the event with the specified id.
        /// </summary>
        /// <param name="id"></param>
        void DeleteEvent(int id);

        // Event detail methods
        /// <summary>
        ///     Retrieve a list of all event details
        /// </summary>
        /// <returns></returns>
        List<EventDetail> GetEventDetails();

        /// <summary>
        ///     Retrieve an event detail by its eventId
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        EventDetail GetEventDetail(int eventId);

        /// <summary>
        ///     Update an existing event detail with new information.
        /// </summary>
        /// <param name="updatedEventDetail"></param>
        void UpdateEventDetail(EventDetail updatedEventDetail);

        /// <summary>
        ///     Add a new event detail.
        /// </summary>
        /// <param name="eventDetail"></param>
        void AddEventDetail(EventDetail eventDetail);

        /// <summary>
        ///     Delete the event detail with the specified eventId.
        /// </summary>
        /// <param name="eventId"></param>
        void DeleteEventDetail(int eventId);

        // Event recurrence methods

        /// <summary>
        ///     Retrieve a list of all event recurrence
        /// </summary>
        /// <returns></returns>
        List<EventRecurrence> GetEventRecurrences();

        /// <summary>
        ///     Retrieve an event recurrence by its id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EventRecurrence GetEventRecurrence(int Id);

        /// <summary>
        ///     Update an existing event recurrence with new information.
        /// </summary>
        /// <param name="updatedEventRecurrence"></param>
        void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence);

        /// <summary>
        ///     Add a new event recurrence.
        /// </summary>
        /// <param name="eventRecurrence"></param>
        void AddEventRecurrence(EventRecurrence eventRecurrence);

        /// <summary>
        ///     Delete the event recurrence with the specified id.
        /// </summary>
        /// <param name="id"></param>
        void DeleteEventRecurrence(int id);

        // Event type methods
        /// <summary>
        ///     Retrieve a list of all event type
        /// </summary>
        /// <returns></returns>
        List<EventType> GetEventTypes();

        /// <summary>
        ///     Retrieve an event type by its id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EventType GetEventType(int Id);

        /// <summary>
        ///     Update an existing event type with new information.
        /// </summary>
        /// <param name="updatedEventType"></param>
        void UpdateEventType(EventType updatedEventType);

        /// <summary>
        ///     Add a new event type.
        /// </summary>
        /// <param name="eventType"></param>
        void AddEventType(EventType eventType);

        /// <summary>
        ///     Delete the event type with the specified id.
        /// </summary>
        /// <param name="id"></param>
        void DeleteEventType(int id);
    }
}