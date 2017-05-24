using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Students;

namespace RR.CoursesCenter.Domain.Validation.Students
{
    public class StudentIsConsistentValidation : Validator<Student>
    {
        public StudentIsConsistentValidation()
        {
            var studentIdentification = new StudentMustContainIdentificationSpecification();
            var studentEmail = new StudentMustHaveEmailValidSpecification();
            var studentBeOlder = new StudentMustBeOlderSpecification();

            Add("studentIdentification", new Rule<Student>(studentIdentification, "A identificação do Estudante deve conter no mínimo 3 caracteres."));
            Add("studentEmail", new Rule<Student>(studentEmail, "Estudante informou um e-mail inválido."));
            Add("studentBeOlder", new Rule<Student>(studentBeOlder, "Estudante não tem maioridade para cadastro."));
        }
    }
}
