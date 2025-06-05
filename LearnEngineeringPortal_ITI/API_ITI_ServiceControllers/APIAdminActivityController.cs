using Odishadtet.DAL;
using Odishadtet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;


namespace Odishadtet.APIServiceControllers
{
    public class APIAdminActivityController : ApiController
    {
        static IAdminService _AdminRepository;

        public APIAdminActivityController(IAdminService Productrepository)
        {
            if (Productrepository == null)
            {
                throw new ArgumentNullException("Productrepository");
            }

            _AdminRepository = Productrepository;
        }

        public List<OpenOrdersDetails> GetOpenOrderDetails(string mapuniv)
        {
            List<OpenOrdersDetails> orders = _AdminRepository.GetOpenOrderDetails(mapuniv);

            return orders;
        }

        public List<AdminActivityModel> GetOrderDeliveryAddressDetails(int userid)
        {

            List<AdminActivityModel> DeliveryAddress = _AdminRepository.GetOrderDeliveryAddressDetails(userid);
            return DeliveryAddress;
        }

        public string UpdatePreparationOrderStatus(Preparationstaus obj)
        {

            string UpdatePreparationStatus = _AdminRepository.UpdatePreparationOrderStatus(obj.preperedBy, obj.orderRefNo, obj.comments, obj.preparaionstatus);

            return UpdatePreparationStatus;
        }


        public string UpdatedeliveryOrderStatus(Deliverystaus payment)
        {

            string UpdatePreparationStatus = _AdminRepository.UpdatedeliveryOrderStatus(payment.preperedBy, payment.orderRefNo, payment.comments, payment.Deliverystatus, payment.DeliverBy, payment.DeliveryOn, payment.CourierName, payment.Courierno, payment.CourierContactno, payment.CourierExpecteddeliverydays);

            return UpdatePreparationStatus;
        }


        public string UpdatePaymentOrderStatus(PaymentStatus delivery)
        {
            string UpdatePaymentStatus = _AdminRepository.UpdatePaymentOrderStatus(delivery.preperedBy, delivery.orderRefNo, delivery.paymentamt, delivery.Paymentstatus, delivery.user_subscribed_masterid, delivery.created_userid);

            return UpdatePaymentStatus;
        }

        public string UpdatePaymentRefundOrderStatus(paymentrefundstatus Paymentrefund)
        {
            string UpdatePaymentRefund = _AdminRepository.UpdatePaymentRefundOrderStatus(Paymentrefund.preperedBy, Paymentrefund.paymentrefundamt, Paymentrefund.Paymentrefundstatus, Paymentrefund.OrderRefNo);

            return UpdatePaymentRefund;
        }

        //[HttpGet]
        //public string GetExtendedDaysActivation(int userId, string subjectId, int extended_days, int sms, int email, int subjectid, string subjectcode, string subjectname, string Subjectversion, int userid, int departmentid, string subjectexpirydate, string subjectexpiryextensiondate, int subjectextensiondays, int activatedby)
        //{
        //    string ExtendedDaysActivations = _AdminRepository.ExtendedDaysActivation(userId, subjectId, extended_days, sms, email,subjectid,subjectcode,subjectname,Subjectversion,userid,departmentid,subjectexpirydate,subjectexpiryextensiondate,subjectextensiondays,activatedby);

        //    return ExtendedDaysActivations;
        //}


        [HttpGet]
        public string GetExtendedDaysActivation(int userId, string subjectId, int extended_days, int sms, int email)
        {
            string ExtendedDaysActivations = _AdminRepository.ExtendedDaysActivation(userId, subjectId, extended_days, sms, email);

            return ExtendedDaysActivations;
        }

        public List<UserSubjectDetails> GetUserDetailsForActivationExtendeddays(long MobileNo)
        {
            List<UserSubjectDetails> userdetailsExtendedDaysActivations = _AdminRepository.GetUserDetailsForActivationExtendeddays(MobileNo);

            return userdetailsExtendedDaysActivations;
        }


