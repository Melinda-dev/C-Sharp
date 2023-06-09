using HolmesglenStudentManagementSystem.PresentationLayer;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using HolmesglenStudentManagementSystem.PresentationLayer.StudentPL;
using System.Data;
using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Connection = new SqliteConnection(HolmesglenDB.ConnectionString);
            var subjectDAL = new SubjectDAL(Connection);

            /* *******************StudentL*******************

            //reader all students
            

            var studentDAL = new StudentDAL(Connection);
            var students = studentDAL.ReadAll();

            
                         foreach (var student in students)
                         {
                             Console.WriteLine(student.Id + "-" + student.FirstName + "-" + student.LastName + "-" +student.Email);
                         }
           
            // (new GetAllStudents()).Run();

            */

            /*
            //********************READALL SUBJECT**********************

            var subjects = subjectDAL.ReadAll();

            foreach (Subject result in subjects)
            {
                Console.WriteLine(result.Id + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);
            }

            */

            /*

            //********************CREATE SUBJECT**********************           


            
           
            var subject_new = new Subject("Su0005", "Math", "15", "6");

            //subjectDAL.Delete_by_id("Su0004");
            subjectDAL.Delete_by_id("Su0005");


            subjectDAL.Create_subject(subject_new);

            var subjects = subjectDAL.ReadAll();

            foreach (Subject result in subjects)
            {
                Console.WriteLine(result.Id + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);
            }
            */

            /*

            //********************DELETE SUBJECT********************** 


            subjectDAL.Delete_by_id("Su0005");
            
           
            var subjects = subjectDAL.ReadAll();

            foreach (Subject result in subjects)
            {
                Console.WriteLine(result.Id + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);
            }

            
            */

            
            //********************READ SUBJECT BY ID ********************** 
            
            
            var result = subjectDAL.Read_by_id("Su0001");                      
            
            Console.WriteLine(result.Id + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);
            
                       

            /*

            //********************UPDATE SUBJECT********************** 

            var subject_update = new Subject("Su0002", "English", "15", "6");

            subjectDAL.Update_subject(subject_update);
            var subjects = subjectDAL.ReadAll();

            foreach (Subject result in subjects)
            {
                Console.WriteLine(result.Id + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);
            }



           /*


            //*********************ENROLLMENT**************************


            // uncomment the code below for testing
            //(new GetOneStudent()).Run();
            //(new CreateStudent()).Run();
            //(new UpdateStudent()).Run();
            //(new DeleteStudent()).Run();
            */

        }
    }
}
