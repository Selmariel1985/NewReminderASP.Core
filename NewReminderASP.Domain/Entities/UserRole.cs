using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents a user's role in the system.
    /// </summary>
    public class UserRole
    {
        public string RoleName { get; set; } // Name of the role

        public string UserLogin { get; set; } // User's login (username)

        [Required(ErrorMessage = "Please enter the User")]
        public int UserId { get; set; } // ID of the associated user

        [Required(ErrorMessage = "Please enter the Role")]
        public int RoleId { get; set; } // ID of the role

        public List<int> SelectedRoleIds { get; set; } // List of selected role IDs

        public virtual User User { get; set; } // Associated user object
        public virtual Role Role { get; set; } // Associated role object

        public List<User> Users { get; set; } // List of users
        public List<Role> Roles { get; set; } // List of roles
    }
}