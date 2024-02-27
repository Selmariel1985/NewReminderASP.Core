using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    public interface IPersonalInformationProvider
    {
        List<PersonalInfo> GetPersonalInfos();

        PersonalInfo GetPersonalInfo(string login);

        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);
        void AddPersonalInfo(string userLogin, PersonalInfo personalInfo);
        void DeletePersonalInfo(string login);
    }
}