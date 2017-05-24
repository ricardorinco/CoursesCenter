using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Services
{
    public interface ICourseTypeService : IDisposable
    {
        CourseType Add(CourseType courseType);
        CourseType Update(CourseType courseType);
        void Remove(Guid id);

        CourseType GetById(Guid id);
        IEnumerable<CourseType> GetAll();

        IEnumerable<CourseType> GetByIdentification(string identification);
        IEnumerable<CourseType> GetActive();
        IEnumerable<CourseType> GetInactive();
    }
}
