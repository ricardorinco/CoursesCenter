using AutoMapper;
using RR.CoursesCenter.Application.ViewModels;
using RR.CoursesCenter.Domain.Models;

namespace RR.CoursesCenter.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<CourseType, CourseTypeViewModel>().ReverseMap();
            CreateMap<Instructor, InstructorViewModel>().ReverseMap();
            CreateMap<Course, CourseViewModel>().ReverseMap();


            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailViewModel>().ReverseMap();
        }
    }
}
