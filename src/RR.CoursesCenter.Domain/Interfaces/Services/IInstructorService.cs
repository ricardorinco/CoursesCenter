using RR.CoursesCenter.Domain.Models;

namespace RR.CoursesCenter.Domain.Interfaces.Services
{
    public interface IInstructorService : IService<Instructor>
    {
        Instructor GetByLicenseNumber(int licenseNumber);
        Instructor GetByEmail(string email);
    }
}
