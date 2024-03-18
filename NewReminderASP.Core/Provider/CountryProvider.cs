using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NewReminderASP.Core.Provider
{
    public class CountryProvider : ICountryProvider

    {
        private readonly ICountryRepository _countryRepository;

        public CountryProvider(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<Country> GetCountries()
        {
            return _countryRepository.GetCountries().ToList();
        }

        public Country GetCountry(int id)
        {
            return _countryRepository.GetCountry(id);
        }

        public void UpdateCountry(Country updatedCountry)
        {
            _countryRepository.UpdateCountry(updatedCountry);
        }

        public void AddCountry(Country country)
        {
            _countryRepository.AddCountry(country);
        }


        public void DeleteCountry(int id)
        {
            _countryRepository.DeleteCountry(id);
        }
    }
}