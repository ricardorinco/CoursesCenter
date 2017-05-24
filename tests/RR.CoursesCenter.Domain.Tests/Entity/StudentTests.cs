using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using System;
using System.Linq;

namespace RR.CoursesCenter.Domain.Tests.Entity
{
    [TestClass]
    public class StudentTests
    {
        // AAA => Arrange, Act, Assert
        // Arrange  => Manipula os dados
        // Act      => Testa os dados
        // Assert   => Valida o resultado do teste

        [TestMethod]
        public void Student_SelfValidation_IsValid()
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
            var result = student.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Student_SelfValidation_IsNotValid()
        {
            // Arrange
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Identification = "Ri",
                Email = "ricardo2hotmail.com",
                AcademicRegistration = 777,
                BirthDate = new DateTime(2016, 08, 26),
                Active = true,
            };

            // Act
            var result = student.IsValid();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(student.ValidationResult.Erros.Any(e => e.Message == "A identificação do Estudante deve conter no mínimo 3 caracteres."));
            Assert.IsTrue(student.ValidationResult.Erros.Any(e => e.Message == "Estudante não tem maioridade para cadastro."));
            Assert.IsTrue(student.ValidationResult.Erros.Any(e => e.Message == "Estudante informou um e-mail inválido."));
        }
    }
}
