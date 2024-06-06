using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Contract;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.WcfService
{
    /// <summary>
    /// This class implements various service interfaces for user-related operations.
    /// </summary>
    public class Service1 : IUserService, ICountryService, IAddressService, IPersonalInfoService, IEventService, IPhoneService
    {
        /// <summary>
        /// Connection string for the database.
        /// </summary>
        private readonly string connectionString = "Data Source=DESKTOP-HAJP4KN\\SQLEXPRESS;Initial Catalog=ReminderEF;Persist Security Info=True;User ID=supergrisha;Password=supergrisha;";

        /// <summary>
        /// This method retrieves a list of addresses from the database.
        /// </summary>
        public List<AddressDto> GetAddresses()
        {
            var addresses = new List<AddressDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetAddresses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create a new AddressDto object and populate it with data from the database
                            var address = new AddressDto
                            {
                                ID = reader.GetInt32(0),
                                Street = reader.GetString(1),
                                City = reader.GetString(2),
                                CountryName = reader.GetString(3),
                                PostalCode = reader.GetString(4),
                                Description = reader.GetString(5),
                                Login = reader.GetString(6),
                                UserID = reader.GetInt32(7)
                            };
                            // Add the address to the list
                            addresses.Add(address);
                        }
                    }
                }
            }

            return addresses;
        }


        /// <summary>
        /// This method retrieves a specific address by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the address to retrieve.</param>
        public AddressDto GetAddress(int id)
        {
            // Create a new AddressDto object to store the retrieved address
            var address = new AddressDto();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetAddress", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the address ID
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Check if there is a result for the given ID
                        if (reader.Read())
                        {
                            // Populate the AddressDto object with data from the database
                            address.ID = reader.GetInt32(0);
                            address.Street = reader.GetString(1);
                            address.City = reader.GetString(2);
                            address.CountryName = reader.GetString(3);
                            address.PostalCode = reader.GetString(4);
                            address.Description = reader.GetString(5);
                            address.Login = reader.GetString(6);
                            address.UserID = reader.GetInt32(7);
                        }
                    }
                }
            }

            return address;
        }


        /// <summary>
        /// This method retrieves a specific address by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the address to retrieve.</param>
        public AddressDto GetAddressByID(int id)
        {
            // Create a new AddressDto object to store the retrieved address
            var address = new AddressDto();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetAddressByID", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the address ID
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Check if there is a result for the given ID
                        if (reader.Read())
                        {
                            // Populate the AddressDto object with data from the database
                            address.ID = reader.GetInt32(0);
                            address.Street = reader.GetString(1);
                            address.City = reader.GetString(2);
                            address.CountryID = reader.GetInt32(3);
                            address.PostalCode = reader.GetString(4);
                            address.Description = reader.GetString(5);
                            address.Login = reader.GetString(6);
                            address.UserID = reader.GetInt32(7);
                        }
                    }
                }
            }

            return address;
        }


        /// <summary>
        /// Retrieves a list of addresses associated with a specific user ID from the database.
        /// </summary>
        /// <param name="userId">The ID of the user whose addresses are to be retrieved.</param>
        /// <returns>A list of AddressDto objects associated with the specified user ID.</returns>
        public List<AddressDto> GetAddressesByUserId(int userId)
        {
            // Create a list to store the addresses
            var addresses = new List<AddressDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetAddressesByUserID", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the user ID
                    command.Parameters.Add(new SqlParameter("@UserID", userId));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Read and populate the AddressDto objects with data from the database
                        while (reader.Read())
                        {
                            var address = new AddressDto
                            {
                                ID = reader.GetInt32(0),
                                Street = reader.GetString(1),
                                City = reader.GetString(2),
                                CountryName = reader.GetString(3),
                                PostalCode = reader.GetString(4),
                                Description = reader.GetString(5),
                                UserID = reader.GetInt32(6),
                                Login = reader.GetString(7)
                            };
                            addresses.Add(address);
                        }
                    }
                }
            }

            return addresses;
        }


        /// <summary>
        /// Updates an address in the database with the provided updated address information.
        /// </summary>
        /// <param name="updatedAddress">The updated address information to be saved in the database.</param>
        public void UpdateAddress(AddressDto updatedAddress)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure for updating an address
                using (var command = new SqlCommand("[UpdateAddress]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Set parameters for the stored procedure
                    command.Parameters.AddWithValue("@id", updatedAddress.ID);
                    command.Parameters.AddWithValue("@street", updatedAddress.Street);
                    command.Parameters.AddWithValue("@city", updatedAddress.City);
                    command.Parameters.AddWithValue("@countryID", updatedAddress.CountryID);
                    command.Parameters.AddWithValue("@postalCode", updatedAddress.PostalCode);
                    command.Parameters.AddWithValue("@description", updatedAddress.Description);
                    command.Parameters.AddWithValue("@login", updatedAddress.Login);

                    // Open the connection and execute the update command
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new address to the database.
        /// </summary>
        /// <param name="address">The address information to be added to the database.</param>
        public void AddAddress(AddressDto address)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddAddress", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Set parameters for the stored procedure
                    command.Parameters.AddWithValue("@Street", address.Street);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@CountryName", address.CountryName);
                    command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    // Use DBNull.Value if address.Description is null
                    command.Parameters.AddWithValue("@Description", (object)address.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Login", address.Login);

                    // Open the connection and execute the command to add the address
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new address to the database using the "AddAddressRegister" stored procedure.
        /// </summary>
        /// <param name="address">The address information to be added to the database.</param>
        public void AddAddressRegister(AddressDto address)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddAddressRegister", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Set parameters for the stored procedure
                    command.Parameters.AddWithValue("@Street", address.Street);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@CountryID", address.CountryID);
                    command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    // Use DBNull.Value if address.Description is null
                    command.Parameters.AddWithValue("@Description", (object)address.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Login", address.Login);

                    // Open the connection and execute the command to add the address
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deletes an address from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the address to be deleted.</param>
        public void DeleteAddress(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("DeleteAddress", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the address ID
                    command.Parameters.AddWithValue("@ID", id);

                    // Open the connection and execute the command to delete the address
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Retrieves a list of countries from the database.
        /// </summary>
        /// <returns>A list of CountryDto objects representing the countries.</returns>
        public List<CountryDto> GetCountries()
        {
            var countries = new List<CountryDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetCountries", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Read and populate the CountryDto objects with data from the database
                        while (reader.Read())
                        {
                            var country = new CountryDto
                            {
                                CountryID = reader.GetInt32(0),
                                CountryCode = reader.GetString(1),
                                PhoneCode = reader.GetString(2),
                                Name = reader.GetString(3)
                            };
                            countries.Add(country);
                        }
                    }
                }
            }

            return countries;
        }


        /// <summary>
        /// Retrieves a specific country by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve.</param>
        /// <returns>The CountryDto object representing the country with the specified ID.</returns>
        public CountryDto GetCountry(int id)
        {
            var country = new CountryDto();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetCountryById", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the country ID
                    command.Parameters.AddWithValue("@CountryID", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Check if there is a result for the given country ID
                        if (reader.Read())
                        {
                            // Populate the CountryDto object with data from the database
                            country.CountryID = reader.GetInt32(0);
                            country.CountryCode = reader.GetString(1);
                            country.PhoneCode = reader.GetString(2);
                            country.Name = reader.GetString(3);
                        }
                    }
                }
            }

            return country;
        }


        /// <summary>
        /// Updates country information in the database.
        /// </summary>
        /// <param name="updateCountry">The CountryDto object containing the updated country information.</param>
        public void UpdateCountry(CountryDto updateCountry)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateCountry", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the updated country information
                    command.Parameters.AddWithValue("@CountryID", updateCountry.CountryID);
                    command.Parameters.AddWithValue("@CountryCode", updateCountry.CountryCode);
                    command.Parameters.AddWithValue("@PhoneCode", updateCountry.PhoneCode);
                    command.Parameters.AddWithValue("@CountryName", updateCountry.Name);

                    // Open the connection and execute the command to update the country
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new country to the database.
        /// </summary>
        /// <param name="country">The CountryDto object containing the country information to be added.</param>
        public void AddCountry(CountryDto country)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddCountry", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new country information
                    command.Parameters.AddWithValue("@CountryCode", country.CountryCode);
                    command.Parameters.AddWithValue("@PhoneCode", country.PhoneCode);
                    command.Parameters.AddWithValue("@CountryName", country.Name);

                    // Open the connection and execute the command to add the new country
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deletes a country from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to be deleted.</param>
        public void DeleteCountry(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("DeleteCountry", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the country ID
                    command.Parameters.AddWithValue("@CountryID", id);

                    // Open the connection and execute the command to delete the country
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Retrieves a list of events from the database.
        /// </summary>
        /// <returns>A list of EventDto objects representing the events.</returns>
        public List<EventDto> GetEvents()
        {
            // Create a list to store the events
            var events = new List<EventDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEvents", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Read and populate the EventDto objects with data from the database
                        while (reader.Read())
                        {
                            var eventDto = new EventDto
                            {
                                ID = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                EventType = reader.GetString(2),
                                Title = reader.GetString(3),
                                Date = reader.GetDateTime(4),
                                Time = reader.GetTimeSpan(5),
                                Recurrence = reader.GetString(6),
                                Reminders = reader.GetString(7)
                            };
                            events.Add(eventDto);
                        }
                    }
                }
            }

            return events;
        }


        /// <summary>
        /// Retrieves a list of events associated with a specific user by their login from the database.
        /// </summary>
        /// <param name="login">The login of the user for whom events are to be retrieved.</param>
        /// <returns>A list of EventDto objects associated with the specified user login.</returns>
        public List<EventDto> GetEventsForUser(string login)
        {
            // Create a list to store the events
            var events = new List<EventDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEventsForUser", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the user login
                    command.Parameters.Add(new SqlParameter("@Login", login));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Read and populate the EventDto objects with data from the database
                        while (reader.Read())
                        {
                            var eventDto = new EventDto
                            {
                                ID = reader.GetInt32(0),
                                EventType = reader.GetString(1),
                                Title = reader.GetString(2),
                                Date = reader.GetDateTime(3), // Adjust if the data type differs
                                Time = reader.GetTimeSpan(4), // Adjust if the data type differs
                                Recurrence = reader.GetString(5),
                                Reminders = reader.GetString(6),
                                UserID = reader.GetInt32(7),
                                Login = reader.GetString(8)
                            };
                            events.Add(eventDto);
                        }
                    }
                }
            }

            return events;
        }



        /// <summary>
        /// Retrieves a list of events associated with a specific user by their ID from the database.
        /// </summary>
        /// <param name="id">The ID of the user for whom events are to be retrieved.</param>
        /// <returns>A list of EventDto objects associated with the specified user ID.</returns>
        public List<EventDto> GetEventsForID(int id)
        {
            // Create a list to store the events
            var events = new List<EventDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEventsForID", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the user ID
                    command.Parameters.Add(new SqlParameter("@UserID", id));

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Read and populate the EventDto objects with data from the database
                        while (reader.Read())
                        {
                            var eventDto = new EventDto
                            {
                                ID = reader.GetInt32(0),
                                EventType = reader.GetString(1),
                                Title = reader.GetString(2),
                                Date = reader.GetDateTime(3),
                                Time = reader.GetTimeSpan(4),
                                Recurrence = reader.GetString(5),
                                Reminders = reader.GetString(6),
                                UserID = reader.GetInt32(7),
                                Login = reader.GetString(8)
                            };
                            events.Add(eventDto);
                        }
                    }
                }
            }

            return events;
        }



        /// <summary>
        /// Retrieves a specific event by its ID from the database.
        /// </summary>
        /// <param name="Id">The ID of the event to retrieve.</param>
        /// <returns>The EventDto object representing the event with the specified ID.</returns>
        public EventDto GetEvent(int Id)
        {
            // Create an instance to store the event details
            var events = new EventDto();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEvent", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the event ID
                    command.Parameters.AddWithValue("@ID", Id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Check if there is a result for the given event ID
                        if (reader.Read())
                        {
                            // Populate the EventDto object with data from the database
                            events.ID = reader.GetInt32(0);
                            events.Login = reader.GetString(1);
                            events.EventType = reader.GetString(2);
                            events.Title = reader.GetString(3);
                            events.Date = reader.GetDateTime(4);
                            events.Time = reader.GetTimeSpan(5);
                            events.Recurrence = reader.GetString(6);
                            events.Reminders = reader.GetString(7);
                        }
                    }
                }
            }

            return events;
        }


        /// <summary>
        /// Updates the details of an event in the database.
        /// </summary>
        /// <param name="updatedEvent">The EventDto object containing the updated details of the event.</param>
        public void UpdateEvent(EventDto updatedEvent)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateEvent", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the updated event details
                    command.Parameters.AddWithValue("@ID", updatedEvent.ID);
                    command.Parameters.AddWithValue("@Login", updatedEvent.Login);
                    command.Parameters.AddWithValue("@EventType", updatedEvent.EventType);
                    command.Parameters.AddWithValue("@Title", updatedEvent.Title);
                    command.Parameters.AddWithValue("@Date", updatedEvent.Date);
                    command.Parameters.AddWithValue("@Time", updatedEvent.Time);
                    command.Parameters.AddWithValue("@Recurrence", updatedEvent.Recurrence);
                    command.Parameters.AddWithValue("@Reminders", updatedEvent.Reminders);

                    connection.Open();
                    // Execute the update command
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new event to the database.
        /// </summary>
        /// <param name="events">The EventDto object representing the event to be added.</param>
        public void AddEvent(EventDto events)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddEvent", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new event details
                    command.Parameters.AddWithValue("@Login", events.Login);
                    command.Parameters.AddWithValue("@EventType", events.EventType);
                    command.Parameters.AddWithValue("@Title", events.Title);
                    command.Parameters.AddWithValue("@Date", events.Date);
                    command.Parameters.AddWithValue("@Time", events.Time);
                    command.Parameters.AddWithValue("@Recurrence", events.Recurrence);
                    command.Parameters.AddWithValue("@Reminders", events.Reminders);

                    connection.Open();
                    // Execute the command to add the event
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deletes an event from the database based on the provided event ID.
        /// </summary>
        /// <param name="id">The ID of the event to be deleted.</param>
        public void DeleteEvent(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("DeleteEvent", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the event ID to be deleted
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    // Execute the command to delete the event
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Retrieves a list of event details from the database.
        /// </summary>
        /// <returns>A list of EventDetailDto objects containing event details.</returns>
        public List<EventDetailDto> GetEventDetails()
        {
            // Create a list to store the event details
            var eventDetails = new List<EventDetailDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEventDetails", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Read and populate the EventDetailDto objects with data from the database
                        while (reader.Read())
                        {
                            var eventDetail = new EventDetailDto
                            {
                                EventID = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                Status = reader.GetString(2)
                            };
                            eventDetails.Add(eventDetail);
                        }
                    }
                }
            }

            return eventDetails;
        }


        /// <summary>
        /// Retrieves a specific event detail by its ID from the database.
        /// </summary>
        /// <param name="eventId">The ID of the event detail to retrieve.</param>
        /// <returns>The EventDetailDto object representing the event detail with the specified ID.</returns>
        public EventDetailDto GetEventDetail(int eventId)
        {
            // Create an instance to store the event detail
            var eventDetails = new EventDetailDto();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEventDetail", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the event ID
                    command.Parameters.AddWithValue("@EventID", eventId);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Check if there is a result for the given event ID
                        if (reader.Read())
                        {
                            // Populate the EventDetailDto object with data from the database
                            eventDetails.EventID = reader.GetInt32(0);
                            eventDetails.Description = reader.GetString(1);
                            eventDetails.Status = reader.GetString(2);
                        }
                    }
                }
            }

            return eventDetails;
        }


        /// <summary>
        /// Updates the details of an event in the database.
        /// </summary>
        /// <param name="updatedEventDetail">The EventDetailDto object containing the updated event details.</param>
        public void UpdateEventDetail(EventDetailDto updatedEventDetail)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateEventDetail", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the updated event detail
                    command.Parameters.AddWithValue("@EventID", updatedEventDetail.EventID);
                    command.Parameters.AddWithValue("@Description", updatedEventDetail.Description);
                    command.Parameters.AddWithValue("@Status", updatedEventDetail.Status);

                    connection.Open();
                    // Execute the update command
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new event detail to the database.
        /// </summary>
        /// <param name="eventDetail">The EventDetailDto object representing the event detail to be added.</param>
        public void AddEventDetail(EventDetailDto eventDetail)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("AddEventDetail", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new event detail
                    command.Parameters.AddWithValue("@EventID", eventDetail.EventID);
                    command.Parameters.AddWithValue("@Description", eventDetail.Description);
                    command.Parameters.AddWithValue("@Status", eventDetail.Status);

                    connection.Open();
                    // Execute the command to add the event detail
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deletes an event detail from the database based on the provided event ID.
        /// </summary>
        /// <param name="eventId">The ID of the event to delete its detail.</param>
        public void DeleteEventDetail(int eventId)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("DeleteEventDetail", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the event ID to be deleted
                    command.Parameters.AddWithValue("@EventID", eventId);

                    connection.Open();
                    // Execute the command to delete the event detail
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Retrieves a list of event recurrences from the database.
        /// </summary>
        /// <returns>A list of EventRecurrenceDto objects containing event recurrence details.</returns>
        public List<EventRecurrenceDto> GetEventRecurrences()
        {
            // Create a list to store the event recurrences
            var eventRecurrences = new List<EventRecurrenceDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEventRecurrences", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate EventRecurrenceDto objects with data from the database
                            var eventRecurrence = new EventRecurrenceDto
                            {
                                ID = reader.GetInt32(0),
                                RecurrenceType = reader.GetString(1)
                            };
                            eventRecurrences.Add(eventRecurrence);
                        }
                    }
                }
            }

            return eventRecurrences;
        }


        /// <summary>
        /// Retrieves a specific event recurrence by its ID from the database.
        /// </summary>
        /// <param name="Id">The ID of the event recurrence to retrieve.</param>
        /// <returns>The EventRecurrenceDto object representing the event recurrence with the specified ID.</returns>
        public EventRecurrenceDto GetEventRecurrence(int Id)
        {
            // Create an instance to store the event recurrence
            var eventRecurrence = new EventRecurrenceDto();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEventRecurrence", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the event recurrence ID
                    command.Parameters.AddWithValue("@ID", Id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Check if there is a result for the given ID
                        if (reader.Read())
                        {
                            // Populate the EventRecurrenceDto object with data from the database
                            eventRecurrence.ID = reader.GetInt32(0);
                            eventRecurrence.RecurrenceType = reader.GetString(1);
                        }
                    }
                }
            }

            return eventRecurrence;
        }


        /// <summary>
        /// Updates the details of an event recurrence in the database.
        /// </summary>
        /// <param name="updatedEventRecurrence">The EventRecurrenceDto object containing the updated event recurrence details.</param>
        public void UpdateEventRecurrence(EventRecurrenceDto updatedEventRecurrence)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("UpdateEventRecurrence", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the updated event recurrence
                    command.Parameters.AddWithValue("@ID", updatedEventRecurrence.ID);
                    command.Parameters.AddWithValue("@RecurrenceType", updatedEventRecurrence.RecurrenceType);

                    connection.Open();
                    // Execute the update command
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new event recurrence to the database.
        /// </summary>
        /// <param name="eventRecurrence">The EventRecurrenceDto object representing the event recurrence to be added.</param>
        public void AddEventRecurrence(EventRecurrenceDto eventRecurrence)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("AddEventRecurrence", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the new event recurrence
                    command.Parameters.AddWithValue("@RecurrenceType", eventRecurrence.RecurrenceType);

                    connection.Open();
                    // Execute the command to add the event recurrence
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deletes an event recurrence from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the event recurrence to delete.</param>
        public void DeleteEventRecurrence(int id)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("DeleteEventRecurrence", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the event recurrence ID to be deleted
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    // Execute the command to delete the event recurrence
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Retrieves a list of event types from the database.
        /// </summary>
        /// <returns>A list of EventTypeDto objects containing event type details.</returns>
        public List<EventTypeDto> GetEventTypes()
        {
            // Create a list to store the event types
            var eventTypes = new List<EventTypeDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEventTypes", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate EventTypeDto objects with data from the database
                            var eventType = new EventTypeDto
                            {
                                ID = reader.GetInt32(0),
                                TypeName = reader.GetString(1)
                            };
                            eventTypes.Add(eventType);
                        }
                    }
                }
            }

            return eventTypes;
        }


        /// <summary>
        /// Retrieves a specific event type by its ID from the database.
        /// </summary>
        /// <param name="Id">The ID of the event type to retrieve.</param>
        /// <returns>The EventTypeDto object representing the event type with the specified ID.</returns>
        public EventTypeDto GetEventType(int Id)
        {
            // Create an instance to store the event type
            var eventType = new EventTypeDto();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetEventType", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Add parameter for the event type ID
                    command.Parameters.AddWithValue("@ID", Id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the EventTypeDto object with data from the database
                            eventType.ID = reader.GetInt32(0);
                            eventType.TypeName = reader.GetString(1);
                        }
                    }
                }
            }

            return eventType;
        }


        /// <summary>
        /// Updates an existing event type in the database.
        /// </summary>
        /// <param name="updatedEventType">The EventTypeDto object containing the updated event type details.</param>
        public void UpdateEventType(EventTypeDto updatedEventType)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("UpdateEventType", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the updated event type
                    command.Parameters.AddWithValue("@ID", updatedEventType.ID);
                    command.Parameters.AddWithValue("@TypeName", updatedEventType.TypeName);

                    connection.Open();
                    // Execute the update command
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new event type to the database.
        /// </summary>
        /// <param name="eventType">The EventTypeDto object representing the event type to be added.</param>
        public void AddEventType(EventTypeDto eventType)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure
                using (var command = new SqlCommand("AddEventType", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new event type
                    // Note: Since ID might be auto-generated or identity in the database, it might not need to be added here
                    command.Parameters.AddWithValue("@TypeName", eventType.TypeName);

                    connection.Open();
                    // Execute the command to add the event type
                    command.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Deletes an event type from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the event type to be deleted.</param>
        public void DeleteEventType(int id)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure for deleting event type
                using (var command = new SqlCommand("DeleteEventType", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the event type ID to be deleted
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    // Execute the command to delete the event type
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Retrieves a list of personal information records from the database.
        /// </summary>
        /// <returns>A list of PersonalInfoDto objects containing personal information details.</returns>
        public List<PersonalInfoDto> GetPersonalInfos()
        {
            // Create a list to store the personal information records
            var personalInfos = new List<PersonalInfoDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetPersonalInfos", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate PersonalInfoDto objects with data from the database
                            var personalInfo = new PersonalInfoDto
                            {
                                Login = reader.GetString(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                MiddleName = reader.GetString(3),
                                Birthdate = reader.GetDateTime(4),
                                Gender = reader.GetString(5),
                                UserID = reader.GetInt32(6)
                            };
                            personalInfos.Add(personalInfo);
                        }
                    }
                }
            }

            return personalInfos;
        }


        /// <summary>
        /// Retrieves personal information for a given user ID from the database.
        /// </summary>
        /// <param name="id">The ID of the user for whom personal information is to be retrieved.</param>
        /// <returns>The PersonalInfoDto object containing personal information of the user.</returns>
        public PersonalInfoDto GetPersonalInfo(int id)
        {
            PersonalInfoDto personalInfo = null;

            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure for retrieving personal info
                using (var command = new SqlCommand("GetPersonalInfo", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the user ID
                    command.Parameters.Add(new SqlParameter("@UserID", id));

                    connection.Open();

                    // Execute the command and read the result
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate PersonalInfoDto object with data from the database
                            personalInfo = new PersonalInfoDto
                            {
                                UserID = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                MiddleName = reader.GetString(4),
                                Birthdate = reader.GetDateTime(5),
                                Gender = reader.GetString(6)
                            };
                        }
                    }
                }
            }

            return personalInfo;
        }



        /// <summary>
        /// Updates the personal information of a user in the database.
        /// </summary>
        /// <param name="updatedPersonalInfo">The PersonalInfoDto object containing the updated personal information.</param>
        public void UpdatePersonalInfo(PersonalInfoDto updatedPersonalInfo)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure for updating personal info
                using (var command = new SqlCommand("UpdatePersonalInfo", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the updated personal information
                    command.Parameters.AddWithValue("@UserID", updatedPersonalInfo.UserID);
                    command.Parameters.AddWithValue("@FirstName", updatedPersonalInfo.FirstName);
                    command.Parameters.AddWithValue("@LastName", updatedPersonalInfo.LastName);
                    command.Parameters.AddWithValue("@MiddleName", updatedPersonalInfo?.MiddleName);
                    command.Parameters.AddWithValue("@Birthdate", updatedPersonalInfo.Birthdate);
                    command.Parameters.AddWithValue("@Gender", updatedPersonalInfo.Gender);

                    connection.Open();
                    // Execute the update command
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds personal information of a user to the database.
        /// </summary>
        /// <param name="personalInfo">The PersonalInfoDto object containing the personal information to be added.</param>
        public void AddPersonalInfo(PersonalInfoDto personalInfo)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure for adding personal info
                using (var command = new SqlCommand("AddPersonalInfo", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new personal information
                    command.Parameters.AddWithValue("@UserID", personalInfo.UserID);
                    command.Parameters.AddWithValue("@FirstName", personalInfo.FirstName);
                    command.Parameters.AddWithValue("@LastName", personalInfo.LastName);
                    command.Parameters.AddWithValue("@MiddleName", personalInfo?.MiddleName);
                    command.Parameters.AddWithValue("@Birthdate", personalInfo.Birthdate);
                    command.Parameters.AddWithValue("@Gender", personalInfo.Gender);

                    connection.Open();
                    // Execute the command to add personal information
                    command.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Deletes the personal information of a user from the database based on the provided UserID.
        /// </summary>
        /// <param name="id">The UserID of the user whose personal information is to be deleted.</param>
        public void DeletePersonalInfo(int id)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the stored procedure for deleting personal info
                using (var command = new SqlCommand("DeletePersonalInfo", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the UserID to delete personal information
                    command.Parameters.AddWithValue("@UserID", id);

                    connection.Open();
                    // Execute the command to delete personal information
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Retrieves a list of user phones from the database.
        /// </summary>
        /// <returns>A list of UserPhoneDto objects containing user phone details.</returns>
        public List<UserPhoneDto> GetUserPhones()
        {
            // Create a list to store the user phones
            var userPhones = new List<UserPhoneDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserPhones", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate UserPhoneDto objects with data from the database
                            var userPhone = new UserPhoneDto
                            {
                                ID = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                PhoneNumber = reader.GetString(2),
                                PhoneType = reader.GetString(3),
                                CountryName = reader.GetString(4),
                                UserID = reader.GetInt32(5)
                            };
                            userPhones.Add(userPhone);
                        }
                    }
                }
            }

            return userPhones;
        }


        /// <summary>
        /// Retrieves a list of user phones for a specific user from the database.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the phones are to be retrieved.</param>
        /// <returns>A list of UserPhoneDto objects containing user phone details.</returns>
        public List<UserPhoneDto> GetUserPhonesByUserId(int userId)
        {
            // Create a list to store the user phones
            var userPhones = new List<UserPhoneDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserPhonesByUserId", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the user ID
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate UserPhoneDto objects with data from the database
                            var userPhone = new UserPhoneDto
                            {
                                ID = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                UserID = reader.GetInt32(2),
                                PhoneNumber = reader.GetString(3),
                                PhoneType = reader.GetString(4),
                                CountryName = reader.GetString(5)
                            };
                            userPhones.Add(userPhone);
                        }
                    }
                }
            }

            return userPhones;
        }



        /// <summary>
        /// Retrieves a specific user phone details based on the provided ID from the database.
        /// </summary>
        /// <param name="id">The ID of the user phone to retrieve.</param>
        /// <returns>The UserPhoneDto object containing details of the user phone.</returns>
        public UserPhoneDto GetUserPhone(int id)
        {
            // Create a UserPhoneDto object to store the user phone details
            var userPhone = new UserPhoneDto();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserPhone", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the user phone ID
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the UserPhoneDto object with data from the database
                            userPhone.ID = reader.GetInt32(0);
                            userPhone.Login = reader.GetString(1);
                            userPhone.PhoneNumber = reader.GetString(2);
                            userPhone.PhoneType = reader.GetString(3);
                            userPhone.CountryName = reader.GetString(4);
                            userPhone.UserID = reader.GetInt32(5);
                        }
                    }
                }
            }

            return userPhone;
        }


        /// <summary>
        /// Updates the user phone details in the database.
        /// </summary>
        /// <param name="updatedUserPhone">The UserPhoneDto object containing the updated user phone details.</param>
        public void UpdateUserPhone(UserPhoneDto updatedUserPhone)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateUserPhone", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the updated user phone details
                    command.Parameters.AddWithValue("@Login", updatedUserPhone.Login);
                    command.Parameters.AddWithValue("@PhoneNumber", updatedUserPhone.PhoneNumber);
                    command.Parameters.AddWithValue("@PhoneTypeID", updatedUserPhone.PhoneTypeID);
                    command.Parameters.AddWithValue("@CountryID", updatedUserPhone.CountryID);

                    connection.Open();
                    // Execute the update command
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new user phone to the database.
        /// </summary>
        /// <param name="userPhone">The UserPhoneDto object containing the user phone details to be added.</param>
        public void AddUserPhone(UserPhoneDto userPhone)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddUserPhone", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new user phone
                    command.Parameters.AddWithValue("@Login", userPhone.Login);
                    command.Parameters.AddWithValue("@PhoneNumber", userPhone.PhoneNumber);
                    command.Parameters.AddWithValue("@PhoneType", userPhone.PhoneType);
                    command.Parameters.AddWithValue("@CountryName", userPhone.CountryName);

                    connection.Open();
                    // Execute the command to add the user phone
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Adds a new user phone registration to the database.
        /// </summary>
        /// <param name="userPhone">The UserPhoneDto object containing the user phone registration details to be added.</param>
        public void AddUserPhoneRegister(UserPhoneDto userPhone)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddUserPhoneRegister", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new user phone registration
                    command.Parameters.AddWithValue("@Login", userPhone.Login);
                    command.Parameters.AddWithValue("@PhoneNumber", userPhone.PhoneNumber);
                    command.Parameters.AddWithValue("@PhoneTypeID", userPhone.PhoneTypeID);
                    command.Parameters.AddWithValue("@CountryID", userPhone.CountryID);

                    connection.Open();
                    // Execute the command to add the user phone registration
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deletes a user phone from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the user phone to be deleted.</param>
        public void DeleteUserPhone(int id)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("DeleteUserPhone", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the user phone ID to be deleted
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    // Execute the command to delete the user phone
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Retrieves a list of phone types from the database.
        /// </summary>
        /// <returns>A list of PhoneTypeDto objects containing phone type details.</returns>
        public List<PhoneTypeDto> GetPhoneTypes()
        {
            // Create a list to store the phone types
            var phoneTypes = new List<PhoneTypeDto>();

            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetPhoneTypes", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate PhoneTypeDto objects with data from the database
                            var phoneType = new PhoneTypeDto
                            {
                                ID = reader.GetInt32(0),
                                TypeName = reader.GetString(1)
                            };
                            phoneTypes.Add(phoneType);
                        }
                    }
                }
            }

            return phoneTypes;
        }


        /// <summary>
        /// Retrieves a specific phone type based on the provided ID from the database.
        /// </summary>
        /// <param name="id">The ID of the phone type to retrieve.</param>
        /// <returns>The PhoneTypeDto object containing details of the phone type.</returns>
        public PhoneTypeDto GetPhoneType(int id)
        {
            // Create a PhoneTypeDto object to store the phone type details
            var phoneType = new PhoneTypeDto();

            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetPhoneType", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the phone type ID
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the PhoneTypeDto object with data from the database
                            phoneType.ID = reader.GetInt32(0);
                            phoneType.TypeName = reader.GetString(1);
                        }
                    }
                }
            }

            return phoneType;
        }


        /// <summary>
        /// Updates an existing phone type in the database.
        /// </summary>
        /// <param name="updatedPhoneType">The PhoneTypeDto object containing the updated phone type details.</param>
        public void UpdatePhoneType(PhoneTypeDto updatedPhoneType)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdatePhoneType", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for updating the phone type
                    command.Parameters.AddWithValue("@ID", updatedPhoneType.ID);
                    command.Parameters.AddWithValue("@TypeName", updatedPhoneType.TypeName);

                    connection.Open();
                    // Execute the command to update the phone type
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Adds a new phone type to the database.
        /// </summary>
        /// <param name="eventPhoneType">The PhoneTypeDto object containing the details of the new phone type to be added.</param>
        public void AddPhoneType(PhoneTypeDto eventPhoneType)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddPhoneType", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameter for the new phone type
                    command.Parameters.AddWithValue("@TypeName", eventPhoneType.TypeName);

                    connection.Open();
                    // Execute the command to add the new phone type
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deletes a phone type from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the phone type to delete.</param>
        public void DeletePhoneType(int id)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("DeletePhoneType", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    // Execute the command to delete the phone type
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Assigns roles to a user in the database.
        /// </summary>
        /// <param name="user">The UserDto object representing the user to assign roles.</param>
        /// <param name="roles">A list of role names to assign to the user.</param>
        public void AssignRolesToUser(UserDto user, List<string> roles)
        {
            // Establish a connection to the database
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AssignRolesToUser", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", user.Id);

                    connection.Open();

                    foreach (var roleName in roles)
                    {
                        command.Parameters.Clear(); // Clear previous parameters

                        // Add parameters for assigning roles to the user
                        command.Parameters.AddWithValue("@UserId", user.Id);
                        command.Parameters.AddWithValue("@RoleName", roleName);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        /// <summary>
        /// Retrieves a user object based on the provided login from the database.
        /// </summary>
        /// <param name="login">The login of the user to retrieve.</param>
        /// <returns>The UserDto object containing details of the user.</returns>
        public UserDto GetUserByLogin(string login)
        {
            UserDto user = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserByLogin", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Login", login);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (user == null)
                            {
                                // Create a new UserDto and populate its properties with data from the database
                                var hashedPassword = reader.GetString(4);

                                user = new UserDto
                                {
                                    Id = reader.GetInt32(0),
                                    Login = reader.GetString(1),
                                    Email = reader.GetString(2),
                                    Password = hashedPassword,
                                    Roles = new List<string>()
                                };
                                user.Roles.Add(reader.IsDBNull(3) ? string.Empty : reader.GetString(3));
                            }
                            else
                            {
                                // Add roles to the existing user
                                user.Roles.Add(reader.IsDBNull(3) ? string.Empty : reader.GetString(3));
                            }
                        }
                    }
                }
            }

            return user;
        }


        /// <summary>
        /// Retrieves a user object based on the provided email from the database.
        /// </summary>
        /// <param name="email">The email of the user to retrieve.</param>
        /// <returns>The UserDto object containing details of the user.</returns>
        public UserDto GetUserByEmail(string email)
        {
            UserDto user = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserByEmail", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the UserDto with data from the database
                            user = new UserDto
                            {
                                Id = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                Email = reader.GetString(2),
                                Password = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return user;
        }


        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The UserDto object containing the user details to be added.</param>
        public void AddUser(UserDto user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddUser", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new user
                    command.Parameters.AddWithValue("@Login", user.Login);
                    command.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(user.Password));
                    command.Parameters.AddWithValue("@Email", user.Email);

                    connection.Open();
                    // Execute the command to add the user
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="updateUser">The UserDto object containing the updated user details.</param>
        public void UpdateUser(UserDto updateUser)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateUser", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", updateUser.Id);
                    command.Parameters.AddWithValue("@Login", updateUser.Login);
                    command.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(updateUser.Password));
                    command.Parameters.AddWithValue("@Email", updateUser.Email);

                    connection.Open();
                    // Execute the command to update the user
                    command.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Deletes a user from the database based on the provided user ID.
        /// </summary>
        /// <param name="id">The ID of the user to be deleted.</param>
        public void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("DeleteUser", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", id);

                    connection.Open();
                    // Execute the command to delete the user
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves a user object based on the provided password from the database.
        /// </summary>
        /// <param name="password">The password of the user to retrieve.</param>
        /// <returns>The UserDto object containing details of the user.</returns>
        public UserDto GetUserByPassword(string password)
        {
            UserDto user = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserByPassword", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the UserDto with data from the database
                            user = new UserDto
                            {
                                Id = reader.GetInt32(0),
                                Password = reader.GetString(1),
                                Email = reader.GetString(2)
                            };
                        }
                    }
                }
            }

            return user;
        }



        /// <summary>
        /// Adds a new role to the database.
        /// </summary>
        /// <param name="role">The RoleDto object representing the role to be added.</param>
        public void AddRole(RoleDto role)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddRole", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for the new role
                    command.Parameters.AddWithValue("@Name", role?.Name);

                    connection.Open();
                    // Execute the command to add the role
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates an existing role in the database.
        /// </summary>
        /// <param name="updatedRole">The RoleDto object representing the updated role.</param>
        public void UpdateRole(RoleDto updatedRole)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateRole", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for updating the role
                    command.Parameters.AddWithValue("@ID", updatedRole.Id);
                    command.Parameters.AddWithValue("@Name", updatedRole.Name);

                    connection.Open();
                    // Execute the command to update the role
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Removes a role from the database based on the provided role ID.
        /// </summary>
        /// <param name="id">The ID of the role to be removed.</param>
        public void RemoveRole(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("RemoveRole", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    // Execute the command to remove the role
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves all roles from the database.
        /// </summary>
        /// <returns>An array of RoleDto objects representing all roles in the database.</returns>
        public RoleDto[] GetRoles()
        {
            var roles = new List<RoleDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetRoles", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create RoleDto objects based on data from the database
                            var role = new RoleDto
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            roles.Add(role);
                        }
                    }
                }
            }

            return roles.ToArray();
        }


        /// <summary>
        /// Retrieves a role from the database based on the provided role ID.
        /// </summary>
        /// <param name="id">The ID of the role to retrieve.</param>
        /// <returns>The RoleDto object representing the role with the provided ID.</returns>
        public RoleDto GetRolesByID(int id)
        {
            RoleDto role = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetRoleById", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the RoleDto with data from the database
                            role = new RoleDto
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                        }
                    }
                }
            }

            return role;
        }

        /// <summary>
        /// Adds a user role to the database.
        /// </summary>
        /// <param name="userRole">The UserRoleDto object representing the user role to be added.</param>
        public void AddUserRole(UserRoleDto userRole)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddUserRole", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userRole.UserId);
                    command.Parameters.AddWithValue("@RoleId", userRole.RoleId);

                    connection.Open();
                    // Execute the command to add the user role
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Updates the roles associated with a user in the database.
        /// </summary>
        /// <param name="userId">The ID of the user whose roles are to be updated.</param>
        /// <param name="roleIds">A string representing the updated role IDs for the user.</param>
        public void UpdateUserRoles(int userId, string roleIds)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("UpdateUserRoles", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for updating user roles
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@RoleIds", roleIds);

                    connection.Open();
                    // Execute the command to update user roles
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Adds a role to a user in the database.
        /// </summary>
        /// <param name="userLogin">The login of the user to whom the role will be added.</param>
        /// <param name="roleName">The name of the role to be added to the user.</param>
        public void AddUserRoleNormal(string userLogin, string roleName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddUserRole1", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for adding a user role
                    command.Parameters.AddWithValue("@UserLogin", userLogin);
                    command.Parameters.AddWithValue("@RoleName", roleName);

                    connection.Open();
                    // Execute the command to add the user role
                    command.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Retrieves all user roles from the database.
        /// </summary>
        /// <returns>An array of UserRoleDto objects representing all user roles in the database.</returns>
        public UserRoleDto[] GetUsersRoles()
        {
            var userRoles = new List<UserRoleDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUsersRoles", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create UserRoleDto objects based on data from the database
                            var userRole = new UserRoleDto
                            {
                                UserId = reader.GetInt32(0),
                                RoleId = reader.GetInt32(1)
                            };
                            userRoles.Add(userRole);
                        }
                    }
                }
            }

            return userRoles.ToArray();
        }

        /// <summary>
        /// Retrieves user roles from the database based on the provided user ID.
        /// </summary>
        /// <param name="userId">The ID of the user whose roles are to be retrieved.</param>
        /// <returns>The UserRoleDto object representing the roles of the user with the provided ID.</returns>
        public UserRoleDto GetUserRoles(int userId)
        {
            UserRoleDto userRoles = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserRoles", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the UserRoleDto with data from the database
                            userRoles = new UserRoleDto
                            {
                                UserId = reader.GetInt32(0),
                                RoleId = reader.GetInt32(1)
                            };
                        }
                    }
                }
            }

            return userRoles;
        }


        /// <summary>
        /// Retrieves a user with associated roles from the database.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>The UserDto object representing the user with the provided ID.</returns>
        public UserDto GetUser(int userId)
        {
            UserDto user = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserWithRoles", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserDto
                            {
                                Id = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                Email = reader.GetString(2),
                                Password = reader.GetString(3),
                                Roles = new List<string> { reader.GetString(4) }
                            };

                            while (reader.Read())
                            {
                                // Add all associated roles to the user
                                user.Roles.Add(reader.GetString(4));
                            }
                        }
                    }
                }
            }

            return user;
        }


        /// <summary>
        /// Retrieves a user based on the provided password and login from the database.
        /// </summary>
        /// <param name="password">The password of the user to retrieve.</param>
        /// <param name="login">The login of the user to retrieve.</param>
        /// <returns>The UserDto object representing the user with the provided password and login.</returns>
        public UserDto GetUserByPasswordAndLogin(string password, string login)
        {
            UserDto user = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUserByPasswordAndLogin", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Login", login);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserDto
                            {
                                Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                Login = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                Email = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                Roles = new List<string> { reader.IsDBNull(3) ? string.Empty : reader.GetString(3) }
                            };
                        }
                    }
                }
            }

            return user;
        }



        /// <summary>
        /// Retrieves all users along with their associated roles from the database.
        /// </summary>
        /// <returns>A list of UserDto objects representing all users and their roles in the database.</returns>
        public List<UserDto> GetUsers()
        {
            var users = new List<UserDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetUsersWithRoles", connection))
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve user details from the result set
                            var userId = reader.GetInt32(0);
                            var existingUser = users.FirstOrDefault(u => u.Id == userId);

                            // If the user does not exist in the list, create a new user and add to the list
                            if (existingUser == null)
                            {
                                var user = new UserDto
                                {
                                    Id = userId,
                                    Login = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Roles = new List<string> { reader.GetString(4) }
                                };
                                users.Add(user);
                            }
                            // If the user already exists in the list, add the role to the existing user
                            else
                            {
                                existingUser.Roles.Add(reader.GetString(4));
                            }
                        }
                    }
                }
            }

            return users;
        }

    }
}