        public List<UserSubjectDetails> GetUserDetailsForSubjectActivation(long MobileNo)
        {
            List<UserSubjectDetails> userdetailsExtendedDaysActivations = _AdminRepository.GetUserDetailsForSubjectActivation(MobileNo);

            return userdetailsExtendedDaysActivations;
        }


        [HttpGet]
        public List<OpenOrdersDetails> OrderPrepartionDialog(string orderRefNo)
        {
            List<OpenOrdersDetails> ordersPopup = _AdminRepository.OrderPrepartionDialog(orderRefNo);

            return ordersPopup;
        }

        [HttpGet]
        public List<OrderDetails> OrderDetailsDialog(string orderRefNo)
        {
            List<OrderDetails> orders = _AdminRepository.OrderDetailsDialog(orderRefNo);

            return orders;
        }

        public string UpdateQualityCheck(Qcstatus obj)
        {
            string qcstatus = _AdminRepository.UpdateQualityCheckStatus(obj.preperedBy, obj.OrderRefNo, obj.Comments, obj.qc_status);

            return qcstatus;
        }


        // [HttpGet]
        //public string UpdatedeliveryOrderStatus(long preperedBy, string OrderRefNo, string Comments, int Preparaionstatus, string DeliverBy, string DeliveryOn, string CourierName, string Courierno, string CourierContactno, int CourierExpecteddeliverydays)
        //{

        //    string UpdatePreparationStatus = _AdminRepository.UpdatedeliveryOrderStatus(preperedBy,OrderRefNo,Comments,Preparaionstatus,DeliverBy,DeliveryOn,CourierName,Courierno,CourierContactno,CourierExpecteddeliverydays);

        //    return UpdatePreparationStatus;
        //}


        [HttpPost]
        public string SaveUserSubjectDetailsForActivation(savesubjectactivation subactivation)
        {
            string SaveUserSubjectDetailsForActivation = _AdminRepository.SaveUserSubjectDetailsForActivation(subactivation.subjectid, subactivation.subjectcode, subactivation.subjectname, subactivation.Subjectversion, subactivation.userid, subactivation.departmentid, subactivation.subjectexpirydate, Convert.ToDateTime(subactivation.subjectexpiryextensiondate), subactivation.subjectextensiondays, subactivation.activatedby);
            return SaveUserSubjectDetailsForActivation;
        }

        [HttpPost]
        public string SaveSubjectActivatedUserDetails(savesubjectactivation subactivation)
        {
            string SaveUserSubjectDetailsForActivation = _AdminRepository.SaveSubjectActivatedUserDetails(subactivation.subjectid, subactivation.subjectcode, subactivation.subjectname, subactivation.Subjectversion, subactivation.userid, subactivation.departmentid, subactivation.subjectexpirydate, Convert.ToDateTime(subactivation.subjectexpiryextensiondate), subactivation.subjectextensiondays, subactivation.activatedby);
            return SaveUserSubjectDetailsForActivation;
        }
        [HttpGet]
        public string InsertOrUpdateLicenseExtensionByAdmin(int pUserID, string pPackageIds, int pSubjectUnitType, int trialDays, int sms, int email, int activatedby)
        {
            string InsertOrUpdateLicense = _AdminRepository.InsertOrUpdateLicenseExtensionByAdmin(pUserID, pPackageIds, pSubjectUnitType, trialDays, sms, email, activatedby);
            return InsertOrUpdateLicense;
        }



        public List<UserSubjectDetails> GetAllUserSubjectDetails(long MobileNo)
        {
            List<UserSubjectDetails> AllUserSubjectDetail = _AdminRepository.GetAllUserSubjectDetails(MobileNo);
            return AllUserSubjectDetail;
        }

        public List<UserSubjectDetails> GetOverallSubjectDetails(long MobileNo, int departmentId, int year, int semester, int subjunitType)
        {
            List<UserSubjectDetails> AllUserSubjectDetail = _AdminRepository.GetOverallSubjectDetails(MobileNo, departmentId, year, semester, subjunitType);
            return AllUserSubjectDetail;
        }


