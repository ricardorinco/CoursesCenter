using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RR.CoursesCenter.Application.ViewModels;
using RR.CoursesCenter.UI.WebApp.Models;
using RR.CoursesCenter.Application.Interfaces;
using RR.CoursesCenter.UI.WebApp.Filters;

namespace RR.CoursesCenter.UI.WebApp.Controllers
{
    // Claims
    // LA = List All
    // AD = Add
    // ED = Edit
    // DE = Delete
    // VI = Visualization

    public class CourseTypesController : Controller
    {
        private readonly ICourseTypeAppService courseTypeAppService;

        public CourseTypesController(ICourseTypeAppService courseTypeAppService)
        {
            this.courseTypeAppService = courseTypeAppService;
        }

        [ClaimsAuthorize("CourseType", "LA")]
        public ActionResult Index()
        {
            ViewBag.Control = "Index";
            ViewBag.Title = "Lista de Tipos de Curso";

            return View("List", courseTypeAppService.GetActive());
        }

        [ClaimsAuthorize("CourseType", "LA")]
        public ActionResult ListAll()
        {
            ViewBag.Control = "ListAll";
            ViewBag.Title = "Lista de Todos os Tipos de Cursos";

            return View("List", courseTypeAppService.GetAll());
        }

        [ClaimsAuthorize("CourseType", "LA")]
        public ActionResult ListInactive()
        {
            ViewBag.Control = "ListInactive";
            ViewBag.Title = "Lista de Tipos de Cursos Inativos";

            return View("List", courseTypeAppService.GetInactive());
        }

        [ClaimsAuthorize("CourseType", "VI")]
        public ActionResult Details(Guid? id)
        {
            ViewBag.Title = "Detalhes";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseTypeViewModel = courseTypeAppService.GetById(id.Value);

            if (courseTypeViewModel == null)
            {
                return HttpNotFound();
            }

            return View(courseTypeViewModel);
        }

        [ClaimsAuthorize("CourseType", "AD")]
        public ActionResult Create()
        {
            ViewBag.Title = "Novo registro";

            return View();
        }

        [ClaimsAuthorize("CourseType", "AD")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseTypeViewModel courseTypeViewModel)
        {
            ViewBag.Title = "Novo registro";

            if (ModelState.IsValid)
            {
                courseTypeViewModel = courseTypeAppService.Add(courseTypeViewModel);

                if (!courseTypeViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in courseTypeViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(courseTypeViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(courseTypeViewModel);
        }

        [ClaimsAuthorize("CourseType", "ED")]
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Title = "Edição de registro";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseTypeViewModel = courseTypeAppService.GetById(id.Value);

            if (courseTypeViewModel == null)
            {
                return HttpNotFound();
            }

            return View("Create", courseTypeViewModel);
        }

        [ClaimsAuthorize("CourseType", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseTypeViewModel courseTypeViewModel)
        {
            ViewBag.Title = "Edição de registro";

            if (ModelState.IsValid)
            {
                courseTypeViewModel = courseTypeAppService.Update(courseTypeViewModel);

                if (!courseTypeViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in courseTypeViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(courseTypeViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(courseTypeViewModel);
        }

        [ClaimsAuthorize("CourseType", "DE")]
        public ActionResult Delete(Guid? id)
        {
            ViewBag.Title = "Deletar";

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var courseTypeViewModel = courseTypeAppService.GetById(id.Value);

            if (courseTypeViewModel == null)
            {
                return HttpNotFound();
            }

            return View(courseTypeViewModel);
        }

        [ClaimsAuthorize("CourseType", "DE")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            courseTypeAppService.Remove(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                courseTypeAppService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
