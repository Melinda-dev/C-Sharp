using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using System.Threading.Tasks;



namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class OtherDBQueryDAL
    {
        private SqliteConnection Connection;

        public OtherDBQueryDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
       
        public string EnrollmentsReport()
        {

            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                select StudentID,FirstName|| "" "" ||LastName as StudentName,SubjectID,Title
                from Enrollment e, Student st, Subject su
                where e.StudentID_FK = st.StudentID
                AND e.SubjectID_FK = su.SubjectID";

            var reader = command.ExecuteReader();

            string writeText = "StudentID   ,StudentName ,SubjectId  ,  SubjectTitle   \n";// Create a text string

            while (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentName = reader.GetString(1);
                var subjectId = reader.GetString(2);
                var subjectTitle = reader.GetString(3);

                writeText += studentId + " , " + studentName + " , " + subjectId + " , " + subjectTitle + '\n';


            }
            Connection.Close();

            return writeText;
        }


        public string EmailEnrollments(string id)
        {

            // get a student
            Connection.Open();


            var command = Connection.CreateCommand();
            command.CommandText = @"           
                SELECT SubjectID, Title
                from Enrollment e, Student st, Subject su
                where e.StudentID_FK = st.StudentID
                AND e.SubjectID_FK = su.SubjectID
                AND st.StudentID = @a 
              ";

            command.Parameters.AddWithValue("a", id);
            var reader = command.ExecuteReader();           

            
            string writeText = "";                
            while (reader.Read())
            {
               
                var subjectId = reader.GetString(0);
                var title = reader.GetString(1);                               

                writeText += title + " ( " + subjectId + " ) " + '\n';

            }           
            
            Connection.Close();


            return writeText;

        }
    }  
   
   
}

