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
    public class CourseAppService : ICourseAppService
    {
        private readonly ICourseService courseService;
        private readonly IUnitOfWork unitOfWork;

        public CourseAppService(ICourseService courseService, IUnitOfWork unitOfWork)
        {
            this.courseService = courseService;
            this.unitOfWork = unitOfWork;
        }

        public CourseViewModel Add(CourseViewModel courseViewModel)
        {
            var course = Mapper.Map<Course>(courseViewModel);
            var courseReturn = courseService.Add(course);

            if (courseReturn.ValidationResult.IsValid)
            {
                unitOfWork.Commit();
            }

            courseViewModel = Mapper.Map<CourseViewModel>(courseReturn);

            return courseViewModel;
        }

        public CourseViewModel Update(CourseViewModel courseViewModel)
        {
            var course = Mapper.Map<Course>(courseViewModel);
            var courseReturn = courseService.Update(course);

            if (courseReturn.ValidationResult.IsValid)
            {
                unitOfWork.Commit();
            }

            courseViewModel = Mapper.Map<CourseViewModel>(courseReturn);

            return courseViewModel;
        }

        public void Remove(Guid id)
        {
            courseService.Remove(id);
            unitOfWork.Commit();
        }

        public CourseViewModel GetById(Guid id)
        {
            return Mapper.Map<CourseViewModel>(courseService.GetById(id));
        }

        public IEnumerable<CourseViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<CourseViewModel>>(courseService.GetAll());
        }

        public IEnumerable<CourseViewModel> GetByIdentification(string identification)
        {
            return Mapper.Map<IEnumerable<CourseViewModel>>(courseService.GetByIdentification(identification));
        }

        public IEnumerable<CourseViewModel> GetByLimitMaxPrice(decimal price)
        {
            return Mapper.Map<IEnumerable<CourseViewModel>>(courseService.GetByLimitMaxPrice(price));
        }

        public IEnumerable<CourseViewModel> GetByCourseType(Guid courseTypeId)
        {
            return Mapper.Map<IEnumerable<CourseViewModel>>(courseService.GetByCourseType(courseTypeId));
        }

        public IEnumerable<CourseViewModel> GetByInstructor(Guid intructorId)
        {
            return Mapper.Map<IEnumerable<CourseViewModel>>(courseService.GetByInstructor(intructorId));
        }

        public IEnumerable<CourseViewModel> GetActive()
        {
            return Mapper.Map<IEnumerable<CourseViewModel>>(courseService.GetActive());
        }

        public IEnumerable<CourseViewModel> GetInactive()
        {
            return Mapper.Map<IEnumerable<CourseViewModel>>(courseService.GetInactive());
        }

        public void Dispose()
        {
            courseService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
