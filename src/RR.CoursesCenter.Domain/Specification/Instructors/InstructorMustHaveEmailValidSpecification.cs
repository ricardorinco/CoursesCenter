using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Base;

namespace RR.CoursesCenter.Domain.Specification.Instructors
{
    public class InstructorMustHaveEmailValidSpecification : ISpecification<Instructor>
    {
        public bool IsSatisfiedBy(Instructor instructor)
        {
            return EmailValidation.Validate(instructor.Email);
        }
    }
}
