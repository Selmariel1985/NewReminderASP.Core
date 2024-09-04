using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Interface for providing event-related functionality.
    /// </summary>
    public interface IEventProvider
    {
        // Events

        /// <summary>
        ///     Get a list of all events.
        /// </summary>
        /// <returns></returns>
        List<Event> GetEvents();

        /// <summary>
        ///     Get events associated with a specific user.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<Event> GetEventsForUser(string userName);

        /// <summary>
        ///     Get events with a specific ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Event> GetEventsForID(int id);

        /// <summary>
        ///     Get an event by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Event GetEvent(int id);

        /// <summary>
        ///     Update the provided event information.
        /// </summary>
        /// <param name="updatedEvent"></param>
        void UpdateEvent(Event updatedEvent);

        /// <summary>
        ///     Add a new event.
        /// </summary>
        /// <param name="events"></param>
        void AddEvent(Event events);

        /// <summary>
        ///     Add a new event with admin privileges.
        /// </summary>
        /// <param name="events"></param>
        void AddAdminEvent(Event events);

        /// <summary>
        ///     Delete an event by its ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteEvent(int id);

        // Event Details

        /// <summary>
        ///     Get a list of all event details.
        /// </summary>
        /// <returns></returns>
        List<EventDetail> GetEventDetails();

        /// <summary>
        ///     Get an event detail by its event ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        EventDetail GetEventDetail(int eventId);

        /// <summary>
        ///     Update the provided event detail information.
        /// </summary>
        /// <param name="updatedEventDetail"></param>
        void UpdateEventDetail(EventDetail updatedEventDetail);

        /// <summary>
        ///     Add a new event detail.
        /// </summary>
        /// <param name="eventDetail"></param>
        void AddEventDetail(EventDetail eventDetail);

        /// <summary>
        ///     Delete an event detail by its event ID.
        /// </summary>
        /// <param name="eventId"></param>
        void DeleteEventDetail(int eventId);

        // Event Recurrences

        /// <summary>
        ///     Get a list of all event recurrences.
        /// </summary>
        /// <returns></returns>
        List<EventRecurrence> GetEventRecurrences();

        /// <summary>
        ///     Get an event recurrence by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EventRecurrence GetEventRecurrence(int id);

        /// <summary>
        ///     Update the provided event recurrence information.
        /// </summary>
        /// <param name="updatedEventRecurrence"></param>
        void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence);

        /// <summary>
        ///     Add a new event recurrence.
        /// </summary>
        /// <param name="eventRecurrence"></param>
        void AddEventRecurrence(EventRecurrence eventRecurrence);

        /// <summary>
        ///     Delete an event recurrence by its ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteEventRecurrence(int id);

        // Event Types

        /// <summary>
        ///     Get a list of all event types.
        /// </summary>
        /// <returns></returns>
        List<EventType> GetEventTypes();

        /// <summary>
        ///     Get an event type by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EventType GetEventType(int id);

        /// <summary>
        ///     Update the provided event type information.
        /// </summary>
        /// <param name="updatedEventType"></param>
        void UpdateEventType(EventType updatedEventType);

        /// <summary>
        ///     Add a new event type.
        /// </summary>
        /// <param name="eventType"></param>
        void AddEventType(EventType eventType);

        /// <summary>
        ///     Delete an event type by its ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteEventType(int id);
    }
}