using System;
using System.Collections.Generic;
using System.Web; // Import for accessing HttpContext
using log4net;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    /// Client class for interacting with the address service.
    /// </summary>
    public class AddressClient : IAddressClient

    {

        /// <summary>
        /// Method to get a list of addresses based on the user's role and login.
        /// </summary>
        public List<Address> GetAddresses()
        {
            var addresses = new List<Address>(); // Create a list to store Address objects
            var currentUserLogin = HttpContext.Current.User.Identity.Name; // Get the current user's login
            var isAdmin = HttpContext.Current.User.IsInRole("admin"); // Check for admin role

            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open(); // Establish a connection to the service

                    var result = connection.GetAddresses(); // Get a list of addresses from the service

                    if (result != null)
                    {
                        foreach (var addressDto in result)
                        {
                            // Check for admin role or matching login
                            if (isAdmin || addressDto.Login == currentUserLogin)
                            {
                                addresses.Add(new Address
                                {
                                    ID = addressDto.ID,
                                    Street = addressDto.Street,
                                    City = addressDto.City,
                                    CountryName = addressDto.CountryName,
                                    PostalCode = addressDto.PostalCode,
                                    Description = addressDto.Description,
                                    Login = addressDto.Login,
                                    UserID = addressDto.UserID
                                });
                            }
                        }
                    }

                    connection.Close(); // Close the connection to the service
                }
                catch (Exception ex)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", ex); // Log the error
                    throw; // Throw the exception further
                }
            }

            return addresses; // Return the list of addresses
        }




        /// <summary>
        /// Method to retrieve addresses based on a specific user ID.
        /// </summary>
        /// <param name="userId">The user ID to filter addresses by.</param>
        /// <returns>A list of addresses filtered by the specified user ID.</returns>
        public List<Address> GetAddressesByUserId(int userId)
        {
            var addresses = new List<Address>(); // Create a list to store Address objects

            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetAddressesByUserId(userId); // Retrieve addresses by user ID

                    if (result != null)
                    {
                        foreach (var addressDto in result)
                        {
                            var address = new Address
                            {
                                ID = addressDto.ID,
                                Street = addressDto.Street,
                                City = addressDto.City,
                                CountryName = addressDto.CountryName,
                                PostalCode = addressDto.PostalCode,
                                Description = addressDto.Description,
                                UserID = addressDto.UserID,
                                Login = addressDto.Login
                            };
                            addresses.Add(address); // Add Address object to the list
                        }
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception ex)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", ex); // Log the error
                    throw; // Re-throw the exception
                }
            }

            return addresses; // Return the list of Address objects
        }

        /// <summary>
        /// Method to retrieve an address by its ID.
        /// </summary>
        /// <param name="id">The ID of the address to retrieve.</param>
        /// <returns>The address corresponding to the specified ID, or null if not found.</returns>
        public Address GetAddress(int id)
        {
            Address address = null; // Initialize the address variable as null

            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetAddress(id); // Retrieve the address by its ID

                    if (result != null)
                    {
                        address = new Address
                        {
                            ID = result.ID,
                            Street = result.Street,
                            City = result.City,
                            CountryName = result.CountryName,
                            PostalCode = result.PostalCode,
                            Description = result.Description,
                            Login = result.Login,
                            UserID = result.UserID
                        };
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Re-throw the exception
                }
            }

            return address; // Return the address
        }

        /// <summary>
        /// Retrieves an address by its ID from the address service.
        /// </summary>
        /// <param name="id">The ID of the address to retrieve.</param>
        /// <returns>The address object corresponding to the specified ID, or null if not found.</returns>
        public Address GetAddressByID(int id)
        {
            Address address = null; // Initialize the address variable as null

            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetAddressByID(id); // Retrieve the address by its ID

                    if (result != null)
                    {
                        // Create a new Address object with data from the result
                        address = new Address
                        {
                            ID = result.ID,
                            Street = result.Street,
                            City = result.City,
                            CountryID = result.CountryID,
                            PostalCode = result.PostalCode,
                            Description = result.Description,
                            Login = result.Login,
                            UserID = result.UserID
                        };
                    }

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Re-throw the exception
                }
            }

            return address; // Return the address object
        }


        /// <summary>
        /// Updates the specified address in the address service.
        /// </summary>
        /// <param name="updateAddress">The address object containing the updated information.</param>
        public void UpdateAddress(Address updateAddress)
        {
            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.UpdateAddress(new AddressDto
                    {
                        ID = updateAddress.ID,
                        Street = updateAddress.Street,
                        City = updateAddress.City,
                        CountryID = updateAddress.CountryID,
                        PostalCode = updateAddress.PostalCode,
                        Description = updateAddress.Description,
                        Login = updateAddress.Login
                    });

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Re-throw the exception
                }
            }
        }


        /// <summary>
        /// Adds a new address to the address service.
        /// </summary>
        /// <param name="address">The address object to be added.</param>
        public void AddAddress(Address address)
        {
            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.AddAddress(new AddressDto
                    {
                        Street = address.Street,
                        City = address.City,
                        CountryName = address.CountryName,
                        PostalCode = address.PostalCode,
                        Description = address.Description,
                        Login = address.Login
                    });

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Re-throw the exception
                }
            }
        }

        /// <summary>
        /// Adds a new address registration to the address service.
        /// </summary>
        /// <param name="address">The address object to be registered.</param>
        public void AddAddressRegister(Address address)
        {
            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.AddAddressRegister(new AddressDto
                    {
                        Street = address.Street,
                        City = address.City,
                        CountryID = address.CountryID,
                        PostalCode = address.PostalCode,
                        Description = address.Description,
                        Login = address.Login
                    });

                    address.UserID = address.UserID; // Assign the UserID from the parameter

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Re-throw the exception
                }
            }
        }

        /// <summary>
        /// Deletes the address with the specified ID from the address service.
        /// </summary>
        /// <param name="id">The ID of the address to be deleted</param>
        public void DeleteAddress(int id)
        {
            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.DeleteAddress(id); // Delete the address by its ID

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Re-throw the exception
                }
            }
        }
    }
}