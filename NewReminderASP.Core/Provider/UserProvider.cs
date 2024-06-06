using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Microsoft.Extensions.Caching.Memory;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Provider class for user-related operations.
    /// </summary>
    public class UserProvider : IUserProvider
    {
        private readonly IMemoryCache _cache;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor for UserProvider.
        /// </summary>
        /// <param name="userRepository">The repository for accessing user data</param>
        /// <param name="cache">The memory cache for caching user data</param>
        public UserProvider(IUserRepository userRepository, IMemoryCache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        // User-related operations

        /// <summary>
        /// Get all users.
        /// </summary>
        public List<User> GetUsers()
        {
            return _userRepository.GetUsers().ToList();
        }

        /// <summary>
        /// Get a user by ID.
        /// </summary>
        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        /// <summary>
        /// Get a user by login with caching mechanism and logging.
        /// </summary>
        public User GetUserByLogin(string login)
        {
            try
            {
                var cacheKey = "user_" + login;

                if (_cache.TryGetValue(cacheKey, out User cachedUser))
                    return cachedUser;

                var user = _userRepository.GetUserByLogin(login);

                if (user != null)
                    _cache.Set(cacheKey, user, TimeSpan.FromMinutes(10));

                return user;
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred while fetching user by login", ex);
                throw;
            }
        }

        /// <summary>
        /// Get a user by email.
        /// </summary>
        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        /// <summary>
        /// Update user information.
        /// </summary>
        public void UpdateUser(User updatedUser)
        {
            _userRepository.UpdateUser(updatedUser);
        }

        /// <summary>
        /// Add a new user.
        /// </summary>
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        /// <summary>
        /// Get a user by password.
        /// </summary>
        public User GetUserByPassword(string password)
        {
            return _userRepository.GetUserByPassword(password);
        }

        /// <summary>
        /// Get a user by login and password.
        /// </summary>
        public User GetUserByPasswordAndLogin(string password, string login)
        {
            return _userRepository.GetUserByPasswordAndLogin(password, login);
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        public List<Role> GetRoles()
        {
            return _userRepository.GetRoles().ToList();
        }

        /// <summary>
        /// Get a role by ID.
        /// </summary>
        public Role GetRolesByID(int id)
        {
            return _userRepository.GetRolesByID(id);
        }

        /// <summary>
        /// Get user roles by user ID.
        /// </summary>
        public UserRole GetUserRoles(int userId)
        {
            return _userRepository.GetUserRoles(userId);
        }

        /// <summary>
        /// Get all user roles.
        /// </summary>
        public List<UserRole> GetUsersRoles()
        {
            return _userRepository.GetUsersRoles().ToList();
        }

        /// <summary>
        /// Add a new role.
        /// </summary>
        public void AddRole(Role role)
        {
            _userRepository.AddRole(role);
        }

        /// <summary>
        /// Add a user role.
        /// </summary>
        public void AddUserRole(UserRole userRole)
        {
            _userRepository.AddUserRole(userRole);
        }

        /// <summary>
        /// Update a role.
        /// </summary>
        public void UpdateRole(Role updatedRole)
        {
            _userRepository.UpdateRole(updatedRole);
        }

        /// <summary>
        /// Remove a role by ID.
        /// </summary>
        public void RemoveRole(int id)
        {
            _userRepository.RemoveRole(id);
        }

        /// <summary>
        /// Assign roles to a user.
        /// </summary>
        public void AssignRolesToUser(User user, List<string> roles)
        {
            _userRepository.AssignRolesToUser(user, roles);
        }

        /// <summary>
        /// Add a user role in a normal way.
        /// </summary>
        public void AddUserRoleNormal(string userLogin, string roleName)
        {
            _userRepository.AddUserRoleNormal(userLogin, roleName);
        }

        /// <summary>
        /// Update user roles by user ID and role IDs.
        /// </summary>
        public void UpdateUserRoles(int userId, string roleIds)
        {
            _userRepository.UpdateUserRoles(userId, roleIds);
        }

    }
}
