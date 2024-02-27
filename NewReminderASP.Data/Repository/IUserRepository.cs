﻿using System.Collections.Generic;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.Data.Repository
{
    public interface IUserRepository
    {
        IReadOnlyList<User> GetUsers();

        User GetUser(int id);
        User GetUserByLogin(string login);
        User GetUserByEmail(string email);
        void UpdateUser(User updatedUser);
        void AddUser(User user);
        void DeleteUser(int id);
        User GetUserByPassword(string password);
        User GetUserByPasswordAndLogin(string password, string login);
        void AddRole(int id, string name);

        void RemoveRole(int id, string name);
        IReadOnlyList<Role> GetRoles();
        IReadOnlyList<UserRole> GetUsersRoles();
        Role GetRolesByID(int id);

        UserRole GetUserRoles(int userId);


        void AddUserRole(UserRole userRole);
        void AssignRolesToUser(User user, List<string> roles);

        void AddUserRoleNormal(string userLogin, string roleName);
    }
}