using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL
{
    public class DeleteSubject : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Deleting a subject");
            Console.Write("Subejct ID: ");
            var id = Console.ReadLine();

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Delete(id);
            if (result == false)
            {
                Console.WriteLine($"Delete subject unsuccessful");
            }
            else
            {
                Console.WriteLine($"Delete subject successful");
            }
        }
    }
}
