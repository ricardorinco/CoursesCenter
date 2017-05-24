using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Instructors;

namespace RR.CoursesCenter.Domain.Validation.Instructors
{
    public class InstructorReadyToRegisterValidation : Validator<Instructor>
    {
        public InstructorReadyToRegisterValidation(IInstructorRepository instructorRepository)
        {
            var instructorLicenseNumberDuplicate = new InstructorMustHaveUniqueLicenseNumberSpecification(instructorRepository);
            var instructorEmailDuplicate = new InstructorMustHaveUniqueEmailSpecification(instructorRepository);

            Add("instructorLicenseNumberDuplicate", new Rule<Instructor>(instructorLicenseNumberDuplicate, "Número de Licença informado já está cadastrado na base de dados."));
            Add("instructorEmailDuplicate", new Rule<Instructor>(instructorEmailDuplicate, "E-mail já cadastrado na base de dados."));
        }
    }
}