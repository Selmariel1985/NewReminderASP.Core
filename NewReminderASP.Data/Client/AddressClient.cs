using System;
using System.Collections.Generic;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Data.Client
{
    public class AddressClient : IAddressClient

    {
        public List<Address> GetAddresses()
        {
            var addresses = new List<Address>();

            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetAddresses();

                    if (result != null)
                        foreach (var adressDto in result)
                            addresses.Add(
                                new Address
                                {
                                    ID = adressDto.ID,
                                    Street = adressDto.Street,
                                    City = adressDto.City,
                                    CountryName = adressDto.CountryName,
                                    PostalCode = adressDto.PostalCode,
                                    Description = adressDto.Description,
                                    Login = adressDto.Login
                                });

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return addresses;
        }

        public Address GetAddress(int id)
        {
            Address address = null;

            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetAddress(id);

                    if (result != null)
                        address = new Address
                        {
                            ID = result.ID,
                            Street = result.Street,
                            City = result.City,
                            CountryName = result.CountryName,
                            PostalCode = result.PostalCode,
                            Description = result.Description,
                            Login = result.Login
                        };

                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return address;
        }


        public void UpdateCountry(Address updateAddress)
        {
            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdateAddress(new AddressDto
                    {
                        ID = updateAddress.ID,
                        Street = updateAddress.Street,
                        City = updateAddress.City,
                        CountryName = updateAddress.CountryName,
                        PostalCode = updateAddress.PostalCode,
                        Description = updateAddress.Description,
                        Login = updateAddress.Login
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

        public void AddAddress(Address address)
        {
            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddAddress(new AddressDto
                    {
                        Street = address.Street,
                        City = address.City,
                        CountryName = address.CountryName,
                        PostalCode = address.PostalCode,
                        Description = address.Description,
                        Login = address.Login
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

        public void AddAddressRegister(Address address)
        {
            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddAddressRegister(new AddressDto
                    {
                        Street = address.Street,
                        City = address.City,
                        CountryID = address.CountryID,
                        PostalCode = address.PostalCode,
                        Description = address.Description,
                        Login = address.Login
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

        public void DeleteAddress(int id)
        {
            using (var connection = new AddressServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeleteAddress(id);

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