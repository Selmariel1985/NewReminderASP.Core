using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for user phone details.
    /// </summary>
    [DataContract]
    public class UserPhoneDto
    {
        [DataMember]
        public int ID { get; set; } // Phone ID

        [DataMember]
        public int UserID { get; set; } // User ID associated with the phone number

        [DataMember]
        public string PhoneNumber { get; set; } // Phone number

        [DataMember]
        public int PhoneTypeID { get; set; } // ID of the phone type

        [DataMember]
        public int CountryID { get; set; } // ID of the country

        [DataMember]
        public string Login { get; set; } // User login

        [DataMember]
        public string PhoneType { get; set; } // Type of the phone

        [DataMember]
        public string CountryName { get; set; } // Name of the country
    }
}