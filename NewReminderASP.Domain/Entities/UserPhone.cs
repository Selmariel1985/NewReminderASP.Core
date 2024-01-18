using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Domain.Entities
{
    public class UserPhone
    {
        
        public int ID { get; set; }
       
        public int UserID { get; set; }
       
        public string PhoneNumber { get; set; } = string.Empty;
       
        public int PhoneTypeID { get; set; }
        
        public int CountryID { get; set; }
        
        public virtual User User { get; set; }
       
        public virtual PhoneType PhoneType { get; set; }
        
        public virtual Country UserCountry { get; set; }
    }
}
