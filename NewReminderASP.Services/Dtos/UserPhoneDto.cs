using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class UserPhoneDto
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; } = string.Empty;

        [DataMember]
        public int PhoneTypeID { get; set; }

        [DataMember]
        public int CountryID { get; set; }
    }
}
