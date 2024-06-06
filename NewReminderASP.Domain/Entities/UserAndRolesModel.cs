using System.Collections.Generic;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Model representing a user along with their assigned roles.
    /// </summary>
    public class UserAndRolesModel
    {
        public User User { get; set; } // User object
        public UserRole UserRole { get; set; } // User's role
        public List<Role> Roles { get; set; } // List of roles
    }
}