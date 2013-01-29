using System;
using System.Linq;

namespace Reference.Repository
{
   public  interface IRepository
    {
        IQueryable<Student> GetAllStudents();
    }
}
