using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reference.Repository
{
    public interface BaseRepository<out T> where T:Student
    {
        IEnumerable<Student> GetAllStudents();
    }
}
