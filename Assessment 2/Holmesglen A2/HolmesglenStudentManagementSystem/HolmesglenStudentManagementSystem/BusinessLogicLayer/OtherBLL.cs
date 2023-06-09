using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class OtherBLL
    {
        AppDAL appDAL;
        public OtherBLL()
        {
            appDAL = new AppDAL();
        }
        

        public string EnrollmentsReport()
        {
            return appDAL.OtherDBQueryDALInstance.EnrollmentsReport();
        }


        public string EmailEnrollments(string id)
        {
            return appDAL.OtherDBQueryDALInstance.EmailEnrollments(id);
        }

    

    }




}

