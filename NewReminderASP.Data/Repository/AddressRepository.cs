using System.Collections.Generic;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    /// Repository for interacting with address data through the address client.
    /// </summary>
    internal class AddressRepository : IAddressRepository
    {
        private readonly IAddressClient _addressClient;

        public AddressRepository(IAddressClient addressClient)
        {
            _addressClient = addressClient;
        }

        /// <summary>
        /// Retrieve a list of all addresses.
        /// </summary>
        public List<Address> GetAddresses()
        {
            return _addressClient.GetAddresses();
        }

        /// <summary>
        /// Retrieve a list of addresses associated with a specific user ID.
        /// </summary>
        public List<Address> GetAddressesByUserId(int userId)
        {
            return _addressClient.GetAddressesByUserId(userId);
        }

        /// <summary>
        /// Retrieve an individual address by its ID.
        /// </summary>
        public Address GetAddress(int id)
        {
            return _addressClient.GetAddress(id);
        }

        /// <summary>
        /// Retrieve an address by its ID.
        /// </summary>
        public Address GetAddressByID(int id)
        {
            return _addressClient.GetAddressByID(id);
        }

        /// <summary>
        /// Update an existing address with new information.
        /// </summary>
        public void UpdateAddress(Address updatedAddress)
        {
            _addressClient.UpdateAddress(updatedAddress);
        }

        /// <summary>
        /// Add a new address.
        /// </summary>
        public void AddAddress(Address address)
        {
            _addressClient.AddAddress(address);
        }

        /// <summary>
        /// Add a new address registration.
        /// </summary>
        public void AddAddressRegister(Address address)
        {
            _addressClient.AddAddressRegister(address);
        }

        /// <summary>
        /// Delete the address with the specified ID.
        /// </summary>
        public void DeleteAddress(int id)
        {
            _addressClient.DeleteAddress(id);
        }
    }
}
