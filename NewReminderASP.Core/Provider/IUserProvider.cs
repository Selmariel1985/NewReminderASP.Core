using NewReminderASP.Domain.Entities;
using System.Collections.Generic;

namespace NewReminderASP.Core.Provider
{
    public interface IUserProvider
    {
        List<User> GetUsers();

        User GetUser(int id);
        User GetUserByLogin(string login);
        User GetUserByEmail(string email);

        void UpdateUser(User updatedUser);
        void AddUser(User user);
        void DeleteUser(int id);
        User GetUserByPassword(string password);

        User GetUserByPasswordAndLogin(string password, string login);

        List<Role> GetRoles();
        Role GetRolesByID(int id);
        UserRole GetUserRoles(int userId);
        List<UserRole> GetUsersRoles();


        void AddRole(Role role);
        void AddUserRole(UserRole userRole);
        void UpdateRole(Role updatedRole);
        void RemoveRole(int id);
        void AssignRolesToUser(User user, List<string> roles);

        void AddUserRoleNormal(string userLogin, string roleName);
        void UpdateUserRoles(int userId, string roleIds);
    }
}