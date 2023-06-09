using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL
{
    public class UpdateEnrollment : PLBase
    {
        public override void Run()
        {
            var enrollment = new Enrollment();
            Console.WriteLine("Updating a new enrollment");
            Console.Write("Enter ID: ");
            enrollment.Id = Console.ReadLine();
            Console.Write("Enter StudentID: ");
            enrollment.StudentID_FK = Console.ReadLine();
            Console.Write("Enter SubjectID: ");
            enrollment.SubjectID_FK = Console.ReadLine();
            

            var enrollmentBLL = new EnrollmentBLL();
            var result = enrollmentBLL.Update(enrollment);

            if (result == false)
            {
                Console.WriteLine($"Update enrollment unsuccessful");
            }
            else
            {
                Console.WriteLine($"Update enrollment successful");
            }
        }
    }
}
