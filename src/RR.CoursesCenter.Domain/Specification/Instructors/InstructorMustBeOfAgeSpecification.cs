using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Base;

namespace RR.CoursesCenter.Domain.Specification.Instructors
{
    class InstructorMustBeOfAgeSpecification : ISpecification<Instructor>
    {
        public bool IsSatisfiedBy(Instructor instructor)
        {
            return OfAgeValidation.Validate(instructor.BirthDate);
        }
    }
}
