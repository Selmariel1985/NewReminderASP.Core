using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Interface for providing address-related functionality.
    /// </summary>
    public interface IAddressProvider
    {
        /// <summary>
        ///     Get a list of all addresses.
        /// </summary>
        /// <returns></returns>
        List<Address> GetAddresses();

        /// <summary>
        ///     Get addresses associated with a specific user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Address> GetAddressesByUserId(int userId);

        /// <summary>
        ///     Get an address by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Address GetAddress(int id);

        /// <summary>
        ///     Get an address by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Address GetAddressByID(int id);

        /// <summary>
        ///     Update the provided address information.
        /// </summary>
        /// <param name="updatedAddress"></param>
        void UpdateAddress(Address updatedAddress);

        /// <summary>
        ///     Add a new address.
        /// </summary>
        /// <param name="address"></param>
        void AddAddress(Address address);

        /// <summary>
        ///     Add a new address during registration.
        /// </summary>
        /// <param name="address"></param>
        void AddAddressRegister(Address address);

        /// <summary>
        ///     Delete an address by its ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteAddress(int id);
    }
}