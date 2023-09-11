using CourseCreator.Core.Convertors;
using CourseCreator.Core.DTOs;
using CourseCreator.Core.Security;
using CourseCreator.Core.Services.Interfaces;
using CourseCreator.Core.Utils;
using CourseCreator.Datalayer.Context;
using CourseCreator.Datalayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Services
{

    public class UserService : IUserService
    {

        private readonly CourseCreatorContext _context;


        public UserService(CourseCreatorContext context)
        {
            _context = context;
        }

    

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = HashString.hashString(login.Password);
            string email = InputConvertors.EmailValidator(login.Email);
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == hashPassword);
        }

        public bool ActiveAccount(string avtiveCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == avtiveCode);
            if (user == null || user.IsActive)
                return false;
            user.IsActive = true;
            user.ActiveCode = CodeGenerator.stringCodeGenerator();
            _context.SaveChanges();
            return true;
        }
        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }
        public InformationUserViewModel GetUserInformation(string username)
        {
            var user = GetUserByUsername(username);
            InformationUserViewModel information = new InformationUserViewModel();
            information.Username = user.Username;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;

            return information;
        }

        public UserForAdminViewModel GetUsers(int PageId = 1, string filterEmail = "", string filterUsername = "")
        {
            IQueryable<User> result = _context.Users;

            if(!string.IsNullOrEmpty(filterEmail))
                result = result.Where(u => u.Email.Contains(filterEmail));

            if (!string.IsNullOrEmpty(filterUsername))
                result = result.Where(u => u.Username.Contains(filterUsername));

            int take = 20;
            int skip = (PageId - 1 ) * take;

           
            UserForAdminViewModel list = new UserForAdminViewModel();
            list.CurrentPage = PageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            return list;
        }
    }
}
