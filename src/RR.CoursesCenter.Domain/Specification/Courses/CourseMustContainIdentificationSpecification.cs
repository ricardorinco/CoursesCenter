using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation;

namespace RR.CoursesCenter.Domain.Specification.Courses
{
    public class CourseMustContainIdentificationSpecification : ISpecification<Course>
    {
        public bool IsSatisfiedBy(Course course)
        {
            return IdentificationValidation.Validate(course.Identification);
        }
    }
}