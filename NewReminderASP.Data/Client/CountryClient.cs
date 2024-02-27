using System;
using System.Collections.Generic;
using log4net;
using NewReminderASP.Data.Client;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

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
                                ID = countryDto.ID,
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
                        ID = result.ID,
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
                    ID = updateCountry.ID,
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