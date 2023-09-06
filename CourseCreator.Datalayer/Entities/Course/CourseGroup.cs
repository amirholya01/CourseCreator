using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Datalayer.Entities.Course
{
    public class CourseGroup
    {
        [Key]
        public int CourseGroupId { get; set; }

        [Display(Name = "title of group")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(200, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string GroupTitle { get; set; }

        [Display(Name = "Is delete?")]
        public bool IsDelete { get; set; }

        [Display(Name = "main group")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public ICollection<CourseGroup> CourseGroups { get; set; }
    }
}
