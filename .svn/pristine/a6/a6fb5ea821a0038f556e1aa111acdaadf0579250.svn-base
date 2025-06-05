using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odishadtet.Models
{
    
    public class proLoginUserDefaultValues
    {
        LoginModels DBUtil = new LoginModels();
        public int loginUserID
        {
            get
            {
                var strUserID = DBUtil.GetValuesFromDefaultSession("loginUserID").ToString();
                return Convert.ToInt32(string.IsNullOrEmpty(strUserID) ? "0" : strUserID);
            }
            set { loginUserID = value; }
        }
        public string loginPassword
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginPassword").ToString(); }
            set { loginPassword = value; }
        }

        public string loginUserFullName
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginUserFullName").ToString(); }
            set { loginUserFullName = value; }
        }

        public string loginUserRoleID
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginUserRoleID").ToString(); }
            set { loginUserRoleID = value; }
        }

        public string loginUserRoleName
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginUserRoleName").ToString(); }
            set { loginUserRoleName = value; }
        }

        public string loginUserEmailID
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginUserEmailID").ToString(); }
            set { loginUserEmailID = value; }
        }

        public string loginUserMobileNumber
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginUserMobileNumber").ToString(); }
            set { loginUserMobileNumber = value; }
        }

        public string loginUserPhotoURL
        {
            get { return DBUtil.GetValuesFromDefaultSession("ProfileImage").ToString(); }
            set { loginUserPhotoURL = value; }
        }

        public Int32 loginUserDepartmentID
        {
            get { return Convert.ToInt32(DBUtil.GetValuesFromDefaultSession("loginUserDepartmentID").ToString()); }
            set { Convert.ToInt32(loginUserDepartmentID); }
        }

        public string loginUserDepartmentName
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginUserDepartmentName").ToString(); }
            set { loginUserDepartmentName = value; }
        }

        public Int32 loginUserUnivID
        {
            get { return Convert.ToInt32(DBUtil.GetValuesFromDefaultSession("loginUserUnivID").ToString()); }
            set { Convert.ToInt32(loginUserUnivID); }
        }

        public string loginUserUnivName
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginUserUnivName").ToString(); }
            set { loginUserUnivName = value; }
        }

        public Int32 loginUserCollegeID
        {
            get { return Convert.ToInt32(DBUtil.GetValuesFromDefaultSession("loginUserCollegeID").ToString()); }
            set { Convert.ToInt32(loginUserCollegeID); }
        }

        public string loginUserCollegeName
        {
            get { return DBUtil.GetValuesFromDefaultSession("loginUserCollegeName").ToString(); }
            set { loginUserCollegeName = value; }
        }
      

     
       
      

    }
}