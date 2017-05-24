using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.CoursesCenter.Domain.Models;
using System;
using System.Linq;

namespace RR.CoursesCenter.Domain.Tests.Validation.Courses
{
    [TestClass]
    public class CourseReadyToRegisterValidationTests
    {
        [TestMethod]
        public void Course_Ready_IsValid()
        {
            // Arrange
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Identification = "Progrmação Web II",
                Price = 89.90m,
                Active = true,
                CourseTypeId = Guid.Parse("60CF681E-8A76-4882-8903-EDF594FFFEDC"),
                InstructorId = Guid.Parse("54B80D9C-7F51-4859-87C6-3CDAEEC5ADD9")
            };

            // Act
            var result = course.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Course_Ready_IsNotValid()
        {
            // Arrange
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Identification = "Pr",
                Price = -89.90m,
                Active = true
            };

            // Act
            var result = course.IsValid();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(course.ValidationResult.Erros.Any(e => e.Message == "Curso obrigatoriamente deve conter um Tipo de Curso."));
            Assert.IsTrue(course.ValidationResult.Erros.Any(e => e.Message == "Curso obrigatoriamente deve conter um Instrutor."));
        }
    }
}
