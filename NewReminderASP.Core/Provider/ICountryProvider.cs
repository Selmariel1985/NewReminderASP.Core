using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

namespace NewReminderASP.Core.Provider
{
    public interface ICountryProvider
    {
        List<Country> GetCountries();

        Country GetCountry(int id);

        void UpdateCountry(Country updatedCountry);
        void AddCountry(Country country);
        void DeleteCountry(int id);
    }
}