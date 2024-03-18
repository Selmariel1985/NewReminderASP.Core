using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

namespace NewReminderASP.Data.Client
{
    public interface IAddressClient
    {
        List<Address> GetAddresses();


        Address GetAddress(int id);

        Address GetAddressByID(int id);
        void UpdateAddress(Address updatedAddress);

        void AddAddress(Address newAddress);
        void AddAddressRegister(Address address);

        void DeleteAddress(int id);
    }
}