using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Reference.Controllers;
using System.Web.Mvc;
using Reference.Repository;
using Ninject;
using System.Reflection;
using Moq;

namespace TestProject.Test
{
   [TestFixture]
   public  class TestClass
    {
       private  IRepository repos;

       [TestFixtureSetUp]
       public void SetUp()
       {
           var  kernel = new StandardKernel();
           kernel.Load(Assembly.GetExecutingAssembly());
           kernel.Bind<IRepository>().To<Reference.Repository.MockRepository>();
           // kernel.Bind<IRepository>().To<Repository.MockRepository>().When(c=>c.Target.Type.Assembly.FullName.StartsWith("TestProject.Test"));
           repos = kernel.Get<IRepository>();
       }

        [TestCase]
        public void Index()
        {
            // Arrange
           
            
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
            Assert.AreEqual(4,repo.Object.GetAllStudents().Count() );
        }
        
        [TestCase]
        public void About()
        {
            // Arrange

            HomeController controller = new HomeController(repos);
            
            // Act
            //ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual(3, repos.GetAllStudents().Count());
        }
    }
}
