using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    [ServiceContract]
    public interface IAddressService

    {
        [OperationContract]
        List<AddressDto> GetAddresses();

        [OperationContract]
        AddressDto GetAddress(int id);
        [OperationContract]
        AddressDto GetAddressByID(int id);

        [OperationContract]
        void UpdateAddress(AddressDto updatedAddress);

        [OperationContract]
        void AddAddress(AddressDto address);

        [OperationContract]
        void AddAddressRegister(AddressDto address);

        [OperationContract]
        void DeleteAddress(int id);
    }
}