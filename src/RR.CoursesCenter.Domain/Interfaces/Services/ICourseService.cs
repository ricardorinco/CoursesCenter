using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Services
{
    public interface ICourseService : IDisposable
    {
        Course Add(Course course);
        Course Update(Course course);
        void Remove(Guid id);

        Course GetById(Guid id);
        IEnumerable<Course> GetAll();

        IEnumerable<Course> GetByIdentification(string identification);
        IEnumerable<Course> GetByLimitMaxPrice(decimal price);
        IEnumerable<Course> GetByCourseType(Guid courseTypeId);
        IEnumerable<Course> GetByInstructor(Guid instructorId);
        IEnumerable<Course> GetActive();
        IEnumerable<Course> GetInactive();
    }
}