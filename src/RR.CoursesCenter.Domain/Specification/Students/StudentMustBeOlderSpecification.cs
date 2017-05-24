using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation;

namespace RR.CoursesCenter.Domain.Specification.Students
{
    public class StudentMustBeOlderSpecification : ISpecification<Student>
    {
        public bool IsSatisfiedBy(Student student)
        {
            return BeOlderValidation.Validate(student.BirthDate);
        }
    }
}
