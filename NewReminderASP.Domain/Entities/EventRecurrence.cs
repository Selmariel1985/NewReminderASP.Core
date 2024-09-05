using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    ///     Represents a type of recurrence for an event.
    /// </summary>
    public class EventRecurrence
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please select a Recurrence Type")]
        public string RecurrenceType { get; set; } // Type of recurrence (e.g., daily, weekly, monthly, etc.)
    }
}