using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class EventDetail
    {
        public int EventID { get; set; }
        [Required(ErrorMessage = "Please select a Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select a Status")]
        public string Status { get; set; }
        public virtual Event Event { get; set; }
        public List<Event> EventsId { get; set; }
    }
}