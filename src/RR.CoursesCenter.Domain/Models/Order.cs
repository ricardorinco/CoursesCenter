using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Models
{
    public class Order : Entity
    {
        public DateTime OrderDateTime { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}