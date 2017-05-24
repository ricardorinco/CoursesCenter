using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Courses;
using System;

namespace RR.CoursesCenter.Domain.Tests.Specification.Courses
{
    [TestClass]
    public class CourseCourseTypeSpecificationTests
    {
        [TestMethod]
        public void Course_CourseTypeSpecification_IsSatisfied()
        {
            // Act
            var course = new Course
            {
                CourseTypeId = Guid.NewGuid()
            };

            // Action
            var specificationReturn = new CourseMustBeContainCourseTypeSpecification().IsSatisfiedBy(course);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Course_CourseTypeSpecification_IsNotSatisfied()
        {
            // Act
            var course = new Course { };

            // Action
            var specificationReturn = new CourseMustBeContainCourseTypeSpecification().IsSatisfiedBy(course);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
