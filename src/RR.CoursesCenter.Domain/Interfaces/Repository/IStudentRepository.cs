using RR.CoursesCenter.Domain.Models;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetByIdentification(string identification);
        Student GetByAcademicRegistration(int academicRegistration);
        Student GetByEmail(string email);
        IEnumerable<Student> GetActive();
        IEnumerable<Student> GetInactive();
        int GetNextAcademicRegistration();
    }
}
