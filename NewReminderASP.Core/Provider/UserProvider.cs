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
    ///     Provider class for user-related operations.
    /// </summary>
    public class UserProvider : IUserProvider
    {
        private readonly IMemoryCache _cache;
        private readonly IUserRepository _userRepository;

        /// <summary>
        ///     Constructor for UserProvider.
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="cache"></param>
        public UserProvider(IUserRepository userRepository, IMemoryCache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        // User-related operations

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            return _userRepository.GetUsers().ToList();
        }

        /// <summary>
        ///     Get a user by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        /// <summary>
        ///     Get a user by login with caching mechanism and logging.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
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
        ///     Get a user by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        /// <summary>
        ///     Update user information.
        /// </summary>
        /// <param name="updatedUser"></param>
        public void UpdateUser(User updatedUser)
        {
            _userRepository.UpdateUser(updatedUser);
        }

        /// <summary>
        ///     Add a new user.
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        /// <summary>
        ///     Delete a user by ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        /// <summary>
        ///     Get a user by password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByPassword(string password)
        {
            return _userRepository.GetUserByPassword(password);
        }

        /// <summary>
        ///     Get a user by login and password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public User GetUserByPasswordAndLogin(string password, string login)
        {
            return _userRepository.GetUserByPasswordAndLogin(password, login);
        }

        /// <summary>
        ///     Get all roles.
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoles()
        {
            return _userRepository.GetRoles().ToList();
        }

        /// <summary>
        ///     Get a role by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRolesByID(int id)
        {
            return _userRepository.GetRolesByID(id);
        }

        /// <summary>
        ///     Get user roles by user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserRole GetUserRoles(int userId)
        {
            return _userRepository.GetUserRoles(userId);
        }

        /// <summary>
        ///     Get all user roles.
        /// </summary>
        /// <returns></returns>
        public List<UserRole> GetUsersRoles()
        {
            return _userRepository.GetUsersRoles().ToList();
        }

        /// <summary>
        ///     Add a new role.
        /// </summary>
        /// <param name="role"></param>
        public void AddRole(Role role)
        {
            _userRepository.AddRole(role);
        }

        /// <summary>
        ///     Add a user role.
        /// </summary>
        /// <param name="userRole"></param>
        public void AddUserRole(UserRole userRole)
        {
            _userRepository.AddUserRole(userRole);
        }

        /// <summary>
        ///     Update a role.
        /// </summary>
        /// <param name="updatedRole"></param>
        public void UpdateRole(Role updatedRole)
        {
            _userRepository.UpdateRole(updatedRole);
        }

        /// <summary>
        ///     Remove a role by ID.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveRole(int id)
        {
            _userRepository.RemoveRole(id);
        }

        /// <summary>
        ///     Assign roles to a user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        public void AssignRolesToUser(User user, List<string> roles)
        {
            _userRepository.AssignRolesToUser(user, roles);
        }

        /// <summary>
        ///     Add a user role in a normal way.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="roleName"></param>
        public void AddUserRoleNormal(string userLogin, string roleName)
        {
            _userRepository.AddUserRoleNormal(userLogin, roleName);
        }

        /// <summary>
        ///     Update user roles by user ID and role IDs.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        public void UpdateUserRoles(int userId, string roleIds)
        {
            _userRepository.UpdateUserRoles(userId, roleIds);
        }
    }
}