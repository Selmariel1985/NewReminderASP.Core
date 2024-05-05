using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public interface IAddressRepository

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