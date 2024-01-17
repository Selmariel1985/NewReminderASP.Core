using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Contract;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IUserService, ICountryService, IAddressService, IPersonalInfoService
    {
        private string connectionString =
            "Data Source=DESKTOP-HAJP4KN\\SQLEXPRESS;Initial Catalog=ReminderEF;Persist Security Info=True;User ID=supergrisha;Password=supergrisha;";

        public List<AddressDto> GetAddresses()
        {
            List<AddressDto> addresses = new List<AddressDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetAddresses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;



                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AddressDto address = new AddressDto
                            {
                                ID = reader.GetInt32(0),
                                Street = reader.GetString(1),
                                City = reader.GetString(2),
                                CountryID = reader.GetInt32(3),
                                PostalCode = reader.GetString(4),
                                Description = reader.GetString(5)
                            };
                            addresses.Add(address);
                        }
                    }
                }
            }

            return addresses;
        }



        public AddressDto GetAddress(int id)
        {
            AddressDto address = new AddressDto();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetAddress", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            address.ID = reader.GetInt32(0);
                            address.Street = reader.GetString(1);
                            address.City = reader.GetString(2);
                            address.CountryID = reader.GetInt32(3);
                            address.PostalCode = reader.GetString(4);
                            address.Description = reader.GetString(5);
                        }
                    }
                }
            }

            return address;
        }

        public void UpdateAddress(AddressDto updatedAddress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateAddress", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters if your update stored procedure requires them
                    command.Parameters.AddWithValue("@ID", updatedAddress.ID);
                    command.Parameters.AddWithValue("@Street", updatedAddress.Street);
                    command.Parameters.AddWithValue("@City", updatedAddress.City);
                    command.Parameters.AddWithValue("@CountryID", updatedAddress.CountryID);
                    command.Parameters.AddWithValue("@PostalCode", updatedAddress.PostalCode);
                    command.Parameters.AddWithValue("@Description", updatedAddress.Description);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddAddress(AddressDto address)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("AddAddress", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters if the add stored procedure requires them
                    command.Parameters.AddWithValue("@Street", address.Street);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@CountryID", address.CountryID);
                    command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    command.Parameters.AddWithValue("@Description", address.Description);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAddress(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteAddress", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }



       

        public void AssignRolesToUser(UserDto user, List<string> roles)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("AssignRolesToUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", user.Id);

                connection.Open();

                foreach (var roleName in roles)
                {
                    command.Parameters.Clear(); // Clear previous parameters
                    command.Parameters.AddWithValue("@UserId", user.Id);
                    command.Parameters.AddWithValue("@RoleName", roleName);
                    command.ExecuteNonQuery();
                }
            }
        }




        public UserDto GetUserByEmail(string email)
        {
            UserDto user = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetUserByEmail", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserDto
                        {
                            Id = reader.GetInt32(0),
                            Login = reader.GetString(1),
                            Email = reader.GetString(2)
                        };
                    }
                }
            }

            return user;
        }

        public void AddUser(UserDto user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("AddUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Login", user.Login);
                // Хеширование пароля перед добавлением
                command.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(user.Password));
                command.Parameters.AddWithValue("@Email", user.Email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(UserDto updateUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("UpdateUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", updateUser.Id);
                command.Parameters.AddWithValue("@Login", updateUser.Login);
                // Хеширование пароля перед обновлением
                command.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(updateUser.Password));
                command.Parameters.AddWithValue("@Email", updateUser.Email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }




        public void DeleteUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("DeleteUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public UserDto GetUserByPassword(string password)
        {
            UserDto user = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetUserByPassword", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserDto
                        {
                            Id = reader.GetInt32(0),
                            Password = reader.GetString(1),
                            Email = reader.GetString(2)
                        };
                    }
                }
            }

            return user;
        }


        public void AddRole(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("AddRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddUserRole(UserRoleDto userRole)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("AddUserRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userRole.UserId);
                command.Parameters.AddWithValue("@RoleId", userRole.RoleId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void AddUserRoleNormal(string userLogin, string roleName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("AddUserRole1", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserLogin", userLogin);
                command.Parameters.AddWithValue("@RoleName", roleName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveRole(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("RemoveRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public RoleDto[] GetRoles()
        {
            List<RoleDto> roles = new List<RoleDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetRoles", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RoleDto role = new RoleDto
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                        roles.Add(role);
                    }
                }
            }

            return roles.ToArray();
        }

        public UserRoleDto[] GetUsersRoles()
        {
            List<UserRoleDto> userRoles = new List<UserRoleDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetUsersRoles", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserRoleDto userRole = new UserRoleDto
                        {
                            UserId = reader.GetInt32(0),
                            RoleId = reader.GetInt32(1)
                        };
                        userRoles.Add(userRole);
                    }
                }
            }

            return userRoles.ToArray();
        }

        public RoleDto GetRolesByID(int id)
        {
            RoleDto role = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetRoleById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        role = new RoleDto
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }

            return role;
        }

        public UserRoleDto GetUserRoles(int userId)
        {
            UserRoleDto userRoles = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetUserRoles", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userRoles = new UserRoleDto
                        {
                            UserId = reader.GetInt32(0),
                            RoleId = reader.GetInt32(1)
                        };
                    }
                }
            }

            return userRoles;
        }


        public UserDto GetUser(int userId)
        {
            UserDto user = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetUserWithRoles", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
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
                            user.Roles.Add(reader.GetString(4));
                        }
                    }
                }
            }

            return user;
        }

        public UserDto GetUserByLogin(string login)
        {
            UserDto user = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetUserByLogin", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Login", login);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (user == null)
                        {
                            string hashedPassword = reader.GetString(4); // Retrieve hashed password

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
                            user.Roles.Add(reader.IsDBNull(3) ? string.Empty : reader.GetString(3));
                        }
                    }
                }
            }

            return user;
        }

        public UserDto GetUserByPasswordAndLogin(string password, string login)
        {
            UserDto user = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetUserByPasswordAndLogin", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Login", login);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
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

            return user;
        }


        public List<UserDto> GetUsers()
        {
            List<UserDto> users = new List<UserDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetUsersWithRoles", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32(0);
                        var existingUser = users.FirstOrDefault(u => u.Id == userId);

                        if (existingUser == null)
                        {
                            UserDto user = new UserDto
                            {
                                Id = userId,
                                Login = reader.GetString(1),
                                Password = reader.GetString(2),
                                Email = reader.GetString(3),
                                Roles = new List<string> { reader.GetString(4) }
                            };
                            users.Add(user);
                        }
                        else
                        {
                            existingUser.Roles.Add(reader.GetString(4));
                        }
                    }
                }
            }

            return users;
        }
        public List<CountryDto> GetCountries()
        {
            List<CountryDto> countries = new List<CountryDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetCountries", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CountryDto country = new CountryDto
                        {
                            ID = reader.GetInt32(0),
                            CountryCode = reader.GetString(1),
                            PhoneCode = reader.GetString(2),
                            Name = reader.GetString(3)
                        };
                        countries.Add(country);
                    }
                }
            }

            return countries;
        }

        public CountryDto GetCountry(int id)
        {
            CountryDto country = new CountryDto();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetCountryById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        country.ID = reader.GetInt32(0);
                        country.CountryCode = reader.GetString(1);
                        country.PhoneCode = reader.GetString(2);
                        country.Name = reader.GetString(3);
                    }
                }
            }

            return country;
        }

        public void UpdateCountry(CountryDto updateCountry)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("UpdateCountry", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryID", updateCountry.ID);
                command.Parameters.AddWithValue("@CountryCode", updateCountry.CountryCode);
                command.Parameters.AddWithValue("@PhoneCode", updateCountry.PhoneCode);
                command.Parameters.AddWithValue("@CountryName", updateCountry.Name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddCountry(CountryDto country)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("AddCountry", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryCode", country.CountryCode);
                command.Parameters.AddWithValue("@PhoneCode", country.PhoneCode);
                command.Parameters.AddWithValue("@CountryName", country.Name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCountry(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("DeleteCountry", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<PersonalInfoDto> GetPersonalInfos()
        {
            List<PersonalInfoDto> personalInfos = new List<PersonalInfoDto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetPersonalInfos", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PersonalInfoDto personalInfo = new PersonalInfoDto
                        {
                            UserID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            MiddleName = reader.GetString(3),
                            Birthdate = reader.GetDateTime(4),
                            Gender = reader.GetString(5)
                        };
                        personalInfos.Add(personalInfo);
                    }
                }
            }

            return personalInfos;
        
    }

        public PersonalInfoDto GetPersonalInfo(int userId)
        {
            PersonalInfoDto personalInfo = new PersonalInfoDto();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("GetPersonalInfo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        personalInfo.UserID = reader.GetInt32(0);
                        personalInfo.FirstName = reader.GetString(1);
                        personalInfo.LastName = reader.GetString(2);
                        personalInfo.MiddleName = reader.GetString(3);
                        personalInfo.Birthdate = reader.GetDateTime(4);
                        personalInfo.Gender = reader.GetString(5);
                    }
                }
            }

            return personalInfo;
        }

        public void UpdatePersonalInfo(PersonalInfoDto updatedPersonalInfo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("UpdatePersonalInfo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", updatedPersonalInfo.UserID);
                command.Parameters.AddWithValue("@FirstName", updatedPersonalInfo.FirstName);
                command.Parameters.AddWithValue("@LastName", updatedPersonalInfo.LastName);
                command.Parameters.AddWithValue("@MiddleName", updatedPersonalInfo.MiddleName);
                command.Parameters.AddWithValue("@Birthdate", updatedPersonalInfo.Birthdate);
                command.Parameters.AddWithValue("@Gender", updatedPersonalInfo.Gender);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddPersonalInfo(PersonalInfoDto personalInfo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("AddPersonalInfo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", personalInfo.FirstName);
                command.Parameters.AddWithValue("@LastName", personalInfo.LastName);
                command.Parameters.AddWithValue("@MiddleName", personalInfo.MiddleName);
                command.Parameters.AddWithValue("@Birthdate", personalInfo.Birthdate);
                command.Parameters.AddWithValue("@Gender", personalInfo.Gender);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeletePersonalInfo(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("DeletePersonalInfo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }


}
