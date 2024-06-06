using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [Display(Name = "Username")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        [Display(Name = "Confirm email")]
        [NotMapped]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Please enter an Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "The Email must be at least 8 characters long.")]
        public string Email { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public List<int> SelectedRoleIds { get; set; } // List of selected role IDs for the user

        public bool IsActive { get; set; } // Indicates whether the user account is active

        [NotMapped]
        public int Version { get; set; } // Version number of the user entity (not mapped to a database column)
    }
}
