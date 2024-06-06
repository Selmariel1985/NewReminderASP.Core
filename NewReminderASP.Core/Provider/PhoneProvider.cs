using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Provider class for handling phone-related operations.
    /// </summary>
    public class PhoneProvider : IPhoneProvider
    {
        private readonly IPhoneRepository _phoneRepository;

        /// <summary>
        /// Constructor for PhoneProvider.
        /// </summary>
        /// <param name="phoneRepository">The repository for accessing phone data</param>
        public PhoneProvider(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        /// <summary>
        /// Get all user phones.
        /// </summary>
        public List<UserPhone> GetUserPhones()
        {
            return _phoneRepository.GetUserPhones().ToList();
        }

        /// <summary>
        /// Get user phones by user ID.
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        public List<UserPhone> GetUserPhonesByUserId(int userId)
        {
            return _phoneRepository.GetUserPhonesByUserId(userId).ToList();
        }

        /// <summary>
        /// Get a user phone by ID.
        /// </summary>
        /// <param name="id">The ID of the user phone</param>
        public UserPhone GetUserPhone(int id)
        {
            return _phoneRepository.GetUserPhone(id);
        }

        /// <summary>
        /// Update an existing user phone.
        /// </summary>
        /// <param name="updatedUserPhone">The updated user phone object</param>
        public void UpdateUserPhone(UserPhone updatedUserPhone)
        {
            _phoneRepository.UpdateUserPhone(updatedUserPhone);
        }

        /// <summary>
        /// Add a new user phone.
        /// </summary>
        /// <param name="userPhone">The user phone to be added</param>
        public void AddUserPhone(UserPhone userPhone)
        {
            _phoneRepository.AddUserPhone(userPhone);
        }

        /// <summary>
        /// Add a new user phone for registration.
        /// </summary>
        /// <param name="userPhone">The user phone for registration</param>
        public void AddUserPhoneRegister(UserPhone userPhone)
        {
            _phoneRepository.AddUserPhoneRegister(userPhone);
        }

        /// <summary>
        /// Delete a user phone by ID.
        /// </summary>
        /// <param name="id">The ID of the user phone to delete</param>
        public void DeleteUserPhone(int id)
        {
            _phoneRepository.DeleteUserPhone(id);
        }

        /// <summary>
        /// Get all phone types.
        /// </summary>
        public List<PhoneType> GetPhoneTypes()
        {
            return _phoneRepository.GetPhoneTypes().ToList();
        }

        /// <summary>
        /// Get a phone type by ID.
        /// </summary>
        /// <param name="id">The ID of the phone type</param>
        public PhoneType GetPhoneType(int id)
        {
            return _phoneRepository.GetPhoneType(id);
        }

        /// <summary>
        /// Update an existing phone type.
        /// </summary>
        /// <param name="updatedPhoneType">The updated phone type object</param>
        public void UpdatePhoneType(PhoneType updatedPhoneType)
        {
            _phoneRepository.UpdatePhoneType(updatedPhoneType);
        }

        /// <summary>
        /// Add a new phone type.
        /// </summary>
        /// <param name="eventPhoneType">The phone type to be added</param>
        public void AddPhoneType(PhoneType eventPhoneType)
        {
            _phoneRepository.AddPhoneType(eventPhoneType);
        }

        /// <summary>
        /// Delete a phone type by ID.
        /// </summary>
        /// <param name="id">The ID of the phone type to delete</param>
        public void DeletePhoneType(int id)
        {
            _phoneRepository.DeletePhoneType(id);
        }
    }
}
