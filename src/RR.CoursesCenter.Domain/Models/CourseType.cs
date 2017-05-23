using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Validation.CourseTypes;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Models
{
    public class CourseType : Entity
    {
        public string Identification { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CourseTypeIsConsistentValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
