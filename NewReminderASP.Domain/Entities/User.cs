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
        public string Password { get; set; }

        [NotMapped] public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please enter a Password")]
        public string Email { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
       

        [NotMapped] public int Version { get; set; }
    }
}