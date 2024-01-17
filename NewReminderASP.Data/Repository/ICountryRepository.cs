using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public interface ICountryRepository
    {
        List<Country> GetCountries();

        Country GetCountry(int id);

        void UpdateCountry(Country updatedCountry);
        void AddCountry(Country country);
        void DeleteCountry(int id);
    }
}