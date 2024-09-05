using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for personal information.
    /// </summary>
    [DataContract]
    public class PersonalInfoDto
    {
        [DataMember]
        public int UserID { get; set; } // User ID

        [DataMember]
        public string FirstName { get; set; } // First name

        [DataMember]
        public string LastName { get; set; } // Last name

        [DataMember]
        public string MiddleName { get; set; } // Middle name

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; } // Date of birth

        [DataMember]
        public string Gender { get; set; } // Gender

        [DataMember]
        public string Login { get; set; } // User login
    }
}