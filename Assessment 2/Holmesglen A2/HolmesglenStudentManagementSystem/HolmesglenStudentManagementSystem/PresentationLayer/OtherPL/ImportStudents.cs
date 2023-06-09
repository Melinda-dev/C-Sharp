
using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.OtherPL
{
    public class ImportStudents : PLBase
    {
        public override void Run()
        {
            //using (var reader = new StreamReader("C:\\Users\\liu_s\\OneDrive\\Documents\\Holmesglen Assessment\\C#\\Assessment 2\\Students.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))

            var reader = new StreamReader("C:\\Users\\liu_s\\OneDrive\\Documents\\Holmesglen Assessment\\" +
                "C#\\Assessment 2\\Students.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);


            Console.WriteLine("Import students to database from a CSV file");

            var records = csv.GetRecords<StudentRecord>();
            var studentBLL = new StudentBLL();
            var student = new Student();

            foreach (var record in records)
            {
                Console.WriteLine($"{record.StudentID}     {record.FirstName} {record.LastName}     {record.Email}");

                student.Id = record.StudentID; 
                student.FirstName = record.FirstName;
                student.LastName = record.LastName;
                student.Email = record.Email;
                var result = studentBLL.Create(student);
                if (result == false)
                {
                    Console.WriteLine($"Create new student unsuccessful");
                }
                else
                {
                    Console.WriteLine($"Create new student successful");
                }

            }

        }
    }
}
