using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    ///     Interface for interacting with country data.
    /// </summary>
    public interface ICountryClient
    {
        /// <summary>
        ///     Retrieve a list of all countries.
        /// </summary>
        /// <returns></returns>
        List<Country> GetCountries();

        /// <summary>
        ///     Retrieve a country by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Country GetCountry(int id);

        /// <summary>
        ///     Update an existing country with new information.
        /// </summary>
        /// <param name="updatedCountry"></param>
        void UpdateCountry(Country updatedCountry);

        /// <summary>
        ///     Add a new country.
        /// </summary>
        /// <param name="country"></param>
        void AddCountry(Country country);

        /// <summary>
        ///     Delete the country with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteCountry(int id);
    }
}