using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

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
