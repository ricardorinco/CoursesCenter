using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Instructors;
using System;
using System.Linq;

namespace RR.CoursesCenter.Domain.Tests.Validation.Instructors
{
    [TestClass]
    public class InstructorReadyToRegisterValidationTests
    {
        [TestMethod]
        public void Instructor_Ready_IsValid()
        {
            // Arrange
            var instructor = new Instructor
            {
                Id = Guid.NewGuid(),
                Identification = "Ricardo Rinco",
                Email = "ric@hotmail.com",
                LicenseNumber = 777,
                BirthDate = new DateTime(1986, 08, 26),
                Active = true,
            };

            // Act
            var repository = MockRepository.GenerateStub<IInstructorRepository>();
            repository.Stub(i => i.GetByLicenseNumber(instructor.LicenseNumber)).Return(null);
            repository.Stub(i => i.GetByEmail(instructor.Email)).Return(null);

            var validationReturn = new InstructorReadyToRegisterValidation(repository).Validate(instructor);

            // Assert
            Assert.IsTrue(validationReturn.IsValid);
        }

        [TestMethod]
        public void Instructor_Ready_IsNotValid()
        {
            // Arrange
            var instructor = new Instructor
            {
                Id = Guid.NewGuid(),
                Identification = "Ricardo Rinco",
                Email = "ric@hotmail.com",
                LicenseNumber = 777,
                BirthDate = new DateTime(1986, 08, 26),
                Active = true,
            };

            // Act
            var repository = MockRepository.GenerateStub<IInstructorRepository>();
            repository.Stub(i => i.GetByLicenseNumber(instructor.LicenseNumber)).Return(instructor);
            repository.Stub(i => i.GetByEmail(instructor.Email)).Return(instructor);

            var validationReturn = new InstructorReadyToRegisterValidation(repository).Validate(instructor);

            // Assert
            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "Número de Licença informado já está cadastrado na base de dados."));
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "E-mail já cadastrado na base de dados."));
        }
    }
}
