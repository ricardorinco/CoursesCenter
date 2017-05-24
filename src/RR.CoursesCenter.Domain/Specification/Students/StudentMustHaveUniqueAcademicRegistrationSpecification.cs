using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;

namespace RR.CoursesCenter.Domain.Specification.Students
{
    public class StudentMustHaveUniqueAcademicRegistrationSpecification : ISpecification<Student>
    {
        private readonly IStudentRepository studentRepository;

        public StudentMustHaveUniqueAcademicRegistrationSpecification(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public bool IsSatisfiedBy(Student student)
        {
            return studentRepository.GetByAcademicRegistration(student.AcademicRegistration) == null;
        }
    }
}
