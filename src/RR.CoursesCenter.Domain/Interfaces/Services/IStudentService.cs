using RR.CoursesCenter.Domain.Models;

namespace RR.CoursesCenter.Domain.Interfaces.Services
{
    public interface IStudentService : IService<Student>
    {
        Student GetByAcademicRegistration(int academicRegistration);
        Student GetByEmail(string email);
        int GetNextAcademicRegistration();
    }
}