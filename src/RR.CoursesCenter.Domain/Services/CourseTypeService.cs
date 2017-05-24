using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Interfaces.Services;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.CourseTypes;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Services
{
    public class CourseTypeService : ICourseTypeService
    {
        private readonly ICourseTypeRepository courseTypeRepository;

        public CourseTypeService(ICourseTypeRepository courseTypeRepository)
        {
            this.courseTypeRepository = courseTypeRepository;
        }

        public CourseType Add(CourseType courseType)
        {
            if (!courseType.IsValid())
            {
                return courseType;
            }

            courseType.ValidationResult = new CourseTypeIsConsistentValidation().Validate(courseType);

            if (!courseType.ValidationResult.IsValid)
            {
                return courseType;
            }

            return courseTypeRepository.Add(courseType);
        }

        public CourseType Update(CourseType courseType)
        {
            if (!courseType.IsValid())
            {
                return courseType;
            }

            return courseTypeRepository.Update(courseType);
        }

        public void Remove(Guid id)
        {
            courseTypeRepository.Remove(id);
        }

        public CourseType GetById(Guid id)
        {
            return courseTypeRepository.GetById(id);
        }

        public IEnumerable<CourseType> GetAll()
        {
            return courseTypeRepository.GetAll();
        }

        public IEnumerable<CourseType> GetByIdentification(string identification)
        {
            return courseTypeRepository.GetByIdentification(identification);
        }

        public IEnumerable<CourseType> GetActive()
        {
            return courseTypeRepository.GetActive();
        }

        public IEnumerable<CourseType> GetInactive()
        {
            return courseTypeRepository.GetInactive();
        }

        public void Dispose()
        {
            courseTypeRepository.Dispose();
        }
    }
}
