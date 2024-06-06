using System.Collections.Generic;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Provider class for address-related functionality by interacting with the address repository.
    /// </summary>
    public class AddressProvider : IAddressProvider
    {
        private readonly IAddressRepository _addressRepository;

        public AddressProvider(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Get a list of all addresses.
        /// </summary>
        public List<Address> GetAddresses()
        {
            return _addressRepository.GetAddresses();
        }

        /// <summary>
        /// Get addresses associated with a specific user ID.
        /// </summary>
        public List<Address> GetAddressesByUserId(int userId)
        {
            return _addressRepository.GetAddressesByUserId(userId);
        }

        /// <summary>
        /// Get an address by its ID.
        /// </summary>
        public Address GetAddress(int id)
        {
            return _addressRepository.GetAddress(id);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public Address GetAddressByID(int id)
        {
            return _addressRepository.GetAddressByID(id);
        }

        /// <summary>
        /// Update the provided address information.
        /// </summary>
        public void UpdateAddress(Address updatedAddress)
        {
            _addressRepository.UpdateAddress(updatedAddress);
        }

        /// <summary>
        /// Add a new address.
        /// </summary>
        public void AddAddress(Address address)
        {
            _addressRepository.AddAddress(address);
        }

        /// <summary>
        /// Add a new address during registration.
        /// </summary>
        public void AddAddressRegister(Address address)
        {
            _addressRepository.AddAddressRegister(address);
        }

        /// <summary>
        /// Delete an address by its ID.
        /// </summary>
        public void DeleteAddress(int id)
        {
            _addressRepository.DeleteAddress(id);
        }
    }
}
