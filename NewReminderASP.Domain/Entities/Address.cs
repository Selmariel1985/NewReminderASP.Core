using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents an address entity.
    /// </summary>
    public class Address
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter the city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please select a country")]
        public int CountryID { get; set; }

        public string PostalCode { get; set; }
        public string Description { get; set; }

        public string CountryName { get; set; }

        public int UserID { get; set; }
        public string Login { get; set; }

        public virtual Country Country { get; set; }
        public List<User> Users { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Country> Countries { get; set; }
        public virtual User User { get; set; }
    }
}