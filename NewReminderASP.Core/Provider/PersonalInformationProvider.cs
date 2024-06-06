using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Provider class for handling personal information-related operations.
    /// </summary>
    public class PersonalInformationProvider : IPersonalInformationProvider
    {
        private readonly IPersonalInformationRepository _personalInformationRepository;

        /// <summary>
        /// Constructor for PersonalInformationProvider.
        /// </summary>
        /// <param name="personalInformationRepository">The repository for accessing personal information data</param>
        public PersonalInformationProvider(IPersonalInformationRepository personalInformationRepository)
        {
            _personalInformationRepository = personalInformationRepository;
        }

        /// <summary>
        /// Get all personal information entries.
        /// </summary>
        public List<PersonalInfo> GetPersonalInfos()
        {
            return _personalInformationRepository.GetPersonalInfos().ToList();
        }

        /// <summary>
        /// Get a personal information entry by ID.
        /// </summary>
        /// <param name="id">The ID of the personal information entry to retrieve</param>
        public PersonalInfo GetPersonalInfo(int id)
        {
            return _personalInformationRepository.GetPersonalInfo(id);
        }

        /// <summary>
        /// Update an existing personal information entry.
        /// </summary>
        /// <param name="updatedPersonalInfo">The updated personal information object</param>
        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
            _personalInformationRepository.UpdatePersonalInfo(updatedPersonalInfo);
        }

        /// <summary>
        /// Add a new personal information entry.
        /// </summary>
        /// <param name="personalInfo">The personal information entry to be added</param>
        public void AddPersonalInfo(PersonalInfo personalInfo)
        {
            _personalInformationRepository.AddPersonalInfo(personalInfo);
        }

        /// <summary>
        /// Delete a personal information entry by ID.
        /// </summary>
        /// <param name="id">The ID of the personal information entry to delete</param>
        public void DeletePersonalInfo(int id)
        {
            _personalInformationRepository.DeletePersonalInfo(id);
        }
    }
}
