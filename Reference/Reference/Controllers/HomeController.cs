using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reference.Repository;
using Reference.ViewModels;
using Reference.StudentService;

namespace Reference.Controllers
{
    public class HomeController : Controller
    {
        public readonly IRepository repo;

        public HomeController(IRepository repos)
        {
            repo = repos;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

           
           // TestEntities context = new TestEntities();
            StudentViewModel viewModel = new StudentViewModel
            {
                Students = repo.GetAllStudents()

            };

            return View(viewModel);
        }
        [HttpPost]
        public PartialViewResult Index(StudentViewModel vm)
        {
            TestEntities context = new TestEntities();
            context.Students.Add(vm.newStudent);
            context.SaveChanges();

            return PartialView("_StudentListControl",context.Students);
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
