using CourseCreator.Core.Convertors;
using CourseCreator.Core.DTOs;
using CourseCreator.Core.Services.Interfaces;
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

            //TODO: Register User

            return View();
        }
    }

}
