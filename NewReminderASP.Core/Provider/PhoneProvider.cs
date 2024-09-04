using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Provider class for handling phone-related operations.
    /// </summary>
    public class PhoneProvider : IPhoneProvider
    {
        private readonly IPhoneRepository _phoneRepository;

        /// <summary>
        ///     Constructor for PhoneProvider.
        /// </summary>
        /// <param name="phoneRepository"></param>
        public PhoneProvider(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        /// <summary>
        ///     Get all user phones.
        /// </summary>
        /// <returns></returns>
        public List<UserPhone> GetUserPhones()
        {
            return _phoneRepository.GetUserPhones().ToList();
        }

        /// <summary>
        ///     Get user phones by user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserPhone> GetUserPhonesByUserId(int userId)
        {
            return _phoneRepository.GetUserPhonesByUserId(userId).ToList();
        }

        /// <summary>
        ///     Get a user phone by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserPhone GetUserPhone(int id)
        {
            return _phoneRepository.GetUserPhone(id);
        }

        /// <summary>
        ///     Update an existing user phone.
        /// </summary>
        /// <param name="updatedUserPhone"></param>
        public void UpdateUserPhone(UserPhone updatedUserPhone)
        {
            _phoneRepository.UpdateUserPhone(updatedUserPhone);
        }

        /// <summary>
        ///     Add a new user phone.
        /// </summary>
        /// <param name="userPhone"></param>
        public void AddUserPhone(UserPhone userPhone)
        {
            _phoneRepository.AddUserPhone(userPhone);
        }

        /// <summary>
        ///     Add a new user phone for registration.
        /// </summary>
        /// <param name="userPhone"></param>
        public void AddUserPhoneRegister(UserPhone userPhone)
        {
            _phoneRepository.AddUserPhoneRegister(userPhone);
        }

        /// <summary>
        ///     Delete a user phone by ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUserPhone(int id)
        {
            _phoneRepository.DeleteUserPhone(id);
        }

        /// <summary>
        ///     Get all phone types.
        /// </summary>
        /// <returns></returns>
        public List<PhoneType> GetPhoneTypes()
        {
            return _phoneRepository.GetPhoneTypes().ToList();
        }

        /// <summary>
        ///     Get a phone type by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhoneType GetPhoneType(int id)
        {
            return _phoneRepository.GetPhoneType(id);
        }

        /// <summary>
        ///     Update an existing phone type.
        /// </summary>
        /// <param name="updatedPhoneType"></param>
        public void UpdatePhoneType(PhoneType updatedPhoneType)
        {
            _phoneRepository.UpdatePhoneType(updatedPhoneType);
        }

        /// <summary>
        ///     Add a new phone type.
        /// </summary>
        /// <param name="eventPhoneType"></param>
        public void AddPhoneType(PhoneType eventPhoneType)
        {
            _phoneRepository.AddPhoneType(eventPhoneType);
        }

        /// <summary>
        ///     Delete a phone type by ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeletePhoneType(int id)
        {
            _phoneRepository.DeletePhoneType(id);
        }
    }
}