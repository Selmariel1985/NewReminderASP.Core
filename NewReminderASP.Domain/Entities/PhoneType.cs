using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class PhoneType
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter theType Name")]
        public string TypeName { get; set; }
    }
}