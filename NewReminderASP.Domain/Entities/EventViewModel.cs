using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    ///     View model representing an event data for display purposes.
    /// </summary>
    public class EventViewModel
    {
        /// <summary>
        ///     Constructor for creating EventViewModel based on an Event object.
        /// </summary>
        /// <param name="e">The Event object to extract data from</param>
        public EventViewModel(Event e)
        {
            ID = e.ID;
            Title = e.Title;
            StartDate = string.Format("{0}T{1}", e.Date.ToString("yyyy-MM-dd"), e.Time.ToString("hh\\:mm\\:ss"));
            UserID = e.UserID;
            Login = e.Login;
            EventTypes = e.EventTypes;
        }

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
        public string EndDate { get; set; }
    }
}