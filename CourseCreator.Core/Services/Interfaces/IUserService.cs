using CourseCreator.Core.DTOs;
using CourseCreator.Datalayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
