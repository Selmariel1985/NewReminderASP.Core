using NewReminderASP.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Login { get; set; }
    }
}
