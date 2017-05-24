using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetByOrderDateTime(DateTime orderDateTime);
        IEnumerable<Order> GetByOrderDateTimePeriod(DateTime initialOrderDateTime, DateTime finalOrderDateTime);
        IEnumerable<Order> GetByStudent(Guid studentId);
    }
}
