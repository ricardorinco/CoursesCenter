using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Courses;

namespace RR.CoursesCenter.Domain.Validation.Courses
{
    public class CourseIsConsistentValidation : Validator<Course>
    {
        public CourseIsConsistentValidation()
        {
            var courseIdentification = new CourseMustContainIdentificationSpecification();
            var coursePrice = new CoursePriceCanNotBeNegativeSpecification();
            var courseCourseTypeId = new CourseMustBeContainCourseTypeSpecification();
            var courseInstructor = new CourseMustBeContainInstructorSpecification();

            Add("courseIdentification", new Rule<Course>(courseIdentification, "A identificação do Curso deve conter no mínimo 3 caracteres."));
            Add("coursePrice", new Rule<Course>(coursePrice, "Preço do Curso não conter valores negativos."));
            Add("courseCourseTypeId", new Rule<Course>(courseCourseTypeId, "Curso obrigatoriamente deve conter um Tipo de Curso."));
            Add("courseInstructor", new Rule<Course>(courseInstructor, "Curso obrigatoriamente deve conter um Instrutor."));
        }
    }
}
