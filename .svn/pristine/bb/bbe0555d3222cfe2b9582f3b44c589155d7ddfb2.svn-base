using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Odishadtet.DAL;
using Odishadtet.Models;

namespace TNDET.API_ITI_ServiceControllers
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [CustomeAPIAuthorization]
    public class APICollegeGroupAdminDashBoardReportsController : ApiController
    {
        static ICollegeGroupAdminReportService _AdminRepository;

        public APICollegeGroupAdminDashBoardReportsController(ICollegeGroupAdminReportService Productrepository)
        {
            if (Productrepository == null)
            {
                throw new ArgumentNullException("Productrepository");
            }

            _AdminRepository = Productrepository;
        }

        [HttpGet]
        public UserDashBoardViewModel GetUserDashBoardMain(int LoginId)
        {
           
            UserDashBoardViewModel UserDashBoardMain = _AdminRepository.DashBoardMain(LoginId);
            return UserDashBoardMain;
        }


        // Get: api/APIAdminDashBoardReports
        [HttpGet]
        public UseageDashBoardViewModel GetDashBoardViewData(int SubType = 1)
        {
            UseageDashBoardViewModel UserDashBoardMain = _AdminRepository.UsageDashBoard(SubType);
            return UserDashBoardMain;
        }


        // Get: api/APIAdminDashBoardReports
        [HttpGet]
        public RegistrationDashBoardViewModel GetCollegeGroupDashBoardRegistrationData(int CollegeGrpId, int SubType = 1)
        {
            RegistrationDashBoardViewModel RegistrationDashBoardMain = _AdminRepository.CollegeGroupRegistrationDashBoard(CollegeGrpId,SubType);
            return RegistrationDashBoardMain;
        }


        [HttpGet]
        public UseageDashBoardViewModel GetCollegeGroupDashBoardViewData(int CollegeGrpId, int SubType = 1)
        {
            UseageDashBoardViewModel UserDashBoardMain = _AdminRepository.CollegeGroupUsageDashBoard(SubType, CollegeGrpId);
            return UserDashBoardMain;
        }

        [HttpGet]
        public UserDashBoardViewModel GetCollegeGroupDashBoardMain(int CollegeGrpId)
        {
            UserDashBoardViewModel UserDashBoardMain = _AdminRepository.CollegeGroupDashBoardMain(CollegeGrpId);
            return UserDashBoardMain;
        }


        #region RegistrationReports For CollegeGroup

        /// <summary>
        /// Gets the group admin department list activitionextenddays.
        /// </summary>
        /// <param name="univId">The univ identifier.</param>
        /// <param name="collegeId">The college identifier.</param>
        /// <param name="CollegeGrpId">The college GRP identifier.</param>
        /// <returns></returns>
        public List<Departmentdetails> GetGroupAdminDepartmentListActivitionextenddays(int univId, int collegeId,int CollegeGrpId)
        {
            List<Departmentdetails> DepartmentListForAdminActivity = _AdminRepository.GetGroupAdminDepartmentListActivitionextenddays(univId, collegeId, CollegeGrpId);
            return DepartmentListForAdminActivity;
        }

        /// <summary>
        /// Gets the group admin colleges.
        /// </summary>
        /// <param name="departmentID">The department identifier.</param>
        /// <param name="CollegeGrpId">The college GRP identifier.</param>
        /// <returns></returns>
        public List<CollegeList> GetGroupAdminColleges(int departmentID, int CollegeGrpId)
        {
            List<CollegeList> collegelist = _AdminRepository.GetGroupAdminColleges(departmentID, CollegeGrpId);
            return collegelist;
        }
        #endregion


        #region Registration summary


        /// <summary>
        /// Universities the group admin read history summary spilit.
        /// </summary>
        /// <param name="CollegeGrpId">The college GRP identifier.</param>
        /// <param name="DepartmentID">The department identifier.</param>
        /// <param name="collegeID">The college identifier.</param>
        /// <param name="SubjectID">The subject identifier.</param>
        /// <param name="SemsterID">The semster identifier.</param>
        /// <param name="DateFrom">The date from.</param>
        /// <param name="DateTo">The date to.</param>
        /// <param name="SubjectType">Type of the subject.</param>
        /// <returns></returns>
        [HttpGet]
        public List<UserReadHistoryModel> UniversityGroupAdminReadHistorySummarySpilit(int CollegeGrpId,int DepartmentID, int collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType)
        {
            List<UserReadHistoryModel> univreadhistry = new List<UserReadHistoryModel>();

            univreadhistry = _AdminRepository.UniversityGroupAdminReadHistorySummarySpilit(CollegeGrpId,DepartmentID, collegeID, SubjectID, SemsterID, DateFrom, DateTo, SubjectType);

            return univreadhistry;
        }

        /// <summary>
        /// Universities the read history summary.
        /// </summary>
        /// <param name="CollegeGrpId">The college GRP identifier.</param>
        /// <param name="DepartmentID">The department identifier.</param>
        /// <param name="collegeID">The college identifier.</param>
        /// <param name="SubjectID">The subject identifier.</param>
        /// <param name="SemsterID">The semster identifier.</param>
        /// <param name="DateFrom">The date from.</param>
        /// <param name="DateTo">The date to.</param>
        /// <param name="SubjectType">Type of the subject.</param>
        /// <param name="FilterType">Type of the filter.</param>
        /// <returns></returns>
        [HttpGet]
        public List<UserReadHistoryModel> UniversityReadHistorySummary(int CollegeGrpId, int DepartmentID, int collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType, int FilterType)
        {
            List<UserReadHistoryModel> univreadhistry = new List<UserReadHistoryModel>();

            univreadhistry = _AdminRepository.UniversityReadHistorySummary(CollegeGrpId,DepartmentID, collegeID, SubjectID, SemsterID, DateFrom, DateTo, SubjectType, FilterType);

            return univreadhistry;
        }

        #endregion


        #region javascript reports studentRegistration

        [HttpGet]
        public RegistrationReport RegistrationReportsummary(int CollegeGrpId, int deptID, int collegeID, string DateFrom, string DateTo, int type)
        {
            RegistrationReport Rpt = new RegistrationReport();
            if (type == 2)
            {
              //  Rpt = _AdminRepository.RegistrationReportsummaryTestNew(deptID, collegeID, DateFrom, DateTo, type);
            }
            else
            {
                Rpt = _AdminRepository.RegistrationReportsummary(CollegeGrpId, deptID, collegeID, DateFrom, DateTo, type);
            }
            return Rpt;
        }


        [HttpGet]
        public List<UnivDetails> RegisteredUniversityCollegeDetails(int CollegeGrpId, string year, int semester, string start_date, string end_date, int universityId, int roleid)
        {
            List<UnivDetails> regUnivCollegedetails = _AdminRepository.RegisteredUniversityCollegeDetails(CollegeGrpId, year, semester, start_date, end_date, universityId, roleid);

            return regUnivCollegedetails;

        }

        [HttpGet]
        public List<RegistrationReport> RegistrationReportCollegesummary(int CollegeGrpId, int deptID, int collegeID, string DateFrom, string DateTo, int type)
        {
            List<RegistrationReport> Rpt = new List<RegistrationReport>();
            if (type == 2)
            {
             //   Rpt = _AdminRepository.RegistrationReportCollegesummaryTestNew(deptID, collegeID, DateFrom, DateTo, type);
            }
            else
            {
                Rpt = _AdminRepository.RegistrationReportCollegesummary( CollegeGrpId, deptID, collegeID, DateFrom, DateTo, type);
            }
            return Rpt;
        }


        [HttpGet]
        public List<RegistrationDetailsReport> RegistrationReportCollegeDetails(int CollegeGrpId, int category, int collegeid, int regtype, int deptID, string DateFrom, string DateTo)
        {
            List<RegistrationDetailsReport> Rpt = _AdminRepository.RegistrationReportCollegeDetails(CollegeGrpId, category, collegeid, regtype, deptID, DateFrom, DateTo);
            return Rpt;
        }
        #endregion



        #region userreadhistory 
        [HttpGet]
        public List<UserReadHistoryModel> UniversityReadHistory(int CollegeGrpId, int DepartmentID, string collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType)
        {
            List<UserReadHistoryModel> univreadhistry = _AdminRepository.UniversityReadHistory(CollegeGrpId, DepartmentID, collegeID, SubjectID, SemsterID, DateFrom, DateTo, SubjectType);

            return univreadhistry;
        }
        #endregion


        #region CollegeGroup
        public List<CollegeGroupModel> GetGroupCollegesList()
        {
            List<CollegeGroupModel> GroupCollesgesList = new List<CollegeGroupModel>();
            GroupCollesgesList = _AdminRepository.GetGroupCollesgesList();
            return GroupCollesgesList;
        }

        #endregion

        // Get: api/APIAdminDashBoardReports
        [HttpGet]
        public RegistrationDashBoardViewModel GetDashBoardDatewiseRegistrationData(int CollegeGrpId, int SubType = 1)
        {
            RegistrationDashBoardViewModel RegistrationDashBoardMain = _AdminRepository.RegistrationDashBoardDatewiseCount(CollegeGrpId, SubType);
            return RegistrationDashBoardMain;
        }


    }
}
