using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RR.CoursesCenter.Application.ViewModels
{
    public class InstructorViewModel : EntityViewModel
    {
        public InstructorViewModel()
        {
            Courses = new List<CourseViewModel>();
        }

        [Required(ErrorMessage = "Preencha o campo identificação")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres permitidos")]
        [Display(Name = "Identificação")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Preencha o campo data de aniversário")]
        [DataType(DataType.Date, ErrorMessage = "Data de aniversário preenchida em um formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de Aniversário")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Preencha o campo e-mail")]
        [MaxLength(180, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo número da licença")]
        [Range(0, int.MaxValue, ErrorMessage = "Número da licença preenchido em um formato inválido")]
        [Display(Name = "Número da Licença")]
        public int LicenseNumber { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

        [Display(Name = "Curso")]
        public ICollection<CourseViewModel> Courses { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
