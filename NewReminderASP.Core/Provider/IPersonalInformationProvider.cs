using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

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