using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NewReminderASP.Core.Provider
{
    public class PhoneProvider : IPhoneProvider
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneProvider(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public List<UserPhone> GetUserPhones()
        {
            return _phoneRepository.GetUserPhones().ToList();
        }

        public UserPhone GetUserPhone(int id)
        {
            return _phoneRepository.GetUserPhone(id);
        }

        public void UpdateUserPhone(UserPhone updatedUserPhone)
        {
            _phoneRepository.UpdateUserPhone(updatedUserPhone);
        }

        public void AddUserPhone(UserPhone userPhone)
        {
            _phoneRepository.AddUserPhone(userPhone);
        }

        public void AddUserPhoneRegister(UserPhone userPhone)
        {
            _phoneRepository.AddUserPhoneRegister(userPhone);
        }

        public void DeleteUserPhone(int id)
        {
            _phoneRepository.DeleteUserPhone(id);
        }

        public List<PhoneType> GetPhoneTypes()
        {
            return _phoneRepository.GetPhoneTypes().ToList();
        }

        public PhoneType GetPhoneType(int id)
        {
            return _phoneRepository.GetPhoneType(id);
        }

        public void UpdatePhoneType(PhoneType updatedPhoneType)
        {
            _phoneRepository.UpdatePhoneType(updatedPhoneType);
        }

        public void AddPhoneType(PhoneType eventPhoneType)
        {
            _phoneRepository.AddPhoneType(eventPhoneType);
        }

        public void DeletePhoneType(int id)
        {
            _phoneRepository.DeletePhoneType(id);
        }
    }
}