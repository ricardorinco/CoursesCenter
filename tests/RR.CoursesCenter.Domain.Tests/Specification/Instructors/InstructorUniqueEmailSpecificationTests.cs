using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Instructors;

namespace RR.CoursesCenter.Domain.Tests.Specification.Instructors
{
    [TestClass]
    public class InstructorUniqueEmailSpecificationTests
    {
        [TestMethod]
        public void Instructor_UniqueEmail_IsSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                Email = "ricardo@hotmail.com"
            };

            // Act
            var repository = MockRepository.GenerateStub<IInstructorRepository>();
            repository.Stub(i => i.GetByEmail(instructor.Email)).Return(null);

            var specificationReturn = new InstructorMustHaveUniqueEmailSpecification(repository).IsSatisfiedBy(instructor);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Instructor_UniqueEmail_IsNotSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                Email = "ricardo@hotmail.com"
            };

            // Act
            var repository = MockRepository.GenerateStub<IInstructorRepository>();
            repository.Stub(i => i.GetByEmail(instructor.Email)).Return(instructor);

            var specificationReturn = new InstructorMustHaveUniqueEmailSpecification(repository).IsSatisfiedBy(instructor);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
