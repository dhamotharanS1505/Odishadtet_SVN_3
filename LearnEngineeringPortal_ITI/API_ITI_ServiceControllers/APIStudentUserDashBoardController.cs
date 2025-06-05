
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Odishadtet.DAL;
using Odishadtet.Models;

namespace Odishadtet.APIServiceControllers
{
    public class APIStudentUserDashBoardController : ApiController
    {

        static IStudentUserService _repository;

        public APIStudentUserDashBoardController(IStudentUserService repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }
        // GET: api/APIUserDashBoard
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/APIUserDashBoard/5
        public string Get(int id)
        {
            return "value";
        }

        public string Getinsertpackageusercarts(int UserId, string PackageId)
        {
            string ginsertusercart = _repository.InsertPackageToUserCart(UserId, PackageId);

            return ginsertusercart;
        }


        public string GetInsertToUserWishLists(int UserId, int PackageId)
        {
            string ginsertuserwish = _repository.InsertToUserWishList(UserId, PackageId);

            return ginsertuserwish;

        }

        public List<userViewCart> GetViewCart(int UserId)
        {
            List<userViewCart> gViewCart = _repository.GetViewCartDetails(UserId);

            return gViewCart;
        }


        public List<purchasedSubjects> GetUserPurchasedSubjectsDetails(int UserId)
        {
            List<purchasedSubjects> gPurchasedsubject = _repository.GetUserPurchasedSubjects(UserId);

            return gPurchasedsubject;
        }

        public int GetViewCartCount(int UserId)
        {
            int viewCartCount = _repository.GetViewCartCount(UserId);
            return viewCartCount;
        }

        public List<wishList> GetMyWishListDetails(int UserId)
        {
            List<wishList> gwishLists = _repository.GetMyWishList(UserId);

            return gwishLists;
        }

        public string GetSaveNewUserDetails(string UserName, int Department, int University, int College, int year, int Semester, string Email, long Mobile)
        {

            string gSaveNewUserDetails = _repository.SaveNewUserDetails(UserName, Department, University, College, year, Semester, Email, Mobile);

            return gSaveNewUserDetails;

        }

        public string GetCreateActivationCode(Int64 user_subscribed_masterid, Int64 created_userid)
        {
            string CreateActivationCoderesult = _repository.CreateActivationCode(user_subscribed_masterid, created_userid);
            return CreateActivationCoderesult;
        }


        //public List<checkLogin> LoginValidation(string LoginUserID, string LoginPassword)
        //{
        //    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

        //    List<checkLogin> gLoginDetailes = jsSerializer.Deserialize<List<checkLogin>>(_repository.CheckLoginDetails(LoginUserID, LoginPassword));

        //    return gLoginDetailes;
        //}


        public string GetChangePasswords(long mobileNum, string currPasswrd)
        {

            string gChangePassword = _repository.ChangePassword(mobileNum, currPasswrd);

            return gChangePassword;

        }


        //public string GetUserProfileImages(int UserID)
        //{

        //    string gUserProfileImage = _repository.GetUserProfileImage(UserID);

        //    return gUserProfileImage;

        //}

        //public string GetUpdateContactDetailss(int userid, long mobile, string emailId)
        //{

        //    string gUpdateContactDetails = _repository.UpdateContactDetails(userid, mobile, emailId);

        //    return gUpdateContactDetails;

        //}


        public ForgetPasswordModel GetResetPasswords(long mobileNo, string otpCode, string newPassword)
        {

            ForgetPasswordModel gResetPassword = _repository.ResetPassword(mobileNo, otpCode, newPassword);

            return gResetPassword;

        }

        //public ForgetPasswordModel GetForgetPasswords(long mobileNo)
        //{

        //    ForgetPasswordModel gForgetPassword = _repository.ForgetPassword(mobileNo);

        //    return gForgetPassword;

        //}

        public int GetVerificationCodeByMobile(long MobNo, string emailID)
        {

            int gVerificationCodeByMobile = _repository.GetVerificationCodeByMobile(MobNo, emailID);

            return gVerificationCodeByMobile;

        }


        public int GetRefundVerificationCodeByMobile(long MobNo, string emailID)
        {

            int gVerificationCodeByMobile = _repository.GetVerificationCodeByMobileForRefundProcess(MobNo, emailID);

            return gVerificationCodeByMobile;

        }


