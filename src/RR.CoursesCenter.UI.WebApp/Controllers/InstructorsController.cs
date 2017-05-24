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
    public class InstructorsController : Controller
    {
        private readonly IInstructorAppService instructorAppService;

        public InstructorsController(IInstructorAppService instructorAppService)
        {
            this.instructorAppService = instructorAppService;
        }

        [ClaimsAuthorize("Instructor", "LA")]
        public ActionResult Index()
        {
            ViewBag.Control = "Index";
            ViewBag.Title = "Lista de Instrutores Ativos";

            return View("List", instructorAppService.GetActive());
        }

        [ClaimsAuthorize("Instructor", "LA")]
        public ActionResult ListAll()
        {
            ViewBag.Control = "Index";
            ViewBag.Title = "Lista de Todos os Instrutores";

            return View("List", instructorAppService.GetAll());
        }

        [ClaimsAuthorize("Instructor", "LA")]
        public ActionResult ListInactive()
        {
            ViewBag.Control = "ListInactive";
            ViewBag.Title = "Lista de Instrutores Inativos";

            return View("List", instructorAppService.GetInactive());
        }

        [ClaimsAuthorize("Instructor", "VI")]
        public ActionResult Details(Guid? id)
        {
            ViewBag.Title = "Detalhes";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var instructorViewModel = instructorAppService.GetById(id.Value);

            if (instructorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(instructorViewModel);
        }

        [ClaimsAuthorize("Instructor", "AD")]
        public ActionResult Create()
        {
            ViewBag.Title = "Novo registro";

            return View();
        }

        [ClaimsAuthorize("Instructor", "AD")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorViewModel instructorViewModel)
        {
            ViewBag.Title = "Novo registro";

            if (ModelState.IsValid)
            {
                instructorViewModel = instructorAppService.Add(instructorViewModel);

                if (!instructorViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in instructorViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(instructorViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(instructorViewModel);
        }

        [ClaimsAuthorize("Instructor", "ED")]
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Title = "Edição de registro";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            var instructorViewModel = instructorAppService.GetById(id.Value);

            if (instructorViewModel == null)
            {
                return HttpNotFound();
            }

            return View("Create", instructorViewModel);
        }

        [ClaimsAuthorize("Instructor", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorViewModel instructorViewModel)
        {
            ViewBag.Title = "Edição de registro";

            if (ModelState.IsValid)
            {
                instructorViewModel = instructorAppService.Update(instructorViewModel);

                if (!instructorViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in instructorViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(instructorViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(instructorViewModel);
        }

        [ClaimsAuthorize("Instructor", "DE")]
        public ActionResult Delete(Guid? id)
        {
            ViewBag.Title = "Deletar";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var instructorViewModel = instructorAppService.GetById(id.Value);

            if (instructorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(instructorViewModel);
        }

        [ClaimsAuthorize("Instructor", "DE")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            instructorAppService.Remove(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                instructorAppService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}