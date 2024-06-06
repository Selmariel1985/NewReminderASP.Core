using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    /// Interface for accessing and managing country data.
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Get all countries.
        /// </summary>
        List<Country> GetCountries();

        /// <summary>
        /// Get a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve</param>
        Country GetCountry(int id);

        /// <summary>
        /// Update an existing country.
        /// </summary>
        /// <param name="updatedCountry">The updated country object</param>
        void UpdateCountry(Country updatedCountry);

        /// <summary>
        /// Add a new country.
        /// </summary>
        /// <param name="country">The country to be added</param>
        void AddCountry(Country country);

        /// <summary>
        /// Delete a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete</param>
        void DeleteCountry(int id);
    }
}