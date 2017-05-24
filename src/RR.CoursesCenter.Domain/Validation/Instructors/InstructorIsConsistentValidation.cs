using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Instructors;

namespace RR.CoursesCenter.Domain.Validation.Instructors
{
    public class InstructorIsConsistentValidation : Validator<Instructor>
    {
        public InstructorIsConsistentValidation()
        {
            var instructorIdentification = new InstructorMustContainIdentificationSpecification();
            var instructorEmail = new InstructorMustHaveEmailValidSpecification();
            var instructorBeOlder = new InstructorMustBeOlderSpecification();

            Add("instructorIdentification", new Rule<Instructor>(instructorIdentification, "A identificação do Instrutor deve conter no mínimo 3 caracteres."));
            Add("instructorEmail", new Rule<Instructor>(instructorEmail, "Instrutor informou um e-mail inválido."));
            Add("instructorBeOlder", new Rule<Instructor>(instructorBeOlder, "Instrutor não tem maioridade para cadastro."));
        }
    }
}
