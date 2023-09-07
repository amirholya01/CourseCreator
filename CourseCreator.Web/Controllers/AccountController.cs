using CourseCreator.Core.Convertors;
using CourseCreator.Core.DTOs;
using CourseCreator.Core.Security;
using CourseCreator.Core.Services.Interfaces;
using CourseCreator.Core.Utils;
using CourseCreator.Datalayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseCreator.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid)
                return View(register);

            if(_userService.IsUsernameExist(register.Username))
            {
                ModelState.AddModelError("Username", "The username is not valid.");
                return View(register);
            }

            if(_userService.IsEmailExist(InputConvertors.EmailValidator(register.Email)))
            {
                ModelState.AddModelError("Email", "The email is not valid.");
                return View(register);
            }

            User user = new User()
            {
                ActiveCode = CodeGenerator.stringCodeGenerator(),
                Email = InputConvertors.EmailValidator(register.Email),
                IsActive = false,
                Password = HashString.hashString(register.Password),
                RegisterDate = DateTime.Now,
                UserAvatar = "default.png",
                Username = register.Username,

            };
            _userService.AddUser(user);
            return View("SuccessRegister");
        }
    }

}
