using System.Collections.Generic;

namespace NewReminderASP.Domain.Entities
{
    /// <summary>
    ///     Model representing user details along with associated addresses, phones, personal information, and events.
    /// </summary>
    public class UserDetailsViewModel
    {
        public User User { get; set; } // User object
        public Address Address { get; set; } // Address related to the user
        public UserPhone Phone { get; set; } // Phone related to the user
        public PersonalInfo PersonalInformation { get; set; } // Personal information of the user

        public Event Event { get; set; } // Current event associated with the user
        public List<Event> Events { get; set; } // List of events related to the user

        public List<Address> Addresses { get; set; } // List of addresses associated with the user
        public List<UserPhone> Phones { get; set; } // List of phones associated with the user
    }
}