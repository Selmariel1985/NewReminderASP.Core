using System.Collections.Generic;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Interface for providing event-related functionality.
    /// </summary>
    public interface IEventProvider
    {
        // Events

        /// <summary>
        /// Get a list of all events.
        /// </summary>
        List<Event> GetEvents();

        /// <summary>
        /// Get events associated with a specific user.
        /// </summary>
        List<Event> GetEventsForUser(string userName);

        /// <summary>
        /// Get events with a specific ID.
        /// </summary>
        List<Event> GetEventsForID(int id);

        /// <summary>
        /// Get an event by its ID.
        /// </summary>
        Event GetEvent(int id);

        /// <summary>
        /// Update the provided event information.
        /// </summary>
        void UpdateEvent(Event updatedEvent);

        /// <summary>
        /// Add a new event.
        /// </summary>
        void AddEvent(Event events);

        /// <summary>
        /// Add a new event with admin privileges.
        /// </summary>
        void AddAdminEvent(Event events);

        /// <summary>
        /// Delete an event by its ID.
        /// </summary>
        void DeleteEvent(int id);

        // Event Details

        /// <summary>
        /// Get a list of all event details.
        /// </summary>
        List<EventDetail> GetEventDetails();

        /// <summary>
        /// Get an event detail by its event ID.
        /// </summary>
        EventDetail GetEventDetail(int eventId);

        /// <summary>
        /// Update the provided event detail information.
        /// </summary>
        void UpdateEventDetail(EventDetail updatedEventDetail);

        /// <summary>
        /// Add a new event detail.
        /// </summary>
        void AddEventDetail(EventDetail eventDetail);

        /// <summary>
        /// Delete an event detail by its event ID.
        /// </summary>
        void DeleteEventDetail(int eventId);

        // Event Recurrences

        /// <summary>
        /// Get a list of all event recurrences.
        /// </summary>
        List<EventRecurrence> GetEventRecurrences();

        /// <summary>
        /// Get an event recurrence by its ID.
        /// </summary>
        EventRecurrence GetEventRecurrence(int id);

        /// <summary>
        /// Update the provided event recurrence information.
        /// </summary>
        void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence);

        /// <summary>
        /// Add a new event recurrence.
        /// </summary>
        void AddEventRecurrence(EventRecurrence eventRecurrence);

        /// <summary>
        /// Delete an event recurrence by its ID.
        /// </summary>
        void DeleteEventRecurrence(int id);

        // Event Types

        /// <summary>
        /// Get a list of all event types.
        /// </summary>
        List<EventType> GetEventTypes();

        /// <summary>
        /// Get an event type by its ID.
        /// </summary>
        EventType GetEventType(int id);

        /// <summary>
        /// Update the provided event type information.
        /// </summary>
        void UpdateEventType(EventType updatedEventType);

        /// <summary>
        /// Add a new event type.
        /// </summary>
        void AddEventType(EventType eventType);

        /// <summary>
        /// Delete an event type by its ID.
        /// </summary>
        void DeleteEventType(int id);
    }
}
