using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Interface for providing personal information-related functionality.
    /// </summary>
    public interface IPersonalInformationProvider
    {
        /// <summary>
        ///     Get a list of all personal information entries.
        /// </summary>
        /// <returns></returns>
        List<PersonalInfo> GetPersonalInfos();

        /// <summary>
        ///     Get personal information by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonalInfo GetPersonalInfo(int id);

        /// <summary>
        ///     Update the provided personal information.
        /// </summary>
        /// <param name="updatedPersonalInfo"></param>
        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);

        /// <summary>
        ///     Add a new personal information entry.
        /// </summary>
        /// <param name="personalInfo"></param>
        void AddPersonalInfo(PersonalInfo personalInfo);

        /// <summary>
        ///     Delete personal information by its ID.
        /// </summary>
        /// <param name="id"></param>
        void DeletePersonalInfo(int id);
    }
}