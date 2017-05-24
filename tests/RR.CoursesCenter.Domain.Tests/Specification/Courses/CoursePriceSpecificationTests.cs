using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Courses;

namespace RR.CoursesCenter.Domain.Tests.Specification.Courses
{
    [TestClass]
    public class CoursePriceSpecificationTests
    {
        [TestMethod]
        public void Course_PriceSpecification_IsSatisfied()
        {
            // Arrange
            var course = new Course
            {
                Price = 89.90m
            };

            // Act
            var specificationReturn = new CoursePriceCanNotBeNegativeSpecification().IsSatisfiedBy(course);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Course_PriceSpecification_IsNotSatisfied()
        {
            // Arrange
            var course = new Course
            {
                Price = -0.02m
            };

            // Act
            var specificationReturn = new CoursePriceCanNotBeNegativeSpecification().IsSatisfiedBy(course);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
