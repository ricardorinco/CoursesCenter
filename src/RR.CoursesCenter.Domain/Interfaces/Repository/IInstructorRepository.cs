using RR.CoursesCenter.Domain.Models;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Repository
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        IEnumerable<Instructor> GetByIdentification(string identification);
        Instructor GetByLicenseNumber(int licenseNumber);
        Instructor GetByEmail(string email);
        IEnumerable<Instructor> GetActive();
        IEnumerable<Instructor> GetInactive();
    }
}
