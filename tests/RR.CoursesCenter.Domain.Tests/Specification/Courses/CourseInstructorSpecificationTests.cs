using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Courses;
using System;

namespace RR.CoursesCenter.Domain.Tests.Specification.Courses
{
    [TestClass]
    public class CourseInstructorSpecificationTests
    {
        [TestMethod]
        public void Course_InstructorSpecification_IsSatisfied()
        {
            // Act
            var course = new Course
            {
                InstructorId = Guid.NewGuid()
            };

            // Action
            var specificationReturn = new CourseMustBeContainInstructorSpecification().IsSatisfiedBy(course);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Course_InstructorSpecification_IsNotSatisfied()
        {
            // Act
            var course = new Course { };

            // Action
            var specificationReturn = new CourseMustBeContainInstructorSpecification().IsSatisfiedBy(course);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
