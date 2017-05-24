using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Specification.Instructors;

namespace RR.CoursesCenter.Domain.Tests.Specification.Instructors
{
    [TestClass]
    public class InstructorUniqueLicenseNumberSpecificationTests
    {
        [TestMethod]
        public void Instructor_UniqueLicenseNumber_IsSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                LicenseNumber = 777
            };

            // Act
            var repository = MockRepository.GenerateStub<IInstructorRepository>();
            repository.Stub(i => i.GetByLicenseNumber(instructor.LicenseNumber)).Return(null);

            var specificationReturn = new InstructorMustHaveUniqueLicenseNumberSpecification(repository).IsSatisfiedBy(instructor);

            // Assert
            Assert.IsTrue(specificationReturn);
        }

        [TestMethod]
        public void Instructor_UniqueLicenseNumber_IsNotSatisfied()
        {
            // Arrange
            var instructor = new Instructor
            {
                LicenseNumber = 777
            };

            // Act
            var repository = MockRepository.GenerateStub<IInstructorRepository>();
            repository.Stub(i => i.GetByLicenseNumber(instructor.LicenseNumber)).Return(instructor);

            var specificationReturn = new InstructorMustHaveUniqueLicenseNumberSpecification(repository).IsSatisfiedBy(instructor);

            // Assert
            Assert.IsFalse(specificationReturn);
        }
    }
}
