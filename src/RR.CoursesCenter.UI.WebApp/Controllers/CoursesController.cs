using RR.CoursesCenter.Application.Interfaces;
using RR.CoursesCenter.Application.ViewModels;
using RR.CoursesCenter.UI.WebApp.Filters;
using System;
using System.Net;
using System.Web.Mvc;

namespace RR.CoursesCenter.UI.WebApp.Controllers
{
    // LA = List All
    // AD = Add
    // ED = Edit
    // DE = Delete
    // VI = Visualization

    public class CoursesController : Controller
    {
        private readonly ICourseAppService courseAppService;
        private readonly ICourseTypeAppService courseTypeAppService;
        private readonly IInstructorAppService instructorAppService;

        public CoursesController(ICourseAppService courseAppService, ICourseTypeAppService courseTypeAppService, IInstructorAppService instructorAppService)
        {
            this.courseAppService = courseAppService;
            this.courseTypeAppService = courseTypeAppService;
            this.instructorAppService = instructorAppService;
        }

        public ActionResult Index()
        {
            ViewBag.Control = "Index";
            ViewBag.Title = "Lista de Cursos Ativos";

            return View("List", courseAppService.GetActive());
        }

        public ActionResult ListAll()
        {
            ViewBag.Control = "ListAll";
            ViewBag.Title = "Lista Todos os Cursos";

            return View("List", courseAppService.GetAll());
        }

        public ActionResult ListInactive()
        {
            ViewBag.Control = "ListInactive";
            ViewBag.Title = "Lista de Cursos Inativos";

            return View("List", courseAppService.GetInactive());
        }

        public ActionResult Details(Guid? id)
        {
            ViewBag.Title = "Detalhes";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseViewModel = courseAppService.GetById(id.Value);

            if (courseViewModel == null)
            {
                return HttpNotFound();
            }

            return View(courseViewModel);
        }

        [ClaimsAuthorize("Course", "AD")]
        public ActionResult Create()
        {
            ViewBag.Title = "Novo registro";

            ViewBag.CourseTypeId = new SelectList(courseTypeAppService.GetActive(), "Id", "Identification");
            ViewBag.InstructorId = new SelectList(instructorAppService.GetActive(), "Id", "Identification");

            return View();
        }

        [ClaimsAuthorize("Course", "AD")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel courseViewModel)
        {
            ViewBag.Title = "Novo registro";

            ViewBag.CourseTypeId = new SelectList(courseTypeAppService.GetActive(), "Id", "Identification");
            ViewBag.InstructorId = new SelectList(instructorAppService.GetActive(), "Id", "Identification");

            if (ModelState.IsValid)
            {
                courseViewModel = courseAppService.Add(courseViewModel);

                if (!courseViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in courseViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(courseViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(courseViewModel);
        }

        [ClaimsAuthorize("Course", "ED")]
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Title = "Edição de registro";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseViewModel = courseAppService.GetById(id.Value);

            ViewBag.CourseTypeId = new SelectList(courseTypeAppService.GetActive(), "Id", "Identification", courseViewModel.CourseTypeId);
            ViewBag.InstructorId = new SelectList(instructorAppService.GetActive(), "Id", "Identification", courseViewModel.InstructorId);

            if (courseViewModel == null)
            {
                return HttpNotFound();
            }

            return View("Create", courseViewModel);
        }

        [ClaimsAuthorize("Course", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel courseViewModel)
        {
            ViewBag.Title = "Edição de registro";

            ViewBag.CourseTypeId = new SelectList(courseTypeAppService.GetActive(), "Id", "Identification", courseViewModel.CourseTypeId);
            ViewBag.InstructorId = new SelectList(instructorAppService.GetActive(), "Id", "Identification", courseViewModel.InstructorId);

            if (ModelState.IsValid)
            {
                courseViewModel = courseAppService.Update(courseViewModel);

                if (!courseViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in courseViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(courseViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(courseViewModel);
        }

        [ClaimsAuthorize("Course", "DE")]
        public ActionResult Delete(Guid? id)
        {
            ViewBag.Title = "Deletar";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseViewModel = courseAppService.GetById(id.Value);

            if (courseViewModel == null)
            {
                return HttpNotFound();
            }

            return View(courseViewModel);
        }

        [ClaimsAuthorize("Course", "DE")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            courseAppService.Remove(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                courseAppService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}