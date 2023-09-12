using CourseCreator.Core.Convertors;
using CourseCreator.Core.DTOs;
using CourseCreator.Core.Security;
using CourseCreator.Core.Services.Interfaces;
using CourseCreator.Core.Utils;
using CourseCreator.Datalayer.Context;
using CourseCreator.Datalayer.Entities.User;

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

        public SideBarUserPanelViewModel GetSidebarUserPanelData(string username)
        {
            return _context.Users.Where(u => u.Username == username).Select(u => new SideBarUserPanelViewModel
            { 
                Username = u.Username,
                ImageName = u.UserAvatar,
                RegisterDate = u.RegisterDate,
            }).Single();
        }

        public EditProfileViewModel GetDataForEditProfileUser(string username)
        {
            return _context.Users.Where(u => u.Username == username).Select(u => new EditProfileViewModel()
            {
                AvatarName = u.UserAvatar,
                Username = u.Username,
                Email = u.Email,
            }).Single();
        }

        public int AddUserFromAdmin(CreateUserViewModel createUser)
        {
            User user = new User();
            user.Password = HashString.hashString(createUser.Password);
            user.ActiveCode = CodeGenerator.stringCodeGenerator();
            user.Email = createUser.Email;
            user.IsActive = true;
            user.RegisterDate = DateTime.Now;
            user.Username = createUser.Username;
            //Save avatar
             if (user.UserAvatar != null)
            {
                string imagePath = "";
                user.UserAvatar = CodeGenerator.stringCodeGenerator() + Path.GetExtension(user.UserAvatar);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatar);
                using(var stream = new FileStream(imagePath, FileMode.Create)) 
                {
                    createUser.UserAvatar.CopyTo(stream);
                }
            }

            return AddUser(user);
        }

        //public void EditProfile(EditProfileViewModel profile)
        //{
        //    if(profile.UserAvatar != null)
        //    {
        //        string imagePath = "";
        //        if (profile.AvatarName != "default.png")
        //        {
        //            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
        //            if(File.Exists(imagePath))
        //            {
        //                File.Delete(imagePath);
        //            }
        //        }
        //        string imageName = Guid.NewGuid().ToString();
        //    }
        //}
    }
}
