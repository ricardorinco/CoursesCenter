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
    public class CourseTypeAppService : ICourseTypeAppService
    {
        private readonly ICourseTypeService courseTypeService;
        private readonly IUnitOfWork unitOfWork;

        public CourseTypeAppService(ICourseTypeService courseTypeService, IUnitOfWork unitOfWork)
        {
            this.courseTypeService = courseTypeService;
            this.unitOfWork = unitOfWork;
        }

        public CourseTypeViewModel Add(CourseTypeViewModel courseTypeViewModel)
        {
            var courseType = Mapper.Map<CourseType>(courseTypeViewModel);
            var courseTypeReturn = courseTypeService.Add(courseType);

            if (courseTypeReturn.ValidationResult.IsValid)
            {
                unitOfWork.Commit();
            }

            courseTypeViewModel = Mapper.Map<CourseTypeViewModel>(courseTypeReturn);

            return courseTypeViewModel;
        }

        public CourseTypeViewModel Update(CourseTypeViewModel courseTypeViewModel)
        {
            var courseType = Mapper.Map<CourseType>(courseTypeViewModel);
            var courseTypeReturn = courseTypeService.Update(courseType);

            if (courseTypeReturn.ValidationResult.IsValid)
            {
                unitOfWork.Commit();
            }

            courseTypeViewModel = Mapper.Map<CourseTypeViewModel>(courseTypeReturn);

            return courseTypeViewModel;
        }

        public void Remove(Guid id)
        {
            courseTypeService.Remove(id);
            unitOfWork.Commit();
        }

        public CourseTypeViewModel GetById(Guid id)
        {
            return Mapper.Map<CourseTypeViewModel>(courseTypeService.GetById(id));
        }

        public IEnumerable<CourseTypeViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<CourseTypeViewModel>>(courseTypeService.GetAll());
        }

        public IEnumerable<CourseTypeViewModel> GetByIdentification(string identification)
        {
            return Mapper.Map<IEnumerable<CourseTypeViewModel>>(courseTypeService.GetByIdentification(identification));
        }

        public IEnumerable<CourseTypeViewModel> GetActive()
        {
            return Mapper.Map<IEnumerable<CourseTypeViewModel>>(courseTypeService.GetActive());
        }

        public IEnumerable<CourseTypeViewModel> GetInactive()
        {
            return Mapper.Map<IEnumerable<CourseTypeViewModel>>(courseTypeService.GetInactive());
        }

        public void Dispose()
        {
            courseTypeService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
