using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents a type of event.
    /// </summary>
    public class EventType
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please select a Type Name")]
        public string TypeName { get; set; } // Name of the event type (e.g., meeting, appointment, birthday, etc.)
    }
}