using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
    public class EventClient : IEventClient
    {
        public List<Event> GeEvents()
        {
            var events = new List<Event>();

            using (var connection = new EventServiceClient())
            {

                try
                {
                    connection.Open();

                    var result = connection.GeEvents();

                    if (result != null)
                    {
                        foreach (var eventss in result)
                        {
                            events.Add(new Event
                            {
                                ID = eventss.ID,
                                Login = eventss.Login,
                                EventTypes = eventss.EventType,
                                Title = eventss.Title,
                                Date = eventss.Date,
                                Time = eventss.Time,
                                Recurrence = eventss.Recurrence,
                                Reminders = eventss.Reminders
                            });
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return events;
        }

        public Event GetEvent(int Id)
        {
            Event events = null;

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetEvent(Id);

                    if (result != null)
                    {
                        events = new Event
                        {
                            ID = result.ID,
                            Login = result.Login,
                            EventTypes = result.EventType,
                            Title = result.Title,
                            Date = result.Date,
                            Time = result.Time,
                            Recurrence = result.Recurrence,
                            Reminders = result.Reminders
                        };
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return events;
        }

        public void UpdateEvent(Event updatedEvent)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdateEvent(new EventDto
                    {
                        ID = updatedEvent.ID,
                        Login = updatedEvent.Login,
                        EventType = updatedEvent.EventTypes,
                        Title = updatedEvent.Title,
                        Date = updatedEvent.Date,
                        Time = updatedEvent.Time,
                        Recurrence = updatedEvent.Recurrence,
                        Reminders = updatedEvent.Reminders
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void AddEvent(Event events)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddEvent(new EventDto
                    {
                        
                        Login = events.Login,
                        EventType = events.EventTypes,
                        Title = events.Title,
                        Date = events.Date,
                        Time = events.Time,
                        Recurrence = events.Recurrence,
                        Reminders = events.Reminders
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void DeleteEvent(int id)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeleteEvent(id);

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public List<EventDetail> GetEventDetails()
        {
            var eventDetails = new List<EventDetail>();

            using (var connection = new EventServiceClient())
            {

                try
                {
                    connection.Open();

                    var result = connection.GetEventDetails();

                    if (result != null)
                    {
                        foreach (var eventDetail in result)
                        {
                            eventDetails.Add(new EventDetail
                            {
                                EventID = eventDetail.EventID,
                                Description = eventDetail.Description,
                                Status = eventDetail.Status
                            });
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return eventDetails;
        }

        public EventDetail GetEventDetail(int eventId)
        {
            EventDetail eventDetail = null;

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetEventDetail(eventId);

                    if (result != null)
                    {
                        eventDetail = new EventDetail
                        {
                            EventID = result.EventID,
                            Description = result.Description,
                            Status = result.Status
                        };
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return eventDetail;
        }

        public void UpdateEventDetail(EventDetail updatedEventDetail)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdateEventDetail(new EventDetailDto
                    {
                        EventID = updatedEventDetail.EventID,
                        Description = updatedEventDetail.Description,
                        Status = updatedEventDetail.Status
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

        }

        public void AddEventDetail(EventDetail eventDetail)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddEventDetail(new EventDetailDto
                    {
                        EventID = eventDetail.EventID,
                        Description = eventDetail.Description,
                        Status = eventDetail.Status
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void DeleteEventDetail(int eventId)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeleteEventDetail(eventId);

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public List<EventRecurrence> GetEventRecurrences()
        {
            var eventRecurrences = new List<EventRecurrence>();

            using (var connection = new EventServiceClient())
            {

                try
                {
                    connection.Open();

                    var result = connection.GetEventRecurrences();

                    if (result != null)
                    {
                        foreach (var eventRecurrence in result)
                        {
                            eventRecurrences.Add(new EventRecurrence
                            {
                                ID = eventRecurrence.ID,
                                RecurrenceType = eventRecurrence.RecurrenceType
                            });
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return eventRecurrences;
        }

        public EventRecurrence GetEventRecurrence(int Id)
        {
            EventRecurrence eventRecurrence = null;

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetEventRecurrence(Id);

                    if (result != null)
                    {
                        eventRecurrence = new EventRecurrence
                        {
                            ID = result.ID,
                            RecurrenceType = result.RecurrenceType
                        };
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return eventRecurrence;
        }

        public void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdateEventRecurrence(new EventRecurrenceDto
                    {
                        ID = updatedEventRecurrence.ID,
                        RecurrenceType = updatedEventRecurrence.RecurrenceType
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void AddEventRecurrence(EventRecurrence eventRecurrence)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddEventRecurrence(new EventRecurrenceDto
                    {
                        ID = eventRecurrence.ID,
                        RecurrenceType = eventRecurrence.RecurrenceType
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void DeleteEventRecurrence(int id)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeleteEventRecurrence(id);

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public List<EventType> GetEventTypes()
        {
            var eventTypes = new List<EventType>();

            using (var connection = new EventServiceClient())
            {

                try
                {
                    connection.Open();

                    var result = connection.GetEventTypes();

                    if (result != null)
                    {
                        foreach (var eventType in result)
                        {
                            eventTypes.Add(new EventType
                            {
                                ID = eventType.ID,
                                TypeName = eventType.TypeName
                            });
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return eventTypes;
        }

        public EventType GetEventType(int Id)
        {
            EventType eventType = null;

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetEventType(Id);

                    if (result != null)
                    {
                        eventType = new EventType
                        {
                            ID = result.ID,
                            TypeName = result.TypeName
                        };
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return eventType;
        }

        public void UpdateEventType(EventType updatedEventType)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdateEventType(new EventTypeDto
                    {
                        ID = updatedEventType.ID,
                        TypeName = updatedEventType.TypeName
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void AddPEventType(EventType eventType)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddPEventType(new EventTypeDto
                    {

                        ID = eventType.ID,
                        TypeName = eventType.TypeName
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }





        public void DeleteEventType(int id)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeleteEventType(id);

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
