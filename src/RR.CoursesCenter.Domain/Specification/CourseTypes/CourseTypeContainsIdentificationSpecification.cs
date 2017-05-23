using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Base;

namespace RR.CoursesCenter.Domain.Specification.CourseTypes
{
    public class CourseTypeContainsIdentificationSpecification : ISpecification<CourseType>
    {
        public bool IsSatisfiedBy(CourseType courseType)
        {
            return StringValidation.Validate(courseType.Identification);
        }
    }
}
