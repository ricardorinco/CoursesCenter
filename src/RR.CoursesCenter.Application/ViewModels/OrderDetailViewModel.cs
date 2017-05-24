using System;
using System.ComponentModel.DataAnnotations;

namespace RR.CoursesCenter.Application.ViewModels
{
    public class OrderDetailViewModel : EntityViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Pedido")]
        public Guid OrderId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Curso")]
        public Guid CourseId { get; set; }
    }
}
