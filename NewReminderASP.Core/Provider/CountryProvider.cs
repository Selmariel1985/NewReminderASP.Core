using System.Collections.Generic;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Provider class for country-related functionality by interacting with the country repository.
    /// </summary>
    public class CountryProvider : ICountryProvider
    {
        private readonly ICountryRepository _countryRepository;

        public CountryProvider(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        ///     Get a list of all countries.
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountries()
        {
            return _countryRepository.GetCountries();
        }

        /// <summary>
        ///     Get a country by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country GetCountry(int id)
        {
            return _countryRepository.GetCountry(id);
        }

        /// <summary>
        ///     Update the provided country information.
        /// </summary>
        /// <param name="updatedCountry"></param>
        public void UpdateCountry(Country updatedCountry)
        {
            _countryRepository.UpdateCountry(updatedCountry);
        }

        /// <summary>
        ///     Add a new country.
        /// </summary>
        /// <param name="country"></param>
        public void AddCountry(Country country)
        {
            _countryRepository.AddCountry(country);
        }

        /// <summary>
        ///     Delete a country by its ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCountry(int id)
        {
            _countryRepository.DeleteCountry(id);
        }
    }
}