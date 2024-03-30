using System.Collections.Generic;

namespace NewReminderASP.Domain.Entities
{
    public class UserAndRolesModel
    {
        public User User { get; set; }
        public UserRole UserRole { get; set; }
        public List<Role> Roles { get; set; }
    }
}
