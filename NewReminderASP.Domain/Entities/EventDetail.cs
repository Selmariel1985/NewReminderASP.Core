namespace NewReminderASP.Domain.Entities
{
    public class EventDetail
    {
        public int EventID { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
        public virtual Event Event { get; set; }
    }
}