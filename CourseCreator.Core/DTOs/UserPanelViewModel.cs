using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.DTOs
{
   public class InformationUserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
       
    }

    public class SideBarUserPanelViewModel
    {
        public string Username { get; set; }
        public DateTime RegisterDate { get; set; }
        public string ImageName { get; set; }
    }

    public class EditProfileViewModel
    {
        [Display(Name = "username")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(50, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Username { get; set; }

        [Display(Name = "email")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(200, ErrorMessage = "The {0} can not be more than {1} characters.")]
        [EmailAddress(ErrorMessage = "Your {0} is not valid.")]
        public string Email { get; set; }

        public IFormFile UserAvatar { get; set; }
        public string AvatarName { get; set; }
    }
}
