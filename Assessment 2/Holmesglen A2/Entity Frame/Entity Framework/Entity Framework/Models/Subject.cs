using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class Subject
    {
        public string SubjectID { get; set; }
        public string Title { get; set; }
        public string NumberOfSession { get; set; }
        public string HourPerSession { get; set; }

    }
}
