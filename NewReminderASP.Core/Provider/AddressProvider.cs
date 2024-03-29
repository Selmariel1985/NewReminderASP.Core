﻿using System.Collections.Generic;
using System.Linq;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    public class AddressProvider : IAddressProvider
    {
        private readonly IAddressRepository _addressRepository;

        public AddressProvider(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public List<Address> GetAddresses()
        {
            return _addressRepository.GetAddresses().ToList();
        }

        public Address GetAddress(int id)
        {
            return _addressRepository.GetAddress(id);
        }

        public void UpdateCountry(Address updatedAddress)
        {
            _addressRepository.UpdateCountry(updatedAddress);
        }

        public void AddAddress(Address address)
        {
            _addressRepository.AddAddress(address);
        }

        public void DeleteAddress(int id)
        {
            _addressRepository.DeleteAddress(id);
        }
    }
}