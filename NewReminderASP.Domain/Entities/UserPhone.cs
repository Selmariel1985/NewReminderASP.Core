using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    ///     Represents a user's phone details.
    /// </summary>
    public class UserPhone
    {
        public int ID { get; set; } // Phone ID

        public int UserID { get; set; } // ID of the associated user

        [Required(ErrorMessage = "Please enter the Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty; // Phone number

        public int PhoneTypeID { get; set; } // ID of the phone type

        public int CountryID { get; set; } // ID of the country

        public virtual User User { get; set; } // Associated user

        public string Login { get; set; } // User's login (username)

        public string PhoneTypes { get; set; } // Phone type name

        public string CountryName { get; set; } // Country name

        public List<User> Users { get; set; } // List of users

        public List<PhoneType> PhonesTypes { get; set; } // List of phone types

        public List<Country> Countries { get; set; } // List of countries
    }
}