using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class UserRole
    {

        public string RoleName { get; set; }

        public string UserLogin { get; set; }
        [Required(ErrorMessage = "Please enter the User")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter the Role")]
        public int RoleId { get; set; }
        public string RoleIds { get; set; }
        public List<int> SelectedRoleIds { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
        
}
}