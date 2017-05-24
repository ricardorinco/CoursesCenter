using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Instructors;
using System;

namespace RR.CoursesCenter.Domain.Tests.Specification.Instructors
{
    [TestClass]
    public class InstructorBeOlderValidySpecificationTests
    {
        [TestMethod]
        public void Instructor_BeOlder_IsSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                BirthDate = new DateTime(1986, 08, 26)
            };

            // Act
            var specificationReturn = new InstructorMustBeOlderSpecification().IsSatisfiedBy(instructor);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Instructor_BeOlder_IsNotSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                BirthDate = new DateTime(2016, 08, 26)
            };

            // Act
            var specificationReturn = new InstructorMustBeOlderSpecification().IsSatisfiedBy(instructor);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
