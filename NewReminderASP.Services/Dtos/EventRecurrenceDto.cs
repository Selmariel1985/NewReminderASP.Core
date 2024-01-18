using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class EventRecurrenceDto
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string RecurrenceType { get; set; }
    }
}
