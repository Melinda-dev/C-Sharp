using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL
{
    public class UpdateSubject : PLBase
    {
        public override void Run()
        {
            var subject = new Subject();
            Console.WriteLine("Updating a new subject");
            Console.Write("Enter ID: ");
            subject.SubjectId = Console.ReadLine();
            Console.Write("Enter Title: ");
            subject.Title = Console.ReadLine();
            Console.Write("Enter NumberOfSession: ");
            subject.NumberOfSession = Console.ReadLine();
            Console.Write("Enter HourPerSession: ");
            subject.HourPerSession = Console.ReadLine();

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Update(subject);

            if (result == false)
            {
                Console.WriteLine($"Update subject unsuccessful");
            }
            else
            {
                Console.WriteLine($"Update subject successful");
            }
        }
    }
}
