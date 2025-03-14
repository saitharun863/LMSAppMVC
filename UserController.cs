using DemoWebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace DemoWebAppMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;

        public UserController() : this(new UserRepository())
        {

        }

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }



        // GET: User
        public ActionResult Index(int id)
        {
            if (id == 0)
            {
                ViewBag.Title = "User List";
                ViewData["UserCount"] = -_repo.GetAllUsers().Count();
                List<UserViewModel> user_list = _repo.GetAllUsers().Select(c => new UserViewModel
                {
                    UserId = c.UserId,
                    Name = c.Name,
                    Email = c.Email,
                    Password = c.Password,
                    Role = c.Role,
                }).ToList();
                return View(user_list);
            }
            return Content("Sorry, you are not allowed to access this module");
        }

        public ActionResult Details(int id)
        {
            var user = _repo.GetUserById(id);
            UserViewModel uvm = new UserViewModel();
            uvm.UserId = user.UserId;
            uvm.Name = user.Name;
            uvm.Email = user.Email;
            uvm.Password = user.Password;
            uvm.Role = user.Role;

            if (user == null)
            {
                TempData["Error"] = "User not found";
                return RedirectToAction("Index");
            }
            return View(uvm);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            ViewBag.TypeList = new List<SelectListItem>
            {
                 new SelectListItem{ Value = Actor.Type.Admin.ToString(), Text="Admin"},
                 new SelectListItem{ Value = Actor.Type.Instructor.ToString(), Text="Instructor"},
                 new SelectListItem{ Value = Actor.Type.Student.ToString(), Text="Student"}
            };
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                Actor uvm = new Actor();
                uvm.UserId = user.UserId;
                uvm.Name = user.Name;
                uvm.Email = user.Email;
                uvm.Password = user.Password;
                uvm.Role = user.Role;
                _repo.AddUser(uvm);
                TempData["Success"] = "User added successfully";
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModel uvm)
        {
            string role = _repo.Login(uvm.Email, uvm.Password);
            if (ModelState.IsValid)
            {
                if (role == null)
                {
                    TempData["Error"] = "User not Found";
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
    }
}