        public List<UserSubjectDetails> GetUserSubjectDetails(long MobileNo, int univId, int departmentId, int year, int semester)
        {
            List<UserSubjectDetails> UserSubjectDetail = _AdminRepository.GetUserSubjectDetails(MobileNo, univId, departmentId, year, semester);
            return UserSubjectDetail;
        }



        public List<Departmentdetails> GetDepartmentListActivitionextenddays(int univId,int collegeId)
        {
            List<Departmentdetails> DepartmentListForAdminActivity = _AdminRepository.GetDepartmentListActivitionextenddays(univId,collegeId);
            return DepartmentListForAdminActivity;
        }

        public List<CollegeList> GetColleges(int CollegeGrpId = 0)
        {
            List<CollegeList> collegelist = _AdminRepository.GetColleges(CollegeGrpId);
            return collegelist;
        }

        public List<CollegeList> GetColleges(int departmentID, int CollegeGrpId = 0)
        {
            List<CollegeList> collegelist = _AdminRepository.GetColleges(departmentID, CollegeGrpId);
            return collegelist;
        }
        


        public List<SubjectList> GetSubjects(int departmentID, int collegeID)
        {
            List<SubjectList> collegelist = _AdminRepository.GetSubject(departmentID, collegeID);
            return collegelist;
        }

        public List<SemesterList> GetSemester(int departmentID, int collegeID)
        {
            List<SemesterList> collegelist = _AdminRepository.GetSemester(departmentID, collegeID);
            return collegelist;
        }

        public List<Departmentdetails> GetsemesterSubjectActivation(int univId)
        {
            List<Departmentdetails> yearsemesterorAdminActivity = _AdminRepository.GetsemesterSubjectActivation(univId);
            return yearsemesterorAdminActivity;
        }

        public List<AdminDateWiseSummary> GetDateWiseOrderSummary(string FromDate, string ToDate)
        {
            List<AdminDateWiseSummary> DateWiseOrderSummary = _AdminRepository.GetDateWiseOrderSummary(FromDate, ToDate);

            return DateWiseOrderSummary;
        }


        public List<Universitydetails> GetUniversityDetailsAdmin(string mapuniv)
        {
            List<Universitydetails> univdshboard = _AdminRepository.GetUniversityDetailsAdmin(mapuniv);

            return univdshboard;
        }

        [HttpGet]
        public List<AdminDashboard> AdminDashBoard(string mapuniv)
        {
            List<AdminDashboard> dshboard = _AdminRepository.AdminDashBoard(mapuniv);

            return dshboard;
        }

        [HttpGet]
        public List<AdminDashboard> OpenOrdersAdminDashBoard(string mapuniv)
        {
            List<AdminDashboard> OpenOrdersAdminDashBoard = _AdminRepository.OpenOrdersAdminDashBoard(mapuniv);

            return OpenOrdersAdminDashBoard;
        }

        [HttpGet]
        public List<AdminDashboard> LastweekOrdersAdminDashBoard(string mapuniv)
        {
            List<AdminDashboard> lastweekorder = _AdminRepository.LastweekOrdersAdminDashBoard(mapuniv);

            return lastweekorder;
        }

        [HttpPost]
        public List<checkLogin> VisitedUsersData(string mapuniv)
        {
            List<checkLogin> visitedusers = _AdminRepository.VisitedUersChart(mapuniv);

            return visitedusers;
        }

        public List<userSubjects> GetUserSubjectsDetails_Activation(string OrderID)
        {
            List<userSubjects> GetUserSubjects = _AdminRepository.GetUserSubjectsDetails_Activation(OrderID);
            return GetUserSubjects;
        }


        public List<Packagedetails_product> GetPackagedetails_productdetails(int univId, int DepartId, int Semester)
        {
            List<Packagedetails_product> productpackagedetails = _AdminRepository.GetPackagedetails_productdetails(univId, DepartId, Semester);

            return productpackagedetails;
        }


        public List<Semester_product> GetsemList_productdetails(int univId)
        {
            List<Semester_product> semlist = _AdminRepository.GetsemList_productdetails(univId);
            return semlist;
        }

