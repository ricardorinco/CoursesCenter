using RR.CoursesCenter.Application.ViewModels;
using System.Collections.Generic;

namespace RR.CoursesCenter.Application.Interfaces
{
    public interface ICourseTypeAppService : IAppService<CourseTypeViewModel>
    {
        IEnumerable<CourseTypeViewModel> GetByIdentification(string identification);
        IEnumerable<CourseTypeViewModel> GetActive();
        IEnumerable<CourseTypeViewModel> GetInactive();
    }
}
