using System;
using System.Collections.Generic;
using System.Web;
using log4net;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
   
        /// <summary>
        /// Client class for interacting with user phone service.
        /// </summary>
        public class PhoneClient : IPhoneClient
        {
            /// <summary>
            /// Retrieves a list of user phones based on the user's role and login.
            /// </summary>
            /// <returns>A list of UserPhone objects</returns>
            public List<UserPhone> GetUserPhones()
            {
                var userPhones = new List<UserPhone>(); // Create a list to store UserPhone objects
                var currentUserLogin = HttpContext.Current.User.Identity.Name; // Get current user's login
                var isAdmin = HttpContext.Current.User.IsInRole("admin"); // Check if the current user is an admin

                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service
                        var result = connection.GetUserPhones(); // Retrieve user phones from the service

                        if (result != null)
                        {
                            // Process the retrieved user phones based on the user's role
                            foreach (var userPhoneDto in result)
                            {
                                if (isAdmin || userPhoneDto.Login == currentUserLogin)
                                {
                                    var userPhone = new UserPhone
                                    {
                                        ID = userPhoneDto.ID,
                                        Login = userPhoneDto.Login,
                                        PhoneNumber = userPhoneDto.PhoneNumber,
                                        PhoneTypes = userPhoneDto.PhoneType,
                                        CountryName = userPhoneDto.CountryName,
                                        UserID = userPhoneDto.UserID
                                    };

                                    userPhones.Add(userPhone);
                                }
                            }
                        }

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }

                return userPhones; // Return the list of UserPhone objects
            }

            /// <summary>
            /// Retrieves a list of user phones based on the specified user ID.
            /// </summary>
            /// <param name="userId">The user ID to filter user phones by.</param>
            /// <returns>A list of UserPhone objects filtered by the specified user ID.</returns>
            public List<UserPhone> GetUserPhonesByUserId(int userId)
            {
                var userPhones = new List<UserPhone>(); // Create a list to store UserPhone objects

                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        var result = connection.GetUserPhonesByUserId(userId); // Retrieve user phones by user ID

                        if (result != null)
                        {
                            foreach (var userPhoneDto in result)
                            {
                                var userPhone = new UserPhone
                                {
                                    ID = userPhoneDto.ID,
                                    Login = userPhoneDto.Login,
                                    UserID = userPhoneDto.UserID,
                                    PhoneNumber = userPhoneDto.PhoneNumber,
                                    PhoneTypes = userPhoneDto.PhoneType,
                                    CountryName = userPhoneDto.CountryName
                                };
                                userPhones.Add(userPhone); // Add UserPhone object to the list
                            }
                        }

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception ex)
                    {
                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", ex); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }

                return userPhones; // Return the list of UserPhone objects
            }


            /// <summary>
            /// Retrieves a user phone by the specified ID.
            /// </summary>
            /// <param name="id">The ID of the user phone to retrieve.</param>
            /// <returns>The UserPhone object corresponding to the specified ID, or null if not found.</returns>
            public UserPhone GetUserPhone(int id)
            {
                UserPhone userPhone = null; // Initialize the userPhone variable as null

                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        var result = connection.GetUserPhone(id); // Retrieve user phone by ID

                        if (result != null)
                        {
                            userPhone = new UserPhone
                            {
                                ID = result.ID,
                                Login = result.Login,
                                PhoneNumber = result.PhoneNumber,
                                PhoneTypes = result.PhoneType,
                                CountryName = result.CountryName,
                                UserID = result.UserID
                            };
                        }

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }

                return userPhone; // Return the UserPhone object
            }

            /// <summary>
            /// Updates the information of a user phone in the database.
            /// </summary>
            /// <param name="updatedUserPhone">The UserPhone object containing the updated information.</param>
            public void UpdateUserPhone(UserPhone updatedUserPhone)
            {
                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        // Create a UserPhoneDto object with updated information
                        connection.UpdateUserPhone(new UserPhoneDto
                        {
                            ID = updatedUserPhone.ID,
                            Login = updatedUserPhone.Login,
                            PhoneNumber = updatedUserPhone.PhoneNumber,
                            PhoneTypeID = updatedUserPhone.PhoneTypeID,
                            CountryID = updatedUserPhone.CountryID
                        });

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }
            }

            /// <summary>
            /// Adds a new user phone to the database.
            /// </summary>
            /// <param name="userPhone">The UserPhone object containing the information of the new phone to add.</param>
            public void AddUserPhone(UserPhone userPhone)
            {
                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        // Create a new UserPhoneDto object with user phone information
                        connection.AddUserPhone(new UserPhoneDto
                        {
                            ID = userPhone.ID,
                            Login = userPhone.Login,
                            PhoneNumber = userPhone.PhoneNumber,
                            PhoneType = userPhone.PhoneTypes,
                            CountryName = userPhone.CountryName
                        });

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }
            }

            /// <summary>
            /// Adds a new user phone registration to the database.
            /// </summary>
            /// <param name="userPhone">The UserPhone object containing the information of the new phone registration to add.</param>
            public void AddUserPhoneRegister(UserPhone userPhone)
            {
                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        // Create a new UserPhoneDto object with user phone registration information
                        connection.AddUserPhoneRegister(new UserPhoneDto
                        {
                            ID = userPhone.ID,
                            Login = userPhone.Login,
                            PhoneNumber = userPhone.PhoneNumber,
                            PhoneTypeID = userPhone.PhoneTypeID,
                            CountryID = userPhone.CountryID
                        });

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }
            }

            /// <summary>
            /// Deletes a user phone from the database based on the specified ID.
            /// </summary>
            /// <param name="id">The ID of the user phone to delete.</param>
            public void DeleteUserPhone(int id)
            {
                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        connection.DeleteUserPhone(id); // Delete user phone by ID

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }
            }

            /// <summary>
            /// Retrieves a list of phone types.
            /// </summary>
            /// <returns>A list of PhoneType objects representing the phone types.</returns>
            public List<PhoneType> GetPhoneTypes()
            {
                var phoneTypes = new List<PhoneType>(); // Initialize a list to store phone types

                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        var result = connection.GetPhoneTypes(); // Retrieve phone types from the service

                        if (result != null)
                        {
                            foreach (var phoneType in result)
                            {
                                // Create a new PhoneType object and add it to the list
                                phoneTypes.Add(new PhoneType
                                {
                                    ID = phoneType.ID,
                                    TypeName = phoneType.TypeName
                                });
                            }
                        }

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }

                return phoneTypes; // Return the list of phone types
            }

            /// <summary>
            /// Retrieves a phone type by the specified ID.
            /// </summary>
            /// <param name="id">The ID of the phone type to retrieve.</param>
            /// <returns>The PhoneType object corresponding to the specified ID, or null if not found.</returns>
            public PhoneType GetPhoneType(int id)
            {
                PhoneType phoneType = null; // Initialize the phoneType variable as null

                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        var result = connection.GetPhoneType(id); // Retrieve phone type by ID

                        if (result != null)
                        {
                            phoneType = new PhoneType
                            {
                                ID = result.ID,
                                TypeName = result.TypeName
                            };
                        }

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }

                return phoneType; // Return the PhoneType object
            }

            /// <summary>
            /// Updates the information of a phone type in the database.
            /// </summary>
            /// <param name="updatedPhoneType">The PhoneType object containing the updated information.</param>
            public void UpdatePhoneType(PhoneType updatedPhoneType)
            {
                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        // Create a new PhoneTypeDto object with updated phone type information
                        connection.UpdatePhoneType(new PhoneTypeDto
                        {
                            ID = updatedPhoneType.ID,
                            TypeName = updatedPhoneType.TypeName
                        });

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }
            }

            /// <summary>
            /// Adds a new phone type to the database.
            /// </summary>
            /// <param name="newPhoneType">The PhoneType object containing the information of the new phone type to add.</param>
            public void AddPhoneType(PhoneType newPhoneType)
            {
                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        // Create a new PhoneTypeDto object with new phone type information
                        connection.AddPhoneType(new PhoneTypeDto
                        {
                            TypeName = newPhoneType.TypeName
                        });

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }
            }

            /// <summary>
            /// Deletes a phone type from the database based on the specified ID.
            /// </summary>
            /// <param name="id">The ID of the phone type to delete.</param>
            public void DeletePhoneType(int id)
            {
                using (var connection = new PhoneServiceClient())
                {
                    try
                    {
                        connection.Open(); // Open connection to the phone service

                        connection.DeletePhoneType(id); // Delete phone type by ID

                        connection.Close(); // Close connection to the service
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred", e); // Log the error
                        throw; // Propagate the exception up the call stack
                    }
                }
            }
        }
}