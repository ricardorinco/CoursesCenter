using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Students;

namespace RR.CoursesCenter.Domain.Tests.Specification.Students
{
    [TestClass]
    public class StudentUniqueAcademicRegistrationSpecificationTests
    {
        [TestMethod]
        public void Student_UniqueAcademicRegistration_IsSatisfied()
        {
            // Arrange
            var student = new Student
            {
                AcademicRegistration = 777
            };

            // Act
            var repository = MockRepository.GenerateStub<IStudentRepository>();
            repository.Stub(s => s.GetByAcademicRegistration(student.AcademicRegistration)).Return(null);

            var specificationReturn = new StudentMustHaveUniqueAcademicRegistrationSpecification(repository).IsSatisfiedBy(student);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void StudentUniqueAcademicRegistration_IsNotSatisfied()
        {
            // Arrange
            var student = new Student
            {
                AcademicRegistration = 777
            };

            // Act
            var repository = MockRepository.GenerateStub<IStudentRepository>();
            repository.Stub(s => s.GetByAcademicRegistration(student.AcademicRegistration)).Return(student);

            var specificationReturn = new StudentMustHaveUniqueAcademicRegistrationSpecification(repository).IsSatisfiedBy(student);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
