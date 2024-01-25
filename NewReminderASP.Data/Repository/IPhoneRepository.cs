using NewReminderASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewReminderASP.Data.Repository
{
    public interface IPhoneRepository
    {
        List<UserPhone> GetUserPhones();

        UserPhone GetUserPhone(int id);

        void UpdateUserPhone(UserPhone updatedUserPhone);
        void AddUserPhone(UserPhone userPhone);
        void DeleteUserPhone(int id);

        List<PhoneType> GetPhoneTypes();

        PhoneType GetPhoneType(int id);

        void UpdatePhoneType(PhoneType updatedPhoneType);
        void AddPhoneType(PhoneType eventPhoneType);
        void DeletePhoneType(int id);
    }
}
