using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents an event entity.
    /// </summary>
    public class Event
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int EventTypeID { get; set; }

        [Required(ErrorMessage = "Please select a Title")]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public int RecurrenceID { get; set; }

        [Required(ErrorMessage = "Please select a Reminder")]
        public string Reminders { get; set; }

        public User User { get; set; }
        public string Recurrence { get; set; }
        public string EventTypes { get; set; }
        public string Login { get; set; }
        public List<User> Users { get; set; }
        public List<EventType> EventsTypes { get; set; }
        public List<EventRecurrence> EventRecurrences { get; set; }

        public string StartDate { get; set; }

        /// <summary>
        /// Default constructor for Event class that sets the Date and Time to current date and time.
        /// </summary>
        public Event()
        {
            Date = DateTime.Now;
            Time = DateTime.Now.TimeOfDay;
        }

        /// <summary>
        /// Constructor for creating the start date format from date and time values.
        /// </summary>
        /// <param name="e">The Event object to extract date and time values from</param>
        public Event(Event e)
        {
            StartDate = string.Format("{0}T{1}", e.Date.ToString("yyyy-MM-dd"), e.Time.ToString("hh\\:mm\\:ss"));
        }
    }
}