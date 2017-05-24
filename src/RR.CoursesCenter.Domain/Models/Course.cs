using DomainValidation.Validation;
using RR.CoursesCenter.Domain.Validation.Courses;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Models
{
    public class Course : Entity
    {
        public string Identification { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public bool Active { get; set; }

        public Guid CourseTypeId { get; set; }
        public virtual CourseType CourseType { get; set; }

        public Guid InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CourseIsConsistentValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}