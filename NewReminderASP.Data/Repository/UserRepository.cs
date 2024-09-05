using System.Collections.Generic;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    /// <summary>
    ///     Repository class for managing user-related entities.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IUserClient _userClient;

        /// <summary>
        ///     Constructor for UserRepository.
        /// </summary>
        /// <param name="userClient">The client for accessing user data</param>
        public UserRepository(IUserClient userClient)
        {
            _userClient = userClient;
        }

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<User> GetUsers()
        {
            return _userClient.GetUsers();
        }

        /// <summary>
        ///     Get a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            return _userClient.GetUser(id);
        }

        /// <summary>
        ///     Get a user by login.
        /// </summary>
        /// <param name="login">The login of the user</param>
        /// <returns></returns>
        public User GetUserByLogin(string login)
        {
            return _userClient.GetUserByLogin(login);
        }

        /// <summary>
        ///     Get a user by email.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            return _userClient.GetUserByEmail(email);
        }

        /// <summary>
        ///     Update an existing user.
        /// </summary>
        /// <param name="updatedUser">The updated user object</param>
        public void UpdateUser(User updatedUser)
        {
            _userClient.UpdateUser(updatedUser);
        }

        /// <summary>
        ///     Add a new user.
        /// </summary>
        /// <param name="user">The user to be added</param>
        public void AddUser(User user)
        {
            _userClient.AddUser(user);
        }

        /// <summary>
        ///     Delete a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete</param>
        public void DeleteUser(int id)
        {
            _userClient.DeleteUser(id);
        }

        /// <summary>
        ///     Get a user by password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByPassword(string password)
        {
            return _userClient.GetUserByPassword(password);
        }

        /// <summary>
        ///     Get a user by password and login.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public User GetUserByPasswordAndLogin(string password, string login)
        {
            return _userClient.GetUserByPasswordAndLogin(password, login);
        }

        /// <summary>
        ///     Add a role.
        /// </summary>
        /// <param name="role"></param>
        public void AddRole(Role role)
        {
            _userClient.AddRole(role);
        }

        /// <summary>
        ///     Remove a role by ID.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveRole(int id)
        {
            _userClient.RemoveRole(id);
        }

        /// <summary>
        ///     Update an existing role.
        /// </summary>
        /// <param name="updatedRole"></param>
        public void UpdateRole(Role updatedRole)
        {
            _userClient.UpdateRole(updatedRole);
        }

        /// <summary>
        ///     Get all roles.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Role> GetRoles()
        {
            return _userClient.GetRoles();
        }

        /// <summary>
        ///     Get all users' roles.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<UserRole> GetUsersRoles()
        {
            return _userClient.GetUsersRoles();
        }

        /// <summary>
        ///     Get a role by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRolesByID(int id)
        {
            return _userClient.GetRolesByID(id);
        }

        /// <summary>
        ///     Get user roles by user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserRole GetUserRoles(int userId)
        {
            return _userClient.GetUserRoles(userId);
        }

        /// <summary>
        ///     Add a user role.
        /// </summary>
        /// <param name="userRole"></param>
        public void AddUserRole(UserRole userRole)
        {
            _userClient.AddUserRole(userRole);
        }

        /// <summary>
        ///     Assign roles to a user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        public void AssignRolesToUser(User user, List<string> roles)
        {
            _userClient.AssignRolesToUser(user, roles);
        }

        /// <summary>
        ///     Add a normal user role.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="roleName"></param>
        public void AddUserRoleNormal(string userLogin, string roleName)
        {
            _userClient.AddUserRoleNormal(userLogin, roleName);
        }

        /// <summary>
        ///     Update user roles.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        public void UpdateUserRoles(int userId, string roleIds)
        {
            _userClient.UpdateUserRoles(userId, roleIds);
        }
    }
}