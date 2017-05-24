using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Instructors;

namespace RR.CoursesCenter.Domain.Tests.Specification.Instructors
{
    [TestClass]
    public class InstructorIdentificationSpecificationTests
    {
        [TestMethod]
        public void Instructor_IdentificationSpecification_IsSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                Identification = "José Antonio Martins"
            };

            // Act
            var specificationReturn = new InstructorMustContainIdentificationSpecification().IsSatisfiedBy(instructor);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Instructor_IdentificationSpecification_IsNotSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                Identification = "Jo"
            };

            // Act
            var specificationReturn = new InstructorMustContainIdentificationSpecification().IsSatisfiedBy(instructor);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
