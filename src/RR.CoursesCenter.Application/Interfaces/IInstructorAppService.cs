using RR.CoursesCenter.Application.ViewModels;
using System.Collections.Generic;

namespace RR.CoursesCenter.Application.Interfaces
{
    public interface IInstructorAppService : IAppService<InstructorViewModel>
    {
        IEnumerable<InstructorViewModel> GetByIdentification(string identification);
        InstructorViewModel GetByLicenseNumber(int licenseNumber);
        InstructorViewModel GetByEmail(string email);
        IEnumerable<InstructorViewModel> GetActive();
        IEnumerable<InstructorViewModel> GetInactive();
    }
}
