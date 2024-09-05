using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for event recurrence details.
    /// </summary>
    [DataContract]
    public class EventRecurrenceDto
    {
        [DataMember]
        public int ID { get; set; } // Recurrence ID

        [DataMember]
        public string RecurrenceType { get; set; } // Type of event recurrence
    }
}