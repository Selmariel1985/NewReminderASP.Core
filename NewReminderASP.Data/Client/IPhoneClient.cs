using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    /// Interface for interacting with phone-related data.
    /// </summary>
    public interface IPhoneClient
    {
        // User phone methods
        List<UserPhone> GetUserPhones();
        List<UserPhone> GetUserPhonesByUserId(int userId);
        UserPhone GetUserPhone(int id);
        void UpdateUserPhone(UserPhone updatedUserPhone);
        void AddUserPhone(UserPhone userPhone);
        void DeleteUserPhone(int id);
        void AddUserPhoneRegister(UserPhone userPhone);

        // Phone type methods
        List<PhoneType> GetPhoneTypes();
        PhoneType GetPhoneType(int id);
        void UpdatePhoneType(PhoneType updatedPhoneType);
        void AddPhoneType(PhoneType eventPhoneType);
        void DeletePhoneType(int id);
    }
}