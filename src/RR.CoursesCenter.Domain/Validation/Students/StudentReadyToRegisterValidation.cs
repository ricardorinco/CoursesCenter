using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Students;

namespace RR.CoursesCenter.Domain.Validation.Students
{
    public class StudentReadyToRegisterValidation : Validator<Student>
    {
        public StudentReadyToRegisterValidation(IStudentRepository studentRepository)
        {
            var studentAcademicRegisterDuplicate = new StudentMustHaveUniqueAcademicRegistrationSpecification(studentRepository);
            var studentEmailDuplicate = new StudentMustHaveUniqueEmailSpecification(studentRepository);

            Add("studentAcademicRegisterDuplicate", new Rule<Student>(studentAcademicRegisterDuplicate, "R.A. informado já está cadastrado na base de dados."));
            Add("studentEmailDuplicate", new Rule<Student>(studentEmailDuplicate, "E-mail já cadastrado na base de dados."));
        }
    }
}