using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Students;
using System;

namespace RR.CoursesCenter.Domain.Tests.Specification.Students
{
    [TestClass]
    public class StudentBeOlderValidySpecificationTests
    {
        [TestMethod]
        public void Student_BeOlder_IsSatisfied()
        {
            // Arrange
            var student = new Student
            {
                BirthDate = new DateTime(1980, 01, 01)
            };

            // Act
            var specificationReturn = new StudentMustBeOlderSpecification().IsSatisfiedBy(student);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Student_BeOlder_IsNotSatisfied()
        {
            // Arrange
            var student = new Student
            {
                BirthDate = new DateTime(2018, 01, 01)
            };

            // Act
            var specificationReturn = new StudentMustBeOlderSpecification().IsSatisfiedBy(student);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
