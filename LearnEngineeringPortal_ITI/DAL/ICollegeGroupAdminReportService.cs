using Odishadtet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odishadtet.DAL
{
    public interface ICollegeGroupAdminReportService
    {
       
        //List<UserReadHistoryModel> UniversityReadHistorySummarySpilit(int DepartmentID, int collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType);

        //List<UserReadHistoryModel> UniversityReadHistorySummary(int DepartmentID, int collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType, int ITIorTrade);

        //List<UserReadHistoryModel> GetUserReadHistory(int userID, int univId, string college_id, string semester, string year, string reg_startdate, string reg_end_date, string usg_start_date, string usg_end_date);

        //List<UserReadHistoryModel> GetUserUsageReadHistory(int userID, int univId, string college_id, int deptid, string semester, string year, string reg_startdate, string reg_end_date, string usg_start_date, string usg_end_date);
            
        //List<UserReadHistoryModel> weeklywiseReport(int univId, string college_id, string semester, string year, string reg_startdate, string reg_end_date, string usg_start_date, string usg_end_date);

        //List<UserReadHistoryModel> UniversityReadHistory(int univId, string college_id, string semester, string year, string reg_startdate, string reg_end_date, string usg_start_date, string usg_end_date);

        //List<UserReadHistoryModel> UniversityReadHistory(int departmentID, string collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType);

        //JQGrid UniversityUserReadHistory(JqSearchIn si, int DepartId, string CollegeId);

        //List<UserReadHistoryModel> UniversityUsersReadHistory(int departmentID, int collegeID, int userId);

        //List<UserReadHistoryModel> subjectwiseReadHistory(int userID, int univId, string college_id, string semester, string year, string reg_startdate, string reg_end_date, string usg_start_date, string usg_end_date);

        //List<RegisteredUserUniversity> RegisteredUserUniversityDetails(int univId, string univ_code, string year, int semester, string startdate, string end_date);

        //List<UnivDetails> RegisteredUniversityCollegeDetails(string year, int semester, string start_date, string end_date, int universityId, int roleid);

    
        //List<RegisteredCollegeDetails> RegisteredUserCollegeDetails(string year, int semester, string start_Date, string end_Date, string universityId);

        //List<RegisteredDetails> RegisteredUserDetails(string year, int semester, string startDate, string endDate, int univId, int collegeId, int roleid);

        //RegistrationReport RegistrationReportsummary(int deptID, int collegeID, string DateFrom, string DateTo, int type);

       
        //List<RegistrationReport> RegistrationReportCollegesummary(int deptID, int collegeID, string DateFrom, string DateTo, int type);

       
       
        //List<RegistrationDetailsReport> RegistrationReportCollegeDetails(int category, int collegeid, int regtype, int deptID, string DateFrom, string DateTo);

        
        string WeeklyRegistration();

        string TotalUsage(int UnivId);

        string DailyRegistration();

        string MonthlysRegistration();
        
        string TotalRegistration(int UnivId);

        string TotalUsageITI(int? pUserId = 0, int? pCollegeId = 0);

        string TotalITIRegistration();

        string TotalITIRegistrationTest();

        string InstitutewiseUsagehrs(int? pUserId = 0, int? pCollegeId = 0);

        string HighestRegistered_ITI();

        string HighestRegisteredTrade();

        string DailyUsage(int? pUserId = 0, int? pCollegeId = 0);

        string WeeklyUsage(int? pUserId = 0, int? pCollegeId = 0);

        string MonthlyUsage(int? pUserId = 0, int? pCollegeId = 0);
        List<UserReadHistoryModel> GetTotalHoursUsageReadHistory(int userID, int univId, string college_id, int deptid, string semester, string year, string reg_startdate, string reg_end_date, string usg_start_date, string usg_end_date);

        List<UserReadHistoryModel> GetUserTotalHrsReadHistory(int userID, int univId, string college_id, string semester, string year, string reg_startdate, string reg_end_date, string usg_start_date, string usg_end_date);

        UserDashBoardViewModel DashBoardMain(int GroupLoginId);

        UseageDashBoardViewModel UsageDashBoard(int SubjectType);

        RegistrationDashBoardViewModel CollegeGroupRegistrationDashBoard(int CollegeGrpId ,int SubType);

        UseageDashBoardViewModel CollegeGroupUsageDashBoard(int SubjectType, int CollegeGrpId);

        UserDashBoardViewModel CollegeGroupDashBoardMain(int CollegeGrpId);

        List<Departmentdetails> GetGroupAdminDepartmentListActivitionextenddays(int univId, int collegeId,int CollegeGrpId);

        List<CollegeList> GetGroupAdminColleges(int departmentID,int CollegeGrpId);

        List<UserReadHistoryModel> UniversityGroupAdminReadHistorySummarySpilit(int CollegeGrpId,int DepartmentID, int collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType);

        List<UserReadHistoryModel> UniversityReadHistorySummary(int CollegeGrpId, int DepartmentID, int collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType, int ITIorTrade);

        RegistrationReport RegistrationReportsummary(int CollegeGrpId, int deptID, int collegeID, string DateFrom, string DateTo, int type);

        List<UnivDetails> RegisteredUniversityCollegeDetails(int CollegeGrpId, string year, int semester, string start_date, string end_date, int universityId, int roleid);

        List<RegistrationReport> RegistrationReportCollegesummary(int CollegeGrpId, int deptID, int collegeID, string DateFrom, string DateTo, int type);

        List<RegistrationDetailsReport> RegistrationReportCollegeDetails(int CollegeGrpId, int category, int collegeid, int regtype, int deptID, string DateFrom, string DateTo);

        List<UserReadHistoryModel> UniversityReadHistory(int CollegeGrpId, int departmentID, string collegeID, int SubjectID, int SemsterID, string DateFrom, string DateTo, int SubjectType);

        List<CollegeGroupModel> GetGroupCollesgesList();

        RegistrationDashBoardViewModel RegistrationDashBoardDatewiseCount(int CollegeGrpId, int SubjectType);


    }
}
