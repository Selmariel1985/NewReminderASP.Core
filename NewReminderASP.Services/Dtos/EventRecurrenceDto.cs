using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class EventRecurrenceDto
    {
        [DataMember] public int ID { get; set; }

        [DataMember] public string RecurrenceType { get; set; }
    }
}