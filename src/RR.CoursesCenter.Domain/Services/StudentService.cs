using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Interfaces.Services;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Students;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Student Add(Student student)
        {
            if (!student.IsValid())
            {
                return student;
            }

            student.ValidationResult = new StudentReadyToRegisterValidation(studentRepository).Validate(student);

            if (!student.ValidationResult.IsValid)
            {
                return student;
            }

            return studentRepository.Add(student);
        }

        public Student Update(Student student)
        {
            if (!student.IsValid())
            {
                return student;
            }

            return studentRepository.Update(student);
        }

        public void Remove(Guid id)
        {
            studentRepository.Remove(id);
        }

        public Student GetById(Guid id)
        {
            return studentRepository.GetById(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        public IEnumerable<Student> GetByIdentification(string identification)
        {
            return studentRepository.GetByIdentification(identification);
        }

        public Student GetByAcademicRegistration(int academicRegistration)
        {
            return studentRepository.GetByAcademicRegistration(academicRegistration);
        }

        public Student GetByEmail(string email)
        {
            return studentRepository.GetByEmail(email);
        }

        public IEnumerable<Student> GetActive()
        {
            return studentRepository.GetActive();
        }

        public IEnumerable<Student> GetInactive()
        {
            return studentRepository.GetInactive();
        }

        public int GetNextAcademicRegistration()
        {
            return studentRepository.GetNextAcademicRegistration();
        }

        public void Dispose()
        {
            studentRepository.Dispose();
        }
    }
}
