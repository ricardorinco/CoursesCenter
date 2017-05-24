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
    public class InstructorAppService : IInstructorAppService
    {
        private readonly IInstructorService instructorService;
        private readonly IUnitOfWork unitOfWork;

        public InstructorAppService(IInstructorService instructorService, IUnitOfWork unitOfWork)
        {
            this.instructorService = instructorService;
            this.unitOfWork = unitOfWork;
        }

        public InstructorViewModel Add(InstructorViewModel instructorViewModel)
        {
            var instructor = Mapper.Map<Instructor>(instructorViewModel);
            var instructorReturn = instructorService.Add(instructor);

            if (instructorReturn.ValidationResult.IsValid)
            {
                unitOfWork.Commit();
            }

            instructorViewModel = Mapper.Map<InstructorViewModel>(instructorReturn);

            return instructorViewModel;
        }

        public InstructorViewModel Update(InstructorViewModel instructorViewModel)
        {
            var instructor = Mapper.Map<Instructor>(instructorViewModel);
            var instructorReturn = instructorService.Update(instructor);

            if (instructorReturn.ValidationResult.IsValid)
            {
                unitOfWork.Commit();
            }

            instructorViewModel = Mapper.Map<InstructorViewModel>(instructorReturn);

            return instructorViewModel;
        }

        public void Remove(Guid id)
        {
            instructorService.Remove(id);
            unitOfWork.Commit();
        }

        public InstructorViewModel GetById(Guid id)
        {
            return Mapper.Map<InstructorViewModel>(instructorService.GetById(id));
        }

        public IEnumerable<InstructorViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<InstructorViewModel>>(instructorService.GetAll());
        }

        public IEnumerable<InstructorViewModel> GetByIdentification(string identification)
        {
            return Mapper.Map<IEnumerable<InstructorViewModel>>(instructorService.GetByIdentification(identification));
        }

        public InstructorViewModel GetByLicenseNumber(int licenseNumber)
        {
            return Mapper.Map<InstructorViewModel>(instructorService.GetByLicenseNumber(licenseNumber));
        }

        public InstructorViewModel GetByEmail(string email)
        {
            return Mapper.Map<InstructorViewModel>(instructorService.GetByEmail(email));
        }

        public IEnumerable<InstructorViewModel> GetActive()
        {
            return Mapper.Map<IEnumerable<InstructorViewModel>>(instructorService.GetActive());
        }

        public IEnumerable<InstructorViewModel> GetInactive()
        {
            return Mapper.Map<IEnumerable<InstructorViewModel>>(instructorService.GetInactive());
        }

        public void Dispose()
        {
            instructorService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
