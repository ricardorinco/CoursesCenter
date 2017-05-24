using System;

namespace RR.CoursesCenter.Domain.Models
{
    public class OrderDetail : Entity
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
