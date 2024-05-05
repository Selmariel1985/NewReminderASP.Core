using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ICountryClient _countryClient;

        public CountryRepository(ICountryClient countryClient)
        {
            _countryClient = countryClient;
        }

        public List<Country> GetCountries()
        {
            return _countryClient.GetCountries().ToList();
        }

        public Country GetCountry(int id)
        {
            return _countryClient.GetCountry(id);
        }

        public void AddCountry(Country country)
        {
            _countryClient.AddCountry(country);
        }

        public void DeleteCountry(int id)
        {
            _countryClient.DeleteCountry(id);
        }

        public void UpdateCountry(Country updatedCountry)
        {
            _countryClient.UpdateCountry(updatedCountry);
        }
    }
}