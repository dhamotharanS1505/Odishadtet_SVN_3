using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Odishadtet.DAL;
using Odishadtet.Models;

namespace Odishadtet.APIServiceControllers
{

    public class APIProductHomeController : ApiController
    {

        static IProductService _Productrepository;

        public APIProductHomeController(IProductService Productrepository)
        {
            if (Productrepository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _Productrepository = Productrepository;
        }

        /// <summary>
        /// Gets the departments list.
        /// </summary>
        /// <returns></returns>
        public List<Departmentdetails> GetDepartmentsList()
        {
            List<Departmentdetails> gDepart = _Productrepository.GetDepartmentDetails();

            return gDepart;
        }


        /// <summary>
        /// Gets the subject details.
        /// </summary>
        /// <param name="departmentID">The department identifier.</param>
        /// <returns></returns>
        public List<SubjectDetails> GetSubjectDetails(int departmentID)
        {
            List<SubjectDetails> subjects = _Productrepository.GetSubjectDetails(departmentID);

            return subjects;
        }


        /// <summary>
        /// Gets the package details.
        /// </summary>
        /// <param name="departId">The depart identifier.</param>
        /// <param name="subjectid">The subjectid.</param>
        /// <returns></returns>
        public List<Packagedetails> GetPackageDetails(int departId, long subjectid)
        {
            List<Packagedetails> packages = _Productrepository.GetPackageDetails(departId, subjectid);

            return packages;
        }

        /// <summary>
        /// Gets the university details.
        /// </summary>
        /// <param name="univtype">The univtype.</param>
        /// <param name="loginUserid">The login userid.</param>
        /// <returns></returns>
        public List<Universitydetails> GetUniversityDetails(int univtype, int loginUserid)
        {
            List<Universitydetails> university = _Productrepository.GetUniversityDetails(univtype,loginUserid);

            return university;
        }


        /// <summary>
        /// Gets the university details.
        /// </summary>
        /// <returns></returns>
        public List<Universitydetails> GetUniversityDetails()
        {
            List<Universitydetails> univdshboard = _Productrepository.GetUniversityDetails();

            return univdshboard;
        }


        /// <summary>
        /// Gets the package details.
        /// </summary>
        /// <param name="univId">The univ identifier.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="univtype">The univtype.</param>
        /// <returns></returns>
        public List<Packagedetails> GetPackageDetails(int univId, int departmentId, int userId, int univtype)
        {
            List<Packagedetails> deptPackages = _Productrepository.GetPackageDetails(univId, departmentId, userId, univtype);

            return deptPackages;
        }

        public List<Departmentdetails> GetDepartmentList(int univId, int univtype)
        {
            List<Departmentdetails> departments = _Productrepository.GetDepartmentList(univId, univtype);

            return departments;
        }

        public List<Semester_Regulation> GetSemester(int univId, int univType)
        {
            List<Semester_Regulation> semeter = _Productrepository.GetSemester(univId, univType);

            return semeter;
        }

        public List<Semester_Regulation> GetRegulation(int univ_id)
        {
            List<Semester_Regulation> regulation = _Productrepository.GetRegulation(univ_id);

            return regulation;
        }

        [HttpGet]
        public List<Universitydetails> UnivTypeUniversityId(int univType)
        {
            List<Universitydetails> univTypeId = _Productrepository.GetUniversityId_UnivType(univType);

            return univTypeId;
        }
        [HttpGet]
        public List<Packagedetails> GetPacakages(int departId, long subjectid)
        {
            List<Packagedetails> pack = _Productrepository.GetPackages(departId, subjectid);

            return pack;
        }

        [HttpGet]
        public string SaveMasterCopyUsageDetails(string userName , string emailId, long mobile, string departmentName, int semester)
        {
            string result = "0";

            result = _Productrepository.SaveUserDetailsForMasterCopyUsage(userName, emailId, mobile, departmentName, semester);

            return result;
        }


        [HttpGet]
        public string VerifyUsageOTPDetails(long mastercopy_usage_id, string OTPCode)
        {
            string result = "0";

            result = _Productrepository.Registration_OTPConformation(mastercopy_usage_id,  OTPCode);

            return result; 
        }

        [HttpGet]
        public string ResendOTPDetails(long mastercopy_usage_id)
        {
            string result = "0";

            result = _Productrepository.Registration_ReSendOTP(mastercopy_usage_id);

            return result;
        }
    }
}
