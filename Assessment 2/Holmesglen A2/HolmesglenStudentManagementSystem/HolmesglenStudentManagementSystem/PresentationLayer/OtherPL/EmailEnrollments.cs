

using System.IO;
using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.OtherPL
{
    public class EmailEnrollments : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Generate an email");

            Console.WriteLine("Getting a student");
            Console.Write("Student ID: ");
            var id = Console.ReadLine();

            //1. get student email;
            var studentBLL = new StudentBLL();
            var student = studentBLL.GetOne(id);


            Console.WriteLine(student.Email);

            // 2. get student enroll subjects list information string;
            var otherBLL = new OtherBLL();
            var result = otherBLL.EmailEnrollments(id);

                        
            // 3. combine email subject and body here;
           
            string email = "";
            email = email + "Dear" + student.LastName + ", \n";
            email = email + "You have been enrollment in the following subject \n ";

            email = email + "subject list:\n";


            email = email + result;

            email = email + "Please login to your account and confirm the above enrolments.\r\n\r\nRegards,\r\nCAIT Department\r\n";

            Console.Write(email);




        }
    }
}

