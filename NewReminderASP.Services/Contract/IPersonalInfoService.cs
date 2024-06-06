using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    /// Service contract for personal information-related operations.
    /// </summary>
    [ServiceContract]
    public interface IPersonalInfoService
    {
        /// <summary>
        /// Get a list of all personal information entries.
        /// </summary>
        [OperationContract]
        List<PersonalInfoDto> GetPersonalInfos();

        /// <summary>
        /// Get personal information by ID.
        /// </summary>
        [OperationContract]
        PersonalInfoDto GetPersonalInfo(int id);

        /// <summary>
        /// Update the provided personal information entry.
        /// </summary>
        [OperationContract]
        void UpdatePersonalInfo(PersonalInfoDto updatedPersonalInfo);

        /// <summary>
        /// Add a new personal information entry.
        /// </summary>
        [OperationContract]
        void AddPersonalInfo(PersonalInfoDto personalInfo);

        /// <summary>
        /// Delete personal information by ID.
        /// </summary>
        [OperationContract]
        void DeletePersonalInfo(int id);
    }
}