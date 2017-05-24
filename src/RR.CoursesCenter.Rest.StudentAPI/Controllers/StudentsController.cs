using RR.CoursesCenter.Application.Interfaces;
using RR.CoursesCenter.Application.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RR.CoursesCenter.Rest.StudentAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IStudentAppService studentAppService;

        public StudentsController(IStudentAppService studentAppService)
        {
            this.studentAppService = studentAppService;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return studentAppService.GetAll();
        }

        public IEnumerable<StudentViewModel> GetActive()
        {
            return studentAppService.GetActive();
        }

        public IEnumerable<StudentViewModel> GetInactive()
        {
            return studentAppService.GetInactive();
        }

        public StudentViewModel GetByAcademicRegistration(int id)
        {
            return studentAppService.GetByAcademicRegistration(id);
        }

        public string GetById(int id)
        {
            return "value";
        }

        public void Post([FromBody]string value)
        { }

        public void Put(int id, [FromBody]string value)
        { }

        public void Delete(int id)
        { }
    }
}
