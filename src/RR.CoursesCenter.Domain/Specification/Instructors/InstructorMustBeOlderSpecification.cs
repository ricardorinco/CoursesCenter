using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation;

namespace RR.CoursesCenter.Domain.Specification.Instructors
{
    public class InstructorMustBeOlderSpecification : ISpecification<Instructor>
    {
        public bool IsSatisfiedBy(Instructor instructor)
        {
            return BeOlderValidation.Validate(instructor.BirthDate);
        }
    }
}
