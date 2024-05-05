using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Role")]
        public string Name { get; set; }
    }
}