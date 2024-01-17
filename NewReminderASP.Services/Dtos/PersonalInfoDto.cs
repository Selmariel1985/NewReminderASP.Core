using NewReminderASP.Domain.Entities;
using System;
using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class PersonalInfoDto
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public DateTime Birthdate { get; set; }
        [DataMember]
        public string Gender { get; set; }
       
    }
}
