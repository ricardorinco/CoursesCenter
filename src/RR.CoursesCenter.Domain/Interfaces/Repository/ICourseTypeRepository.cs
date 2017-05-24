using RR.CoursesCenter.Domain.Models;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Repository
{
    public interface ICourseTypeRepository : IRepository<CourseType>
    {
        IEnumerable<CourseType> GetByIdentification(string identification);
        IEnumerable<CourseType> GetActive();
        IEnumerable<CourseType> GetInactive();
    }
}