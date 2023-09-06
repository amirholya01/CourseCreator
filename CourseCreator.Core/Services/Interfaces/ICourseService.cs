using CourseCreator.Datalayer.Entities.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Servieces.Interfaces
{
    public interface ICourseService
    {
        #region Group
        List<CourseGroup> GetAllGroups();
        #endregion
    }
}
