using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for user details.
    /// </summary>
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int Id { get; set; } // User ID

        [DataMember]
        public string Login { get; set; } // User login

        [DataMember]
        public string Password { get; set; } // User password

        [DataMember]
        public string Email { get; set; } // User email

        [DataMember]
        public List<string> Roles { get; set; } // List of roles assigned to the user
    }
}