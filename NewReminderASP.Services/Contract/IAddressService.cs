﻿using NewReminderASP.Services.Dtos;
using System.Collections.Generic;
using System.ServiceModel;

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

        List<AddressDto> GetAddressesByUserId(int userId);

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