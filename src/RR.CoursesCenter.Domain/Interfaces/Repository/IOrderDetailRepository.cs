using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Repository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetByOrder(Guid orderId);
        IEnumerable<OrderDetail> GetByCourse(Guid courseId);
    }
}
