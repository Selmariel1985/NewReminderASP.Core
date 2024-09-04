using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    ///     Service contract for phone-related operations.
    /// </summary>
    [ServiceContract]
    public interface IPhoneService
    {
        // User Phones

        /// <summary>
        ///     Get a list of all user phones.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<UserPhoneDto> GetUserPhones();

        /// <summary>
        ///     Get user phones based on the user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserPhoneDto> GetUserPhonesByUserId(int userId);

        /// <summary>
        ///     Get a user phone by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        UserPhoneDto GetUserPhone(int id);

        /// <summary>
        ///     Update the provided user phone information.
        /// </summary>
        /// <param name="updatedUserPhone"></param>
        [OperationContract]
        void UpdateUserPhone(UserPhoneDto updatedUserPhone);

        /// <summary>
        ///     Add a new user phone.
        /// </summary>
        /// <param name="userPhone"></param>
        [OperationContract]
        void AddUserPhone(UserPhoneDto userPhone);

        /// <summary>
        ///     Add user phone registration.
        /// </summary>
        /// <param name="userPhone"></param>
        [OperationContract]
        void AddUserPhoneRegister(UserPhoneDto userPhone);

        /// <summary>
        ///     Delete a user phone by its ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void DeleteUserPhone(int id);

        // Phone Types

        /// <summary>
        ///     Get a list of all phone types.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<PhoneTypeDto> GetPhoneTypes();

        /// <summary>
        ///     Get a phone type by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        PhoneTypeDto GetPhoneType(int id);

        /// <summary>
        ///     Update the provided phone type information.
        /// </summary>
        /// <param name="updatedPhoneType"></param>
        [OperationContract]
        void UpdatePhoneType(PhoneTypeDto updatedPhoneType);

        /// <summary>
        ///     Add a new phone type.
        /// </summary>
        /// <param name="eventPhoneType"></param>
        [OperationContract]
        void AddPhoneType(PhoneTypeDto eventPhoneType);

        /// <summary>
        ///     Delete a phone type by its ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void DeletePhoneType(int id);
    }
}