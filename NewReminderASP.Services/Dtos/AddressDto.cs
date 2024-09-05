using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for address details.
    /// </summary>
    [DataContract]
    public class AddressDto
    {
        [DataMember] public int ID { get; set; } // Address ID

        [DataMember] public string Street { get; set; } // Street information

        [DataMember] public string City { get; set; } // City information

        [DataMember] public int CountryID { get; set; } // ID of the country

        [DataMember] public string PostalCode { get; set; } // Postal code

        [DataMember] public string Description { get; set; } // Description of the address

        [DataMember] public string CountryName { get; set; } // Country name

        [DataMember] public int UserID { get; set; } // ID of the associated user
        [DataMember] public string Login { get; set; } // User's login (username)
    }
}