        public List<Dashboard> GetStudentDashBoard(int userid)
        {
            List<Dashboard> dashboard = _repository.UserDashboardDetails(userid);

            return dashboard;
        }

        public string GetCOD_Conformation(long buyer_mobileNo, string ToEmailID)
        {
            string codconformation = _repository.COD_Conformation(buyer_mobileNo, ToEmailID);

            return codconformation;
        }

        public string GetOTP_CodeVerification(int userId, string otpCode)
        {
            string otpverify = _repository.OTP_CodeVerification(userId, otpCode);

            return otpverify;
        }

        public string GetCOD_Cancellation(long buyer_mobileNo, string ToEmailID, string OrderID)
        {
            string sendotp = _repository.COD_Cancellation(buyer_mobileNo, ToEmailID, OrderID);

            return sendotp;
        }

        public string GetCOD_Cancellation_approved(long buyer_mobileNo, string ToEmailID, string OrderID)
        {
            string submitotp = _repository.COD_Cancellation_approved(buyer_mobileNo, ToEmailID, OrderID);

            return submitotp;
        }

        public List<UserRegistraion> GetLoadCollegeList(int univId)
        {
            var collegeList = _repository.LoadCollegeList(univId);

            return collegeList;
        }
        public List<UserRegistraion> GetLoadDepartmentList(int univId)
        {
            var departList = _repository.LoadDepartmentList(univId);

            return departList;
        }

        public List<yearsemOnDeptID> GetYearSemesterByDepartID(int PDepartID)
        {
            var yearsem = _repository.GetYearSemesterByDepartID(PDepartID);
            return yearsem;
        }

        //Cancel order otp

        //public string GetCOD_Cancellation(long buyer_mobileNo, string ToEmailID, string OrderID)
        //{
        //    string COD_Cancellations = _repository.COD_Cancellation(buyer_mobileNo, ToEmailID, OrderID);

        //}

        public string GetProfileUpdateOTPCode(string MobNo, int userId)
        {
            string profileotp = _repository.GetProfileUpdateOTPCode(MobNo, userId);

            return profileotp;
        }


        // POST: api/APIUserDashBoard
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APIUserDashBoard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APIUserDashBoard/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public List<QPAndroidApp> QustionAnsAndroidApp(int universityId, int userId)
        {
            List<QPAndroidApp> androidapp = _repository.QustionAnsAndroidApp(universityId, userId);

            return androidapp;
        }

        public List<UserDetails> GetUserDetails(int studentId)
        {
            List<UserDetails> userdetails = _repository.GetUserDetails(studentId);
            return userdetails;
        }

        public string GetUpdateUserProfileImage(Int64 UserID, string ImageName)
        {
            string updateuserprofileimg = _repository.UpdateUserProfileImage(UserID, ImageName);
            return updateuserprofileimg;

        }
        [HttpGet]
        public string UpdateUserDetails(int userid, string userName, int deptId, string deptName, int year, int sem, string collegeName, int collegeId)
        {
            string updateuser = _repository.UpdateUserDetails(userid, userName, deptId, deptName, year, sem, collegeName, collegeId);

            return updateuser;
        }

        [HttpGet]
        public UseageDashBoardViewModel GetUserDashBoardViewData( int UserId, int SubType = 1)
        {
            UseageDashBoardViewModel UserDashBoardMain = _repository.UserUsageDashBoard(SubType, UserId);
            return UserDashBoardMain;
        }

        [HttpGet]
        public UserDashBoardViewModel GetUserDashBoardMain(int UserId)
        {
            UserDashBoardViewModel UserDashBoardMain = _repository.UserDashBoardMain(UserId);
            return UserDashBoardMain;
        }


        [HttpGet]
        public UseageDashBoardViewModel GetCollegeDashBoardViewData(int CollegeId, int SubType = 1)
        {
            UseageDashBoardViewModel UserDashBoardMain = _repository.CollegeUsageDashBoard(SubType, CollegeId);
            return UserDashBoardMain;
        }

        [HttpGet]
        public UserDashBoardViewModel GetCollegeDashBoardMain(int CollegeId)
        {
            UserDashBoardViewModel UserDashBoardMain = _repository.CollegeDashBoardMain(CollegeId);
            return UserDashBoardMain;
        }

       
    }
}
