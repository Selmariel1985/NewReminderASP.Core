using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

namespace NewReminderASP.Data.Client
{
    public interface ICountryClient
    {
        List<Country> GetCountries();

        Country GetCountry(int id);

        void UpdateCountry(Country updatedCountry);
        void AddCountry(Country country);
        void DeleteCountry(int id);
    }
}