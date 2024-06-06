using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    /// Interface for retrieving and managing personal information data.
    /// </summary>
    public interface IPersonalInformationClient
    {
        /// <summary>
        /// Retrieve a list of all personal information records.
        /// </summary>
        List<PersonalInfo> GetPersonalInfos();

        /// <summary>
        /// Retrieve the personal information record by its ID.
        /// </summary>
        PersonalInfo GetPersonalInfo(int id);

        /// <summary>
        /// Update an existing personal information record with new data.
        /// </summary>
        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);

        /// <summary>
        /// Add a new personal information record.
        /// </summary>
        void AddPersonalInfo(PersonalInfo personalInfo);

        /// <summary>
        /// Delete the personal information record with the specified ID.
        /// </summary>
        void DeletePersonalInfo(int id);
    }
}