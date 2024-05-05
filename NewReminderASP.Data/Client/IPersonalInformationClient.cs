﻿using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    public interface IPersonalInformationClient
    {
        List<PersonalInfo> GetPersonalInfos();

        PersonalInfo GetPersonalInfo(int id);

        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);
        void AddPersonalInfo(PersonalInfo personalInfo);
        void DeletePersonalInfo(int id);
    }
}