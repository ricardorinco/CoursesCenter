using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using System;

namespace RR.CoursesCenter.Domain.Specification.Courses
{
    public class CourseMustBeContainCourseTypeSpecification : ISpecification<Course>
    {
        public bool IsSatisfiedBy(Course course)
        {
            return course.CourseTypeId != Guid.Parse("00000000-0000-0000-0000-000000000000");
        }
    }
}
