using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    [ServiceContract]
    public interface IPhoneService
    {
        [OperationContract]
        List<UserPhoneDto> GetUserPhones();

        [OperationContract]
        UserPhoneDto GetUserPhone(int id);

        [OperationContract]
        void UpdateUserPhone(UserPhoneDto updatedUserPhone);

        [OperationContract]
        void AddUserPhone(UserPhoneDto userPhone);

        [OperationContract]
        void AddUserPhoneRegister(UserPhoneDto userPhone);

        [OperationContract]
        void DeleteUserPhone(int id);

        [OperationContract]
        List<PhoneTypeDto> GetPhoneTypes();

        [OperationContract]
        PhoneTypeDto GetPhoneType(int id);

        [OperationContract]
        void UpdatePhoneType(PhoneTypeDto updatedPhoneType);

        [OperationContract]
        void AddPhoneType(PhoneTypeDto eventPhoneType);

        [OperationContract]
        void DeletePhoneType(int id);
    }
}