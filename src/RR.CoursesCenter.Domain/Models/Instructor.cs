using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Validation.Instructors;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Models
{
    public class Instructor : Entity
    {
        public string Identification { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int LicenseNumber { get; set; }
        public bool Active { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new InstructorIsConsistentValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}