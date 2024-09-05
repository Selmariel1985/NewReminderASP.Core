using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    ///     Interface for retrieving and managing personal information data.
    /// </summary>
    public interface IPersonalInformationClient
    {
        /// <summary>
        ///     Retrieve a list of all personal information records.
        /// </summary>
        /// <returns></returns>
        List<PersonalInfo> GetPersonalInfos();

        /// <summary>
        ///     Retrieve the personal information record by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PersonalInfo GetPersonalInfo(int id);

        /// <summary>
        ///     Update an existing personal information record with new data.
        /// </summary>
        /// <param name="updatedPersonalInfo"></param>
        void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo);

        /// <summary>
        ///     Add a new personal information record.
        /// </summary>
        /// <param name="personalInfo"></param>
        void AddPersonalInfo(PersonalInfo personalInfo);

        /// <summary>
        ///     Delete the personal information record with the specified id.
        /// </summary>
        /// <param name="id"></param>
        void DeletePersonalInfo(int id);
    }
}