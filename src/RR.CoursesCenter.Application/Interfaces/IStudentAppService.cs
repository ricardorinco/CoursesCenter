using RR.CoursesCenter.Application.ViewModels;
using System.Collections.Generic;

namespace RR.CoursesCenter.Application.Interfaces
{
    public interface IStudentAppService : IAppService<StudentViewModel>
    {
        IEnumerable<StudentViewModel> GetByIdentification(string identification);
        StudentViewModel GetByAcademicRegistration(int academicRegistration);
        StudentViewModel GetByEmail(string email);
        IEnumerable<StudentViewModel> GetActive();
        IEnumerable<StudentViewModel> GetInactive();
        int GetNextAcademicRegistration();
    }
}
