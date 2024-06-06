using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// Represents details of an event.
    /// </summary>
    public class EventDetail
    {
        public int EventID { get; set; }

        [Required(ErrorMessage = "Please select a Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select a Status")]
        public string Status { get; set; }

        public virtual Event Event { get; set; } // Navigation property to link to the associated Event
        public List<Event> EventsId { get; set; } // List property to hold associated events (consider renaming for clarity)
    }
}