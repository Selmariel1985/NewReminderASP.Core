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
        PersonalInfoDto GetPersonalInfo(int userId);
        [OperationContract]
        void UpdatePersonalInfo(PersonalInfoDto updatedPersonalInfo);
        [OperationContract]
        void AddPersonalInfo(PersonalInfoDto personalInfo);
        [OperationContract]
        void DeletePersonalInfo(int id);
    }
}
