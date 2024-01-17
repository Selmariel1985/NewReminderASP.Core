using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    public class UserProvider : IUserProvider
    {
        private readonly IMemoryCache _cache;
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository, IMemoryCache cache)
        {
            _userRepository = userRepository;
            _cache = cache; // Внедрение зависимости IMemoryCache
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers().ToList();
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public User GetUserByLogin(string login)
        {
            return _userRepository.GetUserByLogin(login);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public void UpdateUser(User updatedUser)
        {
            _userRepository.UpdateUser(updatedUser);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public User GetUserByPassword(string password)
        {
            return _userRepository.GetUserByPassword(password);
        }

        public User GetUserByPasswordAndLogin(string password, string login)
        {
            var cacheKey = "user_" + login + "_" + password;

            if (_cache.TryGetValue(cacheKey, out User cachedUser))
            {
                // Check if cached user data is still valid, refresh if necessary
                var updatedUser = _userRepository.GetUserByPasswordAndLogin(password, login);
                if (updatedUser != null &&
                    updatedUser.Version == cachedUser.Version) return cachedUser; // Return user from cache if found
            }

            var user = _userRepository.GetUserByPasswordAndLogin(password, login);
            if (user != null)
            {
                // Add a version number to the cache key to prevent stale data
                cacheKey = "user_" + login + "_" + password + "_" + user.Version;
                _cache.Set(cacheKey, user, TimeSpan.FromMinutes(5)); // Cache the user data
            }

            return user; // Return the user from the repository
        }


        public List<Role> GetRoles()
        {
            return _userRepository.GetRoles().ToList();
        }

        public Role GetRolesByID(int id)
        {
            return _userRepository.GetRolesByID(id);
        }

        public UserRole GetUserRoles(int userId)
        {
            return _userRepository.GetUserRoles(userId);
        }

        public List<UserRole> GetUsersRoles()
        {
            return _userRepository.GetUsersRoles().ToList();
        }


        public void AddRole(int id, string name)
        {
            _userRepository.AddRole(id, name);
        }

        public void AddUserRole(UserRole userRole)
        {
            _userRepository.AddUserRole(userRole);
        }

        public void RemoveRole(int id, string name)
        {
            _userRepository.RemoveRole(id, name);
        }


        public void AssignRolesToUser(User user, List<string> roles)
        {
            _userRepository.AssignRolesToUser(user, roles);
        }

        public void AddUserRoleNormal(string userLogin, string roleName)
        {
            _userRepository.AddUserRoleNormal(userLogin, roleName);
        }
    }
}