        public List<keywords_longdesc_product> GetBindkewords_longDesc_productdetails(int packageid)
        {
            List<keywords_longdesc_product> quick_desc = _AdminRepository.GetBindkewords_longDesc_productdetails(packageid);

            return quick_desc;
        }



        public string Update_keyword_longDesc_productdetails(keywords_longdesc_product obj)
        {
            string updatekeywordDesc = _AdminRepository.Update_keyword_longDesc_productdetails(obj.Sessionuserid, obj.packageid, obj.PreviousKeywords, obj.CurrentKeywords, obj.PreviousDescription, obj.CurrentDescription);
            return updatekeywordDesc;
        }

        public singlePackagedetails GetSinglePackage(int PackageId)
        {

            singlePackagedetails SinglePackages = _AdminRepository.GetSinglePackage(PackageId);

            return SinglePackages;

        }

        public singlePackagedetails GetSinglePackagewithlogin(long UserId, int PackageId)
        {
            singlePackagedetails pckges = null;
            if (HttpContext.Current.Session["loginUserID"] != null)
            {
                pckges = _AdminRepository.GetSinglePackagewithlogin(Convert.ToInt64(HttpContext.Current.Session["loginUserID"].ToString()), PackageId);
            }

            //singlePackagedetails SinglePackageswithlogin = _AdminRepository.GetSinglePackagewithlogin(UserId, PackageId);
            return pckges;
        }

        public string GetCheckLoginDetails_Update_Keywords_Desc(string Password, int Sessionuserid)
        {
            string checklogin = _AdminRepository.CheckLoginDetails_Update_Keywords_Desc(Password, Sessionuserid);
            return checklogin;
        }

        public List<Departmentdetails> GetyearsemActivitionextenddays(int univId, int departmentId)
        {
            List<Departmentdetails> year = _AdminRepository.GetyearsemActivitionextenddays(univId, departmentId);

            return year;
        }

        public List<ActivationReport> GetSubjectActivationHistoryReport(int UniversityId)
        {
            List<ActivationReport> subjectactivation = _AdminRepository.SubjectActivationHistory_DateWise_Report(UniversityId);
            return subjectactivation;

        }

        public List<ActivationReport> GetSubjectActivationy_For_HistorReportDetails(int UnivId, string Date)
        {
            List<ActivationReport> subjectactivationdetails = _AdminRepository.SubjectActivationy_For_HistorReportDetails(UnivId, Date);
            return subjectactivationdetails;
        }

        public List<ActivationReport> GetSubjectActivation_By_HistoryReportDetails(int UnivId, string Date)
        {
            List<ActivationReport> subjectactivationdetails = _AdminRepository.SubjectActivation_By_HistoryReportDetails(UnivId, Date);
            return subjectactivationdetails;
        }


        public List<ActivationReport> GetSubjectActivationHistory_UniversityWise_Report()

        {
            List<ActivationReport> UniversityWise = _AdminRepository.SubjectActivationHistory_UniversityWise_Report();
            return UniversityWise;

        }

        [HttpGet]
        public List<dropdownloading> LoadSemesterDropdown(int departmentid)
        {
            List<dropdownloading> semester = _AdminRepository.LoadSemesterDropDown(departmentid);
            return semester;
        }

        [HttpGet]
        public List<dropdownloading> LoadUniversityDropdown()
        {
            List<dropdownloading> university = _AdminRepository.LoadUniversityDropdown();

            return university;
        }
        [HttpGet]
        public List<dropdownloading> LoadDepartmentDropdown(int universityId)
        {
            List<dropdownloading> department = _AdminRepository.LoadDepartmentDropdown(universityId);

            return department;
        }

        [HttpGet]
        public string LoadOtpcode(long Mobile)
        {
            string otpProcess = _AdminRepository.GetOTP(Mobile);

            return otpProcess;
        }

