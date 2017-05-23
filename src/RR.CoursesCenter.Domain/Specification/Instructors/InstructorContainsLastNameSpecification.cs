using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Base;

namespace RR.CoursesCenter.Domain.Specification.Instructors
{
    public class InstructorContainsLastNameSpecification : ISpecification<Instructor>
    {
        public bool IsSatisfiedBy(Instructor instructor)
        {
            return StringValidation.Validate(instructor.LastName);
        }
    }
}
