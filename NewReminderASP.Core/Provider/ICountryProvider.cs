using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Interface for providing country-related functionality.
    /// </summary>
    public interface ICountryProvider
    {
        /// <summary>
        /// Get a list of all countries.
        /// </summary>
        List<Country> GetCountries();

        /// <summary>
        /// Get a country by its ID.
        /// </summary>
        Country GetCountry(int id);

        /// <summary>
        /// Update the provided country information.
        /// </summary>
        void UpdateCountry(Country updatedCountry);

        /// <summary>
        /// Add a new country.
        /// </summary>
        void AddCountry(Country country);

        /// <summary>
        /// Delete a country by its ID.
        /// </summary>
        void DeleteCountry(int id);
    }
}