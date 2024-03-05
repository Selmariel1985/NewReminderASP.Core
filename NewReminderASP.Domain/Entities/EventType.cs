using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class EventType
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please select a Type Name")]
        public string TypeName { get; set; }
    }
}