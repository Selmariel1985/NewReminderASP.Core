using NewReminderASP.Services.Dtos;
using System.Collections.Generic;
using System.ServiceModel;

namespace NewReminderASP.Services.Contract

{
    [ServiceContract]
    public interface IPersonalInfoService
    {
        [OperationContract]
        List<PersonalInfoDto> GetPersonalInfos();

        [OperationContract]
        PersonalInfoDto GetPersonalInfo(string login);

        [OperationContract]
        void UpdatePersonalInfo(PersonalInfoDto updatedPersonalInfo);

        [OperationContract]
        void AddPersonalInfo(string userLogin, PersonalInfoDto personalInfo);

        [OperationContract]
        void DeletePersonalInfo(string login);
    }
}