using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Models
{
    public class Instructor : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int LicenseNumber { get; set; }
        public bool Active { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {


            return ValidationResult.IsValid;
        }
    }
}
