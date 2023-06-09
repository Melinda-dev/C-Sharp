using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{

    public class Enrollment

    {
        public string Id;
        public string StudentID_FK;
        public string SubjectID_FK;


        public Enrollment()
        {
            Id = "";
            StudentID_FK = "";
            SubjectID_FK = "";

        }

        public Enrollment(string id, string studentid_fk, string subjectid_fk)
        {
            Id = id;
            StudentID_FK = studentid_fk;
            SubjectID_FK = subjectid_fk;

        }


    }
}