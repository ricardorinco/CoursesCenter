using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using System;
using System.Linq;

namespace RR.CoursesCenter.Domain.Tests.Entity
{
    [TestClass]
    public class CourseTypeTests
    {
        [TestMethod]
        public void CourseType_SelfValidation_IsValid()
        {
            // Arrange
            var courseType = new CourseType()
            {
                Id = Guid.NewGuid(),
                Identification = "Programação I",
                Active = true
            };

            // Act
            var result = courseType.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CourseType_SelValidation_IsNotValid()
        {
            // Arrange
            var courseType = new CourseType()
            {
                Id = Guid.NewGuid(),
                Identification = "PI",
                Active = true
            };

            // Act
            var result = courseType.IsValid();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(courseType.ValidationResult.Erros.Any(ct => ct.Message == "A identificação do Tipo de Curso deve conter no mínimo 3 caracteres."));
        }
    }
}
