using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for event type details.
    /// </summary>
    [DataContract]
    public class EventTypeDto
    {
        [DataMember]
        public int ID { get; set; } // ID of the event type

        [DataMember]
        public string TypeName { get; set; } // Name of the event type
    }
}