using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Domain.Entities
{
    public class EventDetailsViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }

        public Event Event { get; set; }
        public List<Event> Events { get; set; }



    }
}
