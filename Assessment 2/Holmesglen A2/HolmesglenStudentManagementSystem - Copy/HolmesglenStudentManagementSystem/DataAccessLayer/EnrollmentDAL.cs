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
            // connect to the tarGet database
            Connection = connection;
        }


        //Read All Enrollment
        public List<Enrollment> ReadAll()

        {
            var enrollments = new List<Enrollment>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                    SELECT *
                    FROM Enrollment";

            //execute the query
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var Id = reader.GetString(0);
                var StudentID_FK = reader.GetString(1);
                var SubjectID_FK = reader.GetString(2);

                enrollments.Add(new Enrollment(Id, StudentID_FK, SubjectID_FK));

            }
            Connection.Close();
            return enrollments;
        }


        // Create enrollment
        public void Create_enrollment(Enrollment enrollment)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                    INSERT INTO Enrollment
                    (EnrollmentID, StudentID_FK, SubjectID_FK)
                    VALUES(@a, @b, @c);
                ";
            command.Parameters.AddWithValue("a", enrollment.Id);
            command.Parameters.AddWithValue("b", enrollment.StudentID_FK);
            command.Parameters.AddWithValue("c", enrollment.SubjectID_FK);

            var creator = command.ExecuteReader();
            Connection.Close();

        }


        // read only one by id

        public Enrollment Read_by_id(string id)

        {
            Enrollment enrollment = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                        SELECT * FROM Enrollment WHERE EnrollmentId = @a ";

            command.Parameters.AddWithValue("a", id);


            // execute the query
            var read_by_id = command.ExecuteReader();
            if (read_by_id.Read())
            {
                var EnrollmentId = read_by_id.GetString(0);
                var student_fk = read_by_id.GetString(1);
                var subject_fk = read_by_id.GetString(2);

                enrollment = new Enrollment(EnrollmentId, student_fk, subject_fk);

            }

            Connection.Close();
            return enrollment;
        }



        //update 
        public void Update_enrollment(Enrollment enrollment)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                    UPDATE Enrollment
                    SET StudentID_FK = @b, SubjectID_FK = @c
                    WHERE EnrollmentID = @a;
                
                ";
            command.Parameters.AddWithValue("a", enrollment.Id);
            command.Parameters.AddWithValue("b", enrollment.StudentID_FK);
            command.Parameters.AddWithValue("c", enrollment.SubjectID_FK);

            //execute the query
            command.ExecuteReader();

            Connection.Close();

        }

        //delete a enrollment by ID
        public void Delete_by_id(string id)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                    DELETE 
                    from Enrollment
                    WHERE EnrollmentID = @a;
                
                ";
            command.Parameters.AddWithValue("a", id);


            //execute the query
            command.ExecuteReader();

            Connection.Close();

        }


    }
}