using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class AddressDto
    {
        [DataMember] public int ID { get; set; }

        [DataMember] public string Street { get; set; }

        [DataMember] public string City { get; set; }

        [DataMember] public int CountryID { get; set; }

        [DataMember] public string PostalCode { get; set; }

        [DataMember] public string Description { get; set; }

        [DataMember] public string CountryName { get; set; }

        [DataMember] public int UserID { get; set; }
        [DataMember] public string Login { get; set; }




    }
}