using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    /// Service contract for address-related operations.
    /// </summary>
    [ServiceContract]
    public interface IAddressService
    {
        /// <summary>
        /// Get a list of all addresses.
        /// </summary>
        [OperationContract]
        List<AddressDto> GetAddresses();

        /// <summary>
        /// Get an address by its ID.
        /// </summary>
        [OperationContract]
        AddressDto GetAddress(int id);

        /// <summary>
        /// Get an address by its ID.
        /// </summary>
        [OperationContract]
        AddressDto GetAddressByID(int id);

        /// <summary>
        /// Get addresses associated with a specific user ID.
        /// </summary>
        [OperationContract]
        List<AddressDto> GetAddressesByUserId(int userId);

        /// <summary>
        /// Update the provided address information.
        /// </summary>
        [OperationContract]
        void UpdateAddress(AddressDto updatedAddress);

        /// <summary>
        /// Add a new address.
        /// </summary>
        [OperationContract]
        void AddAddress(AddressDto address);

        /// <summary>
        /// Add a new address during registration.
        /// </summary>
        [OperationContract]
        void AddAddressRegister(AddressDto address);

        /// <summary>
        /// Delete an address by its ID.
        /// </summary>
        [OperationContract]
        void DeleteAddress(int id);
    }
}