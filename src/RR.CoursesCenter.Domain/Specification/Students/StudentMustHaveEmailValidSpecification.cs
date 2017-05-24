using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation;

namespace RR.CoursesCenter.Domain.Specification.Students
{
    public class StudentMustHaveEmailValidSpecification : ISpecification<Student>
    {
        public bool IsSatisfiedBy(Student student)
        {
            return EmailValidation.Validate(student.Email);
        }
    }
}
