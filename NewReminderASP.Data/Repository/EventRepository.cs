using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly IEventClient _eventClient;

        public EventRepository(IEventClient eventClient)
        {
            _eventClient = eventClient;
        }

        public List<Event> GeEvents()
        {
            return _eventClient.GeEvents().ToList();
        }

        public Event GetEvent(int Id)
        {
            return _eventClient.GetEvent(Id);
        }

        public void UpdateEvent(Event updatedEvent)
        {
            _eventClient.UpdateEvent(updatedEvent);
        }

        public void AddEvent(Event events)
        {
            _eventClient.AddEvent(events);
        }

        public void DeleteEvent(int id)
        {
            _eventClient.DeleteEvent(id);
        }

        public List<EventDetail> GetEventDetails()
        {
            return _eventClient.GetEventDetails().ToList();
        }

        public EventDetail GetEventDetail(int eventId)
        {
            return _eventClient.GetEventDetail(eventId);
        }

        public void UpdateEventDetail(EventDetail updatedEventDetail)
        {
            _eventClient.UpdateEventDetail(updatedEventDetail);
        }

        public void AddEventDetail(EventDetail eventDetail)
        {
            _eventClient.AddEventDetail(eventDetail);
        }

        public void DeleteEventDetail(int eventId)
        {
            _eventClient.DeleteEventDetail(eventId);
        }

        public List<EventRecurrence> GetEventRecurrences()
        {
            return _eventClient.GetEventRecurrences().ToList();
        }

        public EventRecurrence GetEventRecurrence(int Id)
        {
            return _eventClient.GetEventRecurrence(Id);
        }

        public void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence)
        {
            _eventClient.UpdateEventRecurrence(updatedEventRecurrence);
        }

        public void AddEventRecurrence(EventRecurrence eventRecurrence)
        {
            _eventClient.AddEventRecurrence(eventRecurrence);
        }

        public void DeleteEventRecurrence(int id)
        {
            _eventClient.DeleteEventRecurrence(id);
        }

        public List<EventType> GetEventTypes()
        {
            return _eventClient.GetEventTypes().ToList();
        }

        public EventType GetEventType(int Id)
        {
            return _eventClient.GetEventType(Id);
        }

        public void UpdateEventType(EventType updatedEventType)
        {
            _eventClient.UpdateEventType(updatedEventType);
        }

        public void AddPEventType(EventType eventType)
        {
            _eventClient.AddPEventType(eventType);
        }

        public void DeleteEventType(int id)
        {
            _eventClient.DeleteEventType(id);
        }
    }
}