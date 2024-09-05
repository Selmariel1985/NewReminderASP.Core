using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    ///     Service contract for event-related operations.
    /// </summary>
    [ServiceContract]
    public interface IEventService
    {
        // Events

        /// <summary>
        ///     Get a list of all events.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<EventDto> GetEvents();

        /// <summary>
        ///     Get events associated with a specific user.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [OperationContract]
        List<EventDto> GetEventsForUser(string login);

        /// <summary>
        ///     Get events with a specific ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        List<EventDto> GetEventsForID(int id);

        /// <summary>
        ///     Get an event by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [OperationContract]
        EventDto GetEvent(int Id);

        /// <summary>
        ///     Update the provided event information.
        /// </summary>
        /// <param name="updatedEvent"></param>
        [OperationContract]
        void UpdateEvent(EventDto updatedEvent);

        /// <summary>
        ///     Add a new event.
        /// </summary>
        /// <param name="events"></param>
        [OperationContract]
        void AddEvent(EventDto events);

        /// <summary>
        ///     Delete an event by its ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void DeleteEvent(int id);

        // Event Details

        /// <summary>
        ///     Get a list of all event details.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<EventDetailDto> GetEventDetails();

        /// <summary>
        ///     Get an event detail by its event ID.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [OperationContract]
        EventDetailDto GetEventDetail(int eventId);

        /// <summary>
        ///     Update the provided event detail information.
        /// </summary>
        /// <param name="updatedEventDetail"></param>
        [OperationContract]
        void UpdateEventDetail(EventDetailDto updatedEventDetail);

        /// <summary>
        ///     Add a new event detail.
        /// </summary>
        /// <param name="eventDetail"></param>
        [OperationContract]
        void AddEventDetail(EventDetailDto eventDetail);

        /// <summary>
        ///     Delete an event detail by its event ID.
        /// </summary>
        /// <param name="eventId"></param>
        [OperationContract]
        void DeleteEventDetail(int eventId);

        // Event Recurrences

        /// <summary>
        ///     Get a list of all event recurrences.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<EventRecurrenceDto> GetEventRecurrences();

        /// <summary>
        ///     Get an event recurrence by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [OperationContract]
        EventRecurrenceDto GetEventRecurrence(int Id);

        /// <summary>
        ///     Update the provided event recurrence information.
        /// </summary>
        /// <param name="updatedEventRecurrence"></param>
        [OperationContract]
        void UpdateEventRecurrence(EventRecurrenceDto updatedEventRecurrence);

        /// <summary>
        ///     Add a new event recurrence.
        /// </summary>
        /// <param name="eventRecurrence"></param>
        [OperationContract]
        void AddEventRecurrence(EventRecurrenceDto eventRecurrence);

        /// <summary>
        ///     Delete an event recurrence by its ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void DeleteEventRecurrence(int id);

        // Event Types

        /// <summary>
        ///     Get a list of all event types.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<EventTypeDto> GetEventTypes();

        /// <summary>
        ///     Get an event type by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [OperationContract]
        EventTypeDto GetEventType(int Id);

        /// <summary>
        ///     Update the provided event type information.
        /// </summary>
        /// <param name="updatedEventType"></param>
        [OperationContract]
        void UpdateEventType(EventTypeDto updatedEventType);

        /// <summary>
        ///     Add a new event type.
        /// </summary>
        /// <param name="eventType"></param>
        [OperationContract]
        void AddEventType(EventTypeDto eventType);

        /// <summary>
        ///     Delete an event type by its ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void DeleteEventType(int id);
    }
}