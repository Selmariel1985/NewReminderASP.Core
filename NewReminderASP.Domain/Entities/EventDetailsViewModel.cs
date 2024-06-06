using System.Collections.Generic;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    /// ViewModel representing details of an event along with associated users.
    /// </summary>
    public class EventDetailsViewModel
    {
        public User User { get; set; } // User associated with the event
        public List<User> Users { get; set; } // List of users associated with the event

        public Event Event { get; set; } // Event details
        public List<Event> Events { get; set; } // List of events
    }
}