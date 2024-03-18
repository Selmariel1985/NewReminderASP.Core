using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class UserPhone
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        [Required(ErrorMessage = "Please enter the Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public int PhoneTypeID { get; set; }

        public int CountryID { get; set; }

        public virtual User User { get; set; }


        public string Login { get; set; }

        public string PhoneTypes { get; set; }

        public string CountryName { get; set; }
        public List<User> Users { get; set; }
        public List<PhoneType> PhonesTypes { get; set; }
        public List<Country> Countries { get; set; }
    }
}