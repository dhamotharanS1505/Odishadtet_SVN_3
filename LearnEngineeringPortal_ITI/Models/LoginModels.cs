using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Odishadtet.DAL;
using Odishadtet.Models;
using LearnEngineeringPortalService_ITI;
using System.Web.Script.Serialization;
using System.Net;

namespace Odishadtet.Models
{

    public class LoginModels
    {
        public object GetValuesFromDefaultSession(string keyName)
        {
            object returnValue = String.Empty;
            try
            {
            returnValue = HttpContext.Current.Session[keyName];
            }
            catch
            {
                //throw;
            }
            return returnValue;
        }
      



        public static void SaveUserSessionDetails(checkLogin cl)
        {

            if (cl.userId > 0)
            {
                HttpContext.Current.Session["loginUniversityID"] = cl.universityId;
                HttpContext.Current.Session["loginUserID"] = cl.userId;
                HttpContext.Current.Session["loginUserRoleID"] = cl.roleTypeId;
                HttpContext.Current.Session["loginUserRoledescription"] = cl.roleType;
                HttpContext.Current.Session["loginUserFullName"] = cl.FirstName;
                HttpContext.Current.Session["loginUserDepartmentID"] = cl.DepartmentID;
                HttpContext.Current.Session["loginUserEmailID"] = cl.emailId;
                HttpContext.Current.Session["loginUserMobileNumber"] = cl.mobileNumber;
                HttpContext.Current.Session["ProfileImage"] = cl.ProfileImage;
                HttpContext.Current.Session["loginyear"] = cl.year;
                HttpContext.Current.Session["loginsemester"] = cl.semester;
                HttpContext.Current.Session["ServerDate"] = cl.currentDate;
                HttpContext.Current.Session["loginUniversity_Type"] = cl.Univ_Type;
                HttpContext.Current.Session["MappedUniversities"] = cl.privilegeuniversities;
                HttpContext.Current.Session["CollegeID"] = cl.CollegeID;
                HttpContext.Current.Session["RoleLevel"] = cl.roleLevel;
                HttpContext.Current.Session["logincollegegrpId"] = cl.collegegrpId;
                



            }
        }


        public static void StudentSaveUserSessionDetails(StudentcheckLogin cl)
        {

            if (cl.userId > 0)
            {
                HttpContext.Current.Session["loginUniversityID"] = cl.universityId;
                HttpContext.Current.Session["stdloginUserID"] = cl.userId;
                HttpContext.Current.Session["stdloginUserRoleID"] = cl.roleTypeId;
                HttpContext.Current.Session["loginUserRoledescription"] = cl.roleType;
                HttpContext.Current.Session["loginUserFullName"] = cl.FirstName;
                HttpContext.Current.Session["loginUserDepartmentID"] = cl.DepartmentID;
                HttpContext.Current.Session["loginUserEmailID"] = cl.emailId;
                HttpContext.Current.Session["loginUserMobileNumber"] = cl.mobileNumber;
                HttpContext.Current.Session["ProfileImage"] = cl.ProfileImage;
                HttpContext.Current.Session["loginyear"] = cl.year;
                HttpContext.Current.Session["loginsemester"] = cl.semester;
                HttpContext.Current.Session["ServerDate"] = cl.currentDate;
                HttpContext.Current.Session["loginUniversity_Type"] = cl.Univ_Type;
                HttpContext.Current.Session["MappedUniversities"] = cl.privilegeuniversities;
                HttpContext.Current.Session["CollegeID"] = cl.CollegeID;
                HttpContext.Current.Session["RoleLevel"] = cl.roleLevel;
                HttpContext.Current.Session["logincollegegrpId"] = cl.collegegrpId;
                HttpContext.Current.Session["loginUserdob"] = cl.strdob;
                HttpContext.Current.Session["loginUserroll_no"] = cl.roll_no;
                HttpContext.Current.Session["loginUserDepartmentName"] = cl.DepartmentName;

                HttpContext.Current.Session["loginUserCollegeName"] = cl.CollegeName;
                HttpContext.Current.Session["loginUserAcademicYear"] = cl.AcademicYear;
                HttpContext.Current.Session["loginUserCourseType"] = cl.CourseType;
                HttpContext.Current.Session["loginUserUserRoletype"] = cl.roleType;


            }
        }


        public static string SplitDataFromJsonArray(string JsonArray)
        {
            string findData = "";
            int startingindex = 0, EndingIndex = 0;
            startingindex = JsonArray.IndexOf("[");
            EndingIndex = JsonArray.IndexOf("]");
            findData = JsonArray.Substring(startingindex, (EndingIndex - startingindex) + 1);
            return findData;
        }


        public static JQGrid LoadDemoSubscriberReport(JqSearchIn si)
        {
            List<DemoSubscription> objSourceDataListToDeSerialize = new List<DemoSubscription>();

            try
            {
                si = si.InitialiseObject(si);
                WebClient web = new WebClient();
                WebRequest request = WebRequest.Create(ConfigurationManager.AppSettings["localhost_server"] + "/AdminService.svc/AdminService/DemoSubscriptionReport");
                WebResponse response = request.GetResponse();

                var encoding = ASCIIEncoding.ASCII;


                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                {
                    string JSONdata = reader.ReadToEnd();

                    JavaScriptSerializer objJSSerializer = new JavaScriptSerializer();
                    objSourceDataListToDeSerialize = objJSSerializer.Deserialize<List<DemoSubscription>>(SplitDataFromJsonArray(JSONdata));

                }
                if (!string.IsNullOrEmpty(si.whereString))
                {
                    objSourceDataListToDeSerialize = objSourceDataListToDeSerialize.AsQueryable().Where(si.whereString).OrderBy(si.ShortingQuery).ToList();

                }
                else
                {
                    objSourceDataListToDeSerialize = objSourceDataListToDeSerialize.AsQueryable().OrderBy(si.ShortingQuery).ToList();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

            var Data = si.SetObjectListDataInitialise(objSourceDataListToDeSerialize, si);

            var GridData = new JQGrid
            {
                total = si.totalPages,
                page = si.page,
                records = si.TotalRecCount,
                rows = (
                 from client in Data
                 select new
                 {
                     i = client.SubscriberName,
                     cell = new string[] {
                         client.SubscriberName,
                         client.SubscriberCollege,
                          client.SubscriberEmail,
                         client. MobileNumber,
                         client.SubscribeDate,
                        client.SubscriberCountry,
                         client.SubscriberRegion,
                         client.SubscriberCity
                     }
                 }).ToArray()
            };
            return GridData;
        }


    }

    public class DemoSubscription
    {
        public string SubscriberName { get; set; }
        public string SubscriberCollege { get; set; }
        public string SubscriberEmail { get; set; }
        public string MobileNumber { get; set; }
        public string SubscribeDate { get; set; }
        public string SubscriberCountry { get; set; }
        public string SubscriberRegion { get; set; }
        public string SubscriberCity { get; set; }
        public Int64 SubscribeDateNumber { get; set; }

    }
}