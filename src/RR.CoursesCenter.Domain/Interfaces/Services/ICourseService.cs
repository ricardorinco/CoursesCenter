using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Services
{
    public interface ICourseService : IService<Course>
    {
        IEnumerable<Course> GetByLimitMaxPrice(decimal price);
        IEnumerable<Course> GetByCourseType(Guid courseTypeId);
        IEnumerable<Course> GetByInstructor(Guid instructorId);
    }
}