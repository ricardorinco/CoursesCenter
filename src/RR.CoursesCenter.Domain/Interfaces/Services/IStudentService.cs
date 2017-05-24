using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Services
{
    public interface IStudentService : IDisposable
    {
        Student Add(Student student);
        Student Update(Student student);
        void Remove(Guid id);

        Student GetById(Guid id);
        IEnumerable<Student> GetAll();

        IEnumerable<Student> GetByIdentification(string identification);
        Student GetByAcademicRegistration(int academicRegistration);
        Student GetByEmail(string email);
        IEnumerable<Student> GetActive();
        IEnumerable<Student> GetInactive();
        int GetNextAcademicRegistration();
    }
}