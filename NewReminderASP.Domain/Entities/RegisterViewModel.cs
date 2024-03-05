using System.Collections.Generic;

namespace NewReminderASP.Domain.Entities
{
    public class RegisterViewModel
    {

        public User User { get; set; }
        public Address Address { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public UserPhone UserPhone { get; set; }
        public Country Country { get; set; }

        
        public List<PhoneType> PhoneTypes { get; set; }

        public List<Country> Countries { get; set; }
    }
}