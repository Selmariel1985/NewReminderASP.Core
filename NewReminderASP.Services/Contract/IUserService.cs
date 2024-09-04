using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    ///     Service contract for user-related operations.
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        // Users

        /// <summary>
        ///     Get a list of all users.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<UserDto> GetUsers();

        /// <summary>
        ///     Get a user by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        UserDto GetUser(int id);

        /// <summary>
        ///     Get a user by their login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [OperationContract]
        UserDto GetUserByLogin(string login);

        /// <summary>
        ///     Get a user by their email address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [OperationContract]
        UserDto GetUserByEmail(string email);

        /// <summary>
        ///     Update the provided user's information.
        /// </summary>
        /// <param name="updatedUser"></param>
        [OperationContract]
        void UpdateUser(UserDto updatedUser);

        /// <summary>
        ///     Add a new user.
        /// </summary>
        /// <param name="user"></param>
        [OperationContract]
        void AddUser(UserDto user);

        /// <summary>
        ///     Delete a user by their ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void DeleteUser(int id);

        /// <summary>
        ///     Get a user by their password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        UserDto GetUserByPassword(string password);

        /// <summary>
        ///     Get a user by their password and login.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        [OperationContract]
        UserDto GetUserByPasswordAndLogin(string password, string login);

        // User Roles

        /// <summary>
        ///     Get a user by their password and login.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        RoleDto[] GetRoles();

        /// <summary>
        ///     Get the roles of a specific user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        UserRoleDto GetUserRoles(int userId);

        /// <summary>
        ///     Add a new role.
        /// </summary>
        /// <param name="role"></param>
        [OperationContract]
        void AddRole(RoleDto role);

        /// <summary>
        ///     Add a user role.
        /// </summary>
        /// <param name="userRole"></param>
        [OperationContract]
        void AddUserRole(UserRoleDto userRole);

        /// <summary>
        ///     Update the provided role's information.
        /// </summary>
        /// <param name="updatedRole"></param>
        [OperationContract]
        void UpdateRole(RoleDto updatedRole);

        /// <summary>
        ///     Remove a role by its ID.
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void RemoveRole(int id);

        /// <summary>
        ///     Get user roles.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        UserRoleDto[] GetUsersRoles();

        /// <summary>
        ///     Get a role by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        RoleDto GetRolesByID(int id);

        /// <summary>
        ///     Assign roles to a user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        [OperationContract]
        void AssignRolesToUser(UserDto user, List<string> roles);

        /// <summary>
        ///     Update the roles of a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        [OperationContract]
        void UpdateUserRoles(int userId, string roleIds);

        /// <summary>
        ///     Add a normal user role.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="roleName"></param>
        [OperationContract]
        void AddUserRoleNormal(string userLogin, string roleName);
    }
}