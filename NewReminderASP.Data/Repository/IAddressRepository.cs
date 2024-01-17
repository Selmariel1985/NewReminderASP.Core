using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public interface IAddressRepository

    {
        List<Address> GetAddresses();


        Address GetAddress(int id);


        void UpdateCountry(Address updatedAddress);

        void AddAddress(Address address);

        void DeleteAddress(int id);
    }
}