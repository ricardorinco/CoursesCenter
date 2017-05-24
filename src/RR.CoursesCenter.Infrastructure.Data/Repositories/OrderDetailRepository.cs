using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RR.CoursesCenter.Infrastructure.Data.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DataContext context) : base(context)
        { }

        public IEnumerable<OrderDetail> GetByOrder(Guid orderId)
        {
            return Search(od => od.OrderId == orderId).ToList();
        }

        public IEnumerable<OrderDetail> GetByCourse(Guid courseId)
        {
            return Search(od => od.CourseId == courseId).ToList();
        }
    }
}
