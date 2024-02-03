using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
