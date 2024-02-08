using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
    public class PhoneClient : IPhoneClient
    {
       

        public List<UserPhone> GetUserPhones()
        {
          
            
                var userPhones = new List<UserPhone>();

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
                                var userPhone = new UserPhone
                                {
                                    ID = userPhoneDto.ID,
                                    Login = userPhoneDto.Login,
                                    PhoneNumber = userPhoneDto.PhoneNumber,
                                    PhoneTypes = userPhoneDto.PhoneType,
                                    CountryName = userPhoneDto.CountryName

                                };

                                userPhones.Add(userPhone);
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

                return userPhones;
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
                        PhoneType = updatedUserPhone.PhoneTypes,
                        CountryName = updatedUserPhone.CountryName
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
                    throw;
                }
            }
        }

       
    }
}
