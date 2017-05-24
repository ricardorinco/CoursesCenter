using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RR.CoursesCenter.Application.ViewModels
{
    public class CourseTypeViewModel : EntityViewModel
    {
        public CourseTypeViewModel()
        {
            Courses = new List<CourseViewModel>();
        }

        [Required(ErrorMessage = "Preencha o campo identificação")]
        [MaxLength(180, ErrorMessage = "Máximo de {0} caracteres permitidos")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres permitidos")]
        [Display(Name = "Identificação")]
        public string Identification { get; set; }

        [Display(Name = "Ativo")]
        public bool Active { get; set; }

        public ICollection<CourseViewModel> Courses { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
