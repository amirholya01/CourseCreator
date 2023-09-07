using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Datalayer.Entities.User
{
    public class Role
    {
        public Role()
        {
            
        }


        [Key]
        public int RoleId { get; set; }


        [Display(Name = "title of role")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(200, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string RoleTitle { get; set; }

        #region Relations
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion

    }
}
