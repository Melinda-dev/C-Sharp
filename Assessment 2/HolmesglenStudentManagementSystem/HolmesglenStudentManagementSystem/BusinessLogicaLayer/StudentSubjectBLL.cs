using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolmesglenStudentManagementSystem.BusinessLogicaLayer
{
    internal class StudentSubjectBLL
    {
        public List<StudentSubject> GetAllEnrollments()
        {
            var results = new List<StudentSubject>();
            // get all enrollments
            var allEnrollments = AppDAL.Instance().EnrollmentDALInstance.ReadAll();

            // for each enrollment record get the student ID and subject name
            foreach (var enrollment in allEnrollments)
            {
                var student = AppDAL.Instance().StudentDALInstance.Read(enrollment.Student ID_FK);
                var student = AppDAL.Instance().StudentDALInstance.Read(enrollment.Subject ID_FK);

                results.Add(new StudentSubject(student.ID, student.Email, subject.ID, subject.Title));


            }

            return results;
                
                   

        }


    }
}
