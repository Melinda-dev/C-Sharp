using Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.BusinessLogicLayer
{
    public class StudentBLL
    {
        private AppDbContext db;

        public StudentBLL(AppDbContext appDBContext)
        {
            this.db = appDBContext;
        }

        // read all
        public List<Student> ReadAll()
        {
            var students = db.Students.ToList();
            return students;
        }

        // read by id
        public Student Read(string StudentID)
        {
            Student student = db.Students.Find(StudentID);
            return student;
        }

        // create a student
        public bool Create(Student student)
        {
            if (db.Students.Find(student.StudentID) == null)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        // update by id
        public bool Update(Student student)
        {
            var studentToUpdate = db.Students.Find(student.StudentID);
            if (studentToUpdate == null)
            {
                return false;
            }
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Email = student.Email;
            db.SaveChanges();
            return true;
        }

        // delete by id
        public bool Delete(String StudentID)
        {
            var student = db.Students.Find(StudentID);

            if (student == null)
            {
                return false;
            }
            db.Students.Remove(student);
            db.SaveChanges();
            return true;

        }
    }
}
