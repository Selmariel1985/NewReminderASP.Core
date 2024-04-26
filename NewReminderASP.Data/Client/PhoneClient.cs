using log4net;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Web;

namespace NewReminderASP.Data.Client
{
    public class PhoneClient : IPhoneClient
    {
        public List<UserPhone> GetUserPhones()
        {
            var userPhones = new List<UserPhone>();
            string currentUserLogin = HttpContext.Current.User.Identity.Name;
            bool isAdmin = HttpContext.Current.User.IsInRole("admin");

            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetUserPhones();

                    if (result != null)
                    {
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

                    connection.Close();
                }
                catch (Exception e)
                {
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", e);
                    throw;
                }
            }

            return userPhones;
        }

        public List<UserPhone> GetUserPhonesByUserId(int userId)
        {
            var userPhones = new List<UserPhone>();

            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetUserPhonesByUserId(userId);

                    if (result != null)
                    {
                        foreach (var userPhoneDto in result)
                        {
                            var userPhone = new UserPhone()
                            {

                                ID = userPhoneDto.ID,
                                Login = userPhoneDto.Login,
                                UserID = userPhoneDto.UserID,
                                PhoneNumber = userPhoneDto.PhoneNumber,
                                PhoneTypes = userPhoneDto.PhoneType,
                                CountryName = userPhoneDto.CountryName,

                            };
                            userPhones.Add(userPhone); // Add Address object to the list
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    var logger = LogManager.GetLogger("ErrorLogger");
                    logger.Error("An error occurred", ex);
                    throw;
                }
            }

            return userPhones; // Return the list of Address objects
        }



        public UserPhone GetUserPhone(int id)
        {
            UserPhone userPhone = null;

            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetUserPhone(id);

                    if (result != null)
                        userPhone = new UserPhone
                        {
                            ID = result.ID,
                            Login = result.Login,
                            PhoneNumber = result.PhoneNumber,
                            PhoneTypes = result.PhoneType,
                            CountryName = result.CountryName
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

            return userPhone;
        }

        public void UpdateUserPhone(UserPhone updatedUserPhone)
        {
            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdateUserPhone(new UserPhoneDto
                    {
                        ID = updatedUserPhone.ID,
                        Login = updatedUserPhone.Login,
                        PhoneNumber = updatedUserPhone.PhoneNumber,
                        PhoneTypeID = updatedUserPhone.PhoneTypeID,
                        CountryID = updatedUserPhone.CountryID
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

        public void AddUserPhone(UserPhone userPhone)
        {
            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddUserPhone(new UserPhoneDto
                    {
                        ID = userPhone.ID,
                        Login = userPhone.Login,
                        PhoneNumber = userPhone.PhoneNumber,
                        PhoneType = userPhone.PhoneTypes,
                        CountryName = userPhone.CountryName
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

        public void AddUserPhoneRegister(UserPhone userPhone)
        {
            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddUserPhoneRegister(new UserPhoneDto
                    {
                        ID = userPhone.ID,
                        Login = userPhone.Login,
                        PhoneNumber = userPhone.PhoneNumber,
                        PhoneTypeID = userPhone.PhoneTypeID,
                        CountryID = userPhone.CountryID
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

        public void DeleteUserPhone(int id)
        {
            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeleteUserPhone(id);

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

        public List<PhoneType> GetPhoneTypes()
        {
            var phoneTypes = new List<PhoneType>();

            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetPhoneTypes();

                    if (result != null)
                        foreach (var phoneType in result)
                            phoneTypes.Add(
                                new PhoneType
                                {
                                    ID = phoneType.ID,
                                    TypeName = phoneType.TypeName
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

            return phoneTypes;
        }

        public PhoneType GetPhoneType(int id)
        {
            PhoneType phoneType = null;

            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetPhoneType(id);

                    if (result != null)
                        phoneType = new PhoneType
                        {
                            ID = result.ID,
                            TypeName = result.TypeName
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

            return phoneType;
        }

        public void UpdatePhoneType(PhoneType updatedPhoneType)
        {
            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdatePhoneType(new PhoneTypeDto
                    {
                        ID = updatedPhoneType.ID,
                        TypeName = updatedPhoneType.TypeName
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

        public void AddPhoneType(PhoneType eventPhoneType)
        {
            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddPhoneType(new PhoneTypeDto
                    {
                        TypeName = eventPhoneType.TypeName
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

        public void DeletePhoneType(int id)
        {
            using (var connection = new PhoneServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeletePhoneType(id);

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