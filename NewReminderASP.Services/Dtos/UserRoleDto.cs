using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class UserRoleDto
    {
        [DataMember] public int UserId { get; set; }

        [DataMember] public int RoleId { get; set; }

        [DataMember] public List<RoleDto> Roles { get; set; }

        [DataMember] public string RoleIds { get; set; }
        public string UserLogin { get; set; }
        public string RoleName { get; set; }
    }
}