using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RR.CoursesCenter.Application.ViewModels
{
    public class OrderViewModel : EntityViewModel
    {
        public OrderViewModel()
        {
            OrderDetails = new List<OrderDetailViewModel>();
        }

        [Required(ErrorMessage = "Preencha o campo data do pedido")]
        [DataType(DataType.Date, ErrorMessage = "Data do pedido preenchido em um formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data do Pedido")]
        public DateTime OrderDateTime { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Estudante")]
        public Guid StudentId { get; set; }

        public ICollection<OrderDetailViewModel> OrderDetails { get; set; } 
    }
}