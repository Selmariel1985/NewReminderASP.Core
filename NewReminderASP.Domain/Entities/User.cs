using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewReminderASP.Domain.Entities
{
    public class User

    {
        public int Id { get; set; }

        public string Login { get; set; }


        public string Password { get; set; }

        [NotMapped] public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<PersonalInfo> PersonalInfos{ get; set; }

        [NotMapped] public int Version { get; set; }
    }
}