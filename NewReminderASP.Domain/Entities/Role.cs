using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents a user role within the system.
    /// </summary>
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Role")]
        public string Name { get; set; } // Role name (e.g., Admin, User, Manager, etc.)
    }
}