using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    /// Interface for interacting with country data.
    /// </summary>
    public interface ICountryClient
    {
        /// <summary>
        /// Retrieve a list of all countries.
        /// </summary>
        List<Country> GetCountries();

        /// <summary>
        /// Retrieve a country by its ID.
        /// </summary>
        Country GetCountry(int id);

        /// <summary>
        /// Update an existing country with new information.
        /// </summary>
        void UpdateCountry(Country updatedCountry);

        /// <summary>
        /// Add a new country.
        /// </summary>
        void AddCountry(Country country);

        /// <summary>
        /// Delete the country with the specified ID.
        /// </summary>
        void DeleteCountry(int id);
    }
}