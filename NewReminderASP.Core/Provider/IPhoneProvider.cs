using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

namespace NewReminderASP.Core.Provider
{
    public interface IPhoneProvider
    {
        List<UserPhone> GetUserPhones();

        UserPhone GetUserPhone(int id);

        void UpdateUserPhone(UserPhone updatedUserPhone);
        void AddUserPhone(UserPhone userPhone);
        void AddUserPhoneRegister(UserPhone userPhone);
        void DeleteUserPhone(int id);

        List<PhoneType> GetPhoneTypes();

        PhoneType GetPhoneType(int id);

        void UpdatePhoneType(PhoneType updatedPhoneType);
        void AddPhoneType(PhoneType eventPhoneType);
        void DeletePhoneType(int id);
    }
}