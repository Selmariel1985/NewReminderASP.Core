using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    public interface IPersonalInformationClient
    {
        List<PersonalInfo> GetPersonalInfos();

        PersonalInfo GetPersonalInfo(string login);

        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);
        void AddPersonalInfo(string userLogin, PersonalInfo personalInfo);
        void DeletePersonalInfo(string login);
    }
}