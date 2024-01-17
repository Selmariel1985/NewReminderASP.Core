using System.Collections.Generic;

namespace NewReminderASP.Domain.Entities
{
    public class Country
    {
        public int ID { get; set; }

        public string CountryCode { get; set; }

        public string PhoneCode { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}