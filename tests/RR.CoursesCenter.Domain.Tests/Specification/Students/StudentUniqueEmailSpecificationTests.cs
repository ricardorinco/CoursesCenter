using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Students;

namespace RR.CoursesCenter.Domain.Tests.Specification.Students
{
    [TestClass]
    public class StudentUniqueEmailSpecificationTests
    {
        [TestMethod]
        public void Student_UniqueEmail_IsSatisfied()
        {
            // Arrange
            var student = new Student
            {
                Email = "ricardo@hotmail.com"
            };

            // Act
            var repository = MockRepository.GenerateStub<IStudentRepository>();
            repository.Stub(s => s.GetByEmail(student.Email)).Return(null);

            var specificationReturn = new StudentMustHaveUniqueEmailSpecification(repository).IsSatisfiedBy(student);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Student_UniqueEmail_IsNotSatisfied()
        {
            // Arrange
            var student = new Student
            {
                Email = "ricardo@hotmail.com"
            };

            // Act
            var repository = MockRepository.GenerateStub<IStudentRepository>();
            repository.Stub(s => s.GetByEmail(student.Email)).Return(student);

            var specificationReturn = new StudentMustHaveUniqueEmailSpecification(repository).IsSatisfiedBy(student);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}