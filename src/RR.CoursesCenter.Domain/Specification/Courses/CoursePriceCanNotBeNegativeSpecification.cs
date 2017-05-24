using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation;

namespace RR.CoursesCenter.Domain.Specification.Courses
{
    public class CoursePriceCanNotBeNegativeSpecification : ISpecification<Course>
    {
        public bool IsSatisfiedBy(Course course)
        {
            return PriceValidation.Validate(course.Price);
        }
    }
}
