using System;
using System.Collections.Generic;
using System.Linq;
using Odishadtet.DAL;
using Odishadtet.General;

namespace LearnEngineeringPortalService_ITI.DataAccess
{
    public class UserMasterAccess
    {
        string PageName = "UserMasterAccess";
        /// <summary>
        /// Method for get all users
        /// </summary>
        /// <returns></returns>
        public List<user_master> GetAllUsers()
        {
            using (var DB = new learnengg_payment_portal_entities())
            {
                return DB.user_master.ToList();
            }
        }

        /// <summary>
        /// method for get all user otp codes
        /// </summary>
        /// <returns></returns>
        public List<user_random_pass> GetAllRandomCodes()
        {
            using (var DB = new learnengg_payment_portal_entities())
            {
                return DB.user_random_pass.ToList();
            }
        }

        public bool UpdatePassword(long userId, string password)
        {
            try
            {
                using (var DB = new learnengg_payment_portal_entities())
                {
                    var user = DB.user_master.FirstOrDefault(t => t.user_id == userId);
                    user.password = password;
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception Ex)
            {
                Log.WriteLogMessage(PageName, "UpdatePassword", "UpdatePassword", Ex.Message, "error");
                return false;
            }

        }

        public List<user_random_pass_college> GetAllRandomCodes_CollegeAdmin()
        {
            using (var DB = new learnengg_payment_portal_entities())
            {
                return DB.user_random_pass_college.ToList();
            }
        }


        public List<college_master> GetCollegeAdminUsers()
        {
            using (var DB = new learnengg_payment_portal_entities())
            {
                return DB.college_master.ToList();
            }
        }


       

        public bool UpdatePasswordCollegeAdmin(long collegeId, string password)
        {
            try
            {
                using (var DB = new learnengg_payment_portal_entities())
                {
                    var college = DB.college_master.FirstOrDefault(t => t.college_id == collegeId);
                    college.password = password;
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception Ex)
            {
                Log.WriteLogMessage(PageName, "UpdatePasswordCollegeAdmin", "UpdatePasswordCollegeAdmin", Ex.Message, "error");
                return false;
            }

        }

    }


}