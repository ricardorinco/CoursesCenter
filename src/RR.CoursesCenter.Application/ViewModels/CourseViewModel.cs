using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RR.CoursesCenter.Application.ViewModels
{
    public class CourseViewModel : EntityViewModel
    {
        public CourseViewModel()
        {
            OrderDetails = new List<OrderDetailViewModel>();
        }

        [Required(ErrorMessage = "Preencha o campo identificação")]
        [MaxLength(180, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres permitidos")]
        [Display(Name = "Identificação")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Preencha o campo preço")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Display(Name = "Imagem")]
        public byte[] Image { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

        [Display(Name = "Tipo do Curso")]
        public Guid CourseTypeId { get; set; }
        public CourseTypeViewModel CourseType { get; set; }

        [Display(Name = "Instrutor")]
        public Guid InstructorId { get; set; }
        public InstructorViewModel Instructor { get; set; }

        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}