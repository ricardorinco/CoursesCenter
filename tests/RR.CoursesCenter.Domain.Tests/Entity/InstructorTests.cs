using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using System;
using System.Linq;

namespace RR.CoursesCenter.Domain.Tests.Entity
{
    [TestClass]
    public class InstructorTests
    {
        [TestMethod]
        public void Instructor_SelfValidation_IsValid()
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
            var result = instructor.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Instructor_SelfValidation_IsNotValid()
        {
            // Arrange
            var instructor = new Instructor
            {
                Id = Guid.NewGuid(),
                Identification = "Ri",
                Email = "ricardo2hotmail.com",
                LicenseNumber = 777,
                BirthDate = new DateTime(2016, 08, 26),
                Active = true,
            };

            // Act
            var result = instructor.IsValid();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(instructor.ValidationResult.Erros.Any(e => e.Message == "A identificação do Instrutor deve conter no mínimo 3 caracteres."));
            Assert.IsTrue(instructor.ValidationResult.Erros.Any(e => e.Message == "Instrutor não tem maioridade para cadastro."));
            Assert.IsTrue(instructor.ValidationResult.Erros.Any(e => e.Message == "Instrutor informou um e-mail inválido."));
        }
    }
}
