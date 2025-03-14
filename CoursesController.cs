using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DemoWebAppMVC.Models;

namespace DemoWebAppMVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _repository;

        public CoursesController() : this(new CourseRepository())
        {

        }

        public CoursesController(ICourseRepository repository)
        {
            _repository = repository;
        }

        // GET: Courses
        public ActionResult Index(int id)
        {
            if (id == 0)
            {
                ViewBag.Title = "Course List";
                ViewData["CoursesCount"] = _repository.GetAllCourses().Count();
                List<CourseViewModel> course_list = _repository.GetAllCourses().Select(c => new CourseViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Description = c.Description
                }).ToList();
                return View(course_list);
            }
            return Content("Sorry, you are not allowed to access this module");
        }

        public ActionResult Details(int id)
        {
            var course = _repository.GetCourseById(id);
            CourseViewModel cvm = new CourseViewModel();
            cvm.Title = course.Title;
            cvm.Description = course.Description;
            cvm.CourseId = course.CourseId;
            if (course == null)
            {
                TempData["Error"] = "Course not found";
                return RedirectToAction("Index");
            }
            return View(cvm);
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _repository.AddCourse(course);
                TempData["Success"] = "Course Added Successfully";
                return RedirectToAction("Index");
            }

            return View(course);
        }

        public ActionResult Edit(int id)
        {
            Course course = _repository.GetCourseById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Title,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int id)
        {
            Course course = _repository.GetCourseById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = _repository.GetCourseById(id);
            _repository.DeleteCourse(course);
            return RedirectToAction("Index");
        }
    }
}
