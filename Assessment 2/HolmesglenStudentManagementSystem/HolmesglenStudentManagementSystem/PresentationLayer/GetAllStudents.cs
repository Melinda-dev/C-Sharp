using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolmesglenStudentManagementSystem.PresentationLayer
{
    internal class GetAllStudents
    {               
        private StudentBLL StudentBLLInstance;

        public GetAllStudents(StudentBLL studentBLLInstance)
        {
            StudentBLLInstance = studentBLLInstance;
        }

        public void Run()
        {
            var students = StudentBLLInstance.GetAll();
            foreach (var student in students)
            {
                Console.WriteLine(student.StudentID + "-" + student.FirstName + "-" + student.LastName + "-" + student.Email);
            }
        }

    }


}
