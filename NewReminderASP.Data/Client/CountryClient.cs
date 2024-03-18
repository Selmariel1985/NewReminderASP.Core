using log4net;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;
using System;
using System.Collections.Generic;

namespace NewReminderASP.Data.Client
{
    public class CountryClient : ICountryClient
    {
        public List<Country> GetCountries()
        {
            var contries = new List<Country>();

            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetCountries();

                    if (result != null)
                        foreach (var countryDto in result)
                            contries.Add(
                                new Country
                                {
                                    CountryID = countryDto.CountryID,
                                    CountryCode = countryDto.CountryCode,
                                    PhoneCode = countryDto.PhoneCode,
                                    Name = countryDto.Name
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

            return contries;
        }


        public Country GetCountry(int id)
        {
            Country country = null;

            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open();

                    var result = connection.GetCountry(id);

                    if (result != null)
                        country = new Country
                        {
                            CountryID = result.CountryID,
                            CountryCode = result.CountryCode,
                            PhoneCode = result.PhoneCode,
                            Name = result.Name
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

            return country;
        }

        public void UpdateCountry(Country updateCountry)
        {
            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.UpdateCountry(new CountryDto
                    {
                        CountryID = updateCountry.CountryID,
                        CountryCode = updateCountry.CountryCode,
                        PhoneCode = updateCountry.PhoneCode,
                        Name = updateCountry.Name
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

        public void AddCountry(Country country)
        {
            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.AddCountry(new CountryDto
                    {
                        CountryCode = country.CountryCode,
                        PhoneCode = country.PhoneCode,
                        Name = country.Name
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

        public void DeleteCountry(int id)
        {
            using (var connection = new CountryServiceClient())
            {
                try
                {
                    connection.Open();

                    connection.DeleteCountry(id);

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