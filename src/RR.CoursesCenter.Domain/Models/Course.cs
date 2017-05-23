using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.CoursesCenter.Domain.Models
{
    public class Course : Entity
    {
        public string Identification { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }

        public Guid CourseTypeId { get; set; }
        public virtual CourseType CourseType { get; set; }

        public Guid InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            

            return ValidationResult.IsValid;
        }
    }
}