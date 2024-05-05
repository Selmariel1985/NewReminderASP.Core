using System.Collections.Generic;

namespace NewReminderASP.Domain.Entities
{
    public class UserDetailsViewModel
    {
        public User User { get; set; }
        public Address Address { get; set; }
        public UserPhone Phone { get; set; }
        public PersonalInfo PersonalInformation { get; set; }
        public List<Address> Addresses { get; set; }

        public List<UserPhone> Phones { get; set; }
    }
}