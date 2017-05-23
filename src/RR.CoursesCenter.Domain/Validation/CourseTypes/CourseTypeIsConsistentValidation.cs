using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.CourseTypes;

namespace RR.CoursesCenter.Domain.Validation.CourseTypes
{
    public class CourseTypeIsConsistentValidation : Validator<CourseType>
    {
        public CourseTypeIsConsistentValidation()
        {
            var couseTypeIdentification = new CourseTypeContainsIdentificationSpecification();

            Add("couseTypeIdentification", new Rule<CourseType>(couseTypeIdentification, "A identificação do Tipo de Curso deve conter no mínimo 3 caracteres."));
        }
    }
}
