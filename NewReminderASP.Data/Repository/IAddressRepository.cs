using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Interface for accessing and managing address data.
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        ///     Get all addresses.
        /// </summary>
        /// <returns></returns>
        List<Address> GetAddresses();

        /// <summary>
        ///     Get addresses associated with a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user for whom addresses are to be retrieved</param>
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
        ///     Update an existing address.
        /// </summary>
        /// <param name="updatedAddress">The updated address object</param>
        void UpdateAddress(Address updatedAddress);

        /// <summary>
        ///     Add a new address.
        /// </summary>
        /// <param name="address">The address to be added</param>
        void AddAddress(Address address);

        /// <summary>
        ///     Add a new address during user registration.
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