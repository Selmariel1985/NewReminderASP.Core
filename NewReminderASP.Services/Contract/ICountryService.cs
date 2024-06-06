using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    /// Service contract for country-related operations.
    /// </summary>
    [ServiceContract]
    public interface ICountryService
    {
        /// <summary>
        /// Get a list of all countries.
        /// </summary>
        [OperationContract]
        List<CountryDto> GetCountries();

        /// <summary>
        /// Get country details by its ID.
        /// </summary>
        [OperationContract]
        CountryDto GetCountry(int id);

        /// <summary>
        /// Update the provided country information.
        /// </summary>
        [OperationContract]
        void UpdateCountry(CountryDto updatedCountry);

        /// <summary>
        /// Add a new country.
        /// </summary>
        [OperationContract]
        void AddCountry(CountryDto country);

        /// <summary>
        /// Delete a country by its ID.
        /// </summary>
        [OperationContract]
        void DeleteCountry(int id);
    }
}