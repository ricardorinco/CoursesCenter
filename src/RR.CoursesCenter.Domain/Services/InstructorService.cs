using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Interfaces.Services;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Instructors;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        public Instructor Add(Instructor instructor)
        {
            if (!instructor.IsValid())
            {
                return instructor;
            }

            instructor.ValidationResult = new InstructorReadyToRegisterValidation(instructorRepository).Validate(instructor);

            if (!instructor.ValidationResult.IsValid)
            {
                return instructor;
            }

            return instructorRepository.Add(instructor);
        }

        public Instructor Update(Instructor instructor)
        {
            if (!instructor.IsValid())
            {
                return instructor;
            }

            return instructorRepository.Update(instructor);
        }

        public void Remove(Guid id)
        {
            instructorRepository.Remove(id);
        }

        public Instructor GetById(Guid id)
        {
            return instructorRepository.GetById(id);
        }

        public IEnumerable<Instructor> GetAll()
        {
            return instructorRepository.GetAll();
        }

        public IEnumerable<Instructor> GetByIdentification(string identification)
        {
            return instructorRepository.GetByIdentification(identification);
        }

        public Instructor GetByLicenseNumber(int licenseNumber)
        {
            return instructorRepository.GetByLicenseNumber(licenseNumber);
        }

        public Instructor GetByEmail(string email)
        {
            return instructorRepository.GetByEmail(email);
        }

        public IEnumerable<Instructor> GetActive()
        {
            return instructorRepository.GetActive();
        }

        public IEnumerable<Instructor> GetInactive()
        {
            return instructorRepository.GetInactive();
        }

        public void Dispose()
        {
            instructorRepository.Dispose();
        }
    }
}
