using RR.CoursesCenter.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Application.Interfaces
{
    public interface IOrderAppService : IAppService<OrderViewModel>
    {
        OrderViewModel GetByOrderDateTime(DateTime orderDateTime);
        IEnumerable<OrderViewModel> GetByOrderDateTimePeriod(DateTime initialOrderDateTime, DateTime finalOrderDateTime);
        IEnumerable<OrderViewModel> GetByStudent(Guid studentId);
    }
}
