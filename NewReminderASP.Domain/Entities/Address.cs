namespace NewReminderASP.Domain.Entities
{
    public class Address
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int CountryID { get; set; }
        public string PostalCode { get; set; }
        public string Description { get; set; }
        public string CountryName { get; set; }

        public int UserID { get; set; }
        public string Login { get; set; }

        public virtual Country Country { get; set; }
    }
}