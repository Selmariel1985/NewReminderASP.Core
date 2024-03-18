using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NewReminderASP.Core.Provider
{
    public class EventProvider : IEventProvider
    {
        private readonly IEventRepository _eventRepository;

        public EventProvider(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<Event> GeEvents()
        {
            return _eventRepository.GeEvents().ToList();
        }

        public Event GetEvent(int Id)
        {
            return _eventRepository.GetEvent(Id);
        }

        public void UpdateEvent(Event updatedEvent)
        {
            _eventRepository.UpdateEvent(updatedEvent);
        }

        public void AddEvent(Event events)
        {
            _eventRepository.AddEvent(events);
        }

        public void DeleteEvent(int id)
        {
            _eventRepository.DeleteEvent(id);
        }

        public List<EventDetail> GetEventDetails()
        {
            return _eventRepository.GetEventDetails().ToList();
        }

        public EventDetail GetEventDetail(int eventId)
        {
            return _eventRepository.GetEventDetail(eventId);
        }

        public void UpdateEventDetail(EventDetail updatedEventDetail)
        {
            _eventRepository.UpdateEventDetail(updatedEventDetail);
        }

        public void AddEventDetail(EventDetail eventDetail)
        {
            _eventRepository.AddEventDetail(eventDetail);
        }

        public void DeleteEventDetail(int eventId)
        {
            _eventRepository.DeleteEventDetail(eventId);
        }

        public List<EventRecurrence> GetEventRecurrences()
        {
            return _eventRepository.GetEventRecurrences().ToList();
        }

        public EventRecurrence GetEventRecurrence(int Id)
        {
            return _eventRepository.GetEventRecurrence(Id);
        }

        public void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence)
        {
            _eventRepository.UpdateEventRecurrence(updatedEventRecurrence);
        }

        public void AddEventRecurrence(EventRecurrence eventRecurrence)
        {
            _eventRepository.AddEventRecurrence(eventRecurrence);
        }

        public void DeleteEventRecurrence(int id)
        {
            _eventRepository.DeleteEventRecurrence(id);
        }

        public List<EventType> GetEventTypes()
        {
            return _eventRepository.GetEventTypes().ToList();
        }

        public EventType GetEventType(int Id)
        {
            return _eventRepository.GetEventType(Id);
        }

        public void UpdateEventType(EventType updatedEventType)
        {
            _eventRepository.UpdateEventType(updatedEventType);
        }

        public void AddPEventType(EventType eventType)
        {
            _eventRepository.AddPEventType(eventType);
        }

        public void DeleteEventType(int id)
        {
            _eventRepository.DeleteEventType(id);
        }
    }
}