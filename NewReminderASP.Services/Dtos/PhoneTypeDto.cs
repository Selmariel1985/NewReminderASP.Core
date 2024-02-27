using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class PhoneTypeDto
    {
        [DataMember] public int ID { get; set; }

        [DataMember] public string TypeName { get; set; }
    }
}