using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    /// Client class for interacting with the event service.
    /// </summary>
    public class EventClient : IEventClient
    {
        private readonly string currentUserLogin = HttpContext.Current.User.Identity.Name;

        /// <summary>
        /// Retrieves a list of events based on the user's role and login.
        /// </summary>
        /// <returns>A list of Event objects</returns>
        public List<Event> GetEvents()
        {
            var events = new List<Event>(); // Create a list to store Event objects
            var currentUserLogin = HttpContext.Current.User.Identity.Name; // Get current user's login
            var isAdmin = HttpContext.Current.User.IsInRole("admin"); // Check if the current user is an admin

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service
                    var allEvents = connection.GetEvents(); // Retrieve all events from the service

                    if (isAdmin)
                    {
                        // If the user is an admin, retrieve all events
                        events = allEvents.Select(eventss => new Event
                        {
                            ID = eventss.ID,
                            Login = eventss.Login,
                            EventTypes = eventss.EventType,
                            Title = eventss.Title,
                            Date = eventss.Date,
                            Time = eventss.Time,
                            Recurrence = eventss.Recurrence,
                            Reminders = eventss.Reminders
                        }).ToList();
                    }
                    else
                    {
                        // If the user is not an admin, retrieve events for the current user
                        events = allEvents.Where(eventss => eventss.Login == currentUserLogin)
                            .Select(eventss => new Event
                            {
                                ID = eventss.ID,
                                Login = eventss.Login,
                                EventTypes = eventss.EventType,
                                Title = eventss.Title,
                                Date = eventss.Date,
                                Time = eventss.Time,
                                Recurrence = eventss.Recurrence,
                                Reminders = eventss.Reminders
                            }).ToList();
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return events; // Return the list of Event objects
        }

        /// <summary>
        /// Retrieves a list of events for the specified user based on the username.
        /// </summary>
        /// <param name="userName">The username of the user to retrieve events for</param>
        /// <returns>A list of Event objects for the specified user</returns>
        public List<Event> GetEventsForUser(string userName)
        {
            var events = new List<Event>(); // Create a list to store Event objects
            var currentLogin = HttpContext.Current.User.Identity.Name; // Get the current user's login
            var isAdmin = HttpContext.Current.User.IsInRole("admin"); // Check if the current user is an admin

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service
                    var allEvents = connection.GetEventsForUser(userName); // Retrieve events for the specified user by username

                    if (isAdmin)
                    {
                        // If the user is an admin, retrieve all events for the specified user
                        events = allEvents.Select(e => new Event
                        {
                            ID = e.ID,
                            EventTypes = e.EventType,
                            Title = e.Title,
                            Date = e.Date,
                            Time = e.Time,
                            Recurrence = e.Recurrence,
                            Reminders = e.Reminders,
                            UserID = e.UserID,
                            Login = e.Login
                        }).ToList();
                    }
                    else
                    {
                        // If the user is not an admin, retrieve events for the specified user based on the current user's login
                        events = allEvents.Where(e => e.Login == currentLogin)
                            .Select(e => new Event
                            {
                                ID = e.ID,
                                EventTypes = e.EventType,
                                Title = e.Title,
                                Date = e.Date,
                                Time = e.Time,
                                Recurrence = e.Recurrence,
                                Reminders = e.Reminders,
                                UserID = e.UserID,
                                Login = e.Login
                            }).ToList();
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e);
                    throw; // Propagate the exception up the call stack
                }
            }

            return events; // Return the list of Event objects for the specified 
        }

        /// <summary>
        /// Retrieves a list of events based on the ID and the user's role and login.
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <returns>A list of Event objects</returns>
        public List<Event> GetEventsForID(int id)
        {
            var events = new List<Event>(); // Create a list to store Event objects
            var currentUserLogin = HttpContext.Current.User.Identity.Name; // Get the current user's login
            var isAdmin = HttpContext.Current.User.IsInRole("admin"); // Check if the current user is an admin

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service
                    var allEvents = connection.GetEventsForID(id); // Retrieve events for the specified ID

                    if (isAdmin)
                    {
                        // If the user is an admin, retrieve all events for the specified ID
                        events = allEvents.Select(eventss => new Event
                        {
                            ID = eventss.ID,
                            EventTypes = eventss.EventType,
                            Title = eventss.Title,
                            Date = eventss.Date,
                            Time = eventss.Time,
                            Recurrence = eventss.Recurrence,
                            Reminders = eventss.Reminders,
                            UserID = eventss.UserID
                        }).ToList();
                    }
                    else
                    {
                        // If the user is not an admin, retrieve events based on the current user's login or for the specified ID
                        events = allEvents.Where(eventss => eventss.Login == currentUserLogin || eventss.UserID == id)
                            .Select(eventss => new Event
                            {
                                ID = eventss.ID,
                                EventTypes = eventss.EventType,
                                Title = eventss.Title,
                                Date = eventss.Date,
                                Time = eventss.Time,
                                Recurrence = eventss.Recurrence,
                                Reminders = eventss.Reminders,
                                UserID = eventss.UserID,
                                Login = eventss.Login
                            }).ToList();
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return events; // Return the list of Event objects
        }

        /// <summary>
        /// Retrieves a single event based on the ID.
        /// </summary>
        /// <param name="Id">The ID of the event to retrieve</param>
        /// <returns>An Event object if found, otherwise null</returns>
        public Event GetEvent(int Id)
        {
            Event events = null; // Initialize an Event object to null

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetEvent(Id); // Retrieve the event with the specified ID

                    if (result != null) // Check if a result is returned
                    {
                        events = new Event // If a result is returned, create a new Event object
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

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return events; // Return the Event object, or null if the event is not found
        }


        /// <summary>
        /// Updates an existing event with the provided updated event data.
        /// </summary>
        /// <param name="updatedEvent">The updated event object</param>
        public void UpdateEvent(Event updatedEvent)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.UpdateEvent(new EventDto // Call the UpdateEvent method of the service with the updated event data
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

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Adds a new event using the provided event data.
        /// </summary>
        /// <param name="events">The event to be added</param>
        public void AddEvent(Event events)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.AddEvent(new EventDto // Call the AddEvent method of the service with the new event data
                    {
                        Login = currentUserLogin, // Assuming currentUserLogin is defined elsewhere
                        EventType = events.EventTypes,
                        Title = events.Title,
                        Date = events.Date,
                        Time = events.Time,
                        Recurrence = events.Recurrence,
                        Reminders = events.Reminders
                    });

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Adds a new event by an admin user using the provided event data.
        /// </summary>
        /// <param name="events">The event to be added by an admin user</param>
        public void AddAdminEvent(Event events)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.AddEvent(new EventDto // Call the AddEvent method of the service with the new event data
                    {
                        Login = events.Login,
                        EventType = events.EventTypes,
                        Title = events.Title,
                        Date = events.Date,
                        Time = events.Time,
                        Recurrence = events.Recurrence,
                        Reminders = events.Reminders
                    });

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Deletes an event based on the provided event ID.
        /// </summary>
        /// <param name="id">The ID of the event to be deleted</param>
        public void DeleteEvent(int id)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.DeleteEvent(id); // Call the DeleteEvent method of the service with the specified event ID

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Retrieves a list of event details containing EventID, Description, and Status.
        /// </summary>
        /// <returns>A list of EventDetail objects</returns>
        public List<EventDetail> GetEventDetails()
        {
            var eventDetails = new List<EventDetail>(); // Initialize a list to hold EventDetail objects

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetEventDetails(); // Retrieve event details from the service

                    if (result != null)
                    {
                        foreach (var eventDetail in result) // Iterate through the retrieved event details
                        {
                            eventDetails.Add(new EventDetail // Create new EventDetail objects and add them to the list
                            {
                                EventID = eventDetail.EventID,
                                Description = eventDetail.Description,
                                Status = eventDetail.Status
                            });
                        }
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return eventDetails; // Return the list of EventDetail objects
        }


        /// <summary>
        /// Retrieves details of a specific event based on the event ID.
        /// </summary>
        /// <param name="eventId">The ID of the event to retrieve details for</param>
        /// <returns>An EventDetail object if found, otherwise null</returns>
        public EventDetail GetEventDetail(int eventId)
        {
            EventDetail eventDetail = null; // Initialize an EventDetail object to null

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetEventDetail(eventId); // Retrieve the event detail with the specified ID

                    if (result != null) // Check if a result is returned
                    {
                        eventDetail = new EventDetail // If a result is returned, create a new EventDetail object
                        {
                            EventID = result.EventID,
                            Description = result.Description,
                            Status = result.Status
                        };
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return eventDetail; // Return the EventDetail object, or null if the event detail is not found
        }


        /// <summary>
        /// Updates the details of an event with the provided updated event detail.
        /// </summary>
        /// <param name="updatedEventDetail">The updated details of the event</param>
        public void UpdateEventDetail(EventDetail updatedEventDetail)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.UpdateEventDetail(new EventDetailDto
                    {
                        EventID = updatedEventDetail.EventID,
                        Description = updatedEventDetail.Description,
                        Status = updatedEventDetail.Status
                    }); // Update the event detail using the provided updated details

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Adds a new event detail using the provided event detail object.
        /// </summary>
        /// <param name="eventDetail">The event detail to be added</param>
        public void AddEventDetail(EventDetail eventDetail)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.AddEventDetail(new EventDetailDto
                    {
                        EventID = eventDetail.EventID,
                        Description = eventDetail.Description,
                        Status = eventDetail.Status
                    }); // Add the event detail using the provided event detail object

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }

        /// <summary>
        /// Deletes an event detail based on the provided event ID.
        /// </summary>
        /// <param name="eventId">The ID of the event detail to be deleted</param>
        public void DeleteEventDetail(int eventId)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.DeleteEventDetail(eventId); // Delete the event detail using the provided event ID

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Retrieves a list of event recurrences containing ID and RecurrenceType.
        /// </summary>
        /// <returns>A list of EventRecurrence objects</returns>
        public List<EventRecurrence> GetEventRecurrences()
        {
            var eventRecurrences = new List<EventRecurrence>(); // Initialize a list to hold EventRecurrence objects

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetEventRecurrences(); // Retrieve event recurrences from the service

                    if (result != null)
                    {
                        foreach (var eventRecurrence in result) // Iterate through the retrieved event recurrences
                        {
                            eventRecurrences.Add(new EventRecurrence // Create new EventRecurrence objects and add them to the list
                            {
                                ID = eventRecurrence.ID,
                                RecurrenceType = eventRecurrence.RecurrenceType
                            });
                        }
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return eventRecurrences; // Return the list of EventRecurrence objects
        }


        /// <summary>
        /// Retrieves a specific event recurrence based on the provided ID.
        /// </summary>
        /// <param name="Id">The ID of the event recurrence to retrieve</param>
        /// <returns>The EventRecurrence object if found, otherwise null</returns>
        public EventRecurrence GetEventRecurrence(int Id)
        {
            EventRecurrence eventRecurrence = null; // Initialize an EventRecurrence object to null

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetEventRecurrence(Id); // Retrieve the event recurrence with the specified ID

                    if (result != null) // Check if a result is returned
                    {
                        eventRecurrence = new EventRecurrence // If a result is returned, create a new EventRecurrence object
                        {
                            ID = result.ID,
                            RecurrenceType = result.RecurrenceType
                        };
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return eventRecurrence; // Return the EventRecurrence object, or null if the event recurrence is not found
        }


        /// <summary>
        /// Updates the details of an event recurrence with the provided updated event recurrence.
        /// </summary>
        /// <param name="updatedEventRecurrence">The updated event recurrence details</param>
        public void UpdateEventRecurrence(EventRecurrence updatedEventRecurrence)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.UpdateEventRecurrence(new EventRecurrenceDto
                    {
                        ID = updatedEventRecurrence.ID,
                        RecurrenceType = updatedEventRecurrence.RecurrenceType
                    }); // Update the event recurrence using the provided updated details

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Adds a new event using the provided event recurrence object.
        /// </summary>
        /// <param name="eventRecurrence">The event recurrence to be added</param>
        public void AddEventRecurrence(EventRecurrence eventRecurrence)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.AddEventRecurrence(new EventRecurrenceDto
                    {
                        ID = eventRecurrence.ID,
                        RecurrenceType = eventRecurrence.RecurrenceType
                    }); // Add the event recurrence using the provided details

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Deletes an event recurrence based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the event recurrence to be deleted</param>
        public void DeleteEventRecurrence(int id)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.DeleteEventRecurrence(id); // Delete the event recurrence with the provided ID

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }

        /// <summary>
        /// Retrieves a list of event types containing ID and TypeName.
        /// </summary>
        /// <returns>A list of EventType objects</returns>
        public List<EventType> GetEventTypes()
        {
            var eventTypes = new List<EventType>(); // Initialize a list to hold EventType objects

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetEventTypes(); // Retrieve event types from the service

                    if (result != null)
                    {
                        foreach (var eventType in result) // Iterate through the retrieved event types
                        {
                            eventTypes.Add(new EventType // Create new EventType objects and add them to the list
                            {
                                ID = eventType.ID,
                                TypeName = eventType.TypeName
                            });
                        }
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return eventTypes; // Return the list of EventType objects
        }


        /// <summary>
        /// Retrieves a specific event type based on the provided ID.
        /// </summary>
        /// <param name="Id">The ID of the event type to retrieve</param>
        /// <returns>The EventType object if found, otherwise null</returns>
        public EventType GetEventType(int Id)
        {
            EventType eventType = null; // Initialize an EventType object to null

            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetEventType(Id); // Retrieve the event type with the specified ID

                    if (result != null) // Check if a result is returned
                    {
                        eventType = new EventType // If a result is returned, create a new EventType object
                        {
                            ID = result.ID,
                            TypeName = result.TypeName
                        };
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return eventType; // Return the EventType object, or null if the event type is not found
        }


        /// <summary>
        /// Updates the details of an event type with the provided updated event type information.
        /// </summary>
        /// <param name="updatedEventType">The updated event type details</param>
        public void UpdateEventType(EventType updatedEventType)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.UpdateEventType(new EventTypeDto
                    {
                        ID = updatedEventType.ID,
                        TypeName = updatedEventType.TypeName
                    }); // Update the event type using the provided updated details

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }


        /// <summary>
        /// Adds a new event type using the provided event type information.
        /// </summary>
        /// <param name="eventType">The event type to be added</param>
        public void AddEventType(EventType eventType)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.AddEventType(new EventTypeDto
                    {
                        ID = eventType.ID,
                        TypeName = eventType.TypeName
                    }); // Add the event type using the provided information

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }



        /// <summary>
        /// Deletes an event type based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the event type to be deleted</param>
        public void DeleteEventType(int id)
        {
            using (var connection = new EventServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.DeleteEventType(id); // Delete the event type with the provided ID

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Log the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }
        }

    }
}