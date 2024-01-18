using System;



namespace NewReminderASP.Domain.Entities
{
    public class Event
    {
       
        public int ID { get; set; }
       
        public int UserID { get; set; }
        
        public int EventTypeID { get; set; }
        
        public string Title { get; set; }
        
        public DateTime Date { get; set; }
        
        public TimeSpan Time { get; set; }
        
        public int RecurrenceID { get; set; }
        
        public string Reminders { get; set; }
       
        public User User { get; set; }
        
        public virtual EventType EventType { get; set; }
       
        public virtual EventRecurrence EventRecurrence { get; set; }
        public virtual EventDetail EventDetail { get; set; }
    }
}
