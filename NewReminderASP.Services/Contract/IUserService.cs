using System.Collections.Generic;
using System.ServiceModel;
using NewReminderASP.Services.Dtos;

namespace NewReminderASP.Services.Contract
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<UserDto> GetUsers();

        [OperationContract]
        UserDto GetUser(int id);

        [OperationContract]
        UserDto GetUserByLogin(string login);

        [OperationContract]
        UserDto GetUserByEmail(string email);

        [OperationContract]
        void UpdateUser(UserDto updatedUser);

        [OperationContract]
        void AddUser(UserDto user);

        [OperationContract]
        void DeleteUser(int id);

        [OperationContract]
        UserDto GetUserByPassword(string password);

        [OperationContract]
        UserDto GetUserByPasswordAndLogin(string password, string login);

        [OperationContract]
        RoleDto[] GetRoles();

        [OperationContract]
        UserRoleDto GetUserRoles(int userId);

        [OperationContract]
        void AddRole(int id, string name);

        [OperationContract]
        void AddUserRole(UserRoleDto userRole);

        [OperationContract]
        void RemoveRole(int id, string name);

        [OperationContract]
        UserRoleDto[] GetUsersRoles();
        

        [OperationContract]
        RoleDto GetRolesByID(int id);

        [OperationContract]
        void AssignRolesToUser(UserDto user, List<string> roles);

        [OperationContract]
        void AddUserRoleNormal(string userLogin, string roleName);


    }
}