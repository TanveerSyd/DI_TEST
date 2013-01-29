using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Reference.Repository
{
    public class Repository : IRepository 
    {
        public IQueryable<Student> GetAllStudents()
        {
            return new TestEntities().Students;
        }
    }
}
