using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    public interface IAddressClient
    {
        List<Address> GetAddresses();


        Address GetAddress(int id);


        void UpdateCountry(Address updatedAddress);

        void AddAddress(Address newAddress);

        void DeleteAddress(int id);
    }
}