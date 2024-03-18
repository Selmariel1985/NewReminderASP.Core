using log4net;
using NewReminderASP.Data.Client;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

public class UserClient : IUserClient
{
    public void AssignRolesToUser(User user, List<string> roles)
    {
        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open();

                var userDto = new UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    Roles = roles.ToList()
                };

                client.AssignRolesToUser(userDto, userDto.Roles.ToArray());
                client.Close();
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

    public void AddUserRoleNormal(string userLogin, string roleName)
    {
        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open();

                var userRoleDto = new UserRoleDto
                {
                    UserLogin = userLogin,
                    RoleName = roleName
                };

                client.AddUserRoleNormal(userLogin, roleName);

                client.Close();
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

    public IReadOnlyList<User> GetUsers()
    {
        var users = new List<User>();

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                var result = connection.GetUsers();

                if (result != null)
                    foreach (var userDto in result)
                    {
                        var user = new User
                        {
                            Id = userDto.Id,
                            Login = userDto.Login,
                            Password = userDto.Password,
                            Email = userDto.Email,
                            UserRoles = userDto.Roles.Select(r =>
                                new
                                    UserRole
                                {
                                    User = new User { Id = userDto.Id },
                                    Role
                                            = new Role { Name = r }
                                }).ToList()
                        };
                        users.Add(user);
                    }

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

        return users;
    }

    public User GetUser(int id)
    {
        User user = null;

        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open();

                var result = client.GetUser(id);

                if (result != null)
                    user = new User
                    {
                        Id = result.Id,
                        Login = result.Login,
                        Email = result.Email,
                        Password = result.Password,
                        UserRoles = result.Roles.Select(r =>
                            new
                                UserRole
                            {
                                User = new User { Id = result.Id },
                                Role = new Role { Name = r }
                            }).ToList()
                    };

                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e);
                throw;
            }
        }

        return user;
    }

    public User GetUserByPasswordAndLogin(string password, string login)
    {
        User user = null;

        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open();

                var result = client.GetUserByPasswordAndLogin(password, login);

                if (result != null)
                    user = new User
                    {
                        Id = result.Id,
                        Login = result.Login,
                        Email = result.Email,
                        Password = result.Password,
                        UserRoles = result.Roles.Select(r =>
                            new
                                UserRole
                            {
                                User = new User { Id = result.Id },
                                Role
                                        = new Role { Name = r }
                            }).ToList()
                    };

                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e);
                throw;
            }
        }

        return user;
    }

    public IReadOnlyList<Role> GetRoles()
    {
        var allRoles = new List<Role>();

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                var roles = connection.GetRoles();

                if (roles != null)
                    foreach (var role in roles)
                        allRoles.Add(new Role
                        {
                            Id = role.Id,
                            Name = role.Name
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

        return allRoles;
    }

    public Role GetRolesByID(int id)
    {
        Role role = null;

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                var result = connection.GetRolesByID(id);

                if (result != null)
                    role = new Role
                    {
                        Id = result.Id,
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

        return role;
    }

    public IReadOnlyList<UserRole> GetUsersRoles()
    {
        var allRoles = new List<UserRole>();

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                var roles = connection.GetUsersRoles();

                if (roles != null)
                    foreach (var role in roles)
                        allRoles.Add(new UserRole
                        {
                            UserId = role.UserId,
                            RoleId = role.RoleId
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

        return allRoles;
    }


    public UserRole GetUserRoles(int userId)
    {
        UserRole userRoles = null;

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                var result = connection.GetUserRoles(userId);

                if (result != null)
                    userRoles = new UserRole
                    {
                        UserId = result.UserId,
                        RoleId = result.RoleId
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

        return userRoles;
    }

    public void AddUserRole(UserRole userRole)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                connection.AddUserRole(new UserRoleDto
                {
                    UserId = userRole.UserId,
                    RoleId = userRole.RoleId
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

    public User GetUserByLogin(string login)
    {
        User user = null;

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                var result = connection.GetUserByLogin(login);

                if (result != null)
                    user = new User
                    {
                        Id = result.Id,
                        Login = result.Login,
                        Email = result.Email,
                        Password = result.Password,
                        UserRoles = result.Roles.Select(r =>
                            new
                                UserRole
                            {
                                User = new User { Id = result.Id },
                                Role
                                        = new Role { Name = r }
                            }).ToList()
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

        return user;
    }

    public User GetUserByEmail(string email)
    {
        User user = null;

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                var result = connection.GetUserByEmail(email);

                if (result != null)
                    user = new User
                    {
                        Id = result.Id,
                        Login = result.Login,
                        Email = result.Email
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

        return user;
    }

    public void AddUser(User user)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                connection.AddUser(new UserDto
                {
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email
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

    public void UpdateUser(User updatedUser)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                connection.UpdateUser(new UserDto
                {
                    Id = updatedUser.Id,
                    Login = updatedUser.Login,
                    Password = updatedUser.Password,
                    Email = updatedUser.Email
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


    public void DeleteUser(int id)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                connection.DeleteUser(id);

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

    public User GetUserByPassword(string password)
    {
        User user = null;

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                var result = connection.GetUserByPassword(password);

                if (result != null)
                    user = new User
                    {
                        Id = result.Id,
                        Password = result.Password,
                        Email = result.Email
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

        return user;
    }


    public void AddRole(Role role)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();

                connection.AddRole(new RoleDto
                {
                    Name = role.Name

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

    public void RemoveRole(int id)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open();
                connection.RemoveRole(id);
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