using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class Country
    {
        public int CountryID { get; set; }

        public string CountryCode { get; set; }

        public string PhoneCode { get; set; }
     
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}