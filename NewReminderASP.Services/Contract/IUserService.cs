using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    /// <summary>
    /// Service contract for user-related operations.
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        // Users

        /// <summary>
        /// Get a list of all users.
        /// </summary>
        [OperationContract]
        List<UserDto> GetUsers();

        /// <summary>
        /// Get a user by their ID.
        /// </summary>
        [OperationContract]
        UserDto GetUser(int id);

        /// <summary>
        /// Get a user by their login.
        /// </summary>
        [OperationContract]
        UserDto GetUserByLogin(string login);

        /// <summary>
        /// Get a user by their email address.
        /// </summary>
        [OperationContract]
        UserDto GetUserByEmail(string email);

        /// <summary>
        /// Update the provided user's information.
        /// </summary>
        [OperationContract]
        void UpdateUser(UserDto updatedUser);

        /// <summary>
        /// Add a new user.
        /// </summary>
        [OperationContract]
        void AddUser(UserDto user);

        /// <summary>
        /// Delete a user by their ID.
        /// </summary>
        [OperationContract]
        void DeleteUser(int id);

        /// <summary>
        /// Get a user by their password.
        /// </summary>
        [OperationContract]
        UserDto GetUserByPassword(string password);

        /// <summary>
        /// Get a user by their password and login.
        /// </summary>
        [OperationContract]
        UserDto GetUserByPasswordAndLogin(string password, string login);

        // User Roles

        /// <summary>
        /// Get a list of all roles.
        /// </summary>
        [OperationContract]
        RoleDto[] GetRoles();

        /// <summary>
        /// Get the roles of a specific user.
        /// </summary>
        [OperationContract]
        UserRoleDto GetUserRoles(int userId);

        /// <summary>
        /// Add a new role.
        /// </summary>
        [OperationContract]
        void AddRole(RoleDto role);

        /// <summary>
        /// Add a user role.
        /// </summary>
        [OperationContract]
        void AddUserRole(UserRoleDto userRole);

        /// <summary>
        /// Update the provided role's information.
        /// </summary>
        [OperationContract]
        void UpdateRole(RoleDto updatedRole);

        /// <summary>
        /// Remove a role by its ID.
        /// </summary>
        [OperationContract]
        void RemoveRole(int id);

        /// <summary>
        /// Get user roles.
        /// </summary>
        [OperationContract]
        UserRoleDto[] GetUsersRoles();

        /// <summary>
        /// Get a role by its ID.
        /// </summary>
        [OperationContract]
        RoleDto GetRolesByID(int id);

        /// <summary>
        /// Assign roles to a user.
        /// </summary>
        [OperationContract]
        void AssignRolesToUser(UserDto user, List<string> roles);

        /// <summary>
        /// Update the roles of a user.
        /// </summary>
        [OperationContract]
        void UpdateUserRoles(int userId, string roleIds);

        /// <summary>
        /// Add a normal user role.
        /// </summary>
        [OperationContract]
        void AddUserRoleNormal(string userLogin, string roleName);
    }
}
