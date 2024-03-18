using NewReminderASP.Services.Dtos;
using System.Collections.Generic;
using System.ServiceModel;

namespace NewReminderASP.Services.Contract
{
    [ServiceContract]
    public interface IEventService
    {
        [OperationContract]
        List<EventDto> GeEvents();

        [OperationContract]
        EventDto GetEvent(int Id);

        [OperationContract]
        void UpdateEvent(EventDto updatedEvent);

        [OperationContract]
        void AddEvent(EventDto events);

        [OperationContract]
        void DeleteEvent(int id);

        [OperationContract]
        List<EventDetailDto> GetEventDetails();

        [OperationContract]
        EventDetailDto GetEventDetail(int eventId);

        [OperationContract]
        void UpdateEventDetail(EventDetailDto updatedEventDetail);

        [OperationContract]
        void AddEventDetail(EventDetailDto eventDetail);

        [OperationContract]
        void DeleteEventDetail(int eventId);

        [OperationContract]
        List<EventRecurrenceDto> GetEventRecurrences();

        [OperationContract]
        EventRecurrenceDto GetEventRecurrence(int Id);

        [OperationContract]
        void UpdateEventRecurrence(EventRecurrenceDto updatedEventRecurrence);

        [OperationContract]
        void AddEventRecurrence(EventRecurrenceDto eventRecurrence);

        [OperationContract]
        void DeleteEventRecurrence(int id);

        [OperationContract]
        List<EventTypeDto> GetEventTypes();

        [OperationContract]
        EventTypeDto GetEventType(int Id);

        [OperationContract]
        void UpdateEventType(EventTypeDto updatedEventType);

        [OperationContract]
        void AddPEventType(EventTypeDto eventType);

        [OperationContract]
        void DeleteEventType(int id);
    }
}