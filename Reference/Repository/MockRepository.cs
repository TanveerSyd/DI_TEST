using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Reference.Repository
{
   public class MockRepository : IRepository
    {
        public IQueryable<Student> GetAllStudents()
        {
            return new List<Student>
             {
                 new Student { FirstName="Rob" ,LastName="Kenny",Age=25},
                 new Student { FirstName="George" ,LastName="Lucas",Age=27},
                 new Student { FirstName="Big" ,LastName="Ron",Age=29}

             }.AsQueryable();
        }
    }
}
