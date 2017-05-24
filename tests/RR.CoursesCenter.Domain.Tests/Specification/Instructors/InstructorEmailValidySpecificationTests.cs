using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Instructors;

namespace RR.CoursesCenter.Domain.Tests.Specification.Instructors
{
    [TestClass]
    public class InstructorEmailValidySpecificationTests
    {
        [TestMethod]
        public void Instructor_EmailSpecification_IsSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                Email = "josemartins@hotmail.com"
            };

            // Act
            var specificationReturn = new InstructorMustHaveEmailValidSpecification().IsSatisfiedBy(instructor);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Instructor_EmailSpecification_IsNotSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                Email = "josemartins#hotmail.com"
            };

            // Act
            var specificationReturn = new InstructorMustHaveEmailValidSpecification().IsSatisfiedBy(instructor);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
