using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.Models;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Globalization;
using CsvHelper;


namespace HolmesglenStudentManagementSystem.PresentationLayer.OtherPL
{
    public class ExportStudents : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Export Students Data");

            var studentBLL = new StudentBLL();
            var result = studentBLL.GetAll();

            
            var records = new List<Student>();
                      


            foreach (var res in result)
            {
                Console.WriteLine(res.Id + "," + res.FirstName + "," + res.LastName + "," + res.Email);
                var student = new Student();
                student.FirstName = res.FirstName.Trim();
                student.Id= res.Id.Trim();
                student.LastName = res.LastName.Trim();
                student.Email = res.Email.Trim();

                records.Add(new Student() { Id = res.Id, FirstName = res.FirstName, LastName = res.LastName, Email = res.Email})
            

            }


            using (var writer = new StreamWriter(@"C:\\Users\\liu_s\\OneDrive\\Documents\\Holmesglen Assessment\\C#"
                                           + "\\Assessment 2\\AT2Project\\HolmesglenStudentManagementSystem\\Students_from_database_v3.csv"))
            {


                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(records);
                               
            }




        }
    }

    
}



