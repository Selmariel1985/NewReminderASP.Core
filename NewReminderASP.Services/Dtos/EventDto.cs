using NewReminderASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class EventDto
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]

        public int UserID { get; set; }
        [DataMember]

        public int EventTypeID { get; set; }
        [DataMember]

        public string Title { get; set; }
        [DataMember]

        public DateTime Date { get; set; }
        [DataMember]

        public TimeSpan Time { get; set; }
        [DataMember]

        public int RecurrenceID { get; set; }
        [DataMember]

        public string Reminders { get; set; }
        

        
    }
}
