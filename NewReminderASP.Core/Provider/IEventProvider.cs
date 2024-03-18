﻿using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

namespace NewReminderASP.Core.Provider
{
    public interface IEventProvider
    {
        List<Event> GeEvents();

        Event GetEvent(int Id);

        void UpdateEvent(Event updatedEvent);
        void AddEvent(Event events);
        void DeleteEvent(int id);

        List<EventDetail> GetEventDetails();

        EventDetail GetEventDetail(int eventId);

        void UpdateEventDetail(EventDetail updatedEventDetail);
        void AddEventDetail(EventDetail eventDetail);
        void DeleteEventDetail(int eventId);

        List<EventRecurrence> GetEventRecurrences();

        EventRecurrence GetEventRecurrence(int Id);

        void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence);
        void AddEventRecurrence(EventRecurrence eventRecurrence);
        void DeleteEventRecurrence(int id);

        List<EventType> GetEventTypes();

        EventType GetEventType(int Id);

        void UpdateEventType(EventType updatedEventType);
        void AddPEventType(EventType eventType);
        void DeleteEventType(int id);
    }
}