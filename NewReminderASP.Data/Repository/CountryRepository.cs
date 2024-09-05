using System.Collections.Generic;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Repository for interacting with country data through the country client.
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        private readonly ICountryClient _countryClient;

        public CountryRepository(ICountryClient countryClient)
        {
            _countryClient = countryClient;
        }

        /// <summary>
        ///     Retrieve a list of all countries.
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountries()
        {
            return _countryClient.GetCountries();
        }

        /// <summary>
        ///     Retrieve a country by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country GetCountry(int id)
        {
            return _countryClient.GetCountry(id);
        }

        /// <summary>
        ///     Add a new country.
        /// </summary>
        /// <param name="country"></param>
        public void AddCountry(Country country)
        {
            _countryClient.AddCountry(country);
        }

        /// <summary>
        ///     Delete the country with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCountry(int id)
        {
            _countryClient.DeleteCountry(id);
        }

        /// <summary>
        ///     Update an existing country with new information.
        /// </summary>
        /// <param name="updatedCountry"></param>
        public void UpdateCountry(Country updatedCountry)
        {
            _countryClient.UpdateCountry(updatedCountry);
        }
    }
}