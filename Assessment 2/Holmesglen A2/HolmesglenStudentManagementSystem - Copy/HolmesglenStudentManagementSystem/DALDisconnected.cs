using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem
{
    public class DALDisconnected
    {
        private SQLiteConnection connection;
        // the adapter
        private SQLiteDataAdapter DataAdapter;
        // the data set
        private DataSet DBDataSet;
        // query string is used to define a sbuset of the whole database.
        // the whole data base with three tables are selected.
        private string DBQueryString = @"
        SELECT StudentID, FirstName, LastName, Email
        FROM Student;

        SELECT SubjectID, Title, NumberOfSession, HourPerSession
        FROM Subject;

        SELECT EnrollmentID, StudentID_FK, SubjectID_FK
        FROM Enrollment;
        ";

        public DALDisconnected(string connectionString)
        {
            // create a new connection
            connection = new SQLiteConnection(connectionString);

            // create the data adapter
            DataAdapter = new SQLiteDataAdapter(DBQueryString, connection);

            //populate the Dataset
            DBDataSet = new DataSet();
            DataAdapter.Fill(DBDataSet);

            // give each table a name to access them easily later
            DBDataSet.Tables[0].TableName = "Student";
            DBDataSet.Tables[1].TableName = "Subject";
            DBDataSet.Tables[2].TableName = "Enrollment";
        }

        public List<Student> StudentReadAll()
        {
            var students = new List<Student>();
            foreach (DataRow row in DBDataSet.Tables["Student"].Rows)
            {
                var id = row["StudentID"].ToString();
                var FirstName = row["FirstName"].ToString();
                var LastName = row["LastName"].ToString();
                var Email = row["Email"].ToString();
                students.Add(new Student(id, FirstName, LastName, Email));
            }            
            
            return students;
        }

            public List<Subject> SubjectReadAll()
        {
            var subjects = new List<Subject>();
            foreach (DataRow row in DBDataSet.Tables["Subject"].Rows)
            {
                var id = row["SubjectID"].ToString();
                var Title = row["Title"].ToString();
                var Numberofsession = row["NumberOfSession"].ToString();
                var Hourpersession = row["HourPerSession"].ToString();

                subjects.Add(new Subject(id, Title, Numberofsession, Hourpersession));
            }            
            
            return subjects;
        }

            public List<Enrollment> EnrollmentReadAll()
        {
            var enrollments = new List<Enrollment>();
            foreach (DataRow row in DBDataSet.Tables["Enrollment"].Rows)
            {
                var enrollmentid = row["EnrollmentID"].ToString();
                var studentid_FK = row["StudentID_FK"].ToString();
                var subjectid_FK = row["SubjectID_FK"].ToString();
                

               enrollments.Add(new Enrollment(enrollmentid, studentid_FK, subjectid_FK));
            }            
            
            return enrollments;
        }



        }

}
