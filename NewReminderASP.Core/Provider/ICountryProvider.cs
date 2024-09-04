using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Interface for providing country-related functionality.
    /// </summary>
    public interface ICountryProvider
    {
        /// <summary>
        ///     Get a list of all countries.
        /// </summary>
        /// <returns></returns>
        List<Country> GetCountries();

        /// <summary>
        ///     Get a country by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Country GetCountry(int id);

        /// <summary>
        ///     Update the provided country information.
        /// </summary>
        /// <param name="updatedCountry"></param>
        void UpdateCountry(Country updatedCountry);

        /// <summary>
        ///     Add a new country.
        /// </summary>
        /// <param name="country"></param>
        void AddCountry(Country country);

        /// <summary>
        ///     Delete a country by its ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteCountry(int id);
    }
}