using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class EventRecurrence
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please select a Recurrence Type")]
        public string RecurrenceType { get; set; }
    }
}