using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class CountryDto

    {
        [DataMember] public int ID { get; set; }

        [DataMember] public string CountryCode { get; set; }

        [DataMember] public string PhoneCode { get; set; }

        [DataMember] public string Name { get; set; }
    }
}