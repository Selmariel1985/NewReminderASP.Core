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
    ///     Client class for interacting with personal information service.
    /// </summary>
    public class PersonalInformationClient : IPersonalInformationClient
    {
        /// <summary>
        ///     Retrieves a list of personal information based on the user's role and login.
        /// </summary>
        /// <returns></returns>
        public List<PersonalInfo> GetPersonalInfos()
        {
            var personalInfos = new List<PersonalInfo>(); // Create a list to store PersonalInfo objects
            var currentUserLogin = HttpContext.Current.User.Identity.Name; // Get current user's login
            var isAdmin = HttpContext.Current.User.IsInRole("admin"); // Check if the current user is an admin

            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service
                    var result = connection.GetPersonalInfos(); // Retrieve personal information from the service

                    if (result != null)
                        // Process the retrieved personal information based on the user's role
                        foreach (var personalInfo in result)
                            if (isAdmin || personalInfo.Login == currentUserLogin)
                                personalInfos.Add(new PersonalInfo
                                {
                                    Login = personalInfo.Login,
                                    FirstName = personalInfo.FirstName,
                                    LastName = personalInfo.LastName,
                                    MiddleName = personalInfo.MiddleName,
                                    Birthdate = personalInfo.Birthdate,
                                    Gender = personalInfo.Gender,
                                    UserID = personalInfo.UserID
                                });

                    connection.Close(); // Close connection to the service
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception up the call stack
                }
            }

            return personalInfos; // Return the list of PersonalInfo objects
        }


        /// <summary>
        ///     Retrieves personal information by the specified ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The PersonalInfo object corresponding to the specified ID, or null if not found</returns>
        public PersonalInfo GetPersonalInfo(int id)
        {
            PersonalInfo personalInfo = null; // Initialize the personalInfo variable as null

            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the service

                    var result = connection.GetPersonalInfo(id); // Retrieve personal information by ID

                    if (result != null)
                        personalInfo = new PersonalInfo
                        {
                            UserID = result.UserID,
                            Login = result.Login,
                            FirstName = result.FirstName,
                            LastName = result.LastName,
                            MiddleName = result.MiddleName,
                            Birthdate = result.Birthdate,
                            Gender = result.Gender
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

            return personalInfo; // Return the PersonalInfo object
        }


        /// <summary>
        ///     Updates the personal information. If the information for the provided user ID exists, it is updated.
        ///     If not, new personal information is added.
        /// </summary>
        /// <param name="updatedPersonalInfo"></param>
        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the personal information service

                    // Attempt to update existing information
                    connection.UpdatePersonalInfo(new PersonalInfoDto
                    {
                        UserID = updatedPersonalInfo.UserID,
                        FirstName = updatedPersonalInfo.FirstName,
                        LastName = updatedPersonalInfo.LastName,
                        MiddleName = updatedPersonalInfo.MiddleName,
                        Birthdate = updatedPersonalInfo.Birthdate,
                        Gender = updatedPersonalInfo.Gender
                    });

                    connection.Close(); // Close connection
                }
                catch // Catch any exception
                {
                    try
                    {
                        // If the update fails, perform an insert of new information
                        connection.AddPersonalInfo(new PersonalInfoDto
                        {
                            UserID = updatedPersonalInfo.UserID,
                            FirstName = updatedPersonalInfo.FirstName,
                            LastName = updatedPersonalInfo.LastName,
                            MiddleName = updatedPersonalInfo.MiddleName,
                            Birthdate = updatedPersonalInfo.Birthdate,
                            Gender = updatedPersonalInfo.Gender
                        });

                        connection.Close(); // Close connection
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex); // Output the exception to the console

                        var logger = LogManager.GetLogger("ErrorLogger");
                        logger.Error("An error occurred when updating or inserting personal info", ex); // Log the error
                        throw; // Propagate the exception
                    }
                }
            }
        }


        /// <summary>
        ///     Adds a new personal information entry.
        /// </summary>
        /// <param name="personalInfo"></param>
        public void AddPersonalInfo(PersonalInfo personalInfo)
        {
            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the personal information service

                    // Add the new personal information
                    connection.AddPersonalInfo(new PersonalInfoDto
                    {
                        UserID = personalInfo.UserID,
                        FirstName = personalInfo.FirstName,
                        LastName = personalInfo.LastName,
                        MiddleName = personalInfo.MiddleName,
                        Birthdate = personalInfo.Birthdate,
                        Gender = personalInfo.Gender
                    });

                    connection.Close(); // Close connection
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Output the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception
                }
            }
        }


        /// <summary>
        ///     Deletes the personal information for the specified ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeletePersonalInfo(int id)
        {
            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open(); // Open connection to the personal information service

                    // Delete the personal information by ID
                    connection.DeletePersonalInfo(id);

                    connection.Close(); // Close connection
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); // Output the exception to the console

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e); // Log the error
                    throw; // Propagate the exception
                }
            }
        }
    }
}