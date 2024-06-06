using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for event details.
    /// </summary>
    [DataContract]
    public class EventDto
    {
        [DataMember] public int ID { get; set; } // Event ID

        [DataMember] public int UserID { get; set; } // ID of the associated user

        [DataMember] public int EventTypeID { get; set; } // ID of the event type

        [DataMember] public string Title { get; set; } // Title of the event

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } // Date of the event

        [DataMember] public TimeSpan Time { get; set; } // Time of the event

        [DataMember] public int RecurrenceID { get; set; } // ID of the event recurrence

        [DataMember] public string Reminders { get; set; } // Reminders for the event

        [DataMember] public string Login { get; set; } // User's login (username)

        [DataMember] public string EventType { get; set; } // Type of the event

        [DataMember] public string Recurrence { get; set; } // Recurrence information
    }
}