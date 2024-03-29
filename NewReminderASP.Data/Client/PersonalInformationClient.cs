﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    {
                        foreach (var personalInfo in result)
                        {
                            personalInfos.Add(new PersonalInfo
                            {
                                UserID = personalInfo.UserID,
                                FirstName = personalInfo.FirstName,
                                LastName = personalInfo.LastName,
                                MiddleName = personalInfo.MiddleName,
                                Birthdate = personalInfo.Birthdate,
                                Gender = personalInfo.Gender
                            });
                        }
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return personalInfos;
        }

        public PersonalInfo GetPersonalInfo(int userId)
        {
            PersonalInfo personalInfo = null;

            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetPersonalInfo(userId);

                    if (result != null)
                    {
                        personalInfo = new PersonalInfo
                        {
                            UserID = result.UserID,
                            FirstName = result.FirstName,
                            LastName = result.LastName,
                            MiddleName = result.MiddleName,
                            Birthdate = result.Birthdate,
                            Gender = result.Gender
                        };
                    }

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
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
                        UserID = updatedPersonalInfo.UserID,
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
                    throw;
                }
            }
        }

        public void AddPersonalInfo(PersonalInfo personalInfo)
        {
            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddPersonalInfo(new PersonalInfoDto
                    {
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
                    throw;
                }
            }
        }

        public void DeletePersonalInfo(int id)
        {
            using (var connection = new PersonalInfoServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeletePersonalInfo(id);

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        
    }
}
