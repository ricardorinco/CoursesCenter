using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetByIdentification(string identification);
        IEnumerable<Course> GetByLimitMaxPrice(decimal price);
        IEnumerable<Course> GetByCourseType(Guid courseTypeId);
        IEnumerable<Course> GetByInstructor(Guid instructorId);
        IEnumerable<Course> GetActive();
        IEnumerable<Course> GetInactive();
    }
}
