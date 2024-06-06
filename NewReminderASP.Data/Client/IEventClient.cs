using System.Collections.Generic;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    /// Interface for interacting with event-related data.
    /// </summary>
    public interface IEventClient
    {
        // Event methods
        List<Event> GetEvents();
        List<Event> GetEventsForUser(string userName);
        List<Event> GetEventsForID(int id);
        Event GetEvent(int Id);
        void UpdateEvent(Event updatedEvent);
        void AddEvent(Event events);
        void AddAdminEvent(Event events);
        void DeleteEvent(int id);

        // Event detail methods
        List<EventDetail> GetEventDetails();
        EventDetail GetEventDetail(int eventId);
        void UpdateEventDetail(EventDetail updatedEventDetail);
        void AddEventDetail(EventDetail eventDetail);
        void DeleteEventDetail(int eventId);

        // Event recurrence methods
        List<EventRecurrence> GetEventRecurrences();
        EventRecurrence GetEventRecurrence(int Id);
        void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence);
        void AddEventRecurrence(EventRecurrence eventRecurrence);
        void DeleteEventRecurrence(int id);

        // Event type methods
        List<EventType> GetEventTypes();
        EventType GetEventType(int Id);
        void UpdateEventType(EventType updatedEventType);
        void AddEventType(EventType eventType);
        void DeleteEventType(int id);
    }
}