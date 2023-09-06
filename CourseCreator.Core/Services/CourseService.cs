using CourseCreator.Core.Servieces.Interfaces;
using CourseCreator.Datalayer.Context;
using CourseCreator.Datalayer.Entities.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseCreatorContext _context;
        public CourseService(CourseCreatorContext context)
        {
            _context = context;
        }


        public List<CourseGroup> GetAllGroups()
        {
            return _context.CourseGroups.ToList();
        }
    }
}
