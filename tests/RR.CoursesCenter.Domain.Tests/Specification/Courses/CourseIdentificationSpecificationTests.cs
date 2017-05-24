using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Courses;

namespace RR.CoursesCenter.Domain.Tests.Specification.Courses
{
    [TestClass]
    public class CourseIdentificationSpecificationTests
    {
        [TestMethod]
        public void Course_IdentificationSpecification_IsSatisfied()
        {
            // Arrange
            var course = new Course
            {
                Identification = "Programação Web II"
            };

            // Act
            var specificationReturn = new CourseMustContainIdentificationSpecification().IsSatisfiedBy(course);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Course_IdentificationSpecification_IsNotSatisfied()
        {
            // Arrange
            var course = new Course
            {
                Identification = "Pr"
            };

            // Act
            var specificationReturn = new CourseMustContainIdentificationSpecification().IsSatisfiedBy(course);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
