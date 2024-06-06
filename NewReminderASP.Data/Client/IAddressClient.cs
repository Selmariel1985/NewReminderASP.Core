using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    /// Interface for interacting with address data.
    /// </summary>
    public interface IAddressClient
    {
        /// <summary>
        /// Retrieve a list of all addresses.
        /// </summary>
        List<Address> GetAddresses();

        /// <summary>
        /// Retrieve a list of addresses associated with a specific user ID.
        /// </summary>
        List<Address> GetAddressesByUserId(int userId);

        /// <summary>
        /// Retrieve an individual address by its ID.
        /// </summary>
        Address GetAddress(int id);

        /// <summary>
        /// Retrieve an address by its ID.
        /// </summary>
        Address GetAddressByID(int id);

        /// <summary>
        /// Update an existing address with new information.
        /// </summary>
        void UpdateAddress(Address updatedAddress);

        /// <summary>
        /// Add a new address.
        /// </summary>
        void AddAddress(Address newAddress);

        /// <summary>
        /// Add a new address registration.
        /// </summary>
        void AddAddressRegister(Address address);

        /// <summary>
        /// Delete the address with the specified ID.
        /// </summary>
        void DeleteAddress(int id);
    }
}