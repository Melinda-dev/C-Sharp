using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem
{
    internal class StudentRecord
    {
        
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // add this empty constructor

        public StudentRecord(){}

        public StudentRecord(string studentID, string firstName, string lastName, string email)
        {
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
