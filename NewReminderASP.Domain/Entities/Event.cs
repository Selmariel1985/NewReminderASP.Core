using System;
using System.ComponentModel.DataAnnotations;



namespace NewReminderASP.Domain.Entities
{
    public class Event
    {
       
        public int ID { get; set; }
       
        public int UserID { get; set; }
        
        public int EventTypeID { get; set; }
        
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }
        
        public TimeSpan Time { get; set; }
        
        public int RecurrenceID { get; set; }
        
        public string Reminders { get; set; }
       
        public User User { get; set; }
        
        public virtual EventType EventType { get; set; }
       
        public virtual EventRecurrence EventRecurrence { get; set; }
        public virtual EventDetail EventDetail { get; set; }
        public string Recurrence { get; set; }
        public string EventTypes { get; set; }
        public string Login { get; set; }
    }
}
