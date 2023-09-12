using CourseCreator.Datalayer.Entities.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.DTOs
{
    public class UserForAdminViewModel
    {
        public List<User> Users { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class CreateUserViewModel
    {
        [Display(Name = "username")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(30, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Username { get; set; }


        [Display(Name = "email")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        [EmailAddress(ErrorMessage = "Your {0} address is not valid.")]
        public string Email { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Password { get; set; }

        public  IFormFile UserAvatar { get; set; }
        //public List<int> SelectedRoles { get; set; }



    }
}
