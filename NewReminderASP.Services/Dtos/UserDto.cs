using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class UserDto

    {
        [DataMember] public int Id { get; set; }

        [DataMember] public string Login { get; set; }
        [DataMember] public string Password { get; set; }
        [DataMember] public string Email { get; set; }

        [DataMember] public List<string> Roles { get; set; }
    }
}