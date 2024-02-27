using System.Collections.Generic;
using System.Linq;
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

        public PersonalInfo GetPersonalInfo(string login)
        {
            return _personalInformationRepository.GetPersonalInfo(login);
        }

        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
            _personalInformationRepository.UpdatePersonalInfo(updatedPersonalInfo);
        }

        public void AddPersonalInfo(string userLogin, PersonalInfo personalInfo)
        {
            _personalInformationRepository.AddPersonalInfo(userLogin, personalInfo);
        }

        public void DeletePersonalInfo(string login)
        {
            _personalInformationRepository.DeletePersonalInfo(login);
        }
    }
}