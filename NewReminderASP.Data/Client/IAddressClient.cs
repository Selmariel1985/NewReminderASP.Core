using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    ///     Interface for interacting with address data.
    /// </summary>
    public interface IAddressClient
    {
        /// <summary>
        ///     Retrieve a list of all addresses.
        /// </summary>
        /// <returns></returns>
        List<Address> GetAddresses();

        /// <summary>
        ///     Retrieve a list of addresses associated with a specific user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Address> GetAddressesByUserId(int userId);

        /// <summary>
        ///     Retrieve an individual address by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Address GetAddress(int id);

        /// <summary>
        ///     Retrieve an address by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Address GetAddressByID(int id);

        /// <summary>
        ///     Update an existing address with new information.
        /// </summary>
        /// <param name="updatedAddress"></param>
        void UpdateAddress(Address updatedAddress);

        /// <summary>
        ///     Add a new address.
        /// </summary>
        /// <param name="newAddress"></param>
        void AddAddress(Address newAddress);

        /// <summary>
        ///     Add a new address registration.
        /// </summary>
        /// <param name="address"></param>
        void AddAddressRegister(Address address);

        /// <summary>
        ///     Delete the address with the specified ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteAddress(int id);
    }
}