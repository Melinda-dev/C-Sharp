using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    internal class SubjectDAL
    {
 
        private SqliteConnection Connection;
        public StudentDAL()
        {
            // connect to the target database
            Connection = new SqliteConnection(HolmesglenDB.ConnectionString);
        }

        // create one
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
            command.Parameters.AddWithValue("b", student.FirstName);
            command.Parameters.AddWithValue("b", student.LastName);
            command.Parameters.AddWithValue("b", student.Email);


            //execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        // read ony by id

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
                var FirstName = reader.GetString(1);
                var LastName = reader.GetString(2);
                var Email = reader.GetString(3);
                student = new Student(studentId, FirstName, LastName, Email);

            }// else student = null

            Connection.Close();

            return student;
        }

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

        public override string ToString()
        {
            return base.ToString();
        }

        //update 
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
            command.Parameters.AddWithValue("b", student.FirstName);
            command.Parameters.AddWithValue("c", student.LastName);
            command.Parameters.AddWithValue("d", student.Email);

            //execute the query
            command.ExecuteReader();

            Connection.Close();

        }


    }
}

       
// create student

            



// read one student by id 


           



 }*/

