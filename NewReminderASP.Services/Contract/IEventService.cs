using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    /// Service contract for event-related operations.
    /// </summary>
    [ServiceContract]
    public interface IEventService
    {
        // Events

        /// <summary>
        /// Get a list of all events.
        /// </summary>
        [OperationContract]
        List<EventDto> GetEvents();

        /// <summary>
        /// Get events associated with a specific user.
        /// </summary>
        [OperationContract]
        List<EventDto> GetEventsForUser(string login);

        /// <summary>
        /// Get events with a specific ID.
        /// </summary>
        [OperationContract]
        List<EventDto> GetEventsForID(int id);

        /// <summary>
        /// Get an event by its ID.
        /// </summary>
        [OperationContract]
        EventDto GetEvent(int Id);

        /// <summary>
        /// Update the provided event information.
        /// </summary>
        [OperationContract]
        void UpdateEvent(EventDto updatedEvent);

        /// <summary>
        /// Add a new event.
        /// </summary>
        [OperationContract]
        void AddEvent(EventDto events);

        /// <summary>
        /// Delete an event by its ID.
        /// </summary>
        [OperationContract]
        void DeleteEvent(int id);

        // Event Details

        /// <summary>
        /// Get a list of all event details.
        /// </summary>
        [OperationContract]
        List<EventDetailDto> GetEventDetails();

        /// <summary>
        /// Get an event detail by its event ID.
        /// </summary>
        [OperationContract]
        EventDetailDto GetEventDetail(int eventId);

        /// <summary>
        /// Update the provided event detail information.
        /// </summary>
        [OperationContract]
        void UpdateEventDetail(EventDetailDto updatedEventDetail);

        /// <summary>
        /// Add a new event detail.
        /// </summary>
        [OperationContract]
        void AddEventDetail(EventDetailDto eventDetail);

        /// <summary>
        /// Delete an event detail by its event ID.
        /// </summary>
        [OperationContract]
        void DeleteEventDetail(int eventId);

        // Event Recurrences

        /// <summary>
        /// Get a list of all event recurrences.
        /// </summary>
        [OperationContract]
        List<EventRecurrenceDto> GetEventRecurrences();

        /// <summary>
        /// Get an event recurrence by its ID.
        /// </summary>
        [OperationContract]
        EventRecurrenceDto GetEventRecurrence(int Id);

        /// <summary>
        /// Update the provided event recurrence information.
        /// </summary>
        [OperationContract]
        void UpdateEventRecurrence(EventRecurrenceDto updatedEventRecurrence);

        /// <summary>
        /// Add a new event recurrence.
        /// </summary>
        [OperationContract]
        void AddEventRecurrence(EventRecurrenceDto eventRecurrence);

        /// <summary>
        /// Delete an event recurrence by its ID.
        /// </summary>
        [OperationContract]
        void DeleteEventRecurrence(int id);

        // Event Types

        /// <summary>
        /// Get a list of all event types.
        /// </summary>
        [OperationContract]
        List<EventTypeDto> GetEventTypes();

        /// <summary>
        /// Get an event type by its ID.
        /// </summary>
        [OperationContract]
        EventTypeDto GetEventType(int Id);

        /// <summary>
        /// Update the provided event type information.
        /// </summary>
        [OperationContract]
        void UpdateEventType(EventTypeDto updatedEventType);

        /// <summary>
        /// Add a new event type.
        /// </summary>
        [OperationContract]
        void AddEventType(EventTypeDto eventType);

        /// <summary>
        /// Delete an event type by its ID.
        /// </summary>
        [OperationContract]
        void DeleteEventType(int id);
    }
}
