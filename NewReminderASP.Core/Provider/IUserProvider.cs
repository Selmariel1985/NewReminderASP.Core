using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    /// Interface for providing user-related functionality.
    /// </summary>
    public interface IUserProvider
    {
        // Users

        /// <summary>
        /// Get all users.
        /// </summary>
        List<User> GetUsers();

        /// <summary>
        /// Get a user by ID.
        /// </summary>
        User GetUser(int id);

        /// <summary>
        /// Get a user by login.
        /// </summary>
        User GetUserByLogin(string login);

        /// <summary>
        /// Get a user by email.
        /// </summary>
        User GetUserByEmail(string email);

        /// <summary>
        /// Update an existing user.
        /// </summary>
        void UpdateUser(User updatedUser);

        /// <summary>
        /// Add a new user.
        /// </summary>
        void AddUser(User user);

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        void DeleteUser(int id);

        /// <summary>
        /// Get a user by password.
        /// </summary>
        User GetUserByPassword(string password);

        /// <summary>
        /// Get a user by password and login.
        /// </summary>
        User GetUserByPasswordAndLogin(string password, string login);

        // Roles

        /// <summary>
        /// Get all roles.
        /// </summary>
        List<Role> GetRoles();

        /// <summary>
        /// Get a role by ID.
        /// </summary>
        Role GetRolesByID(int id);

        /// <summary>
        /// Get user roles by user ID.
        /// </summary>
        UserRole GetUserRoles(int userId);

        /// <summary>
        /// Get all users' roles.
        /// </summary>
        List<UserRole> GetUsersRoles();

        /// <summary>
        /// Add a new role.
        /// </summary>
        void AddRole(Role role);

        /// <summary>
        /// Add a user role.
        /// </summary>
        void AddUserRole(UserRole userRole);

        /// <summary>
        /// Update an existing role.
        /// </summary>
        void UpdateRole(Role updatedRole);

        /// <summary>
        /// Remove a role by ID.
        /// </summary>
        void RemoveRole(int id);

        /// <summary>
        /// Assign roles to a user.
        /// </summary>
        void AssignRolesToUser(User user, List<string> roles);

        // User Role Management

        /// <summary>
        /// Add a normal user role.
        /// </summary>
        void AddUserRoleNormal(string userLogin, string roleName);

        /// <summary>
        /// Update user roles.
        /// </summary>
        void UpdateUserRoles(int userId, string roleIds);
    }
}
