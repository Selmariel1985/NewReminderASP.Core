using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Interface for providing phone-related functionality.
    /// </summary>
    public interface IPhoneProvider
    {
        // User Phones

        /// <summary>
        /// Get a list of all user phones.
        /// </summary>
        List<UserPhone> GetUserPhones();

        /// <summary>
        /// Get user phones by user ID.
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        List<UserPhone> GetUserPhonesByUserId(int userId);

        /// <summary>
        /// Get a user phone by ID.
        /// </summary>
        /// <param name="id">The ID of the user phone</param>
        UserPhone GetUserPhone(int id);

        /// <summary>
        /// Update an existing user phone.
        /// </summary>
        /// <param name="updatedUserPhone">The updated user phone object</param>
        void UpdateUserPhone(UserPhone updatedUserPhone);

        /// <summary>
        /// Add a new user phone.
        /// </summary>
        /// <param name="userPhone">The user phone to be added</param>
        void AddUserPhone(UserPhone userPhone);

        /// <summary>
        /// Add a new user phone for registration.
        /// </summary>
        /// <param name="userPhone">The user phone for registration</param>
        void AddUserPhoneRegister(UserPhone userPhone);

        /// <summary>
        /// Delete a user phone by ID.
        /// </summary>
        /// <param name="id">The ID of the user phone to delete</param>
        void DeleteUserPhone(int id);

        // Phone Types

        /// <summary>
        /// Get a list of all phone types.
        /// </summary>
        List<PhoneType> GetPhoneTypes();

        /// <summary>
        /// Get a phone type by ID.
        /// </summary>
        /// <param name="id">The ID of the phone type</param>
        PhoneType GetPhoneType(int id);

        /// <summary>
        /// Update an existing phone type.
        /// </summary>
        /// <param name="updatedPhoneType">The updated phone type object</param>
        void UpdatePhoneType(PhoneType updatedPhoneType);

        /// <summary>
        /// Add a new phone type.
        /// </summary>
        /// <param name="eventPhoneType">The phone type to be added</param>
        void AddPhoneType(PhoneType eventPhoneType);

        /// <summary>
        /// Delete a phone type by ID.
        /// </summary>
        /// <param name="id">The ID of the phone type to delete</param>
        void DeletePhoneType(int id);
    }
}
