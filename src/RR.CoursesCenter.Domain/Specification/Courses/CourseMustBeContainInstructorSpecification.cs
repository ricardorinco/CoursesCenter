using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using System;

namespace RR.CoursesCenter.Domain.Specification.Courses
{
    public class CourseMustBeContainInstructorSpecification : ISpecification<Course>
    {
        public bool IsSatisfiedBy(Course course)
        {
            return course.InstructorId != Guid.Parse("00000000-0000-0000-0000-000000000000");
        }
    }
}
