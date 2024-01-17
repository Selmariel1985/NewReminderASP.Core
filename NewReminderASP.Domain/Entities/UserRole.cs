namespace NewReminderASP.Domain.Entities
{
    public class UserRole
    {
        public string roleName { get; set; }
        public string userLogin { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }




        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        
    }
}