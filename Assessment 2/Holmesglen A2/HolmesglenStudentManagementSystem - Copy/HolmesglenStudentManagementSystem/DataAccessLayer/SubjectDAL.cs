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
            // connect to the tarGet database
            Connection = connection;
            
        }
         
        // Create One subject
        public void Create_subject(Subject subject)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO subject
                (SubjectId, Title, Numberofsession, Hourpersession)
                VALUES(@a, @b, @c, @d);
            ";
            command.Parameters.AddWithValue("a", subject.SubjectId);
            command.Parameters.AddWithValue("b", subject.Title);
            command.Parameters.AddWithValue("c", subject.NumberOfSession);
            command.Parameters.AddWithValue("d", subject.HourPerSession);

            var creator = command.ExecuteReader();
            Connection.Close();
        }


        //Read All subject
        public List<Subject> ReadAll()

        {
            var subjects = new List<Subject>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
            SELECT *
            FROM subject";


            //execute the query
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var Id = reader.GetString(0);
                var Title = reader.GetString(1);
                var numberofsession = reader.GetString(2);
                var hourpersession = reader.GetString(3);

                subjects.Add(new Subject(Id, Title, numberofsession, hourpersession));

            }
            Connection.Close();
            return subjects;
        }


        // read the subject by id

        public Subject Read_by_id(string id)

        {
            Subject subject = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT * FROM subject WHERE subjectId = @a ";

            command.Parameters.AddWithValue("a", id);


            // execute the query
            var read_by_id = command.ExecuteReader();
            if (read_by_id.Read())
            {
                var subjectID = read_by_id.GetString(0);
                var Title = read_by_id.GetString(1);
                var NumberOfSession = read_by_id.GetString(2);
                var HourPerSession = read_by_id.GetString(3);

                subject = new Subject(id, Title, NumberOfSession, HourPerSession);

            }// else subject = null

            Connection.Close();

            return subject;
        }


        //update subject
        public void Update_subject(Subject subject)
        {

            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE subject
                SET Title = @b 
                WHERE subjectID = @a
                
            ";
            command.Parameters.AddWithValue("a", subject.SubjectId);
            command.Parameters.AddWithValue("b", subject.Title);
            command.Parameters.AddWithValue("c", subject.NumberOfSession);
            command.Parameters.AddWithValue("d", subject.HourPerSession);

            //execute the query
            command.ExecuteReader();

            Connection.Close();
        }



        //delete a subject by ID
        public void Delete_by_id(string id)
        {

            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE 
                FROM subject
                WHERE subjectId = @a;
                
            ";
            command.Parameters.AddWithValue("a", id);


            //execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}
