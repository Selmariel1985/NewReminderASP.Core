using System;
using System.Collections.Generic;
using log4net;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
    public class PersonalInformationClient : IPersonalInformationClient
    {
        public List<PersonalInfo> GetPersonalInfos()
        {
            var personalInfos = new List<PersonalInfo>();

            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetPersonalInfos();

                    if (result != null)
                        foreach (var personalInfo in result)
                            personalInfos.Add(new PersonalInfo
                            {
                                Login = personalInfo.Login,
                                FirstName = personalInfo.FirstName,
                                LastName = personalInfo.LastName,
                                MiddleName = personalInfo.MiddleName,
                                Birthdate = personalInfo.Birthdate,
                                Gender = personalInfo.Gender
                            });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e);
                    throw;
                }
            }

            return personalInfos;
        }

        public PersonalInfo GetPersonalInfo(string login)
        {
            PersonalInfo personalInfo = null;

            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetPersonalInfo(login);

                    if (result != null)
                        personalInfo = new PersonalInfo
                        {
                            Login = result.Login,
                            FirstName = result.FirstName,
                            LastName = result.LastName,
                            MiddleName = result.MiddleName,
                            Birthdate = result.Birthdate,
                            Gender = result.Gender
                        };

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e);
                    throw;
                }
            }

            return personalInfo;
        }

        public void UpdatePersonalInfo(PersonalInfo updatedPersonalInfo)
        {
            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdatePersonalInfo(new PersonalInfoDto
                    {
                        Login = updatedPersonalInfo.Login,
                        FirstName = updatedPersonalInfo.FirstName,
                        LastName = updatedPersonalInfo.LastName,
                        MiddleName = updatedPersonalInfo.MiddleName,
                        Birthdate = updatedPersonalInfo.Birthdate,
                        Gender = updatedPersonalInfo.Gender
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e);
                    throw;
                }
            }
        }

        public void AddPersonalInfo(string userLogin, PersonalInfo personalInfo)
        {
            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddPersonalInfo(userLogin, new PersonalInfoDto
                    {
                        Login = personalInfo.Login,
                        FirstName = personalInfo.FirstName,
                        LastName = personalInfo.LastName,
                        MiddleName = personalInfo.MiddleName,
                        Birthdate = personalInfo.Birthdate,
                        Gender = personalInfo.Gender
                    });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e);
                    throw;
                }
            }
        }

        public void DeletePersonalInfo(string login)
        {
            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeletePersonalInfo(login);

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e);
                    throw;
                }
            }
        }
    }
}