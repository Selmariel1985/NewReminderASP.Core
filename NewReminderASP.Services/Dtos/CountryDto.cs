using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for country details.
    /// </summary>
    [DataContract]
    public class CountryDto
    {
        [DataMember]
        public int CountryID { get; set; } // Unique identifier for the country

        [DataMember]
        public string CountryCode { get; set; } // Country code (ISO code)

        [DataMember]
        public string PhoneCode { get; set; } // Phone calling code for the country

        [DataMember]
        public string Name { get; set; } // Name of the country
    }
}