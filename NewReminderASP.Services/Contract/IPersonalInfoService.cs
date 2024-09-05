using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    ///     Service contract for personal information-related operations.
    /// </summary>
    [ServiceContract]
    public interface IPersonalInfoService
    {
        /// <summary>
        ///     Get a list of all personal information entries.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<PersonalInfoDto> GetPersonalInfos();

        /// <summary>
        ///     Get personal information by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        PersonalInfoDto GetPersonalInfo(int id);

        /// <summary>
        ///     Update the provided personal information entry.
        /// </summary>
        /// <param name="updatedPersonalInfo"></param>
        [OperationContract]
        void UpdatePersonalInfo(PersonalInfoDto updatedPersonalInfo);

        /// <summary>
        ///     Add a new personal information entry.
        /// </summary>
        /// <param name="personalInfo"></param>
        [OperationContract]
        void AddPersonalInfo(PersonalInfoDto personalInfo);

        /// <summary>
        ///     Delete personal information by ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void DeletePersonalInfo(int id);
    }
}