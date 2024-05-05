using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    public interface IAddressProvider


    {
        List<Address> GetAddresses();

        List<Address> GetAddressesByUserId(int userId);


        Address GetAddress(int id);

        Address GetAddressByID(int id);
        void UpdateAddress(Address updatedAddress);

        void AddAddress(Address address);
        void AddAddressRegister(Address address);

        void DeleteAddress(int id);
    }
}