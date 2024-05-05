using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public interface IPersonalInformationRepository
    {
        List<PersonalInfo> GetPersonalInfos();

        PersonalInfo GetPersonalInfo(int id);

        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);
        void AddPersonalInfo(PersonalInfo personalInfo);
        void DeletePersonalInfo(int id);
    }
}