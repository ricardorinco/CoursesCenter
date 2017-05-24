using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.CourseTypes;

namespace RR.CoursesCenter.Domain.Tests.Specification.Students
{
    [TestClass]
    public class CourseTypeIdentificationSpecificationTests
    {
        [TestMethod]
        public void CourseType_IdentificationSpecification_IsSatisfied()
        {
            // Arrange
            var courseType = new CourseType()
            {
                Identification = "Programação I"
            };

            // Act
            var specificationReturn = new CourseTypeMustContainIdentificationSpecification().IsSatisfiedBy(courseType);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void CourseType_IdentificationSpecification_IsNotSatisfied()
        {
            // Arrange
            var courseType = new CourseType()
            {
                Identification = "Ri"
            };

            // Act
            var specificationReturn = new CourseTypeMustContainIdentificationSpecification().IsSatisfiedBy(courseType);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
