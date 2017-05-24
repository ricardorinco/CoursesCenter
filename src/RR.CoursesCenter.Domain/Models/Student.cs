using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Validation.Students;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Models
{
    public class Student : Entity
    {
        public string Identification { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int AcademicRegistration { get; set; }
        public bool Active { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new StudentIsConsistentValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}