using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Domain.Validation.Students;
using System;
using System.Linq;

namespace RR.CoursesCenter.Domain.Tests.Validation.Students
{
    [TestClass]
    public class StudentReadyToRegisterValidationTests
    {
        [TestMethod]
        public void Student_Ready_IsValid()
        {
            // Arrange
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Identification = "Ricardo Rinco",
                Email = "ric@hotmail.com",
                AcademicRegistration = 777,
                BirthDate = new DateTime(1986, 08, 26),
                Active = true,
            };

            // Act
            var repository = MockRepository.GenerateStub<IStudentRepository>();
            repository.Stub(s => s.GetByAcademicRegistration(student.AcademicRegistration)).Return(null);
            repository.Stub(s => s.GetByEmail(student.Email)).Return(null);

            var validationReturn = new StudentReadyToRegisterValidation(repository).Validate(student);

            // Assert
            Assert.IsTrue(validationReturn.IsValid);
        }

        [TestMethod]
        public void Student_Ready_IsNotValid()
        {
            // Arrange
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Identification = "Ricardo Rinco",
                Email = "ric@hotmail.com",
                AcademicRegistration = 777,
                BirthDate = new DateTime(1986, 08, 26),
                Active = true,
            };

            // Act
            var repository = MockRepository.GenerateStub<IStudentRepository>();
            repository.Stub(s => s.GetByAcademicRegistration(student.AcademicRegistration)).Return(student);
            repository.Stub(s => s.GetByEmail(student.Email)).Return(student);

            var validationReturn = new StudentReadyToRegisterValidation(repository).Validate(student);

            // Assert
            Assert.IsFalse(validationReturn.IsValid);
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "R.A. informado já está cadastrado na base de dados."));
            Assert.IsTrue(validationReturn.Erros.Any(e => e.Message == "E-mail já cadastrado na base de dados."));
        }
    }
}
