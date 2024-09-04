using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Interface for providing phone-related functionality.
    /// </summary>
    public interface IPhoneProvider
    {
        // User Phones

        /// <summary>
        ///     Get a list of all user phones.
        /// </summary>
        /// <returns></returns>
        List<UserPhone> GetUserPhones();

        /// <summary>
        ///     Get user phones by user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<UserPhone> GetUserPhonesByUserId(int userId);

        /// <summary>
        ///     Get a user phone by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserPhone GetUserPhone(int id);

        /// <summary>
        ///     Update an existing user phone.
        /// </summary>
        /// <param name="updatedUserPhone"></param>
        void UpdateUserPhone(UserPhone updatedUserPhone);

        /// <summary>
        ///     Add a new user phone.
        /// </summary>
        /// <param name="userPhone"></param>
        void AddUserPhone(UserPhone userPhone);

        /// <summary>
        ///     Add a new user phone for registration.
        /// </summary>
        /// <param name="userPhone"></param>
        void AddUserPhoneRegister(UserPhone userPhone);

        /// <summary>
        ///     Delete a user phone by ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteUserPhone(int id);

        // Phone Types

        /// <summary>
        ///     Get a list of all phone types.
        /// </summary>
        /// <returns></returns>
        List<PhoneType> GetPhoneTypes();

        /// <summary>
        ///     Get a phone type by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PhoneType GetPhoneType(int id);

        /// <summary>
        ///     Update an existing phone type.
        /// </summary>
        /// <param name="updatedPhoneType"></param>
        void UpdatePhoneType(PhoneType updatedPhoneType);

        /// <summary>
        ///     Add a new phone type.
        /// </summary>
        /// <param name="eventPhoneType"></param>
        void AddPhoneType(PhoneType eventPhoneType);

        /// <summary>
        ///     Delete a phone type by ID.
        /// </summary>
        /// <param name="id"></param>
        void DeletePhoneType(int id);
    }
}