        [HttpGet]
        public string SubjectMasterUploadPopup(int selectedUniversity, int Department, int Semester, int Subjectid)
        {
            string subjectUpload = _AdminRepository.SubjectMasterUploadPopup(selectedUniversity, Department, Semester, Subjectid);

            return subjectUpload;
        }
        [HttpGet]
        public string SubjectMasterUploadGrid(int selectedUniversity, int Department, int Semester, int Subjectid)
        {
            string subjectUploadGrid = _AdminRepository.SubjectMasterUploadGrid(selectedUniversity, Department, Semester, Subjectid);

            return subjectUploadGrid;
        }

        

        [HttpGet]
        public FeedbackArchieveViewModel GetArchiveFeedbacks()
        {
            FeedbackArchieveViewModel feedback = _AdminRepository.GetArchiveFeedbacks();

            return feedback;
        }
        [HttpGet]
        public List<datewisereport> GetDateWise_user_Registration_reports(string start_date, string End_date)
        {
            List<datewisereport> datewisereports = _AdminRepository.GetDateWise_user_Registration_report(start_date, End_date);

            return datewisereports;
        }


        public List<datewisereport> GetDateWise_user_Registration_report_InitialGrid()
        {
            List<datewisereport> datewisereports_grid = _AdminRepository.DateWise_user_Registration_report_InitialGrid();
            return datewisereports_grid;

        }

        public List<datewisereport_Issues> GetDateWise_user_Registration_report_Issues_popup(string PDate)
        {
            List<datewisereport_Issues> DateWise_Issues_popup = _AdminRepository.DateWise_user_Registration_report_Issues_popup(PDate);
            return DateWise_Issues_popup;
        }

        public List<datewisereport> GetUniversity_user_Registration_report_InitialGrid()
       {
            List<datewisereport> universityWise_Reg_report = _AdminRepository.University_user_Registration_report_InitialGrid();
            return universityWise_Reg_report;
        }

        public List<datewisereport> GetUniversity_Datewise_user_Registration_report_InitialGrid(int UnivId)
        {
            List<datewisereport> Univ_datewiser_report = _AdminRepository.University_Datewise_user_Registration_report_InitialGrid(UnivId);
            return Univ_datewiser_report;
        }

        public List<datewisereport> GetUniversity_SemWise_user_Registration_report_Excel(string start_date, string End_date)
        {
            List<datewisereport> Univ_sem_wise_report_Ecel = _AdminRepository.University_SemWise_user_Registration_report_Excel(start_date,End_date);
            return Univ_sem_wise_report_Ecel;
        }

        public List<datewisereport_Issues> GetUniv_DateWise_user_Registration_report_Issues_popup(string PDate, int UnivId)
        {
            List<datewisereport_Issues> univ_date_wise_popup =_AdminRepository.Univ_DateWise_user_Registration_report_Issues_popup(PDate, UnivId);
            return univ_date_wise_popup;
        }
        [HttpGet]
        public string InsertCollegeInstitute(int pCollege_id,  string pInstallationCentreName, string pPrimaryMac, int pEnterby)
        {
            string result = _AdminRepository.InsertCollegeInstitute(pCollege_id,  pInstallationCentreName, pPrimaryMac, pEnterby);
            return result;
        }


        [HttpGet]
        public string InsertCollegeTestInstitute(int pCollege_id, string pInstallationCentreName, string pPrimaryMac, int pEnterby)
        {
            string result = _AdminRepository.InsertCollegeTestInstitute(pCollege_id, pInstallationCentreName, pPrimaryMac, pEnterby);
            return result;
        }

