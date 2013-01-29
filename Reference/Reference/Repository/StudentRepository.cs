using System.Collections.Generic;
using System.Linq;
using Reference.Models;


namespace SampleMvc.Repository
{
    public class UserRepository 
    {
        #region IUserRepository Members

        public Student GetUser(string studentId)
        {
            return Database.Students.Where(student => student.StudentId == studentId).FirstOrDefault();
        }

        #endregion
    }

    public class Database
    {
        public static List<Student> Students = new List<Student>
                                             {
                                                 new Student
                                                     {
                                                         StudentId = "john_doe",
                                                         LastName = "Doe",
                                                         FirstName = "John",
                                                         Age = 25
                                                     },
                                                 new Student
                                                     {
                                                         StudentId = "user2",
                                                         LastName = "SomeLastName",
                                                         FirstName = "SomeFirstNAme",
                                                         Age = 28
                                                     },
                                             };
    }
}