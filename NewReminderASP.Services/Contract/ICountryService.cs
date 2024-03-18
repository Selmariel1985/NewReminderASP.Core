using NewReminderASP.Services.Dtos;
using System.Collections.Generic;
using System.ServiceModel;

namespace NewReminderASP.Services.Contract
{
    [ServiceContract]
    public interface ICountryService
    {
        [OperationContract]
        List<CountryDto> GetCountries();

        [OperationContract]
        CountryDto GetCountry(int id);

        [OperationContract]
        void UpdateCountry(CountryDto updatedCountry);

        [OperationContract]
        void AddCountry(CountryDto country);

        [OperationContract]
        void DeleteCountry(int id);
    }
}