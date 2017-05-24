using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RR.CoursesCenter.Infrastructure.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base (context)
        { }

        public Order GetByOrderDateTime(DateTime orderDateTime)
        {
            return Search(o => o.OrderDateTime == orderDateTime).SingleOrDefault();
        }

        public IEnumerable<Order> GetByOrderDateTimePeriod(DateTime initialOrderDateTime, DateTime finalOrderDateTime)
        {
            return Search(o => o.OrderDateTime >= initialOrderDateTime && o.OrderDateTime <= finalOrderDateTime).ToList();
        }

        public IEnumerable<Order> GetByStudent(Guid studentId)
        {
            return Search(o => o.StudentId == studentId).ToList();
        }
    }
}
