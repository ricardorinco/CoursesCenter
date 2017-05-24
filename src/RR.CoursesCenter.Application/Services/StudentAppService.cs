using AutoMapper;
using RR.CoursesCenter.Application.Interfaces;
using RR.CoursesCenter.Application.ViewModels;
using RR.CoursesCenter.Domain.Interfaces.Services;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentService studentService;
        private readonly IUnitOfWork unitOfWork;

        public StudentAppService(IStudentService studentService, IUnitOfWork unitOfWork)
        {
            this.studentService = studentService;
            this.unitOfWork = unitOfWork;
        }

        public StudentViewModel Add(StudentViewModel studentViewModel)
        {
            var student = Mapper.Map<Student>(studentViewModel);
            var studentReturn = studentService.Add(student);

            if (studentReturn.ValidationResult.IsValid)
            {
                unitOfWork.Commit();
            }

            studentViewModel = Mapper.Map<StudentViewModel>(studentReturn);

            return studentViewModel;
        }

        public StudentViewModel Update(StudentViewModel studentViewModel)
        {
            var student = Mapper.Map<Student>(studentViewModel);
            var studentReturn = studentService.Update(student);

            if (studentReturn.ValidationResult.IsValid)
            {
                unitOfWork.Commit();
            }

            studentViewModel = Mapper.Map<StudentViewModel>(studentReturn);

            return studentViewModel;
        }

        public void Remove(Guid id)
        {
            studentService.Remove(id);
            unitOfWork.Commit();
        }

        public StudentViewModel GetById(Guid id)
        {
            return Mapper.Map<StudentViewModel>(studentService.GetById(id));
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<StudentViewModel>>(studentService.GetAll());
        }

        public IEnumerable<StudentViewModel> GetByIdentification(string identification)
        {
            return Mapper.Map<IEnumerable<StudentViewModel>>(studentService.GetByIdentification(identification));
        }

        public StudentViewModel GetByAcademicRegistration(int academicRegistration)
        {
            return Mapper.Map<StudentViewModel>(studentService.GetByAcademicRegistration(academicRegistration));
        }

        public StudentViewModel GetByEmail(string email)
        {
            return Mapper.Map<StudentViewModel>(studentService.GetByEmail(email));
        }

        public IEnumerable<StudentViewModel> GetActive()
        {
            return Mapper.Map<IEnumerable<StudentViewModel>>(studentService.GetActive());
        }

        public IEnumerable<StudentViewModel> GetInactive()
        {
            return Mapper.Map<IEnumerable<StudentViewModel>>(studentService.GetInactive());
        }

        public int GetNextAcademicRegistration()
        {
            return studentService.GetNextAcademicRegistration();
        }

        public void Dispose()
        {
            studentService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}