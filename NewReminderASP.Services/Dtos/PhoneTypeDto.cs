using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for phone type details.
    /// </summary>
    [DataContract]
    public class PhoneTypeDto
    {
        [DataMember]
        public int ID { get; set; } // ID of the phone type

        [DataMember]
        public string TypeName { get; set; } // Name of the phone type
    }
}