using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
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
    }
}