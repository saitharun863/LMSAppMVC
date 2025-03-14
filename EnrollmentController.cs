using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DemoWebAppMVC.Models;

namespace DemoWebAppMVC.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentRepository _enrollRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IUserRepository _userRepo;

        public EnrollmentController() : this(new EnrollmentRepository(), new CourseRepository(), new UserRepository())
        {

        }
        public EnrollmentController(IEnrollmentRepository enrollRepo, ICourseRepository courseRepo, IUserRepository userRepo)
        {
            _enrollRepo = enrollRepo;
            _courseRepo = courseRepo;
            _userRepo = userRepo;
        }
        public ActionResult Index(int id)
        {
            if (id == 0)
            {
                ViewBag.Title = "Enrollment List";
                ViewData["EnrollsCount"] = _enrollRepo.GetAllEnrollments().Count();
                List<EnrollmentViewModel> enroll_list = _enrollRepo.GetAllEnrollments().Select(c => new EnrollmentViewModel
                {
                    EnrollmentId = c.EnrollmentId,
                    CourseId = c.CourseId,
                    UserId = c.UserId,
                    EnrollmentDate = c.EnrollmentDate,
                    Course = c.Course,
                    Actor = c.Actor
                }).ToList();
                return View(enroll_list);
            }
            return Content("Sorry, you are not allowed to access this module");
        }

        public ActionResult Details(int id)
        {
            var enroll = _enrollRepo.GetEnrollmentById(id);
            EnrollmentViewModel evm = new EnrollmentViewModel();

            evm.EnrollmentId = enroll.EnrollmentId;
            evm.CourseId = enroll.CourseId;
            evm.UserId = enroll.UserId;
            evm.EnrollmentDate = enroll.EnrollmentDate;
            evm.Course = enroll.Course;
            evm.Actor = enroll.Actor;
            if (enroll == null)
            {
                TempData["Message"] = "Enrollment not found";
                return RedirectToAction("Index");
            }
            return View(evm);
        }

        public ActionResult AddEnrollment()
        {
            var model = new EnrollmentViewModel
            {


                course_list = _courseRepo.GetAllCourses().Select(c => new EnrollSelectItem
                {
                    Id = c.CourseId,
                    Value = c.CourseId.ToString(),
                    Text = c.Title
                }).ToList(),


                user_list = _userRepo.GetAllUsers().Select(u => new EnrollSelectItem
                {
                    Id = u.UserId,
                    Value = u.UserId.ToString(),
                    Text = u.Name
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEnrollment(Enrollment enroll)
        {
            if (ModelState.IsValid)
            {
                _enrollRepo.AddEnrollment(enroll);
                TempData["Message"] = "Enrollment added successfully";
                return RedirectToAction("Index");
            }
            
            return View(enroll);
        }
    }
}