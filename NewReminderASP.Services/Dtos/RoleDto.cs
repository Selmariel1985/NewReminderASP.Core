using System.Runtime.Serialization;

namespace NewReminderASP.Services.Dtos
{
    /// <summary>
    /// Data transfer object for role details.
    /// </summary>
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public int Id { get; set; } // Role ID

        [DataMember]
        public string Name { get; set; } // Name of the role
    }
}