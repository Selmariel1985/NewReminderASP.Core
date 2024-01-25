using NewReminderASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewReminderASP.Data.Client;

namespace NewReminderASP.Data.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly IPhoneClient _phoneClient;
        public PhoneRepository(IPhoneClient phoneClient)
        {
            _phoneClient = phoneClient;
        }

        public List<UserPhone> GetUserPhones()
        {
            return _phoneClient.GetUserPhones().ToList();
        }

        public UserPhone GetUserPhone(int id)
        {
            return _phoneClient.GetUserPhone(id);
        }

        public void UpdateUserPhone(UserPhone updatedUserPhone)
        {
            _phoneClient.UpdateUserPhone(updatedUserPhone);
        }

        public void AddUserPhone(UserPhone userPhone)
        {
            _phoneClient.AddUserPhone(userPhone);
        }

        public void DeleteUserPhone(int id)
        {
            _phoneClient.DeleteUserPhone(id);
        }

        public List<PhoneType> GetPhoneTypes()
        {
            return _phoneClient.GetPhoneTypes().ToList();
        }

        public PhoneType GetPhoneType(int id)
        {
            return _phoneClient.GetPhoneType(id);
        }

        public void UpdatePhoneType(PhoneType updatedPhoneType)
        {
            _phoneClient.UpdatePhoneType(updatedPhoneType);
        }

        public void AddPhoneType(PhoneType eventPhoneType)
        {
            _phoneClient.AddPhoneType(eventPhoneType);
        }

        public void DeletePhoneType(int id)
        {
            _phoneClient.DeletePhoneType(id);
        }
    }
}
