using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class EnrollmentDAL
    {        
        private SqliteConnection Connection;

        public EnrollmentDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create
        public void Create(Enrollment enrollment)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Enrollment
                (EnrollmentID, StudentID_FK, SubjectID_FK)
                VALUES(@a, @b, @c)
            ";

            command.Parameters.AddWithValue("a", enrollment.Id);
            command.Parameters.AddWithValue("b", enrollment.StudentID_FK);
            command.Parameters.AddWithValue("c", enrollment.SubjectID_FK);
            

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        // read enrollment by id
        public Enrollment Read(string id)
        {

            Enrollment enrollment = null;
            try
            {
                Connection.Open();
                // build the query command
                var command = Connection.CreateCommand();
                command.CommandText = @"
                SELECT EnrollmentID, StudentID_FK, SubjectID_FK
                FROM Enrollment
                WHERE EnrollmentId = @a
            ";
                command.Parameters.AddWithValue("a", id);


                // execute the query
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var enrollmentId = reader.GetString(0);
                    var studentID_FK = reader.GetString(1);
                    var subjectID_FK = reader.GetString(2);
                    enrollment = new Enrollment(enrollmentId, studentID_FK, subjectID_FK);
                } // else enrollment = null

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Connection.Close();
            }
            Connection.Close();

            return enrollment;
        }

        // read all
        public List<Enrollment> ReadAll()
        {
            var enrollments = new List<Enrollment>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT EnrollmentID, StudentID_FK, SubjectID_FK
                FROM Enrollment
            ";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var enrollmentId = reader.GetString(0);
                var studentID_FK = reader.GetString(1);
                var subjectID_FK = reader.GetString(2);
                enrollments.Add(new Enrollment(enrollmentId, studentID_FK, subjectID_FK));
            }
            Connection.Close();
            return enrollments;
        }


        // update enrollment
        public void Update(Enrollment enrollment)
        {
            
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Enrollment
                SET StudentID_FK = @a,
                    SubjectID_FK = @b                    
                WHERE EnrollmentID = @c
            ";
            command.Parameters.AddWithValue("a", enrollment.StudentID_FK);
            command.Parameters.AddWithValue("b", enrollment.SubjectID_FK);
            command.Parameters.AddWithValue("c", enrollment.Id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        //delete enrollment

        public void Delete(string id)
        {
            
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Enrollment
                WHERE EnrollmentID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}

