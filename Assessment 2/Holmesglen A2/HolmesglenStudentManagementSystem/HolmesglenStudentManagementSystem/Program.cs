/*using HolmesglenStudentManagementSystem.DataAccessLayer;
using System.Data;
using Microsoft.Data.Sqlite;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Text;
using HolmesglenStudentManagementSystem.Models;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using HolmesglenStudentManagementSystem.PresentationLayer;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

*/
using HolmesglenStudentManagementSystem.PresentationLayer;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using HolmesglenStudentManagementSystem.PresentationLayer.StudentPL;
using HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL;
using HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL;
using HolmesglenStudentManagementSystem.PresentationLayer.OtherPL;

namespace HolmesglenStudentManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            
           // (new DeleteStudent()).Run();
            //(new GetAllStudents()).Run();
            
            //(new GetOneSubject()).Run();
            //(new CreateSubject()).Run();
            //(new DeleteSubject()).Run();
            //(new GetAllSubjects()).Run();
            //(new UpdateSubject()).Run();


            //(new GetOneEnrollment()).Run();
            //(new CreateEnrollment()).Run();
            //(new DeleteEnrollment()).Run();
            //(new GetAllEnrollments()).Run();
            //(new UpdateEnrollment()).Run();

            //(new GetOneStudent()).Run();
            
            //Others

            //(new EnrollmentsReport()).Run();
            //(new ImportStudents()).Run();
            (new ExportStudents()).Run();
            //(new EmailEnrollments()).Run();

            
            Console.ReadKey();
        }
    }          
}





             // uncomment the code below for testing
            //(new GetOneStudent()).Run();
            //(new CreateStudent()).Run();
            //(new UpdateStudent()).Run();
            //(new DeleteStudent()).Run();




 /*     // ********************************Generate a report***************************************** 

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
            select StudentID,FirstName|| "" "" ||LastName as StudentName,SubjectID,Title
            from Enrollment e, Student st, Subject su
            where e.StudentID_FK = st.StudentID
            AND e.SubjectID_FK = su.SubjectID";

            var reader = command.ExecuteReader();

            string writeText = "StudentID   ,StudentName ,SubjectId  ,  SubjectTitle   \n";// Create a text string

            while (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentName = reader.GetString(1);
                var subjectId = reader.GetString(2);
                var subjectTitle = reader.GetString(3);

                writeText += studentId + " , " + studentName + " , " + subjectId + " , " + subjectTitle +'\n';


            }
            connection.Close();

            File.WriteAllTextAsync("C:\\Users\\liu_s\\OneDrive\\Documents\\Holmesglen Assessment\\C#\\Assessment 2\\AT2Project\\HolmesglenStudentManagementSystem\\EnrollmentReport.txt", writeText);

           

        }
    }
}
    
        
          /*  //**************************Generate an email*********************************
            // get a student
            {string name = " ";                

            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT StudentID, FirstName, LastName, Email
                FROM Student
            ";       

            // get enrollment for this student
            list<string>subjects = new List<string >();
            subjects.Add("subject 1");
            subjects.Add("subject 2");
            

            // generate email text
            string email = "";
            email = email + "Dear name, \n";
            email = email + "You have been enrollment in the following subject \n ";

            email = email + "subject list:\n";
            
            foreach(var subject in subjects)
            {
                email = email + " ";
            }
            email = email + "Please login to your account and confirm the above enrolments.\r\n\r\nRegards,\r\nCAIT Department\r\n";
            

            // console write email text()
            Console.WriteLine(email);
            


       
/*
            //********************************Import students to database from a CSV file *************************************

            {                        

                var studentDAL = new StudentDAL(connection);               
                             
                using (var reader = new StreamReader("C:\\Users\\liu_s\\OneDrive\\Documents\\Holmesglen Assessment\\C#\\Assessment 2\\Students.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StudentRecord>();
                    foreach (var record in records)
                    {
                        Console.WriteLine($"{record.StudentID}     {record.FirstName} {record.LastName}     {record.Email}");
                        studentDAL.Create(new Student(record.StudentID, record.FirstName, record.LastName, record.Email));
                   
                    }

                }
                //******************************Export students’ data from database to a CSV file*********************************

                {
                var studentDAL = new StudentDAL(connection);
                var students = studentDAL.ReadAll();

                foreach (var student in students)
                {
                    Console.WriteLine(student.Id + "-" + student.FirstName + "-" + student.LastName + "-" + student.Email);
                }
                                
                using (var writer = new StreamWriter(@"C:\\Users\\liu_s\\OneDrive\\Documents\\Holmesglen Assessment\\C#\\Assessment 2\\Students_from_database.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(students);
                }
                
                  //**********************************test the disconnected studentreadall method ************************************
                  
                

                            {
                                string connectionString = @"Data Source=C:\Users\liu_s\OneDrive\Documents\Holmesglen Assessment\C#\Assessment 2\AT2Project\HolmesglenStudentManagementSystem.db";
                                var dalDisconnected = new DALDisconnected(connectionString);
                                Console.WriteLine("Reading all students using disconnected mode");
                                foreach (var student in dalDisconnected.StudentReadAll())
                                {
                                    Console.WriteLine($"{student.Id}  {student.FirstName}  {student.LastName}  {student.Email}");
                                }
                            }

                             Console.ReadLine();

                            {
                                string connectionString = @"Data Source=C:\Users\liu_s\OneDrive\Documents\Holmesglen Assessment\C#\Assessment 2\AT2Project\HolmesglenStudentManagementSystem.db";
                                var dalDisconnected = new DALDisconnected(connectionString);
                                Console.WriteLine("Reading all subjects using disconnected mode");
                                foreach (var subject in dalDisconnected.SubjectReadAll())
                                {
                                    
                                    Console.WriteLine($"{subject.SubjectId}  {subject.Title}  {subject.NumberOfSession}  {subject.HourPerSession}");

                                }
                            }







        /*    var connection = new SqliteConnection(HolmesglenDB.ConnectionString);
            //var enrollmentDAL = new EnrollmentDAL(connection);
            //var subjectDAL = new SubjectDAL(connection);
            var studentDAL = new StudentDAL(connection)
         *   
         *   
         *   // *******************Subject*******************
             //read  all subjects            


             var subjects = subjectDAL.ReadAll();

             foreach (var subject in subjects)
             {
                 Console.WriteLine(subject.SubjectId + "-" + subject.Title + "-" + subject.NumberOfSession + "-" + subject.HourPerSession);
             }
            

             
             //create subject


             var subject_new = new Subject("Su0005", "English","20", "6" );

             subjectDAL.Create_subject(subject_new);

             var subjects = subjectDAL.ReadAll();

             foreach (Subject result in subjects)
             {
                 Console.WriteLine(result.SubjectId + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);
             }  
            

            
             //delete subject


             subjectDAL.Delete_by_id("Su0002");


             var subjects = subjectDAL.ReadAll();

             foreach (Subject result in subjects)
             {
                 Console.WriteLine(result.SubjectId + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);
             }


            

            //READ subject BY ID            

            var result = subjectDAL.Read_by_id("Su0001");

            Console.WriteLine(result.SubjectId + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);



            //update subject

            var subject_update = new Subject("Su0002", "Law", "9", "3");

            subjectDAL.Update_subject(subject_update);
            var subjects = subjectDAL.ReadAll();

            foreach (Subject result in subjects)
            {
                Console.WriteLine(result.SubjectId + "-" + result.Title + "-" + result.NumberOfSession + "-" + result.HourPerSession);
            }


           //******************Student*******************

            //read  all students            

            var studentDAL = new StudentDAL(Connection);
            var students = studentDAL.ReadAll();

            foreach (var student in students)
            {
                Console.WriteLine(student.Id + "-" + student.FirstName + "-" + student.LastName + "-" +student.Email);
            }

            // (new GetAllStudents()).Run(); */
        /*


            //********************Enrollment**********************

            //read all enrollments

            var enrollments = enrollmentDAL.ReadAll();

        
            foreach (Enrollment result in enrollments)
            {
            Console.WriteLine(result.Id + "-" + result.StudentID_FK + "-" + result.SubjectID_FK);
        
            }   
                          
            //create enrollment


            var enrollment_new = new Enrollment("5", "St0003", "Su0005");

            enrollmentDAL.Create_enrollment(enrollment_new);

            var enrollments = enrollmentDAL.ReadAll();

            foreach (Enrollment result in enrollments)
            {
                Console.WriteLine(result.Id + "-" + result.StudentID_FK + "-" + result.SubjectID_FK);
            }




            //delete enrollment


            enrollmentDAL.Delete_by_id ("1");


            var enrollments = enrollmentDAL.ReadAll();

            foreach (Enrollment result in enrollments)
            {
                Console.WriteLine(result.Id + "-" + result.StudentID_FK + "-" + result.SubjectID_FK);
            }



            //READ Enrollment BY ID            

            var result = enrollmentDAL.Read_by_id("2");                      

            Console.WriteLine(result.Id + "-" + result.StudentID_FK + "-" + result.SubjectID_FK);



            //update enrollment

            var enrollment_update = new Enrollment("4","St0002","Su0003");

            enrollmentDAL.Update_enrollment(enrollment_update);
            var enrollments = enrollmentDAL.ReadAll();

            foreach (Enrollment result in enrollments)
            {
                Console.WriteLine(result.Id + "-" + result.StudentID_FK + "-" + result.SubjectID_FK);
            }
            */
                



            // uncomment the code below for testing
            //(new GetOneStudent()).Run();}}}
            //(new CreateStudent()).Run();
            //(new UpdateStudent()).Run();
            //(new DeleteStudent()).Run();

      
/*
                            Console.ReadLine();


             {
                                string connectionString = @"Data Source=C:\Users\liu_s\OneDrive\Documents\Holmesglen Assessment\C#\Assessment 2\AT2Project\HolmesglenStudentManagementSystem.db";
                                var dalDisconnected = new DALDisconnected(connectionString);
                                Console.WriteLine("Reading all enrollment using disconnected mode");
                                foreach (var enrollment in dalDisconnected.EnrollmentReadAll())
                                {
                                    
                                    Console.WriteLine($"{enrollment.Id}  {enrollment.StudentID_FK}  {enrollment.SubjectID_FK}");

                                }
                            }

                            Console.ReadLine();*/
            
        




    

        