using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Domain.Entities
{
    public class UserDetailsViewModel
    {
        public User User { get; set; }
        public Address Address { get; set; }
        public UserPhone Phone { get; set; }
        public PersonalInfo PersonalInformation { get; set; }
    }
}
