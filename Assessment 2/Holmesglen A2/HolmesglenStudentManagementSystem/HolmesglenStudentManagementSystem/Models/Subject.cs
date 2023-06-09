using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    
    public class Subject
    {
        public string SubjectId;
        public string Title;
        public string NumberOfSession;
        public string HourPerSession;

        public Subject()
        {
            SubjectId = "";
            Title = "";
            NumberOfSession = "";
            HourPerSession = "";
        }

        public Subject(string id, string title, string numberofsession, string hourpersession)
        {
            SubjectId = id;
            Title = title;
            NumberOfSession = numberofsession;
            HourPerSession = hourpersession;

        }
    }

}
