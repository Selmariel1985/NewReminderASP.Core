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
    public class EventDetailDto
    {
        [DataMember]
        public int EventID { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]

        public string Status { get; set; }
       
    }
}
