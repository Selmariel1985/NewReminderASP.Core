using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    ///     Service contract for country-related operations.
    /// </summary>
    [ServiceContract]
    public interface ICountryService
    {
        /// <summary>
        ///     Get a list of all countries.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CountryDto> GetCountries();

        /// <summary>
        ///     Get country details by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        CountryDto GetCountry(int id);

        /// <summary>
        ///     Update the provided country information.
        /// </summary>
        /// <param name="updatedCountry"></param>
        [OperationContract]
        void UpdateCountry(CountryDto updatedCountry);

        /// <summary>
        ///     Add a new country.
        /// </summary>
        /// <param name="country"></param>
        [OperationContract]
        void AddCountry(CountryDto country);

        /// <summary>
        ///     Delete a country by its ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void DeleteCountry(int id);
    }
}