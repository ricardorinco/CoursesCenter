using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Interfaces.Services;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Courses;
using System;
using System.Collections.Generic;

namespace RR.CoursesCenter.Domain.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public Course Add(Course course)
        {
            if (!course.IsValid())
            {
                return course;
            }

            course.ValidationResult = new CourseReadyToRegisterValidation(courseRepository).Validate(course);

            if (!course.ValidationResult.IsValid)
            {
                return course;
            }

            return courseRepository.Add(course);
        }

        public Course Update(Course course)
        {
            if (!course.IsValid())
            {
                return course;
            }

            return courseRepository.Update(course);
        }

        public void Remove(Guid id)
        {
            courseRepository.Remove(id);
        }

        public Course GetById(Guid id)
        {
            return courseRepository.GetById(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return courseRepository.GetAll();
        }

        public IEnumerable<Course> GetByIdentification(string identification)
        {
            return courseRepository.GetByIdentification(identification);
        }

        public IEnumerable<Course> GetByLimitMaxPrice(decimal price)
        {
            return courseRepository.GetByLimitMaxPrice(price);
        }

        public IEnumerable<Course> GetByCourseType(Guid courseTypeId)
        {
            return courseRepository.GetByCourseType(courseTypeId);
        }

        public IEnumerable<Course> GetByInstructor(Guid instructorId)
        {
            return courseRepository.GetByInstructor(instructorId);
        }

        public IEnumerable<Course> GetActive()
        {
            return courseRepository.GetActive();
        }

        public IEnumerable<Course> GetInactive()
        {
            return courseRepository.GetInactive();
        }

        public void Dispose()
        {
            courseRepository.Dispose();
        }
    }
}