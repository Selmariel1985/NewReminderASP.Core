using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Provider class for handling personal information-related operations.
    /// </summary>
    public class PersonalInformationProvider : IPersonalInformationProvider
    {
        private readonly IPersonalInformationRepository _personalInformationRepository;

        /// <summary>
        ///     Constructor for PersonalInformationProvider.
        /// </summary>
        /// <param name="personalInformationRepository"></param>
        public PersonalInformationProvider(IPersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }

        /// <summary>
        ///     Get all personal information entries.
        /// </summary>
        /// <returns></returns>
        public List<PersonalInfo> GetPersonalInfos()
        {
            return _personalInformationRepository.GetPersonalInfos().ToList();
        }

        /// <summary>
        ///     Get a personal information entry by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonalInfo GetPersonalInfo(int id)
        {
            return _personalInformationRepository.GetPersonalInfo(id);
        }

        /// <summary>
        ///     Update an existing personal information entry.
        /// </summary>
        /// <param name="updatedPersonalInfo"></param>
        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
            _personalInformationRepository.UpdatePersonalInfo(updatedPersonalInfo);
        }

        /// <summary>
        ///     Add a new personal information entry.
        /// </summary>
        /// <param name="personalInfo"></param>
        public void AddPersonalInfo(PersonalInfo personalInfo)
        {
            _personalInformationRepository.AddPersonalInfo(personalInfo);
        }

        /// <summary>
        ///     Delete a personal information entry by ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeletePersonalInfo(int id)
        {
            _personalInformationRepository.DeletePersonalInfo(id);
        }
    }
}