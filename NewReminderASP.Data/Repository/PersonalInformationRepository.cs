﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public class PersonalInformationRepository : IPersonalInformationRepository
    {
        private readonly IPersonalInformationClient _personalInformationClient;

        public PersonalInformationRepository(IPersonalInformationClient personalInformationClient)
        {
            _personalInformationClient = personalInformationClient;
        }

        public List<PersonalInfo> GetPersonalInfos()
        {
            return _personalInformationClient.GetPersonalInfos().ToList();
        }

        public PersonalInfo GetPersonalInfo(int userId)
        {
            return _personalInformationClient.GetPersonalInfo(userId);
        }

        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
            _personalInformationClient.UpdatePersonalInfo(updatedPersonalInfo);
        }

        public void AddPersonalInfo(PersonalInfo personalInfo)
        {
            _personalInformationClient.AddPersonalInfo(personalInfo);
        }

        public void DeletePersonalInfo(int id)
        {
            _personalInformationClient.DeletePersonalInfo(id);
        }
    }
}
