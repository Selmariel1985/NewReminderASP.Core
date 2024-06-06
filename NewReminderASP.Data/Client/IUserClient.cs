using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Client
{
    /// <summary>
    /// Interface for interacting with user-related data.
    /// </summary>
    public interface IUserClient
    {
        // User methods
        IReadOnlyList<User> GetUsers();
        User GetUser(int id);
        User GetUserByLogin(string login);
        User GetUserByEmail(string email);
        void UpdateUser(User updatedUser);
        void AddUser(User user);
        void DeleteUser(int id);
        User GetUserByPassword(string password);
        User GetUserByPasswordAndLogin(string password, string login);

        // Role methods
        void AddRole(Role role);
        void UpdateRole(Role updatedRole);
        void RemoveRole(int id);
        IReadOnlyList<Role> GetRoles();
        Role GetRolesByID(int id);

        // User roles and assignments
        IReadOnlyList<UserRole> GetUsersRoles();
        UserRole GetUserRoles(int userId);
        void AddUserRole(UserRole userRole);
        void AssignRolesToUser(User user, List<string> roles);
        void AddUserRoleNormal(string userLogin, string roleName);
        void UpdateUserRoles(int userId, string roleIds);
    }
}