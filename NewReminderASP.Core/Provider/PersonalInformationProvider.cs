using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    public class PersonalInformationProvider : IPersonalInformationProvider

    {
        private readonly IPersonalInformationRepository _personalInformationRepository;
        public PersonalInformationProvider(IPersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }
        public List<PersonalInfo> GetPersonalInfos()
        {
            return _personalInformationRepository.GetPersonalInfos().ToList();
        }

        public PersonalInfo GetPersonalInfo(int userId)
        {
            return _personalInformationRepository.GetPersonalInfo(userId);
        }

        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
             _personalInformationRepository.UpdatePersonalInfo(updatedPersonalInfo);
        }

        public void AddPersonalInfo(PersonalInfo personalInfo)
        {
            _personalInformationRepository.AddPersonalInfo(personalInfo);
        }

        public void DeletePersonalInfo(int id)
        {
            _personalInformationRepository.DeletePersonalInfo(id);
        }
    }
}
