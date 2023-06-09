using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace HolmesglenStudentManagementSystem.PresentationLayer.OtherPL
{
    public class EnrollmentsReport : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Generate a report");

            var otherBLL = new OtherBLL();
            var result = otherBLL.EnrollmentsReport();

            File.WriteAllTextAsync("C:\\Users\\liu_s\\OneDrive\\Documents\\Holmesglen Assessment" +
                "\\C#\\Assessment 2\\AT2Project\\HolmesglenStudentManagementSystem\\EnrollmentReport.txt", result);

        }
    }
}

