using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Domain.Entities
{
    public class EventType
    {
        
        public int ID { get; set; }
       
        public string TypeName { get; set; }
    }
}