        [HttpGet]
        public string sendOtp_VerifyCollege(int collegeId,long pMobileNo,string emailId,int isSendorResend)
        {
            string result = _AdminRepository.sendOtp_VerifyCollege(collegeId,pMobileNo, emailId, isSendorResend);
            return result;
        }
        [HttpGet]
        public string verifyOtp_updateCollegePassword(int collegeId, string OTP, string pPassword)
        {
            string result = _AdminRepository.verifyOtp_updateCollegePassword(collegeId, OTP, pPassword);
            return result;
        }
        [HttpGet]
        public string checkCollegeLogin(string loginID, string Password)
        {
            string gLoginDetailes  = _AdminRepository.CheckCollegeLogin(loginID, Password);
            
            return gLoginDetailes;
        }
        [HttpGet]
        public string GetCollegeList()
        {
            string collegeList = _AdminRepository.GetCollegeList();

            return collegeList;
        }
        [HttpGet]
        public string GetDepartmentList()
        {
            string departmentList = _AdminRepository.GetDepartmentList();

            return departmentList;
        }
        [HttpGet]
        public string getServerDate()
        {
           string serverDate = _AdminRepository.getServerDate();

            return serverDate;
        }
        [HttpGet]
        public string GetUserIP()
        {
            string userIP = _AdminRepository.GetUserIP();

            return userIP;
        }
        [HttpGet]
        public string getCollegeSubjectExpiryDetails(int collegeId, string primaryMac)
        {
            string collegeSubjectExpiry = _AdminRepository.getCollegeSubjectExpiryDetails(collegeId, primaryMac);
            return collegeSubjectExpiry;
        }


        [HttpGet]
        public string getCollegeSubjectTestExpiryDetails(int collegeId, string primaryMac)
        {
            string collegeSubjectExpiry = _AdminRepository.getCollegeTestSubjectExpiryDetails(collegeId, primaryMac);
            return collegeSubjectExpiry;
        }

        [HttpGet]
        public string updateCollegeInstallOn(int collegeId, string primaryMac, int departmentID)
        {

            string resUpdate = _AdminRepository.updateCollegeInstallOn(collegeId, primaryMac, departmentID);
            return resUpdate;
        }
         


        #region User(Institutor) Process
        [HttpGet]
        public string GetUserid(long MobNo, string emailID)
        {
            string userID = _AdminRepository.GetUserid(MobNo,  emailID);
            return userID;
        }
        [HttpGet]
        public string SaveRegistrationWithReference(string userName, string password, string emailId, long mobileNo, int collegeid, string collegeName)
        {
            string saveUser = _AdminRepository.SaveRegistrationWithReference(userName,  password,  emailId,  mobileNo,  collegeid,  collegeName);
            return saveUser;
        }
        [HttpGet]
        public int GetVerificationCodeByMobile(long pMobileNo, string pEmailID, int isSendorResend) {
            int userVerification = _AdminRepository.GetVerificationCodeByMobile(pMobileNo, pEmailID, isSendorResend);
            return userVerification;
        }
        [HttpGet]
        public string RandomCodeVerification(int userId, string verifyCode)
        {
            string otpVerify = _AdminRepository.RandomCodeVerification(userId, verifyCode);
            return otpVerify;
        }
        [HttpGet]
        public string CheckLoginDetail(string loginID, string Password)
        {
            string userDetails = _AdminRepository.CheckLoginDetail(loginID, Password);
            return userDetails;
        }
        #endregion



        // password change

        [HttpGet]
        public string getforgetPasswords(long mobileNo)
        {
            string gLoginDetailes = _AdminRepository.ForgetPassword(Convert.ToInt64(mobileNo));
            return gLoginDetailes;
        }
        [HttpGet]
        public string getforgetCollegeAdminPasswords(long mobileNo)
        {
            string gLoginDetailes = _AdminRepository.ForgetPasswordCollegeAdmin(Convert.ToInt64(mobileNo));
            return gLoginDetailes;
        }


        [HttpGet]
        public string GetResetPasswords(long mobileNo, string otpCode, string newPassword)
        {

            string gResetPassword = _AdminRepository.ResetPassword(mobileNo, otpCode, newPassword);

            return gResetPassword;
        }
        [HttpGet]
        public string GetResetPasswordsCollegeAdmin(long mobileNo, string otpCode, string newPassword)
        {

            string gResetPassword = _AdminRepository.ResetPasswordCollegeAdmin(mobileNo, otpCode, newPassword);

            return gResetPassword;

        }



