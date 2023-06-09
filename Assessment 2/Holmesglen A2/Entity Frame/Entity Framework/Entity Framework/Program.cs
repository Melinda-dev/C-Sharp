using Entity_Framework.BusinessLogicLayer;
using Entity_Framework.Models;
using System;

namespace Entity_Framework
{
    
    internal class Program
    {
        static private AppDbContext db;

        static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();
            var studentBLL = new StudentBLL(db);


            /* // create a student

            var st1 = new Student() { StudentID = "St001", FirstName = "Peter1", LastName = "Kfc1", Email = "peter1.kfc@gmail.com"};
            studentBLL.Create(st1);
            var st2 = new Student() { StudentID = "St002", FirstName = "Peter2", LastName = "Kfc2", Email = "peter2.kfc@gmail.com" };
            studentBLL.Create(st2);
            var st3 = new Student() { StudentID = "St003", FirstName = "Peter3", LastName = "Kfc2", Email = "peter3.kfc@gmail.com" };
            studentBLL.Create(st3);

           
            
            // read all students
            foreach (Student st in studentBLL.ReadAll())
            {
                Console.WriteLine($"{st.StudentID}/{st.FirstName}/{st.LastName}/{st.Email}");
            }



            //read by id 

            var s = studentBLL.Read("St001");

            Console.WriteLine($"{s.StudentID}/{s.FirstName}/{s.LastName}/{s.Email}");

            
            
            // update a student by id
            studentBLL.Update(new Student() { StudentID = "St002", FirstName = "Peterupated", LastName = "Kfcupdated", Email = "peterupdated.kfcupdated@hotmail.com"});*/
            
            
            //delete a student
            studentBLL.Delete("St001");


            //display all students after the delete
            foreach(Student item in studentBLL.ReadAll())
            {
                Console.WriteLine($"{item.StudentID}/{item.FirstName}/{item.LastName}/{item.Email}");
            }
           



        }
    }
}
