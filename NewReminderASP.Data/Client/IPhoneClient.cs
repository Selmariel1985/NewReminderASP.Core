using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    ///     Interface for interacting with phone-related data.
    /// </summary>
    public interface IPhoneClient
    {
        // User phone methods

        /// <summary>
        ///     Retrieve a list of all user phone.
        /// </summary>
        /// <returns></returns>
        List<UserPhone> GetUserPhones();

        /// <summary>
        ///     Retrieve the  list of all user phone by its userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<UserPhone> GetUserPhonesByUserId(int userId);

        /// <summary>
        ///     Retrieve the user phone by its userId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserPhone GetUserPhone(int id);

        /// <summary>
        ///     Update an existing user phone with new data.
        /// </summary>
        /// <param name="updatedUserPhone"></param>
        void UpdateUserPhone(UserPhone updatedUserPhone);

        /// <summary>
        ///     Add a new user phone.
        /// </summary>
        /// <param name="userPhone"></param>
        void AddUserPhone(UserPhone userPhone);

        /// <summary>
        ///     Delete the user phone with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteUserPhone(int id);

        /// <summary>
        ///     Add a new user phone.
        /// </summary>
        /// <param name="userPhone"></param>
        void AddUserPhoneRegister(UserPhone userPhone);

        // Phone type methods
        /// <summary>
        ///     Retrieve a list of all Phone type.
        /// </summary>
        /// <returns></returns>
        List<PhoneType> GetPhoneTypes();

        /// <summary>
        ///     Retrieve the  Phone type by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PhoneType GetPhoneType(int id);

        /// <summary>
        ///     Update an existing Phone type with new data.
        /// </summary>
        /// <param name="updatedPhoneType"></param>
        void UpdatePhoneType(PhoneType updatedPhoneType);

        /// <summary>
        ///     Add a new Phone type.
        /// </summary>
        /// <param name="eventPhoneType"></param>
        void AddPhoneType(PhoneType eventPhoneType);

        /// <summary>
        ///     Delete the Phone type record with the specified id.
        /// </summary>
        /// <param name="id"></param>
        void DeletePhoneType(int id);
    }
}