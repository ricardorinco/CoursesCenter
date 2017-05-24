using RR.CoursesCenter.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Application.Interfaces
{
    public interface IOrderDetailAppService : IAppService<OrderDetailViewModel>
    {
        IEnumerable<OrderDetailViewModel> GetByOrder(Guid orderId);
        IEnumerable<OrderDetailViewModel> GetByCourse(Guid courseId);
    }
}
