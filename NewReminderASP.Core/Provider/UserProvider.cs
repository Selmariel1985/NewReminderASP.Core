using log4net;
using Microsoft.Extensions.Caching.Memory;
using NewReminderASP.Data.Repository;
using NewReminderASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewReminderASP.Core.Provider
{
    public class UserProvider : IUserProvider
    {
        private readonly IMemoryCache _cache;
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository, IMemoryCache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
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
            try
            {
                var cacheKey = "user_" + login;

                if (_cache.TryGetValue(cacheKey,
                        out User cachedUser)) return cachedUser;

                var user = _userRepository.GetUserByLogin(login);
                if (user != null) _cache.Set(cacheKey, user, TimeSpan.FromMinutes(1));

                return user;
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetLogger("ErrorLogger");
                logger.Error("An error occurred while fetching user by login", ex);
                throw;
            }
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
            return _userRepository.GetUserByPasswordAndLogin(password, login);
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


        public void AddRole(Role role)
        {
            _userRepository.AddRole(role);
        }

        public void AddUserRole(UserRole userRole)
        {
            _userRepository.AddUserRole(userRole);
        }
        public void UpdateRole(Role updatedRole)
        {
            _userRepository.UpdateRole(updatedRole);
        }

        public void RemoveRole(int id)
        {
            _userRepository.RemoveRole(id);
        }


        public void AssignRolesToUser(User user, List<string> roles)
        {
            _userRepository.AssignRolesToUser(user, roles);
        }

        public void AddUserRoleNormal(string userLogin, string roleName)
        {
            _userRepository.AddUserRoleNormal(userLogin, roleName);
        }

        public void UpdateUserRoles(int userId, string roleIds)
        {
            _userRepository.UpdateUserRoles(userId, roleIds);
        }

    //    public void GenerateConfirmationToken(User user)
    //    {
    //        user.ConfirmationToken = GenerateUniqueToken();
    //        _userRepository.UpdateUser(user);
    //    }


    //    public void SendConfirmationEmail(User user, string confirmationLink)
    //    {
    //        // Implement the logic to send a confirmation email to the user
    //        // This can involve using SMTP, an email API, or a service like SendGrid
    //    }


    //    private string GenerateUniqueToken()
    //    {
    //        // Implement a logic to generate a unique token
    //        return Guid.NewGuid().ToString(); // Example of generating a unique token using GUID
    //    }

        
    

    //public bool VerifyConfirmationToken(string token)
    //    {
    //        // Assume the validToken variable contains the allowed confirmation token
    //        string validToken = "abc123";  // Replace with the actual valid token or retrieve it from the data store

    //        // Verify the validity of the confirmation token
    //        if (token == validToken)
    //        {
    //            return true;  // Valid token
    //        }
    //        else
    //        {
    //            return false;  // Invalid token
    //        }
    //    }
    }
}