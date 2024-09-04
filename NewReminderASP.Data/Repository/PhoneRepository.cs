using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Repository class for managing phone-related entities.
    /// </summary>
    public class PhoneRepository : IPhoneRepository
    {
        private readonly IPhoneClient _phoneClient;

        /// <summary>
        ///     Constructor for PhoneRepository.
        /// </summary>
        /// <param name="phoneClient">The client for accessing phone data</param>
        public PhoneRepository(IPhoneClient phoneClient)
        {
            _phoneClient = phoneClient;
        }

        /// <summary>
        ///     Get all user phones.
        /// </summary>
        /// <returns></returns>
        public List<UserPhone> GetUserPhones()
        {
            return _phoneClient.GetUserPhones().ToList();
        }

        /// <summary>
        ///     Get user phones by user ID.
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <returns></returns>
        public List<UserPhone> GetUserPhonesByUserId(int userId)
        {
            return _phoneClient.GetUserPhonesByUserId(userId).ToList();
        }

        /// <summary>
        ///     Get a user phone by ID.
        /// </summary>
        /// <param name="id">The ID of the user phone</param>
        /// <returns></returns>
        public UserPhone GetUserPhone(int id)
        {
            return _phoneClient.GetUserPhone(id);
        }

        /// <summary>
        ///     Update an existing user phone.
        /// </summary>
        /// <param name="updatedUserPhone">The updated user phone object</param>
        public void UpdateUserPhone(UserPhone updatedUserPhone)
        {
            _phoneClient.UpdateUserPhone(updatedUserPhone);
        }

        /// <summary>
        ///     Add a new user phone.
        /// </summary>
        /// <param name="userPhone">The user phone to be added</param>
        public void AddUserPhone(UserPhone userPhone)
        {
            _phoneClient.AddUserPhone(userPhone);
        }

        /// <summary>
        ///     Add a new user phone for registration.
        /// </summary>
        /// <param name="userPhone">The user phone for registration</param>
        public void AddUserPhoneRegister(UserPhone userPhone)
        {
            _phoneClient.AddUserPhoneRegister(userPhone);
        }

        /// <summary>
        ///     Delete a user phone by ID.
        /// </summary>
        /// <param name="id">The ID of the user phone to delete</param>
        public void DeleteUserPhone(int id)
        {
            _phoneClient.DeleteUserPhone(id);
        }

        /// <summary>
        ///     Get all phone types.
        /// </summary>
        /// <returns></returns>
        public List<PhoneType> GetPhoneTypes()
        {
            return _phoneClient.GetPhoneTypes().ToList();
        }

        /// <summary>
        ///     /// Get a phone type by ID.
        /// </summary>
        /// <param name="id">The ID of the phone type</param>
        /// <returns></returns>
        public PhoneType GetPhoneType(int id)
        {
            return _phoneClient.GetPhoneType(id);
        }

        /// <summary>
        ///     Update an existing phone type.
        /// </summary>
        /// <param name="updatedPhoneType">The updated phone type object</param>
        public void UpdatePhoneType(PhoneType updatedPhoneType)
        {
            _phoneClient.UpdatePhoneType(updatedPhoneType);
        }

        /// <summary>
        ///     Add a new phone type.
        /// </summary>
        /// <param name="eventPhoneType">The phone type to be added</param>
        public void AddPhoneType(PhoneType eventPhoneType)
        {
            _phoneClient.AddPhoneType(eventPhoneType);
        }

        /// <summary>
        ///     Delete a phone type by ID.
        /// </summary>
        /// <param name="id">The ID of the phone type to delete</param>
        public void DeletePhoneType(int id)
        {
            _phoneClient.DeletePhoneType(id);
        }
    }
}