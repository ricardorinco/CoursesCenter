using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Students;

namespace RR.CoursesCenter.Domain.Tests.Specification.Students
{
    [TestClass]
    public class StudentIdentificationSpecificationTests
    {
        [TestMethod]
        public void Student_IdentificationSpecification_IsSatisfied()
        {
            // Arrange
            var student = new Student
            {
                Identification = "Ricardo Antonio Rinco"
            };

            // Act
            var specificationReturn = new StudentMustContainIdentificationSpecification().IsSatisfiedBy(student);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Student_IdentificationSpecification_IsNotSatisfied()
        {
            // Arrange
            var student = new Student
            {
                Identification = "Ri"
            };

            // Act
            var specificationReturn = new StudentMustContainIdentificationSpecification().IsSatisfiedBy(student);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
