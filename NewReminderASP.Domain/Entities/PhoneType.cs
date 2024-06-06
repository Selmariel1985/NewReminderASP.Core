using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents a type of phone.
    /// </summary>
    public class PhoneType
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the Type Name")]
        public string TypeName { get; set; } // Name of the phone type (e.g., mobile, home, work, etc.)
    }
}