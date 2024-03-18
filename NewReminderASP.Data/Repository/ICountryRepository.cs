using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

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