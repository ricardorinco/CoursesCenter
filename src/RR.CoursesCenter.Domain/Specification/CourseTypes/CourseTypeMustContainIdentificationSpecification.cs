using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation;

namespace RR.CoursesCenter.Domain.Specification.CourseTypes
{
    public class CourseTypeMustContainIdentificationSpecification : ISpecification<CourseType>
    {
        public bool IsSatisfiedBy(CourseType courseType)
        {
            return IdentificationValidation.Validate(courseType.Identification);
        }
    }
}