        [HttpGet]
        public string getforgetPasswordsEmail(string Email)
        {
            string gLoginDetailes = _AdminRepository.ForgetPasswordEmail(Email);
            return gLoginDetailes;
        }
        [HttpGet]
        public string getforgetCollegeAdminPasswordsEmail(string Email)
        {
            string gLoginDetailes = _AdminRepository.ForgetPasswordCollegeAdminEmail(Email);
            return gLoginDetailes;
        }


        [HttpGet]
        public string GetResetPasswordsEmail(string Email, string otpCode, string newPassword)
        {

            string gResetPassword = _AdminRepository.ResetPasswordEmail(Email, otpCode, newPassword);

            return gResetPassword;
        }
        [HttpGet]
        public string GetResetPasswordsCollegeAdminEmail(string Email, string otpCode, string newPassword)
        {

            string gResetPassword = _AdminRepository.ResetPasswordCollegeAdminEmail(Email, otpCode, newPassword);

            return gResetPassword;

        }

        [HttpGet]
        public List<TradeSubjects> GetCollegeNotMappedTrades(int collegeId)
        {
            List<TradeSubjects> lTradeSubjects = _AdminRepository.GetCollegeNotMappedTrades(collegeId);

            return lTradeSubjects;
        }
        [HttpGet]
        public string SaveCollegeTradeMapping(int pCollegeId, string pMapTrades, int pTotalLicense, int pDurationDays, int pCreatedBy)
        {
            string result = _AdminRepository.SaveCollegeTradeMapping(pCollegeId, pMapTrades, pTotalLicense, pDurationDays, pCreatedBy);

            return result;
        }
        [HttpGet]
        public List<TradeSubjects> GetCollegeMappedTrades(int collegeId)
        {
            List<TradeSubjects> lTradeSubjects = _AdminRepository.GetCollegeMappedTrades(collegeId);

            return lTradeSubjects;
        }
        /// <summary>
        /// Gets the college administrators.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CollegeModel> GetCollegeAdministrators(int pcollege_group_id)
        {
            List<CollegeModel> CM = new List<CollegeModel>();
            CM = _AdminRepository.GetCollegeAdministrators(pcollege_group_id);
            return CM;
        }


        [HttpGet]
        public string RemoveCollegeTradeMapping(int pCollegeId, string pMapTrades)
        {
            string result = _AdminRepository.RemoveCollegeTradeMapping(pCollegeId, pMapTrades);

            return result;
        }
        [HttpGet]
        public string EditCollegeTradeMapping(int pCollegeId, string pMapTrades, int pTotalLicense, int pDurationDays, int pCreatedBy)
        {
            string result = _AdminRepository.EditCollegeTradeMapping(pCollegeId, pMapTrades, pTotalLicense, pDurationDays, pCreatedBy);

            return result;
        }

        [HttpGet]
        public string RemoveTradeSemesterLicense(int pCollegeId, string pPrimaryMac, string pDepartmentSemester)
        {
            string resDelete = _AdminRepository.RemoveTradeSemesterLicense(pCollegeId, pPrimaryMac, pDepartmentSemester);
            return resDelete;
        }
        [HttpGet]
        public string getCollegeTotalLicenseDetails(int collegeId)
        {
            string totalLicenseList = _AdminRepository.getCollegeTotalLicenseDetails(collegeId);
            return totalLicenseList;
        }

        [HttpGet]
        public string SaveCollegeTradeSemSubjects(int pCollegeId, string pPrimaryMac, string pDepartmentIdSemester)
        {
            string result = _AdminRepository.SaveCollegeTradeSemSubjects(pCollegeId, pPrimaryMac, pDepartmentIdSemester);
            return result;
        }


        //[HttpGet]
        //public string SaveCollegeTradeSemSubjectDetails(int pCollegeId, string pPrimaryMac, int pDepartmentId, int pSemester)
        //{
        //    string result = _AdminRepository.SaveCollegeTradeSemSubjectDetails(pCollegeId, pPrimaryMac, pDepartmentId, pSemester);
        //    return result;
        //}

        [HttpGet]
        public string GetSampleMail(string pEmailId)
        {
            string result = _AdminRepository.SampleMail(pEmailId);
            return result;
        }
    }
}
