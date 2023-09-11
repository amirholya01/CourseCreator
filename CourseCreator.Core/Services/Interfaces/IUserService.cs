using CourseCreator.Core.DTOs;
using CourseCreator.Datalayer.Entities.User;

namespace CourseCreator.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUsernameExist(string username);
        bool IsEmailExist(string email);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        bool ActiveAccount(string activeCode);
        User GetUserByUsername(string username);

        #region User Panel
        InformationUserViewModel GetUserInformation(string username);
        #endregion

        #region Admin Panel
        UserForAdminViewModel GetUsers(int PageId = 1, string filterEmail = "", string filterUsername = "");
        #endregion
    }
}
