using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class EventDetailDto
    {
        [DataMember] public int EventID { get; set; }

        [DataMember] public string Description { get; set; }

        [DataMember] public string Status { get; set; }
    }
}