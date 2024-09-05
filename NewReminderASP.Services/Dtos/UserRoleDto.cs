using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for user roles details.
    /// </summary>
    [DataContract]
    public class UserRoleDto
    {
        [DataMember]
        public int UserId { get; set; } // User ID

        [DataMember]
        public int RoleId { get; set; } // Role ID

        [DataMember]
        public List<RoleDto> Roles { get; set; } // List of roles

        [DataMember]
        public string RoleIds { get; set; } // Comma-separated role IDs

        public string UserLogin { get; set; } // User login
        public string RoleName { get; set; } // Role name
    }
}