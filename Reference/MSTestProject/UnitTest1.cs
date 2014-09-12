using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Reflection;
using Moq;
using Reference.Controllers;
using System.Web.Mvc;
using Reference.Repository;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private IRepository repos;
        [TestInitialize]
        public void TestInit()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IRepository>().To<Reference.Repository.MockRepository>();
            // kernel.Bind<IRepository>().To<Repository.MockRepository>().When(c=>c.Target.Type.Assembly.FullName.StartsWith("TestProject.Test"));
            repos = kernel.Get<IRepository>();
        }

        [TestMethod]
        public void Index()
        {
            var repo = new Mock<BaseRepository<Student>>();
            var data = new List<Student>
             {
                 new Student { FirstName="Gerome" ,LastName="Levoy",Age=27},
                 //new Student { FirstName="Ron" ,LastName="Harper",Age=25},                 
                 new Student { FirstName="Eva" ,LastName="Rose",Age=29},
                 new Student { FirstName="Ilora" ,LastName="Guha",Age=29}

             };

            repo.Setup(r => r.GetAllStudents()).Returns(data);



            // Act
            //ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.AreEqual("Welcome to ASP.NET MVC!", result.ViewBag.Message);
            Assert.AreEqual(3, repo.Object.GetAllStudents().Count());
        }
         [TestMethod]
        public void About()
        {
            // Arrange

            HomeController controller = new HomeController(repos);

            // Act
            //ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual(3, repos.GetAllStudents().Count());
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            GC.Collect();
        }
    }
}
