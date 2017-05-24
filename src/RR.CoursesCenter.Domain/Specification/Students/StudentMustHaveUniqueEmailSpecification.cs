using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;

namespace RR.CoursesCenter.Domain.Specification.Students
{
    public class StudentMustHaveUniqueEmailSpecification : ISpecification<Student>
    {
        private readonly IStudentRepository studentRepository;

        public StudentMustHaveUniqueEmailSpecification(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public bool IsSatisfiedBy(Student student)
        {
            return studentRepository.GetByEmail(student.Email) == null;
        }
    }
}
