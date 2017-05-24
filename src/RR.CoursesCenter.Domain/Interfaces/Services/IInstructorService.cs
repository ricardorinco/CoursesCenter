using RR.CoursesCenter.Domain.Models;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Interfaces.Services
{
    public interface IInstructorService : IDisposable
    {
        Instructor Add(Instructor instructor);
        Instructor Update(Instructor instructor);
        void Remove(Guid id);

        Instructor GetById(Guid id);
        IEnumerable<Instructor> GetAll();

        IEnumerable<Instructor> GetByIdentification(string identification);
        Instructor GetByLicenseNumber(int licenseNumber);
        Instructor GetByEmail(string email);
        IEnumerable<Instructor> GetActive();
        IEnumerable<Instructor> GetInactive();
    }
}
