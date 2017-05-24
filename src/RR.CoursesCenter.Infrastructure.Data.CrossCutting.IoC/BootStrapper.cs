using RR.CoursesCenter.Application.Interfaces;
using RR.CoursesCenter.Application.Services;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Interfaces.Services;
using RR.CoursesCenter.Domain.Services;
using RR.CoursesCenter.Infrastructure.Data.Context;
using RR.CoursesCenter.Infrastructure.Data.Interfaces;
using RR.CoursesCenter.Infrastructure.Data.Repositories;
using RR.CoursesCenter.Infrastructure.Data.UoW;
using SimpleInjector;

namespace RR.CoursesCenter.Infrastructure.Data.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            // APP
            container.Register<IStudentAppService, StudentAppService>(Lifestyle.Scoped);
            container.Register<ICourseTypeAppService, CourseTypeAppService>(Lifestyle.Scoped);
            container.Register<IInstructorAppService, InstructorAppService>(Lifestyle.Scoped);
            container.Register<ICourseAppService, CourseAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IStudentService, StudentService>(Lifestyle.Scoped);
            container.Register<ICourseTypeService, CourseTypeService>(Lifestyle.Scoped);
            container.Register<IInstructorService, InstructorService>(Lifestyle.Scoped);
            container.Register<ICourseService, CourseService>(Lifestyle.Scoped);

            // Data
            container.Register<IStudentRepository, StudentRepository>(Lifestyle.Scoped);
            container.Register<ICourseTypeRepository, CourseTypeRepository>(Lifestyle.Scoped);
            container.Register<IInstructorRepository, InstructorRepository>(Lifestyle.Scoped);
            container.Register<ICourseRepository, CourseRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<DataContext>(Lifestyle.Scoped);
        }
    }
}