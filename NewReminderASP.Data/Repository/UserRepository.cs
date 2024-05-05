using System.Collections.Generic;
using NewReminderASP.Data.Client;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserClient _userClient;


        public UserRepository(IUserClient userClient)
        {
            _userClient = userClient;
        }

        public IReadOnlyList<User> GetUsers()
        {
            return _userClient.GetUsers();
        }


        public User GetUser(int id)
        {
            return _userClient.GetUser(id);
        }

        public User GetUserByLogin(string login)
        {
            return _userClient.GetUserByLogin(login);
        }

        public User GetUserByEmail(string email)
        {
            return _userClient.GetUserByEmail(email);
        }

        public void UpdateUser(User updatedUser)
        {
            _userClient.UpdateUser(updatedUser);
        }

        public void AddUser(User user)
        {
            _userClient.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            _userClient.DeleteUser(id);
        }

        public User GetUserByPassword(string password)
        {
            return _userClient.GetUserByPassword(password);
        }

        public User GetUserByPasswordAndLogin(string password, string login)
        {
            return _userClient.GetUserByPasswordAndLogin(password, login);
        }

        public void AddRole(Role role)
        {
            _userClient.AddRole(role);
        }

        public void RemoveRole(int id)
        {
            _userClient.RemoveRole(id);
        }

        public void UpdateRole(Role updatedRole)
        {
            _userClient.UpdateRole(updatedRole);
        }


        public IReadOnlyList<Role> GetRoles()
        {
            return _userClient.GetRoles();
        }

        public IReadOnlyList<UserRole> GetUsersRoles()
        {
            return _userClient.GetUsersRoles();
        }

        public Role GetRolesByID(int id)
        {
            return _userClient.GetRolesByID(id);
        }


        public UserRole GetUserRoles(int userId)
        {
            return _userClient.GetUserRoles(userId);
        }

        public void AddUserRole(UserRole userRole)
        {
            _userClient.AddUserRole(userRole);
        }

        public void AssignRolesToUser(User user, List<string> roles)
        {
            _userClient.AssignRolesToUser(user, roles);
        }

        public void AddUserRoleNormal(string userLogin, string roleName)
        {
            _userClient.AddUserRoleNormal(userLogin, roleName);
        }

        public void UpdateUserRoles(int userId, string roleIds)
        {
            _userClient.UpdateUserRoles(userId, roleIds);
        }
    }
}