using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public PersonalInfo GetPersonalInfo(string login)
        {
            return _personalInformationClient.GetPersonalInfo(login);
        }

        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
            _personalInformationClient.UpdatePersonalInfo(updatedPersonalInfo);
        }

        public void AddPersonalInfo(string userLogin, PersonalInfo personalInfo)
        {
            _personalInformationClient.AddPersonalInfo(userLogin, personalInfo);
        }

        public void DeletePersonalInfo(string login)
        {
            _personalInformationClient.DeletePersonalInfo(login);
        }
    }
}