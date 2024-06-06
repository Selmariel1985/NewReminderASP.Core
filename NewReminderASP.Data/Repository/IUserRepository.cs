using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    /// Interface for accessing and managing user-related data.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get all users.
        /// </summary>
        IReadOnlyList<User> GetUsers();

        /// <summary>
        /// Get a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user</param>
        User GetUser(int id);

        /// <summary>
        /// Get a user by login.
        /// </summary>
        /// <param name="login">The login of the user</param>
        User GetUserByLogin(string login);

        /// <summary>
        /// Get a user by email.
        /// </summary>
        /// <param name="email">The email of the user</param>
        User GetUserByEmail(string email);

        /// <summary>
        /// Update an existing user.
        /// </summary>
        /// <param name="updatedUser">The updated user object</param>
        void UpdateUser(User updatedUser);

        /// <summary>
        /// Add a new user.
        /// </summary>
        /// <param name="user">The user to be added</param>
        void AddUser(User user);

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete</param>
        void DeleteUser(int id);

        /// <summary>
        /// Get a user by password.
        /// </summary>
        User GetUserByPassword(string password);

        /// <summary>
        /// Get a user by password and login.
        /// </summary>
        User GetUserByPasswordAndLogin(string password, string login);

        /// <summary>
        /// Add a role.
        /// </summary>
        void AddRole(Role role);

        /// <summary>
        /// Update an existing role.
        /// </summary>
        void UpdateRole(Role updatedRole);

        /// <summary>
        /// Remove a role by ID.
        /// </summary>
        void RemoveRole(int id);

        /// <summary>
        /// Get all roles.
        /// </summary>
        IReadOnlyList<Role> GetRoles();

        /// <summary>
        /// Get all users' roles.
        /// </summary>
        IReadOnlyList<UserRole> GetUsersRoles();

        /// <summary>
        /// Get a role by ID.
        /// </summary>
        Role GetRolesByID(int id);

        /// <summary>
        /// Get user roles by user ID.
        /// </summary>
        UserRole GetUserRoles(int userId);

        /// <summary>
        /// Add a user role.
        /// </summary>
        void AddUserRole(UserRole userRole);

        /// <summary>
        /// Assign roles to a user.
        /// </summary>
        /// <param name="user">The user to assign roles to</param>
        /// <param name="roles">The roles to be assigned</param>
        void AssignRolesToUser(User user, List<string> roles);

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
