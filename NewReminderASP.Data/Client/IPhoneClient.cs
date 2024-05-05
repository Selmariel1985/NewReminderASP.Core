using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    public interface IPhoneClient
    {
        List<UserPhone> GetUserPhones();

        List<UserPhone> GetUserPhonesByUserId(int userId);

        UserPhone GetUserPhone(int id);

        void UpdateUserPhone(UserPhone updatedUserPhone);
        void AddUserPhone(UserPhone userPhone);
        void DeleteUserPhone(int id);

        List<PhoneType> GetPhoneTypes();

        PhoneType GetPhoneType(int id);

        void UpdatePhoneType(PhoneType updatedPhoneType);
        void AddPhoneType(PhoneType eventPhoneType);
        void DeletePhoneType(int id);
        void AddUserPhoneRegister(UserPhone userPhone);
    }
}