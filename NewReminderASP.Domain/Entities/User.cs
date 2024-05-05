using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewReminderASP.Domain.Entities
{
    public class User

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage =
                "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }

        [NotMapped] public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter an Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "The Email must be at least 8 characters long.")]
        public string Email { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public List<int> SelectedRoleIds { get; set; }
        public bool IsActive { get; set; }

        [NotMapped] public int Version { get; set; }
    }
}