using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Students;

namespace RR.CoursesCenter.Domain.Tests.Specification.Students
{
    [TestClass]
    public class StudentEmailValidySpecificationTests
    {
        [TestMethod]
        public void Student_EmailSpecification_IsSatisfied()
        {
            // Arrange
            var student = new Student
            {
                Email = "ricardo@hotmail.com"
            };

            // Act
            var specificationReturn = new StudentMustHaveEmailValidSpecification().IsSatisfiedBy(student);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Student_EmailSpecification_IsNotSatisfied()
        {
            // Arrange
            var student = new Student
            {
                Email = "ricardo#hotmail.com"
            };

            // Act
            var specificationReturn = new StudentMustHaveEmailValidSpecification().IsSatisfiedBy(student);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
