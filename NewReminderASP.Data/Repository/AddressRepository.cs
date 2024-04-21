﻿using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NewReminderASP.Data.Repository
{
    internal class AddressRepository : IAddressRepository
    {
        private readonly IAddressClient _addressClient;

        public AddressRepository(IAddressClient addressClient)
        {
            _addressClient = addressClient;
        }

        public List<Address> GetAddresses()
        {
            return _addressClient.GetAddresses().ToList();
        }

        public List<Address> GetAddressesByUserId(int userId)
        {
            return _addressClient.GetAddressesByUserId(userId).ToList();
        }

        public Address GetAddress(int id)
        {
            return _addressClient.GetAddress(id);
        }

        public Address GetAddressByID(int id)
        {
            return _addressClient.GetAddressByID(id); ;
        }

        public void UpdateAddress(Address updatedAddress)
        {
            _addressClient.UpdateAddress(updatedAddress);
        }

        public void AddAddress(Address address)
        {
            _addressClient.AddAddress(address);
        }

        public void AddAddressRegister(Address address)
        {
            _addressClient.AddAddressRegister(address);
        }

        public void DeleteAddress(int id)
        {
            _addressClient.DeleteAddress(id);
        }
    }
}