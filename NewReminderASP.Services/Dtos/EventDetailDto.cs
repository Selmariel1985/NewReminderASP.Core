using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for event detail information.
    /// </summary>
    [DataContract]
    public class EventDetailDto
    {
        [DataMember]
        public int EventID { get; set; } // ID of the associated event

        [DataMember]
        public string Description { get; set; } // Description of the event detail

        [DataMember]
        public string Status { get; set; } // Status of the event detail
    }
}