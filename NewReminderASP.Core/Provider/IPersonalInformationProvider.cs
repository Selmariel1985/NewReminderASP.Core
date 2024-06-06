using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Interface for providing personal information-related functionality.
    /// </summary>
    public interface IPersonalInformationProvider
    {
        /// <summary>
        /// Get a list of all personal information entries.
        /// </summary>
        List<PersonalInfo> GetPersonalInfos();

        /// <summary>
        /// Get personal information by its ID.
        /// </summary>
        PersonalInfo GetPersonalInfo(int id);

        /// <summary>
        /// Update the provided personal information.
        /// </summary>
        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);

        /// <summary>
        /// Add a new personal information entry.
        /// </summary>
        void AddPersonalInfo(PersonalInfo personalInfo);

        /// <summary>
        /// Delete personal information by its ID.
        /// </summary>
        void DeletePersonalInfo(int id);
    }
}