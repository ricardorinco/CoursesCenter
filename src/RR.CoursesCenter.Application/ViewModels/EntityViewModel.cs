using System;
using System.ComponentModel.DataAnnotations;

namespace RR.CoursesCenter.Application.ViewModels
{
    public abstract class EntityViewModel
    {
        protected EntityViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}