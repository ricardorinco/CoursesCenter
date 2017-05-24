using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.CourseTypes;

namespace RR.CoursesCenter.Domain.Validation.CourseTypes
{
    public class CourseTypeIsConsistentValidation : Validator<CourseType>
    {
        public CourseTypeIsConsistentValidation()
        {
            var courseTypeIdentification = new CourseTypeMustContainIdentificationSpecification();

            Add("courseTypeIdentification", new Rule<CourseType>(courseTypeIdentification, "A identificação do Tipo de Curso deve conter no mínimo 3 caracteres."));
        }
    }
}
