using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Interface for providing address-related functionality.
    /// </summary>
    public interface IAddressProvider
    {
        /// <summary>
        /// Get a list of all addresses.
        /// </summary>
        List<Address> GetAddresses();

        /// <summary>
        /// Get addresses associated with a specific user ID.
        /// </summary>
        List<Address> GetAddressesByUserId(int userId);

        /// <summary>
        /// Get an address by its ID.
        /// </summary>
        Address GetAddress(int id);

        /// <summary>
        /// Get an address by its ID.
        /// </summary>
        Address GetAddressByID(int id);

        /// <summary>
        /// Update the provided address information.
        /// </summary>
        void UpdateAddress(Address updatedAddress);

        /// <summary>
        /// Add a new address.
        /// </summary>
        void AddAddress(Address address);

        /// <summary>
        /// Add a new address during registration.
        /// </summary>
        void AddAddressRegister(Address address);

        /// <summary>
        /// Delete an address by its ID.
        /// </summary>
        void DeleteAddress(int id);
    }
}