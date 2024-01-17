using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    [DataContract]
    public class RoleDto
    {
        [DataMember] public int Id { get; set; }

        [DataMember] public string Name { get; set; }
    }
}