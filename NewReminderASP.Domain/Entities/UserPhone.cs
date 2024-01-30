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
        public string Login { get; set; }
        public string PhoneTypes { get; set; }
        public string CountryName { get; set; }
    }
}