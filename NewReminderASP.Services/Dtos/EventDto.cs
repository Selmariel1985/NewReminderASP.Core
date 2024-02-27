using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class EventDto
    {
        [DataMember] public int ID { get; set; }

        [DataMember] public int UserID { get; set; }

        [DataMember] public int EventTypeID { get; set; }

        [DataMember] public string Title { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }

        [DataMember] public TimeSpan Time { get; set; }

        [DataMember] public int RecurrenceID { get; set; }

        [DataMember] public string Reminders { get; set; }

        [DataMember] public string Login { get; set; }

        [DataMember] public string EventType { get; set; }

        [DataMember] public string Recurrence { get; set; }
    }
}