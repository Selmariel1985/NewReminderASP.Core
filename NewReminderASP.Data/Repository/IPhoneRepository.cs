using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Interface for accessing and managing user phone data.
    /// </summary>
    public interface IPhoneRepository
    {
        #region User Phone Methods

        /// <summary>
        ///     Get all user phones.
        /// </summary>
        /// <returns></returns>
        List<UserPhone> GetUserPhones();

        /// <summary>
        ///     Get user phones by user ID.
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <returns></returns>
        List<UserPhone> GetUserPhonesByUserId(int userId);

        /// <summary>
        ///     Get a user phone by ID.
        /// </summary>
        /// <param name="id">The ID of the user phone</param>
        /// <returns></returns>
        UserPhone GetUserPhone(int id);

        /// <summary>
        ///     Update an existing user phone.
        /// </summary>
        /// <param name="updatedUserPhone">The updated user phone object</param>
        void UpdateUserPhone(UserPhone updatedUserPhone);

        /// <summary>
        ///     Add a new user phone.
        /// </summary>
        /// <param name="userPhone">The user phone to be added</param>
        void AddUserPhone(UserPhone userPhone);

        /// <summary>
        ///     Add a new user phone for registration.
        /// </summary>
        /// <param name="userPhone">The user phone for registration</param>
        void AddUserPhoneRegister(UserPhone userPhone);

        /// <summary>
        ///     Delete a user phone by ID.
        /// </summary>
        /// <param name="id">The ID of the user phone to delete</param>
        void DeleteUserPhone(int id);

        #endregion

        #region Phone Type Methods

        /// <summary>
        ///     Get all phone types.
        /// </summary>
        /// <returns></returns>
        List<PhoneType> GetPhoneTypes();

        /// <summary>
        ///     Get a phone type by ID.
        /// </summary>
        /// <param name="id">The ID of the phone type</param>
        /// <returns></returns>
        PhoneType GetPhoneType(int id);

        /// <summary>
        ///     Update an existing phone type.
        /// </summary>
        /// <param name="updatedPhoneType">The updated phone type object</param>
        void UpdatePhoneType(PhoneType updatedPhoneType);

        /// <summary>
        ///     Add a new phone type.
        /// </summary>
        /// <param name="eventPhoneType">The phone type to be added</param>
        void AddPhoneType(PhoneType eventPhoneType);

        /// <summary>
        ///     Delete a phone type by ID.
        /// </summary>
        /// <param name="id">The ID of the phone type to delete</param>
        void DeletePhoneType(int id);

        #endregion
    }
}