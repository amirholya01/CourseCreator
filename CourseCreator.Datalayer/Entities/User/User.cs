using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Datalayer.Entities.User
{
    public class User
    {

        public User()
        {
            
        }


        [Key]
        public int UserId { get; set; }

        [Display(Name = "username")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(50, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Username { get; set; }

        [Display(Name = "email")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(200, ErrorMessage = "The {0} can not be more than {1} characters.")]
        [EmailAddress(ErrorMessage = "Your {0} is not valid.")]
        public string Email { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(200, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Password { get; set; }

        [Display(Name ="active code")]
        [MaxLength(50, ErrorMessage = "The {0} can not be more than {1} characters.")]

        public string ActiveCode { get; set; }


        [Display(Name = "status")]
        public bool IsActive { get; set; }

        [Display(Name = "user image")]
        [MaxLength(200, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string UserAvatar { get; set; }

        [Display(Name = "date of ragistration")]
        public DateTime RegisterDate { get; set; }



        #region Relations
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}
