using CourseCreator.Core.Servieces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseCreator.Web.ViewComponents
{
    public class CourseGroupComponent : ViewComponent
    {
        private readonly ICourseService _courseService;
        public CourseGroupComponent(ICourseService courseService)
        {
            _courseService = courseService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("CourseGroup", _courseService.GetAllGroups()));
        }
    }
}
