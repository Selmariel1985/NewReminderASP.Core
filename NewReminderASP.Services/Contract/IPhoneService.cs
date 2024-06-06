using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    /// Service contract for phone-related operations.
    /// </summary>
    [ServiceContract]
    public interface IPhoneService
    {
        // User Phones

        /// <summary>
        /// Get a list of all user phones.
        /// </summary>
        [OperationContract]
        List<UserPhoneDto> GetUserPhones();

        /// <summary>
        /// Get user phones based on the user ID.
        /// </summary>
        [OperationContract]
        List<UserPhoneDto> GetUserPhonesByUserId(int userId);

        /// <summary>
        /// Get a user phone by its ID.
        /// </summary>
        [OperationContract]
        UserPhoneDto GetUserPhone(int id);

        /// <summary>
        /// Update the provided user phone information.
        /// </summary>
        [OperationContract]
        void UpdateUserPhone(UserPhoneDto updatedUserPhone);

        /// <summary>
        /// Add a new user phone.
        /// </summary>
        [OperationContract]
        void AddUserPhone(UserPhoneDto userPhone);

        /// <summary>
        /// Add user phone registration.
        /// </summary>
        [OperationContract]
        void AddUserPhoneRegister(UserPhoneDto userPhone);

        /// <summary>
        /// Delete a user phone by its ID.
        /// </summary>
        [OperationContract]
        void DeleteUserPhone(int id);

        // Phone Types

        /// <summary>
        /// Get a list of all phone types.
        /// </summary>
        [OperationContract]
        List<PhoneTypeDto> GetPhoneTypes();

        /// <summary>
        /// Get a phone type by its ID.
        /// </summary>
        [OperationContract]
        PhoneTypeDto GetPhoneType(int id);

        /// <summary>
        /// Update the provided phone type information.
        /// </summary>
        [OperationContract]
        void UpdatePhoneType(PhoneTypeDto updatedPhoneType);

        /// <summary>
        /// Add a new phone type.
        /// </summary>
        [OperationContract]
        void AddPhoneType(PhoneTypeDto eventPhoneType);

        /// <summary>
        /// Delete a phone type by its ID.
        /// </summary>
        [OperationContract]
        void DeletePhoneType(int id);
    }
}
