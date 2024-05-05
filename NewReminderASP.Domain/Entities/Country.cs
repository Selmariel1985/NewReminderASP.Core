using System.ComponentModel.DataAnnotations;

namespace NewReminderASP.Domain.Entities
{
    public class Country
    {
        public int CountryID { get; set; }

        [Required(ErrorMessage = "Please select a country Code")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Please select a Phone Code")]
        public string PhoneCode { get; set; }

        [Required(ErrorMessage = "Please select a Country Name")]
        public string Name { get; set; }
    }
}