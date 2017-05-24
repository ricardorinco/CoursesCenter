using RR.CoursesCenter.Application.Interfaces;
using RR.CoursesCenter.Application.ViewModels;
using RR.CoursesCenter.UI.WebApp.Filters;
using System;
using System.Net;
using System.Web.Mvc;

namespace RR.CoursesCenter.UI.WebApp.Controllers
{
    // Claims
    // LA = List All
    // AD = Add
    // ED = Edit
    // DE = Delete
    // VI = Visualization

    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IStudentAppService studentAppService;

        public StudentsController(IStudentAppService studentAppService)
        {
            this.studentAppService = studentAppService;
        }

        [ClaimsAuthorize("Student", "LA")]
        public ActionResult Index()
        {
            ViewBag.Control = "Index";
            ViewBag.Title = "Lista de Estudantes Ativos";

            return View("List", studentAppService.GetActive());
        }

        [ClaimsAuthorize("Student", "LA")]
        public ActionResult ListAll()
        {
            ViewBag.Control = "ListAll";
            ViewBag.Title = "Lista de Todos os Estudantes";

            return View("List", studentAppService.GetAll());
        }

        [ClaimsAuthorize("Student", "LA")]
        public ActionResult ListInactive()
        {
            ViewBag.Control = "ListInactive";
            ViewBag.Title = "Lista de Estudantes Inativos";

            return View("List", studentAppService.GetInactive());
        }

        [ClaimsAuthorize("Student", "VI")]
        public ActionResult Details(Guid? id)
        {
            ViewBag.Title = "Detalhes";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var studentViewModel = studentAppService.GetById(id.Value);

            if (studentViewModel == null)
            {
                return HttpNotFound();
            }

            return View(studentViewModel);
        }

        [ClaimsAuthorize("Student", "AD")]
        public ActionResult Create()
        {
            ViewBag.Title = "Novo registro";

            var studentViewModel = new StudentViewModel();
            studentViewModel.AcademicRegistration = studentAppService.GetNextAcademicRegistration();
            studentViewModel.BirthDate = null;

            return View(studentViewModel);
        }

        [ClaimsAuthorize("Student", "AD")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            ViewBag.Title = "Novo registro";

            if (ModelState.IsValid)
            {
                studentViewModel.AcademicRegistration = studentAppService.GetNextAcademicRegistration();
                studentViewModel = studentAppService.Add(studentViewModel);

                if (!studentViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in studentViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(studentViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(studentViewModel);
        }

        [ClaimsAuthorize("Student", "ED")]
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Title = "Edição de registro";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var studentViewModel = studentAppService.GetById(id.Value);

            if (studentViewModel == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Control = studentViewModel.AcademicRegistration;
            }

            return View("Create", studentViewModel);
        }

        [ClaimsAuthorize("Student", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            ViewBag.Title = "Edição de registro";

            if (ModelState.IsValid)
            {
                studentViewModel = studentAppService.Update(studentViewModel);

                if (!studentViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in studentViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(studentViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(studentViewModel);
        }

        [ClaimsAuthorize("Student", "DE")]
        public ActionResult Delete(Guid? id)
        {
            ViewBag.Title = "Deletar";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var studentViewModel = studentAppService.GetById(id.Value);
            
            if (studentViewModel == null)
            {
                return HttpNotFound();
            }

            return View(studentViewModel);
        }

        [ClaimsAuthorize("Student", "DE")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            studentAppService.Remove(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                studentAppService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
