using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    public interface IAddressProvider


    {
        List<Address> GetAddresses();


        Address GetAddress(int id);


        void UpdateCountry(Address updatedAddress);

        void AddAddress(Address address);
        void AddAddressRegister(Address address);

        void DeleteAddress(int id);
    }
}