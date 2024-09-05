using System;
using System.Collections.Generic;
using log4net;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    ///     Client class for interacting with the country service.
    /// </summary>
    public class CountryClient : ICountryClient
    {
        /// <summary>
        ///     Retrieve a list of countries from the country service.
        /// </summary>
        /// <returns>A list of Country objects</returns>
        public List<Country> GetCountries()
        {
            var countries = new List<Country>(); // Create a list to store Country objects

            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open(); // Open a connection to the service

                    var result = connection.GetCountries();

                    if (result != null)
                        // Transform each CountryDto object to Country object and add to the list
                        foreach (var countryDto in result)
                            countries.Add(new Country
                            {
                                CountryID = countryDto.CountryID,
                                CountryCode = countryDto.CountryCode,
                                PhoneCode = countryDto.PhoneCode,
                                Name = countryDto.Name
                            });

                    connection.Close(); // Close the connection to the service
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Output the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return countries; // Return the list of Country objects
        }


        /// <summary>
        ///     Retrieves a specific country by its ID from the country service.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve</param>
        /// <returns>The Country object corresponding to the specified ID, or null if not found</returns>
        public Country GetCountry(int id)
        {
            Country country = null; // Initialize the country variable as null

            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetCountry(id); // Retrieve the country by its ID

                    if (result != null)
                        // Create a new Country object with data from the result
                        country = new Country
                        {
                            CountryID = result.CountryID,
                            CountryCode = result.CountryCode,
                            PhoneCode = result.PhoneCode,
                            Name = result.Name
                        };

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

            return country; // Return the Country object
        }

        /// <summary>
        ///     Updates a country in the country service.
        /// </summary>
        /// <param name="updateCountry">The country object to be updated</param>
        public void UpdateCountry(Country updateCountry)
        {
            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    // Update the country using the provided data
                    connection.UpdateCountry(new CountryDto
                    {
                        CountryID = updateCountry.CountryID,
                        CountryCode = updateCountry.CountryCode,
                        PhoneCode = updateCountry.PhoneCode,
                        Name = updateCountry.Name
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
        ///     Adds a new country to the country service.
        /// </summary>
        /// <param name="country">The country object to be added</param>
        public void AddCountry(Country country)
        {
            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    // Add the new country using the provided data
                    connection.AddCountry(new CountryDto
                    {
                        CountryCode = country.CountryCode,
                        PhoneCode = country.PhoneCode,
                        Name = country.Name
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
        ///     Deletes a country from the country service using the specified ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete</param>
        public void DeleteCountry(int id)
        {
            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    connection.DeleteCountry(id); // Delete the country with the given ID

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