using System.Collections.Generic;
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

        public List<Address> GetAddressesByUserId(int userId)
        {
            return _addressRepository.GetAddressesByUserId(userId).ToList();
        }

        public Address GetAddress(int id)
        {
            return _addressRepository.GetAddress(id);
        }

        public Address GetAddressByID(int id)
        {
            return _addressRepository.GetAddressByID(id);
        }

        public void UpdateAddress(Address updatedAddress)
        {
            _addressRepository.UpdateAddress(updatedAddress);
        }

        public void AddAddress(Address address)
        {
            _addressRepository.AddAddress(address);
        }

        public void AddAddressRegister(Address address)
        {
            _addressRepository.AddAddressRegister(address);
        }

        public void DeleteAddress(int id)
        {
            _addressRepository.DeleteAddress(id);
        }
    }
}