using RR.CoursesCenter.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Application.Interfaces
{
    public interface ICourseAppService : IAppService<CourseViewModel>
    {
        IEnumerable<CourseViewModel> GetByIdentification(string identification);
        IEnumerable<CourseViewModel> GetByLimitMaxPrice(decimal price);
        IEnumerable<CourseViewModel> GetByCourseType(Guid courseTypeId);
        IEnumerable<CourseViewModel> GetByInstructor(Guid instructorId);
        IEnumerable<CourseViewModel> GetActive();
        IEnumerable<CourseViewModel> GetInactive();
    }
}
