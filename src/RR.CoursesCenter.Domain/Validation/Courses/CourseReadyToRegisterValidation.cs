using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Courses;

namespace RR.CoursesCenter.Domain.Validation.Courses
{
    public class CourseReadyToRegisterValidation : Validator<Course>
    {
        public CourseReadyToRegisterValidation(ICourseRepository courseRepository)
        {
            var courseType = new CourseMustBeContainCourseTypeSpecification();
            var intructor = new CourseMustBeContainInstructorSpecification();

            Add("courseType", new Rule<Course>(courseType, "Curso obrigatoriamente deve conter um Tipo de Curso."));
            Add("intructor", new Rule<Course>(intructor, "Curso obrigatoriamente deve conter um Instrutor."));
        }
    }
}