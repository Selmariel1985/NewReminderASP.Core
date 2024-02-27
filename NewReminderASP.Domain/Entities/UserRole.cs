using System.Collections.Generic;

namespace NewReminderASP.Domain.Entities
{
    public class UserRole
    {
        public string RoleName { get; set; }
        public string UserLogin { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }


        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
    }
}