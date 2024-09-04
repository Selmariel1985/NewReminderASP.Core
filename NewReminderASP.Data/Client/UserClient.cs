using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using NewReminderASP.Data.Client;
using NewReminderASP.Data.ServiceReference1;
using NewReminderASP.Domain.Entities;
using NewReminderASP.Services.Dtos;

/// <summary>
///     Client class for interacting with user service.
/// </summary>
public class UserClient : IUserClient
{
    /// <summary>
    ///     Assigns roles to a user in the system.
    /// </summary>
    /// <param name="user">The user to whom roles are to be assigned.</param>
    /// <param name="roles">The list of role names to assign to the user.</param>
    public void AssignRolesToUser(User user, List<string> roles)
    {
        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open(); // Open connection to the user service

                var userDto = new UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    Roles = roles.ToList()
                };

                client.AssignRolesToUser(userDto, userDto.Roles.ToArray()); // Assign roles to the user
                client.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }

    /// <summary>
    ///     Adds a normal user role to the specified user.
    /// </summary>
    /// <param name="userLogin">The login of the user to assign the role to.</param>
    /// <param name="roleName">The name of the role to add.</param>
    public void AddUserRoleNormal(string userLogin, string roleName)
    {
        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open(); // Open connection to the user service

                var userRoleDto = new UserRoleDto
                {
                    UserLogin = userLogin,
                    RoleName = roleName
                };

                client.AddUserRoleNormal(userLogin, roleName); // Add the user role

                client.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }


    /// <summary>
    ///     Retrieves a list of users based on the current user's role and login.
    /// </summary>
    /// <returns>A read-only list of User objects</returns>
    public IReadOnlyList<User> GetUsers()
    {
        var users = new List<User>(); // Create a list to store User objects
        var currentUserLogin = HttpContext.Current.User.Identity.Name; // Get current user's login
        var isAdmin = HttpContext.Current.User.IsInRole("admin"); // Check if the current user is an admin

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service
                var result = connection.GetUsers(); // Retrieve users from the service

                if (isAdmin)
                    // If the user is an admin, map all retrieved users to User objects
                    users = result.Select(MapUserDtoToUser).ToList();
                else
                    // If the user is not an admin, map only the current user to a User object
                    users = result.Where(userDto => userDto.Login == currentUserLogin)
                        .Select(MapUserDtoToUser).ToList();

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return users.AsReadOnly(); // Return the list of User objects as read-only
    }

    /// <summary>
    ///     Retrieves a user by the specified ID.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve.</param>
    /// <returns>The User object corresponding to the specified ID, or null if not found.</returns>
    public User GetUser(int id)
    {
        User user = null; // Initialize the user variable as null

        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open(); // Open connection to the user service

                var result = client.GetUser(id); // Retrieve user by ID

                if (result != null) user = MapUserDtoToUser(result); // Map UserDto to User object

                client.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return user; // Return the User object
    }


    /// <summary>
    ///     Retrieves a user by the specified password and login.
    /// </summary>
    /// <param name="password">The password of the user to retrieve.</param>
    /// <param name="login">The login of the user to retrieve.</param>
    /// <returns>The User object corresponding to the specified password and login, or null if not found.</returns>
    public User GetUserByPasswordAndLogin(string password, string login)
    {
        User user = null; // Initialize the user variable as null

        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open(); // Open connection to the user service

                var result = client.GetUserByPasswordAndLogin(password, login); // Retrieve user by password and login

                if (result != null) user = MapUserDtoToUser(result); // Map UserDto to User object

                client.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return user; // Return the User object
    }

    /// <summary>
    ///     Retrieves a list of all roles available.
    /// </summary>
    /// <returns>A read-only list of Role objects representing all available roles.</returns>
    public IReadOnlyList<Role> GetRoles()
    {
        var allRoles = new List<Role>(); // Initialize list to store Role objects

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                var roles = connection.GetRoles(); // Get all roles from the service

                if (roles != null)
                    foreach (var role in roles)
                        allRoles.Add(new Role
                        {
                            Id = role.Id,
                            Name = role.Name
                        });

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return allRoles; // Return the list of Role objects
    }

    /// <summary>
    ///     Retrieves a role by the specified ID.
    /// </summary>
    /// <param name="id">The ID of the role to retrieve.</param>
    /// <returns>The Role object corresponding to the specified ID, or null if not found.</returns>
    public Role GetRolesByID(int id)
    {
        Role role = null; // Initialize the role variable as null

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                var result = connection.GetRolesByID(id); // Retrieve roles by ID

                if (result != null)
                    role = new Role
                    {
                        Id = result.Id,
                        Name = result.Name
                    };

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return role; // Return the Role object
    }

    /// <summary>
    ///     Retrieves the list of user roles.
    /// </summary>
    /// <returns>A read-only list of UserRole objects representing the user roles.</returns>
    public IReadOnlyList<UserRole> GetUsersRoles()
    {
        var allUserRoles = new List<UserRole>(); // Initialize list to store UserRole objects

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                var roles = connection.GetUsersRoles(); // Get user roles from the service

                if (roles != null)
                    foreach (var role in roles)
                        allUserRoles.Add(new UserRole
                        {
                            UserId = role.UserId,
                            RoleId = role.RoleId
                        });

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return allUserRoles; // Return the list of UserRole objects
    }


    /// <summary>
    ///     Retrieves the roles of a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user to retrieve roles for.</param>
    /// <returns>The UserRole object containing the roles of the specified user, or null if not found.</returns>
    public UserRole GetUserRoles(int userId)
    {
        UserRole userRoles = null; // Initialize the userRoles variable as null

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                var result = connection.GetUserRoles(userId); // Retrieve user roles by user ID

                if (result != null)
                    userRoles = new UserRole
                    {
                        UserId = result.UserId,
                        RoleId = result.RoleId
                    };

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return userRoles; // Return the UserRole object
    }

    /// <summary>
    ///     Adds a user role to the system.
    /// </summary>
    /// <param name="userRole">The UserRole object to add.</param>
    public void AddUserRole(UserRole userRole)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                connection.AddUserRole(new UserRoleDto
                {
                    UserId = userRole.UserId,
                    RoleId = userRole.RoleId
                }); // Add the user role

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }

    /// <summary>
    ///     Retrieves a user by login.
    /// </summary>
    /// <param name="login">The user's login.</param>
    /// <returns>The User object corresponding to the specified login, or null if not found.</returns>
    public User GetUserByLogin(string login)
    {
        User user = null; // Initialize the user variable as null

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                var result = connection.GetUserByLogin(login); // Retrieve user by login

                if (result != null) user = MapUserDtoToUser(result); // Map UserDto to User object

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return user; // Return the User object
    }

    /// <summary>
    ///     Retrieves a user by email.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <returns>The User object corresponding to the specified email, or null if not found.</returns>
    public User GetUserByEmail(string email)
    {
        User user = null; // Initialize the user variable as null

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                var result = connection.GetUserByEmail(email); // Retrieve user by email

                if (result != null)
                    user = new User
                    {
                        Id = result.Id,
                        Login = result.Login,
                        Email = result.Email,
                        Password = result.Password
                    };

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return user; // Return the User object
    }

    /// <summary>
    ///     Adds a new user to the system.
    /// </summary>
    /// <param name="user">The User object to add.</param>
    public void AddUser(User user)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                connection.AddUser(new UserDto
                {
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email
                }); // Add the user

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }

    /// <summary>
    ///     Updates an existing user in the system.
    /// </summary>
    /// <param name="updatedUser">The updated User object.</param>
    public void UpdateUser(User updatedUser)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                connection.UpdateUser(new UserDto
                {
                    Id = updatedUser.Id,
                    Login = updatedUser.Login,
                    Password = updatedUser.Password,
                    Email = updatedUser.Email
                }); // Update the user

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }


    /// <summary>
    ///     Deletes a user from the system by their ID.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    public void DeleteUser(int id)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                connection.DeleteUser(id); // Delete the user by ID

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }

    /// <summary>
    ///     Retrieves a user by password.
    /// </summary>
    /// <param name="password">The user's password.</param>
    /// <returns>The User object corresponding to the specified password, or null if not found.</returns>
    public User GetUserByPassword(string password)
    {
        User user = null; // Initialize the user variable as null

        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                var result = connection.GetUserByPassword(password); // Retrieve user by password

                if (result != null)
                    user = new User
                    {
                        Id = result.Id,
                        Password = result.Password,
                        Email = result.Email
                    };

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }

        return user; // Return the User object
    }


    /// <summary>
    ///     Adds a new role to the system.
    /// </summary>
    /// <param name="role">The Role object to add.</param>
    public void AddRole(Role role)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                connection.AddRole(new RoleDto
                {
                    Name = role.Name
                }); // Add the role

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }

    /// <summary>
    ///     Updates an existing role in the system.
    /// </summary>
    /// <param name="updatedRole">The updated Role object.</param>
    public void UpdateRole(Role updatedRole)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                connection.UpdateRole(new RoleDto
                {
                    Id = updatedRole.Id,
                    Name = updatedRole.Name
                }); // Update the role

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }

    /// <summary>
    ///     Updates the roles of a specific user in the system.
    /// </summary>
    /// <param name="userId">The ID of the user whose roles need to be updated.</param>
    /// <param name="roleIds">A string containing the updated role IDs for the user.</param>
    public void UpdateUserRoles(int userId, string roleIds)
    {
        using (var client = new UserServiceClient())
        {
            try
            {
                client.Open(); // Open connection to the user service

                client.UpdateUserRoles(userId, roleIds); // Update user roles

                client.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }

    /// <summary>
    ///     Removes a role from the system by its ID.
    /// </summary>
    /// <param name="id">The ID of the role to remove.</param>
    public void RemoveRole(int id)
    {
        using (var connection = new UserServiceClient())
        {
            try
            {
                connection.Open(); // Open connection to the user service

                connection.RemoveRole(id); // Remove the role by ID

                connection.Close(); // Close connection to the service
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // Output the exception to the console

                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred", e); // Log the error
                throw; // Propagate the exception up the call stack
            }
        }
    }

    // Maps a UserDto object to a User object
    private User MapUserDtoToUser(UserDto userDto)
    {
        return new User
        {
            Id = userDto.Id,
            Login = userDto.Login,
            Password = userDto.Password,
            Email = userDto.Email,
            UserRoles = userDto.Roles.Select(r => new UserRole
            {
                User = new User { Id = userDto.Id },
                Role = new Role { Name = r }
            }).ToList()
        };
    }
}