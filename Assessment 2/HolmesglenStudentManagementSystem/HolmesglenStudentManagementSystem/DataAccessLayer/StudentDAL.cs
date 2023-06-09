using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class StudentDAL
    {

        private SqliteConnection Connection;
        public StudentDAL()
        {
            // connect to the target database
            Connection = new SqliteConnection(HolmesglenDB.ConnectionString);

            
            Connection.Open();

            // build the quary command with verify sql statement 
            var command = Connection.CreateCommand();
            command.CommandText = @"
            SELECT *
            FROM Student
            ";
            // execute the command and retrive the result
            var reader = command.ExecuteReader();
        }

        // create one

        // read ony by id

        // read all

        public List<Student> ReadAll()
        {
            Connection.Open();
            // build the quary command with verify sql statement 
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT *
                FROM Student
            ";
            // execute the command and 5retrive the result
            var reader = command.ExecuteReader();

            var students = new List<Student>();
            while (reader.Read())
            {
                var studentID = reader.GetString(0);
                var FirstName = reader.GetString(1);
                var LastName = reader.GetString(2);
                var Email = reader.GetString(3);
                students.Add(new Student(studentID, FirstName, LastName, Email));
            }

            return students;
        }
    }
}

        /*
        var connection = new SqliteConnection(connectionString);
        connection.Open();

            // build the quary command with verify sql statement 
            var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT *
            FROM Student
            ";
            // execute the command and retrive the result
            var reader = command.ExecuteReader();



        public List<Student> ReadAll()
        {
            var students = new List<Student>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
            SELECT *
            FROM Student
        ";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var studentID = reader.GetString(0);
                var FirstName = reader.GetString(1);
                var LastName = reader.GetString(2);
                var Email = reader.GetString(3);
                students.Add(new student(studentID, FirstName, LastName, Email));
            }
            Connection.Close();
            return students;
        }
            /*
            public void Create(Student student)
            {
                Connection.Open();
                // build the query command
                var command = Connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO Student
                    (StudentID, Name)
                    VALUES(@a, @b);
                ";
                command.Parameters.AddWithValue("a", student.Id);
                command.Parameters.AddWithValue("b", student.Name);

                //execute the query
                command.ExecuteReader();

                Connection.Close();
            }

            public Student Read(string id)

            {
                Student student = null;
                Connection.Open();
                // build the query command
                var command = Connection.CreateCommand();
                command.CommandText = @"
                    SELECT * FROM Student WHERE StudentId = @a ";

                command.Parameters.AddWithValue("a", id);


                // execute the query
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var studentId = reader.GetString(0);
                    var studentName = reader.GetString(1);
                    student = new Student(studentId, studentName);

                }// else student = null

                Connection.Close();

                return student;

           

            public void Update(Student student)
            {
                Connection.Open();
                // build the query command
                var command = Connection.CreateCommand();
                command.CommandText = @"
                UPDATE Student
                SET Name = @b 
                WHERE StudentId = @a;
                
            ";
                command.Parameters.AddWithValue("a", student.Id);
                command.Parameters.AddWithValue("b", student.Name);

                //execute the query
                command.ExecuteReader();

                Connection.Close();

            }
        }
    }


 }*/

    /*



        Public Student Read(string id)
            {
            Student student = null;
            Connection.Open();
            // build the query command
            var command = Connection. CreateCommand();
            command.CommandText = @"
            INSERT INTO STUDENT
            (StudentID, Name)
            VALUES(@A, @B);
        ";
            command.Parameters.AddWithValue("a", id);


            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentName = reader.GetString(1);
                student = new Student(studentId, studentName);

            }// else student = null

            Connection.Close ();

            return student;

        }


    }
    }
    }

    */

