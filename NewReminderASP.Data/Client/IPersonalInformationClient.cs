﻿using NewReminderASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Data.Client
{
    public interface IPersonalInformationClient
    {
        List<PersonalInfo> GetPersonalInfos();

        PersonalInfo GetPersonalInfo(int userId);

        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);
        void AddPersonalInfo(PersonalInfo personalInfo);
        void DeletePersonalInfo(int id);
    }
}
