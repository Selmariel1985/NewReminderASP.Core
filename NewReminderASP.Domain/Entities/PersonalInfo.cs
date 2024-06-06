using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents personal information of a user.
    /// </summary>
    public class PersonalInfo
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter a FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a LastName")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter a Birthdate")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Please enter a Gender")]
        public string Gender { get; set; }

        public virtual User User { get; set; }

        public string Login { get; set; }
        public List<User> Users { get; set; }
    }
}