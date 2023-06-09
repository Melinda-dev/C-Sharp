using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class SubjectDAL
    {        
        private SqliteConnection Connection;

        public SubjectDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }


        // create
        public void Create(Subject subject)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Subject
                (SubjectID, Title, NumberOfSession, HourPerSession)
                VALUES(@a, @b, @c, @d)
            ";

            command.Parameters.AddWithValue("a", subject.SubjectId);
            command.Parameters.AddWithValue("b", subject.Title);
            command.Parameters.AddWithValue("c", subject.NumberOfSession);
            command.Parameters.AddWithValue("d", subject.HourPerSession);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }



        // read subject by id
        public Subject Read(string id)
        {

            Subject subject = null;
            try
            {
                Connection.Open();
                // build the query command
                var command = Connection.CreateCommand();
                command.CommandText = @"
                SELECT SubjectID, Title, NumberOfSession, HourPerSession
                FROM Subject
                WHERE SubjectId = @a
            ";
                command.Parameters.AddWithValue("a", id);


                // execute the query
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var subjectId = reader.GetString(0);
                    var title = reader.GetString(1);
                    var numberofsession = reader.GetString(2);
                    var hourpersession = reader.GetString(3);
                    subject = new Subject(subjectId, title, numberofsession, hourpersession);
                } // else subject = null

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Connection.Close();
            }
            Connection.Close();

            return subject;
        }

        // read all
        public List<Subject> ReadAll()
        {
            var subjects = new List<Subject>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT SubjectID, Title, NumberOfSession, HourPerSession
                FROM Subject
            ";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var subjectId = reader.GetString(0);
                var title = reader.GetString(1);
                var numberofsession = reader.GetString(2);
                var hourpersession = reader.GetString(3);
                subjects.Add(new Subject(subjectId,title,numberofsession,hourpersession));
            }
            Connection.Close();
            return subjects;
        }


        // update subject
        public void Update(Subject subject)
        {
            
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Subject
                SET Title = @a,
                    NumberOfSession = @b,
                    HourPerSession = @c
                WHERE SubjectID = @d
            ";
            command.Parameters.AddWithValue("d", subject.SubjectId);
            command.Parameters.AddWithValue("a", subject.Title);
            command.Parameters.AddWithValue("b", subject.NumberOfSession);
            command.Parameters.AddWithValue("c", subject.HourPerSession);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        //delete subject

        public void Delete(string id)
        {
            
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Subject
                WHERE SubjectID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}


