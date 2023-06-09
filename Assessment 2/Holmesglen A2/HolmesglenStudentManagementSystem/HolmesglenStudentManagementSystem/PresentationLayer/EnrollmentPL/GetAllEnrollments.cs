using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL
{
    public class GetAllEnrollments : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting all enrollments");

            var enrollmentBLL = new EnrollmentBLL();
            var result = enrollmentBLL.GetAll();
            if (result.Count == 0)
            {
                Console.WriteLine("table is empty");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Id}\t{item.StudentID_FK}\t{item.SubjectID_FK}");
                }
            }
        }
    }
}
