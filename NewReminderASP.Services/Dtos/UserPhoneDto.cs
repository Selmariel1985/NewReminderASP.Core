using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class UserPhoneDto
    {
        [DataMember] public int ID { get; set; }

        [DataMember] public int UserID { get; set; }

        [DataMember] public string PhoneNumber { get; set; }

        [DataMember] public int PhoneTypeID { get; set; }

        [DataMember] public int CountryID { get; set; }
        [DataMember] public string Login { get; set; }
       
        [DataMember] public string PhoneType { get; set; }
        [DataMember] public string CountryName { get; set; }
    }
}