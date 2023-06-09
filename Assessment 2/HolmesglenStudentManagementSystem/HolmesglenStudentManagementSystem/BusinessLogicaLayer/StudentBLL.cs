using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolmesglenStudentManagementSystem.BusinessLogicaLayer
{
    internal class StudentBLL
    {

        private StudentDAL StudentDALInstance;
        public StudentBLL(StudentDAL studentDALInstance)
        {
            StudentDALInstance = studentDALInstance;
        }

        public List<Student> GetAll()
        {
            return StudentDALInstance.ReadAll();
        }
    }   

}

