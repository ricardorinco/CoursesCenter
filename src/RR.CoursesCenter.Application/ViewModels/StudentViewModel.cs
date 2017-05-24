using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RR.CoursesCenter.Application.ViewModels
{
    public class StudentViewModel : EntityViewModel
    {
        public StudentViewModel()
        {
            Orders = new List<OrderViewModel>();
        }

        [Required(ErrorMessage = "Preencha o campo identificação")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres permitidos")]
        [Display(Name = "Nome Completo")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Preencha o campo data de aniversário")]
        [DataType(DataType.Date, ErrorMessage = "Data de aniversário preenchida em um formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Nascimento")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Preencha o campo e-mail")]
        [MaxLength(180, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo registro acadêmico")]
        [Range(0, int.MaxValue, ErrorMessage = "Registro acadêmico preenchido em um formato inválido")]
        [Display(Name = "R.A.")]
        public int AcademicRegistration { get; set; }

        [Display(Name = "Ativo?")]
        public bool Active { get; set; }

        public ICollection<OrderViewModel> Orders { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
