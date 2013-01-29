using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reference.Repository
{
   public  class GenericStudentRepository
    {
       private static IEnumerable<Student> _students;

       private static IEnumerable<Student> GetStudents()
       {
           if(_students !=null) return _students;

           _students= new List<Student>
             {
                 new Student { FirstName="Gerome" ,LastName="Levoy",Age=27},
                 new Student { FirstName="Ron" ,LastName="Harper",Age=25},                 
                 new Student { FirstName="Eva" ,LastName="Rose",Age=29},
                 new Student { FirstName="Ilora" ,LastName="Guha",Age=29}

             }.AsQueryable();

           return _students;
       }

       public IEnumerable<Student> GetAllStudents()
       {
           return GetStudents();
       }
    }
}
