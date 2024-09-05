using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Core.Provider
{
    /// <summary>
    ///     Interface for providing user-related functionality.
    /// </summary>
    public interface IUserProvider
    {
        // Users

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <returns></returns>
        List<User> GetUsers();

        /// <summary>
        ///     Get a user by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUser(int id);

        /// <summary>
        ///     Get a user by login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        User GetUserByLogin(string login);

        /// <summary>
        ///     Get a user by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUserByEmail(string email);

        /// <summary>
        ///     Update an existing user.
        /// </summary>
        /// <param name="updatedUser"></param>
        void UpdateUser(User updatedUser);

        /// <summary>
        ///     Add a new user.
        /// </summary>
        /// <param name="user"></param>
        void AddUser(User user);

        /// <summary>
        ///     Delete a user by ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(int id);

        /// <summary>
        ///     Get a user by password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        User GetUserByPassword(string password);

        /// <summary>
        ///     Get a user by password and login.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        User GetUserByPasswordAndLogin(string password, string login);

        // Roles

        /// <summary>
        ///     Get all roles.
        /// </summary>
        /// <returns></returns>
        List<Role> GetRoles();

        /// <summary>
        ///     Get a role by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Role GetRolesByID(int id);

        /// <summary>
        ///     Get user roles by user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserRole GetUserRoles(int userId);

        /// <summary>
        ///     Get all users' roles.
        /// </summary>
        /// <returns></returns>
        List<UserRole> GetUsersRoles();

        /// <summary>
        ///     Add a new role.
        /// </summary>
        /// <param name="role"></param>
        void AddRole(Role role);

        /// <summary>
        ///     Add a user role.
        /// </summary>
        /// <param name="userRole"></param>
        void AddUserRole(UserRole userRole);

        /// <summary>
        ///     Update an existing role.
        /// </summary>
        /// <param name="updatedRole"></param>
        void UpdateRole(Role updatedRole);

        /// <summary>
        ///     Remove a role by ID.
        /// </summary>
        /// <param name="id"></param>
        void RemoveRole(int id);

        /// <summary>
        ///     Assign roles to a user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        void AssignRolesToUser(User user, List<string> roles);

        // User Role Management

        /// <summary>
        ///     Add a normal user role.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="roleName"></param>
        void AddUserRoleNormal(string userLogin, string roleName);

        /// <summary>
        ///     Update user roles.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        void UpdateUserRoles(int userId, string roleIds);
    }
}