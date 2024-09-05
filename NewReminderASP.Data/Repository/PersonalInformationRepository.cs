using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Repository class for managing personal information entities.
    /// </summary>
    public class PersonalInformationRepository : IPersonalInformationRepository
    {
        private readonly IPersonalInformationClient _personalInformationClient;

        /// <summary>
        ///     Constructor for PersonalInformationRepository.
        /// </summary>
        /// <param name="personalInformationClient">The client for accessing personal information data</param>
        public PersonalInformationRepository(IPersonalInformationClient personalInformationClient)
        {
            _personalInformationClient = personalInformationClient;
        }

        /// <summary>
        ///     Get all personal information entries.
        /// </summary>
        /// <returns></returns>
        public List<PersonalInfo> GetPersonalInfos()
        {
            return _personalInformationClient.GetPersonalInfos().ToList();
        }

        /// <summary>
        ///     Get a personal information entry by ID.
        /// </summary>
        /// <param name="id">The ID of the personal information entry to retrieve</param>
        /// <returns></returns>
        public PersonalInfo GetPersonalInfo(int id)
        {
            return _personalInformationClient.GetPersonalInfo(id);
        }

        /// <summary>
        ///     Update an existing personal information entry.
        /// </summary>
        /// <param name="updatedPersonalInfo">The updated personal information object</param>
        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
            _personalInformationClient.UpdatePersonalInfo(updatedPersonalInfo);
        }

        /// <summary>
        ///     Add a new personal information entry.
        /// </summary>
        /// <param name="personalInfo">The personal information entry to be added</param>
        public void AddPersonalInfo(PersonalInfo personalInfo)
        {
            _personalInformationClient.AddPersonalInfo(personalInfo);
        }

        /// <summary>
        ///     Delete a personal information entry by ID.
        /// </summary>
        /// <param name="id">The ID of the personal information entry to delete</param>
        public void DeletePersonalInfo(int id)
        {
            _personalInformationClient.DeletePersonalInfo(id);
        }
    }
}