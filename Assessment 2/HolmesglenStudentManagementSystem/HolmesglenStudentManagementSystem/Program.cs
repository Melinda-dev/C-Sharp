using System;
using HolmesglenStudentManagementSystem.BusinessLogicaLayer;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using HolmesglenStudentManagementSystem.PresentationLayer;
using Microsoft.Data.Sqlite;

namespace HolmesglenStudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            StudentDAL studentDAL = new StudentDAL();
            StudentBLL studentBLL = new StudentBLL(studentDAL);
            GetAllStudents getAllStudents = new GetAllStudents(studentBLL);
            
            /*
            var students = studentDAL.ReadAll();
            foreach (var student in students)
            {
                Console.WriteLine(student.StudentID + "-" + student.FirstName + "-" + student.LastName + "-" +student.Email);
            }
            */
            getAllStudents.Run();
        }
    }
}

 