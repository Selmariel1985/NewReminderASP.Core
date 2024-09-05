using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Interface for accessing and managing personal information data.
    /// </summary>
    public interface IPersonalInformationRepository
    {
        /// <summary>
        ///     Get all personal information entries.
        /// </summary>
        /// <returns></returns>
        List<PersonalInfo> GetPersonalInfos();

        /// <summary>
        ///     Get personal information by ID.
        /// </summary>
        /// <param name="id">The ID of the personal information entry to retrieve</param>
        /// <returns></returns>
        PersonalInfo GetPersonalInfo(int id);

        /// <summary>
        ///     Update an existing personal information entry.
        /// </summary>
        /// <param name="updatedPersonalInfo">The updated personal information object</param>
        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);

        /// <summary>
        ///     Add a new personal information entry.
        /// </summary>
        /// <param name="personalInfo">The personal information entry to be added</param>
        void AddPersonalInfo(PersonalInfo personalInfo);

        /// <summary>
        ///     Delete a personal information entry by ID.
        /// </summary>
        /// <param name="id">The ID of the personal information entry to delete</param>
        void DeletePersonalInfo(int id);
    }
}