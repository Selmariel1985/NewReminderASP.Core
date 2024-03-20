using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Domain.Entities
{
    public class UserAndRolesModel
    {
        public User User { get; set; } // User entity
        public UserRole UserRole { get; set; } // UserRoles entity 
        public List<Role> Roles { get; set; } // Roles entity 
    }
}
