using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Interface for accessing and managing user-related data.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<User> GetUsers();

        /// <summary>
        ///     Get a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns></returns>
        User GetUser(int id);

        /// <summary>
        ///     Get a user by login.
        /// </summary>
        /// <param name="login">The login of the user</param>
        /// <returns></returns>
        User GetUserByLogin(string login);

        /// <summary>
        ///     Get a user by email.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns></returns>
        User GetUserByEmail(string email);

        /// <summary>
        ///     Update an existing user.
        /// </summary>
        /// <param name="updatedUser">The updated user object</param>
        void UpdateUser(User updatedUser);

        /// <summary>
        ///     Add a new user.
        /// </summary>
        /// <param name="user">The user to be added</param>
        void AddUser(User user);

        /// <summary>
        ///     Delete a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete</param>
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

        /// <summary>
        ///     Add a role.
        /// </summary>
        void AddRole(Role role);

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
        ///     Get all roles.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Role> GetRoles();

        /// <summary>
        ///     Get all users' roles.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<UserRole> GetUsersRoles();

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
        ///     Add a user role.
        /// </summary>
        /// <param name="userRole"></param>
        void AddUserRole(UserRole userRole);

        /// <summary>
        ///     Assign roles to a user.
        /// </summary>
        /// <param name="user">The user to assign roles to</param>
        /// <param name="roles">The roles to be assigned</param>
        void AssignRolesToUser(User user, List<string> roles);

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