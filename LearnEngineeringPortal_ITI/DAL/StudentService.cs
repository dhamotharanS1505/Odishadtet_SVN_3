using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Odishadtet.Models;
using Odishadtet.DAL;
using LearnEngineeringPortalService_ITI;
using LearnEngineeringPortalService_ITI.DataAccess;
using System.Xml.Linq;
using LearnEnggPaymentPortal;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Odishadtet.General;

namespace Odishadtet.DAL
{
    /// <summary>
    /// Show Student Registration,Login,OTP Details
    /// </summary>
    public class StudentService : IStudentService
    {
        string pkgCoverpath = ConfigurationManager.AppSettings["SubjectCoverPath"].ToString();

        string PageName = "StudentUserService.cs";

        public void DoWork()
        {
        }

        public bool isXmlOrJson(int xmlOrJson)
        {
            if (xmlOrJson == 1)
            {
                return true;
            }

            return false;
        }

        //// <summary>
        ///// Method for Check OTP with userId
        ///// </summary>
        ///// <param name="userId">long</param>
        ///// <param name="code">string</param>
        ///// <returns></returns>
        public bool GetRandomCode(long userId, string code)
        {
            bool isValid = false;

            var userCodes = new UserMasterAccess().GetAllRandomCodes();
            if (userCodes.Any(t => t.user_id == userId && t.verification_code == code))
            {
                isValid = true;
            }

            return isValid;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userMobile"></param>
        /// <param name="adminMobile"></param>
        /// <returns></returns>
        public int RemoveUser(long userMobile, long adminMobile)
        {
            int result = 0;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    user_master AdminChek = (from adm in contextsdce.user_master where adm.mobile == adminMobile select adm).FirstOrDefault();
                    if (AdminChek != null)
                    {
                        //Delete UserId if Already Exist
                        user_master delurp = (from del in contextsdce.user_master where del.mobile == userMobile select del).FirstOrDefault();
                        if (delurp != null)
                        {
                            contextsdce.user_master.Remove(delurp);
                            result = contextsdce.SaveChanges();
                        }
                    }                   
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "RefundPayment", "GetVerificationCode", ex.Message, "error");
                    return (0);
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the verification code by mobile for refund process.
        /// </summary>
        /// <param name="MobNo">The mob no.</param>
        /// <param name="emailID">The email identifier.</param>
        /// <returns></returns>
        public int GetVerificationCodeByMobileForRefundProcess(long MobNo, string emailID)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    var userdetails = (from userm in contextsdce.user_master where userm.mobile == MobNo && userm.email_id == emailID select userm).FirstOrDefault();

                    if (userdetails != null)
                    {

                        CallSendSMS obj1 = new CallSendSMS();
                        string strPostResponse;
                        string sOTP = obj1.CreateRandomPassword(5);

                        //Delete User Id if Already Exsist
                        user_random_pass delurp = (from del in contextsdce.user_random_pass where del.user_id == userdetails.user_id && del.action_type == 2 select del).FirstOrDefault();
                        if (delurp != null)
                        {
                            //contextsdce.user_random_pass.DeleteObject(delurp);
                            contextsdce.user_random_pass.Remove(delurp);
                            contextsdce.SaveChanges();
                        }


                        //Inserting Random password to user_random_pass Generated in verificationcode
                        user_random_pass urp = new user_random_pass();
                        urp.verification_code = sOTP;
                        urp.generated_time = DateTime.Now;
                        urp.action_type = 2;
                        urp.user_id = Convert.ToInt32(userdetails.user_id);
                        //contextsdce.AddTouser_random_pass(urp);
                        contextsdce.user_random_pass.Add(urp);
                        contextsdce.SaveChanges();


                        //OTP send to Mobile Number
                        strPostResponse = obj1.SendSMS(MobNo.ToString().Trim(), "Please enter OTP :  " + sOTP + "  to Complete the Refund Process , Infoplus learnengg.com Support", "test");


                        //OTP send to EMail
                        string mbody = MailHelper.EmailBody_OTP("Request Process", MobNo + "", sOTP, "");
                        MailHelper.SendMail(emailID, "One Time PassWord", mbody);

                        //MailHelper.SendMail("infoplus.otp@gmail.com", userdetails.collegename.ToString().Trim() + " - One Time PassWord For Registration", "One Time Password For:    " + userdetails.email_id.ToString() + " and his/her mobile number is : " + userdetails.mobile.ToString().Trim() + " and OTP is : " + "<b>" + sOTP + " " + "</b>" + " </br></br></br></br> By </br><b> LearnEngg Team</b>");


                        //return Convert.ToInt32(userdetails.user_id);

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }


                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "RefundPayment", "GetVerificationCode", ex.Message, "error");


                    return (0);

                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }
        /// <summary>
        /// To get verification for new user while Registration Process
        /// </summary>
        /// <param name="MobNo"></param>
        /// <param name="emailID"></param>
        /// <returns></returns>
        /// <summary>
        /// Method for Generate And Send OTP To User For Registeration
        /// </summary>

        /// <returns></returns>

        public int GetVerificationCodeByMobile(long MobNo, string emailID)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    var userdetails = (from userm in contextsdce.user_master where userm.mobile == MobNo && userm.email_id == emailID select userm).FirstOrDefault();

                    if (userdetails != null)
                    {

                        CallSendSMS obj1 = new CallSendSMS();
                        string strPostResponse;
                        string sOTP = obj1.CreateRandomPassword(5);

                        //Delete User Id if Already Exsist
                        user_random_pass delurp = (from del in contextsdce.user_random_pass where del.user_id == userdetails.user_id && del.action_type == 1 select del).FirstOrDefault();
                        if (delurp != null)
                        {
                            //contextsdce.user_random_pass.DeleteObject(delurp);
                            contextsdce.user_random_pass.Remove(delurp);
                            contextsdce.SaveChanges();
                        }


                        //Inserting Random password to user_random_pass Generated in verificationcode
                        user_random_pass urp = new user_random_pass();
                        urp.verification_code = sOTP;
                        urp.generated_time = DateTime.Now;
                        urp.action_type = 1;
                        urp.user_id = Convert.ToInt32(userdetails.user_id);
                        //contextsdce.AddTouser_random_pass(urp);
                        contextsdce.user_random_pass.Add(urp);
                        contextsdce.SaveChanges();


                        //OTP send to Mobile Number
                        strPostResponse = obj1.SendSMS(MobNo.ToString().Trim(), "Please enter OTP :  " + sOTP + "  to Complete the Registration Process , Infoplus learnengg.com Support", "test");


                        //OTP send to EMail
                        string mbody = MailHelper.EmailBody_OTP("Request Process", MobNo + "", sOTP, "");
                        MailHelper.SendMail(emailID, "One Time PassWord", mbody);

                        //MailHelper.SendMail("infoplus.otp@gmail.com", userdetails.collegename.ToString().Trim() + " - One Time PassWord For Registration", "One Time Password For:    " + userdetails.email_id.ToString() + " and his/her mobile number is : " + userdetails.mobile.ToString().Trim() + " and OTP is : " + "<b>" + sOTP + " " + "</b>" + " </br></br></br></br> By </br><b> LearnEngg Team</b>");


                        //return Convert.ToInt32(userdetails.user_id);

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }


                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "NewUserRegistration", "GetVerificationCode", ex.Message, "error");


                    return (0);

                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }
        /// <summary>
        /// Sending otp code through mobile to update profile
        /// </summary>
        /// <param name="MobNo"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetProfileUpdateOTPCode(string MobNo, int userId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                try
                {
                    CallSendSMS obj1 = new CallSendSMS();
                    string strPostResponse;
                    string sOTP = obj1.CreateRandomPassword(5);

                    //delete user id if already exsist in random pass
                    user_random_pass delurp = (from del in contextsdce.user_random_pass where del.user_id == userId && del.action_type == 1 select del).FirstOrDefault();
                    if (delurp != null)
                    {
                        contextsdce.user_random_pass.Remove(delurp);
                        contextsdce.SaveChanges();
                    }
                    //inserting Random new password to user_random_pass Generated as verificationcode
                    user_random_pass urp = new user_random_pass();
                    urp.verification_code = sOTP;
                    urp.generated_time = DateTime.Now;
                    urp.action_type = 1;
                    urp.user_id = userId;
                    contextsdce.user_random_pass.Add(urp);
                    contextsdce.SaveChanges();

                    //OTP send to Mobile Number
                    strPostResponse = obj1.SendSMS(MobNo.Trim(), "Please enter the OTP :  " + sOTP + "  to complete your profile update process, Infoplus learnengg.com Support", "");

                    return "1";

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "NewUserRegistration", "GetVerificationCode", ex.Message, "error");
                    return "";
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Update user details from user profile
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="userName"></param>
        /// <param name="deptId"></param>
        /// <param name="year"></param>
        /// <param name="sem"></param>
        /// <param name="collegeName"></param>
        /// <param name="collegeId"></param>
        /// <returns></returns>
        public string UpdateUserDetails(int userid, string userName, int deptId, string deptName, int year, int sem, string collegeName, int collegeId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var userDetails = (from user in contextsdce.user_master where user.user_id == userid select user).FirstOrDefault();

                    if (userDetails != null)
                    {
                        userDetails.user_first_name = userName;
                        userDetails.user_name = userName;
                        userDetails.DepartmentID = deptId;
                        userDetails.department_name = deptName;
                        userDetails.currentyear = year;
                        userDetails.currentsemester = sem;
                        userDetails.collegename = collegeName;
                        userDetails.collegeid = collegeId;

                        contextsdce.user_master.AddOrUpdate(userDetails);
                        int result = contextsdce.SaveChanges();

                        if (result > 0)
                        {
                            return "1";
                        }
                        else
                        {
                            return "-1";
                        }
                    }
                    else
                    {
                        return "2";
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "ProfileUpdate", "UpdateUserDetails", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }


        /// <summary>
        /// Method for Save New User Registeration For Login Purpose
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Department"></param>
        /// <param name="University"></param>
        /// <param name="College"></param>
        /// <param name="year"></param>
        /// <param name="Semester"></param>
        /// <param name="Email"></param>
        /// <param name="Mobile"></param>
        /// <returns></returns>

        public string SaveNewUserDetails(string UserName, int Department, int University, int College, int year, int Semester, string Email, long Mobile)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    user_master usermaster = new user_master();
                    usermaster.user_name = UserName;
                    usermaster.DepartmentID = Department;
                    usermaster.univ_id = University;
                    usermaster.collegeid = College;
                    usermaster.currentyear = year;
                    usermaster.currentsemester = Semester;
                    usermaster.email_id = Email;
                    usermaster.mobile = Mobile;
                    usermaster.created_on = DateTime.Now;

                    contextsdce.user_master.Add(usermaster);

                    int result = contextsdce.SaveChanges();

                    if (result > 0)
                    {
                        return " Registration Saved Successfully";
                    }
                    else
                    {
                        return "Registration Not Saved";
                    }

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "NewUserRegistration", "SaveNewUserDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }

        }

        #region Using Code hari
        //Changed by Hema
        /// <summary>
        /// Method for Check User Login Details with User LoginId and Password
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public checkLogin CheckLoginDetails(string loginID, string Password)
        {
            checkLogin chckLogin = new checkLogin();
            long mobile = 0;
            bool result = Int64.TryParse(loginID, out mobile);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    EncryptionDecryption encrypt = new EncryptionDecryption();
                    var pass = encrypt.encrptpwd(Password, true);

                    try
                    {
                        var data11 = (from login in contextsdce.college_master
                                      join univ in contextsdce.university_master on login.university_id equals univ.univ_id
                                      join cgm in contextsdce.college_group_master on login.college_name equals cgm.college_group_name
                                      join cgmm in contextsdce.college_group_map on cgm.college_group_id equals cgmm.college_group_id
                                      where (login.college_email.Trim() == loginID.Trim() || login.college_mobile == mobile) && login.password.Trim() == pass.Trim()
                                      select new { cgmm.college_group_id }).ToList();
                    }
                    catch (Exception ex1)
                    {
                        Log.WriteLogMessage(PageName, "CheckLoginDetails", "CheckLoginDetails Exception Message", ex1.Message, "error");
                        throw;
                    }

                   var data1 = (from login in contextsdce.college_master
                                 join univ in contextsdce.university_master on login.university_id equals univ.univ_id
                                 join cgm in contextsdce.college_group_master on login.college_name equals cgm.college_group_name
                                 join cgmm in contextsdce.college_group_map on cgm.college_group_id equals cgmm.college_group_id
                                 where (login.college_email.Trim() == loginID.Trim() || login.college_mobile == mobile) && login.password.Trim() == pass.Trim()
                                  select new
                                 {
                                     FirstName = login.college_name,
                                     emailId = login.college_email,
                                     roleTypeId = 10, // College Admin By Hema 14/09/2017
                                     collegegrpId = cgm == null ? 0 : cgm.college_group_id,
                                     userId = (long)login.college_id,
                                     year =1,
                                     semester = 1,
                                     isFrstLogin = 1,
                                     actveStatus = login.active_status,
                                     Firstloggedin =1,
                                     roleType = "CollegeAdmin",
                                     universityId = login.university_id,
                                     collegeId = login.college_id,
                                     mobileNumber = login.college_mobile??0,
                                     ProfileImage = "",
                                     role_type_code = 10,
                                     Univ_Type = univ.university_type ?? 0,
                                     // currentDate = DateTime.Now.ToString("dd-MM-yyyy"),
                                     roleLevel =  0
                                 }).ToList();

                   

                    var data = (from login in contextsdce.user_master
                                 join ur in contextsdce.user_role on login.role_id equals ur.role_id
                                 //join cm in contextsdce.college_master on login.collegeid equals cm.college_id
                                 join um in contextsdce.university_master on login.univ_id equals um.univ_id
                                 join cgms in contextsdce.college_group_master on login.college_group_id equals cgms.college_group_id into cgmtemp
                                 from cgm in cgmtemp.DefaultIfEmpty()
                                 where (login.email_id.Trim() == loginID.Trim() || login.mobile == mobile) && login.password.Trim() == pass.Trim()
                                 select new
                                 {
                                     FirstName = login.user_first_name,
                                     emailId = login.email_id,
                                     roleTypeId = login.role_id,
                                     collegegrpId = cgm==null? 0: cgm.college_group_id,
                                     userId = login.user_id,                                    
                                     year = login.currentyear ?? 0,
                                     semester = login.currentsemester ?? 0,
                                     isFrstLogin = login.is_first_login,
                                     actveStatus = login.active_status,
                                     Firstloggedin = login.last_loggedin_date == null ? 1 : 2,
                                     roleType = ur.role_desc,
                                     universityId = login.univ_id ?? 0,
                                     collegeId = login.collegeid ?? 0,
                                     mobileNumber = login.mobile,
                                     ProfileImage = login.profileimage ?? "",
                                     role_type_code = ur.role_type,
                                     Univ_Type = um.university_type ?? 0,
                                     // currentDate = DateTime.Now.ToString("dd-MM-yyyy"),
                                     roleLevel = ur.role_level ?? 0
                                 }).ToList();

                    if ((data.Count > 0 && data1.Count > 0))
                    {
                        checkLogin dt = new checkLogin();
                        dt.message = "User blocked Temporaily, please contact administrator";
                        chckLogin = dt;
                        return chckLogin;
                    }

                    if (data.Count > 0)
                    {

                    }
                    else if (data1.Count > 0)
                    {
                        data = data1;
                    }
                    //else if (data2.Count > 0)
                    //{
                    //    data = data2;
                    //}


                    var userData = (from c in data
                                    select new checkLogin
                                    {
                                        FirstName = c.FirstName,
                                        emailId = c.emailId,
                                        roleTypeId = c.roleTypeId,
                                        collegegrpId = c.collegegrpId,
                                        userId = c.userId,
                                        year = c.year,
                                        semester = c.semester,
                                        isFrstLogin = c.isFrstLogin,
                                        actveStatus = c.actveStatus,
                                        Firstloggedin = c.Firstloggedin,
                                        roleType = c.roleType,
                                        universityId = c.universityId,
                                        CollegeID = c.collegeId,
                                        mobileNumber = c.mobileNumber,
                                        ProfileImage = c.ProfileImage,
                                        role_type_code = c.role_type_code,
                                        Univ_Type = c.Univ_Type,
                                        currentDate = DateTime.Now.ToString("dd-MM-yyyy"),
                                        roleLevel = c.roleLevel,
                                        privilegeuniversities = c.universityId.ToString()
                                    }).ToList();

                    if (userData.Any() == true)
                    {
                        // for dash board - only for mapped universities
                        if (userData.FirstOrDefault().roleTypeId > 2)
                        {
                            long userlogid = userData.FirstOrDefault().userId;
                            string univIds = "0";
                           // univIds = string.Join(",", contextsdce.user_master.Where(s => s.user_id == userlogid).Select(t => t.university_id));
                            //userData.FirstOrDefault().privilegeuniversities = univIds;
                        }
                        userData.FirstOrDefault().message = "";
                        if (userData.FirstOrDefault().isFrstLogin == 1 && userData.FirstOrDefault().actveStatus == 1)
                        {
                            //success
                            long UserID = userData.FirstOrDefault().userId;
                            //  return jsSerializer.Serialize(chckLogin);
                            DateTime today_date = DateTime.Now.Date;
                            var ultData = (from ul in contextsdce.user_login_track where ul.user_id == UserID && ul.visited_on == today_date select ul).FirstOrDefault();
                            user_login_track ult = new user_login_track();
                            ult.user_id = Convert.ToInt32(userData.FirstOrDefault().userId);
                            ult.visited_on = DateTime.Now.Date;
                            ult.visited_time = DateTime.Now;
                            if (ultData != null)
                            {
                                ult.is_first_time_login = ultData.is_first_time_login == 1 ? 1 : userData.FirstOrDefault().Firstloggedin;
                                ult.repeated_login_cnt = ultData.repeated_login_cnt + 1;
                            }
                            else
                            {
                                ult.is_first_time_login = userData.FirstOrDefault().Firstloggedin;
                                ult.repeated_login_cnt = 1;
                            }
                            contextsdce.user_login_track.AddOrUpdate(u => new { u.user_id, u.visited_on }, ult);
                            contextsdce.SaveChanges();
                            var user = (from login in contextsdce.user_master
                                        where (login.email_id.Trim() == loginID.Trim() || login.mobile == mobile) && login.password.Trim() == pass.Trim()
                                        select login).FirstOrDefault();
                            if (user != null)
                            {
                                user.last_loggedin_date = DateTime.Now;
                                user.loggedin_status = 1;
                                contextsdce.SaveChanges();
                            }
                        }
                        else if (userData.FirstOrDefault().isFrstLogin == 2 && userData.FirstOrDefault().actveStatus == 0)
                        {
                            userData.FirstOrDefault().message = "Your Account is Not Activated. Please Activate Your Account";
                            GetVerificationCodeByMobile(userData.FirstOrDefault().mobileNumber, userData.FirstOrDefault().emailId);
                        }
                        else
                        {
                            userData.FirstOrDefault().message = "Your Account is Not Active";
                        }
                        chckLogin = userData.FirstOrDefault();
                        return chckLogin;
                    }
                    else
                    {
                        //var userDataa = CheckCollegeLogin(loginID, Password);
                        checkLogin dt = new checkLogin();
                        dt.message = "The UserName and Password doesn't exists";
                        chckLogin = dt;
                        return chckLogin; // "No details for this user You Entered wrong Mobile or EmailId";
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "CheckLoginDetails", "CheckLoginDetails Exception Message", ex.Message, "error");
                    Log.WriteLogMessage(PageName, "CheckLoginDetails", "InnerException", ex.InnerException.Message.ToString(), "error");
                    Log.WriteLogMessage(PageName, "CheckLoginDetails", "chckLogin", chckLogin.userId.ToString(), "error");

                    return chckLogin;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        public string CheckCollegeLogin(string loginID, string Password)
        {
            checkCollegeLogin chckLogin = new checkCollegeLogin();
            long mobile = 0;
            bool result = Int64.TryParse(loginID, out mobile);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    EncryptionDecryption encrypt = new EncryptionDecryption();
                    var pass = encrypt.encrptpwd(Password, true);
                    var data = (from login in contextsdce.college_master

                                where (login.college_email.Trim() == loginID.Trim() || login.college_mobile == mobile) && login.password.Trim() == pass.Trim()
                                select new
                                {
                                    college_id = login.college_id,
                                    college_name = login.college_name,
                                    emailId = login.college_email,
                                    mobileNumber = login.college_mobile,
                                    actveStatus = login.active_status,
                                }).ToList();
                    var userData = (from c in data
                                    select new checkCollegeLogin
                                    {
                                        CollegeID = c.college_id,
                                        CollegeName = c.college_name,
                                        emailId = c.emailId,
                                        mobileNumber = c.mobileNumber,
                                        actveStatus = c.actveStatus,
                                        currentDate = DateTime.Now.ToString("dd-MM-yyyy"),
                                    }).ToList();

                    if (userData.Any() == true)
                    {
                        chckLogin = userData.First();
                        XDocument xdoc = new XDocument(new XElement("CollegeList",
                                                                                   new XElement("College",
                                                                                                new XAttribute("CollegeId", chckLogin.CollegeID),
                                                                                                new XAttribute("CollegeName", chckLogin.CollegeName),
                                                                                                new XAttribute("emailId", chckLogin.emailId),
                                                                                                new XAttribute("mobileNumber", chckLogin.mobileNumber),
                                                                                                new XAttribute("actveStatus", chckLogin.actveStatus)
                                                                                              )));
                        return xdoc.ToString();


                    }
                    else
                    {
                        checkCollegeLogin dt = new checkCollegeLogin();
                        dt.message = "The UserName and Password doesn't exists";
                        chckLogin = dt;
                        return jsSerializer.Serialize("The UserName and Password doesn't exists");
                        // "No details for this user You Entered wrong Mobile or EmailId";
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "checkCollegeLogin", "CheckLoginDetails Exception Message", ex.Message, "error");
                    Log.WriteLogMessage(PageName, "checkCollegeLogin", "InnerException", ex.InnerException.Message.ToString(), "error");
                    Log.WriteLogMessage(PageName, "checkCollegeLogin", "chckLogin", chckLogin.CollegeID.ToString(), "error");

                    return jsSerializer.Serialize("The UserName and Password doesn't exists");

                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Method for check Number Of Times User Visited Page  
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="loginID"></param>
        /// <param name="VisitedPageURL"></param>
        /// <returns></returns>
        public int UserSessionDetails(string sessionID, Int64 loginID, string VisitedPageURL)
        {
            int result = 0;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    DateTime today_date = DateTime.Now.Date;
                    var ultData = (from ul in contextsdce.user_session_track where ul.session_id == sessionID && ul.visited_on == today_date && ul.visit_page_url == VisitedPageURL select ul).FirstOrDefault();
                    user_session_track ust = new user_session_track();
                    ust.session_id = sessionID;
                    ust.user_id = loginID;
                    ust.visit_page_url = VisitedPageURL;
                    ust.visited_on = DateTime.Now.Date;
                    ust.visited_time = DateTime.Now;
                    if (ultData != null)
                    {
                        ust.repeated_visit_count = ultData.repeated_visit_count + 1;
                    }
                    else
                    {
                        ust.repeated_visit_count = 1;
                    }
                    contextsdce.user_session_track.AddOrUpdate(u => new { u.session_id, u.user_id, u.visit_page_url, u.visited_on }, ust);
                    result = contextsdce.SaveChanges();
                    return result;

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "CheckLoginDetails", "CheckLoginDetails", ex.Message, "error");

                    return 0;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Method for forget password, to send otp to mobile and email
        /// </summary>
        /// <param name="mobileNo">long</param>
        /// <returns>Forget password view model</returns>
        public ForgetPasswordModel ForgetPassword(long mobileNo)
        {
            ForgetPasswordModel forgetModel = new ForgetPasswordModel();
            try
            {
                var userDetails = new UserMasterAccess().GetAllUsers();
                if (userDetails.Any(t => t.mobile == mobileNo))
                {
                    var user = userDetails.FirstOrDefault(t => t.mobile == mobileNo);
                    string emailId = user.email_id;
                    int UserID = GetVerificationCodeByMobile(mobileNo, emailId);
                    forgetModel.userID = user.user_id;
                    forgetModel.message = "OTP send to your registered mobile number.";
                }
                else
                {
                    forgetModel.userID = 0;
                    forgetModel.message = "Mobile Number doesnot registered with us.";
                }
            }
            catch (Exception Ex)
            {
                Log.WriteLogMessage(PageName, "ForgetPassword", "SendForgetPassword", Ex.Message, "error");
                forgetModel.userID = 0;
                forgetModel.message = "Please try again later.";
            }

            return forgetModel;
        }

        /// <summary>
        /// Method for Reset Password
        /// </summary>
        /// <param name="mobileNo">long</param>
        /// <param name="otpCode">string</param>
        /// <param name="newPassword">string</param>
        /// <returns>Foret password model</returns>
        public ForgetPasswordModel ResetPassword(long mobileNo, string otpCode, string newPassword)
        {
            ForgetPasswordModel resetModel = new ForgetPasswordModel();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    //var userDetails = new UserMasterAccess().GetAllUsers();
                    var userDetails = (from usm in contextsdce.user_master where usm.mobile == mobileNo select usm);
                    // if (userDetails.Any(t => t.mobile == mobileNo))
                    if (userDetails.Any() == true)
                    {
                        var user = userDetails.FirstOrDefault(t => t.mobile == mobileNo);
                        if (GetRandomCode(user.user_id, otpCode))
                        {
                            var password = new EncryptionDecryption().encrptpwd(newPassword, true);
                            var isUpdated = new UserMasterAccess().UpdatePassword(user.user_id, password);
                            if (isUpdated)
                            {
                                resetModel.userID = user.user_id;
                                resetModel.message = "Password changed successfully.";
                                //new Notification().PasswordChange(user.user_first_name, user.email_id);
                                string mbody = MailHelper.EmailBody_PasswordChange(user.user_first_name, user.email_id);
                                MailHelper.SendMail(user.email_id, "Password changed successfully.", mbody);
                            }
                            else
                            {
                                resetModel.userID = 0;
                                resetModel.message = "Password doesnot changed.Please try again later.";
                            }
                        }
                        else
                        {
                            resetModel.userID = 0;
                            resetModel.message = "OTP code doesnot match.Please enter valid code.";
                        }
                    }
                    else
                    {
                        resetModel.userID = 0;
                        resetModel.message = "Mobile Number doesnot registered with us.";
                    }


                }
                catch (Exception Ex)
                {
                    Log.WriteLogMessage(PageName, "ResetPassword", "CallResetPassword", Ex.Message, "error");
                    resetModel.message = "Password doesnot changed.Please try again later.";
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
            return resetModel;

        }
        #endregion



        /// <summary>
        ///To get and chagne current password for logged in user using mobile number and current password
        /// </summary>
        /// <param name="mobileNum"></param>
        /// <param name="currPasswrd"></param>
        /// <returns></returns>

        public string ChangePassword(long mobileNum, string currPasswrd)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var curntPwd = new EncryptionDecryption().encrptpwd(currPasswrd, true);

                    var userpwd = (from chnagepwd in contextsdce.user_master where chnagepwd.mobile == mobileNum && chnagepwd.password == curntPwd select chnagepwd);
                    string message = "Please Check Your Current Password";

                    if (userpwd.Any())
                    {
                        var emailId = userpwd.FirstOrDefault().email_id;

                        GetVerificationCodeByMobile(mobileNum, emailId);

                        message = "OTP Sent To Your Mobile Number And EmailId";
                    }
                    return jsSerializer.Serialize("" + message);
                }

                catch
                {
                    return jsSerializer.Serialize("Please Check Your Current Password");
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///  To get profile image for logged in user
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>


        public string GetUserProfileImage(int UserID)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    checkLogin chckLogin = new checkLogin();
                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    // var updateDept = (from User in context.user_master where User.user_id == UserID select User).FirstOrDefault();

                    var userData = (from login in contextsdce.user_master
                                    join ur in contextsdce.user_role on login.role_id equals ur.role_id
                                    where login.user_id == UserID
                                    select new checkLogin
                                    {
                                        FirstName = login.user_first_name,
                                        emailId = login.email_id,
                                        roleTypeId = login.role_id,
                                        userId = login.user_id,
                                        isFrstLogin = login.is_first_login,
                                        actveStatus = login.active_status,
                                        roleType = ur.role_desc,
                                        universityId = login.univ_id ?? 0,
                                        mobileNumber = login.mobile,
                                        ProfileImage = login.profileimage ?? "profile_img.png"
                                    });

                    chckLogin = userData.FirstOrDefault();
                    return jsSerializer.Serialize(chckLogin);
                    //return chckLogin.ProfileImage;
                    // return updateDept.profileimage ?? "profile_img.png";

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "GetUserProfileImage", "GetUserProfileImage", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }
        /// <summary>
        /// To Update contact details and login status for single user based on mobile and email
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="mobile"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        /// <summary>
        /// Method For Update User Contact Details 
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="mobile"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>

        public string UpdateContactDetails(int userid, long mobile, string emailId)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    var updateContact = (from user in contextsdce.user_master
                                         where user.user_id == userid
                                         select user).FirstOrDefault();
                    updateContact.mobile = mobile;
                    updateContact.email_id = emailId;
                    updateContact.is_first_login = 2;

                    int updatecon = contextsdce.SaveChanges();

                    if (updatecon > 0)
                    {
                        return "Updated successfully";
                    }
                    else
                    {
                        return "Updated Failure";
                    }

                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }

            }
        }

        /***** Used in User View Cart Details controller ****/

        /// <summary>
        /// Method For Get User Purchased Product Details In ViewCart
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<userViewCart> GetViewCartDetails(long UserId)
        {

            List<userViewCart> CartDetails = new List<userViewCart>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var cart = (from packg in contextsdce.package_master
                                join pcd in contextsdce.package_details on packg.package_id equals pcd.package_id into leftpcd
                                from pcd in leftpcd.DefaultIfEmpty()
                                join sm in contextsdce.subject_master on pcd.subject_id equals sm.subject_id into leftsm
                                from sm in leftsm.DefaultIfEmpty()
                                join ucd in contextsdce.user_cart_details on packg.package_id equals ucd.package_id
                                join usdm in contextsdce.user_subscribe_delivery_mode on ucd.delivery_modeid equals usdm.user_subscribe_delivery_mode_id
                                into usrcart
                                from usdm in usrcart.DefaultIfEmpty()
                                where ucd.user_id == UserId && packg.activestatus == 1
                                group new { packg, sm, usdm, ucd } by new { packg.package_id } into packgrp
                                orderby packgrp.Key.package_id

                                select new
                                {
                                    packageID = packgrp.Key.package_id,

                                    subject = packgrp.OrderBy(x => x.sm.subject_name)
                                });
                    int sumsubtotal = 0;
                    int packitems = 0;
                    userViewCart uvc;
                    foreach (var output in cart)
                    {
                        uvc = new userViewCart();
                        uvc.packageID = output.packageID;
                        int itemcnt = 0;
                        List<string> BundleSubject = new List<string>();
                        foreach (var res in output.subject)
                        {
                            //if (itemcnt == 0)
                            //{
                            //    uvc.Bundlesubjects += (res.sm == null) ? "" : res.sm.univ_subject_code + "-" + res.sm.subject_name ;
                            //}else
                            //{
                            //    uvc.Bundlesubjects += (res.sm == null) ? "" : "," + res.sm.univ_subject_code + "-" + res.sm.subject_name ;
                            //}

                            BundleSubject.Add((res.sm == null) ? "" : res.sm.univ_subject_code + "-" + res.sm.subject_name);
                            uvc.userid = res.ucd.user_id;
                            uvc.packageName = res.packg.package_name;
                            uvc.Bundle = res.packg.is_bundle;
                            // uvc.Bundlesubjects = res.packg.long_desc;
                            uvc.OsType = (res.packg.os_type == 1) ? "Windows" : "Android";
                            uvc.packageID = res.packg.package_id;
                            uvc.packageCode = res.packg.package_code;
                            uvc.packagecoverpath = res.packg.cover_path;
                            uvc.PackageActualPrice = res.packg.actual_price;
                            uvc.PackageSellingPrice = res.packg.selling_price;
                            uvc.DiscountPrice = (res.packg.actual_price - res.packg.selling_price);
                            uvc.packageDuration = res.packg.package_duration_days;
                            uvc.userCartDate = res.packg.created_on;
                            if (res.packg.is_bundle == 1)
                            {
                                if (itemcnt == 0)
                                {
                                    sumsubtotal = sumsubtotal + res.packg.selling_price;
                                }
                            }
                            else
                            {
                                sumsubtotal = sumsubtotal + res.packg.selling_price;
                            }

                            uvc.deliveryModePrice = res.usdm == null ? 0 : res.usdm.price;
                            uvc.deliveryModeType = res.usdm == null ? 0 : (int)res.usdm.delivery_type;
                            uvc.DeliveryProductPrice = res.usdm == null ? 0 : (int)res.usdm.product_price;
                            uvc.DeliveryShippingPrice = res.usdm == null ? 0 : (int)res.usdm.delivery_price;
                            uvc.DeliveryDesc = res.usdm == null ? "" : res.usdm.delivery_desc;
                            itemcnt++;


                        }
                        uvc.Bundlesubjects = BundleSubject;
                        packitems++;
                        CartDetails.Add(uvc);
                    }
                    CartDetails.ToList().ForEach(c => c.subTotal = sumsubtotal);
                    CartDetails.ToList().ForEach(c => c.itemCount = packitems);
                    return CartDetails;
                }

                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "StudentService", "GetViewCartDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }

        }



        public List<userViewCart> GetViewCartDetails_beforeLogin(string PackageID)
        {

            List<userViewCart> CartDetails = new List<userViewCart>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    string[] strPackageID = PackageID.ToString().Split(',');

                    var cart = (from packg in contextsdce.package_master
                                where strPackageID.Contains(packg.package_id.ToString()) && packg.activestatus == 1

                                select new
                                {
                                    packg.package_name,
                                    packg.package_id,
                                    packg.package_code,
                                    packg.cover_path,
                                    packg.actual_price,
                                    packg.selling_price,
                                    packg.package_duration_days

                                }).ToList();

                    CartDetails = (from c in cart
                                   select new userViewCart
                                   {
                                       packageName = c.package_name,
                                       packageID = c.package_id,
                                       packageCode = c.package_code,
                                       packagecoverpath = c.cover_path,
                                       PackageActualPrice = c.actual_price,
                                       PackageSellingPrice = c.selling_price,
                                       itemCount = cart.Select(z => z.package_id).Count(),
                                       subTotal = cart.Select(z => z.selling_price).Sum(),
                                       packageDuration = c.package_duration_days
                                   }).Distinct().ToList();

                    return CartDetails;
                }

                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "StudentService", "GetViewCartDetails_beforeLogin", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }

        }

        /***** Used in Product Details / Product Home / Dash board Controller ****/
        /***** VIEW CART *****/

        #region User Cart Methods

        /// <summary>
        /// Method For Remove Product From Cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PackageID"></param>
        /// <returns></returns>
        public int RemovePackage(int UserId, int PackageID)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    user_cart_details ucd = (from usrcart in contextsdce.user_cart_details where usrcart.user_id == UserId && usrcart.package_id == PackageID select usrcart).FirstOrDefault();
                    if (ucd != null)
                    {
                        contextsdce.user_cart_details.Remove(ucd);
                        contextsdce.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "StudentService", "viewCount", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pass"></param>
        /// <returns></returns>
        public string GetEncPasswordString(string Pass)
        {
            string result = "";
            result = new EncryptionDecryption().encrptpwd(Pass, true);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EncPass"></param>
        /// <returns></returns>
        public string GetPasswordString(string EncPass)
        {
            string result = "";
            result = new EncryptionDecryption().Decryptpwd(EncPass,true);
            return result;
        }

        /// <summary>
        /// Method For Update User selected Delivery Mode in View Cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="DeliveryModeId"></param>
        /// <returns></returns>
        public int UpdateDeliveryMode(int UserId, int DeliveryModeId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var ucd = (from usrcart in contextsdce.user_cart_details where usrcart.user_id == UserId select usrcart).ToList();
                    if (ucd != null)
                    {
                        ucd.ForEach(a => a.delivery_modeid = DeliveryModeId);
                        contextsdce.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "StudentService", "viewCount", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        /// <summary>
        /// Method For Show Number Of Products Uount  In User Cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int GetViewCartCount(int UserId)
        {
            int ViewCartCount = 0;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    ViewCartCount = (from usrcart in contextsdce.user_cart_details where usrcart.user_id == UserId select usrcart).Distinct().Count();
                    return ViewCartCount;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Payment", "viewCount", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        /// <summary>
        /// Method For Get User Purchased Delivery Mode Type
        /// </summary>
        /// <returns></returns>
        public List<DeliveryOptionMode> GetDeliveryMode()
        {
            List<DeliveryOptionMode> DeliveryOptionDetails = new List<DeliveryOptionMode>();
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    DeliveryOptionDetails = (from dom in contextsdce.user_subscribe_delivery_mode
                                             where dom.active_status==1
                                             select new DeliveryOptionMode
                                             {
                                                 DeliveryOptionID = dom.user_subscribe_delivery_mode_id,
                                                 DeliveryMode = dom.subscribe_delivery_mode,
                                                 DeliveryOptionPrice = dom.price,
                                                 DeliveryProductPrice = (int)dom.product_price,
                                                 DeliveryShippingPrice = (int)dom.delivery_price,
                                                 Description = dom.description,
                                                 DeliveryDesc = dom.delivery_desc
                                             }).ToList();

                }

                return DeliveryOptionDetails;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        //public string InsertPackageToUserCart(int UserId, int PackageId)
        //{

        //    using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
        //    {
        //        try
        //        {
        //            var checkUserCart = (from uc in contextsdce.user_cart_details where uc.user_id == UserId && uc.package_id == PackageId select uc).FirstOrDefault();
        //            if (checkUserCart == null)
        //            {
        //                user_cart_details ucd = new user_cart_details();
        //                ucd = new user_cart_details();
        //                ucd.package_id = PackageId;
        //                ucd.user_id = UserId;
        //                ucd.created_on = DateTime.Now;

        //                contextsdce.user_cart_details.Add(ucd);

        //                int result = contextsdce.SaveChanges();

        //                if (result > 0)
        //                {
        //                    return "Added to Cart Successfully";
        //                }
        //                else
        //                {
        //                    return "Not Added to Cart";
        //                }
        //            }
        //            else
        //            {
        //                return "Already added to Cart";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.WriteLogMessage(PageName, "NewUserRegistration", "InsertToUserWishList", ex.Message, "error");
        //            Log.WriteLogMessage(PageName, "NewUserRegistration", "InsertToUserWishList", ex.InnerException.Message, "error");

        //            throw;
        //        }
        //        finally
        //        {
        //            if (contextsdce != null)
        //            {
        //                contextsdce.Dispose();
        //            }

        //        }
        //    }
        //}

        /// <summary>
        /// Method For Insert User Purchased Product Details Into User View Cart
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PackageIds"></param>
        /// <returns></returns>
        public string InsertPackageToUserCart(int UserId, string PackageIds)
        {

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    string[] strPackageIds = PackageIds.Split(',').Distinct().ToArray();
                    int result = 0;
                    for (int i = 0; i < strPackageIds.Length; i++)
                    {
                        int packageid = Convert.ToInt32(strPackageIds[i]);
                        var checkUserCart = (from uc in contextsdce.user_cart_details where uc.user_id == UserId && uc.package_id == packageid select uc).FirstOrDefault();
                        if (checkUserCart == null)
                        {
                            user_cart_details ucd = new user_cart_details();

                            ucd = new user_cart_details();
                            ucd.package_id = Convert.ToInt32(strPackageIds[i].ToString());
                            ucd.user_id = UserId;
                            ucd.created_on = DateTime.Now;

                            contextsdce.user_cart_details.Add(ucd);
                            result = contextsdce.SaveChanges();
                        }
                    }

                    if (result > 0)
                    {
                        return "Added to Cart";
                    }
                    else
                    {
                        return "Already Added to Cart";
                    }

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "InsertPackageToUserCart", "InsertPackageToUserCart", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }

                }
            }
        }

        #endregion

        /***** WISHLIST ******/
        #region User Wishlist Methods

        /// <summary>
        /// Method For Insert User Purchased Product Into User WishList
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PackageId"></param>
        /// <returns></returns>
        public string InsertToUserWishList(int UserId, int PackageId)
        {

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                try
                {
                    var insertuserwishlist = (from user in contextsdce.user_wishlist
                                              where user.user_id == UserId && user.package_id == PackageId
                                              select user).FirstOrDefault();
                    if (insertuserwishlist == null)
                    {
                        insertuserwishlist.user_id = UserId;
                        insertuserwishlist.package_id = PackageId;
                        insertuserwishlist.created_on = DateTime.Now;
                        contextsdce.user_wishlist.Add(insertuserwishlist);
                        int result = contextsdce.SaveChanges();
                        return "Saved Successfully";
                    }
                    else
                    {
                        return "Not Saved";
                    }


                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "NewUserRegistration", "InsertToUserWishList", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Method For Get User Purchased Product From WishList
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<wishList> GetMyWishList(int UserId)
        {

            List<wishList> mywishlist = new List<wishList>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    mywishlist = (from packg in contextsdce.package_master
                                  join userwishlist in contextsdce.user_wishlist on packg.package_id equals userwishlist.package_id
                                  where userwishlist.user_id == UserId && packg.activestatus == 1
                                  select new wishList
                                  {
                                      userid = userwishlist.user_id,
                                      packageName = packg.package_name,
                                      packageID = packg.package_id,
                                      packageCode = packg.package_code,
                                      packagecoverpath = packg.cover_path,
                                      actualPrice = packg.actual_price,
                                      sellingPrice = packg.selling_price,
                                      packageDuration = packg.package_duration_days
                                  }).Distinct().ToList();
                    return mywishlist;
                }

                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "Product", "GetMyWishList", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }

        }

        #endregion


        /***** Used in User Dashboard Controller ****/

        /// <summary>
        /// Method For Get User Purchased Subject Details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<purchasedSubjects> GetUserPurchasedSubjects(int UserId)
        {

            List<purchasedSubjects> PurchasedSubject = new List<purchasedSubjects>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    PurchasedSubject = (from packg in contextsdce.package_master
                                        join usm in contextsdce.user_subject_mapping on packg.subject_id equals usm.subject_id
                                        where usm.user_id == UserId && packg.activestatus == 1
                                        select new purchasedSubjects
                                        {
                                            userid = usm.user_id,
                                            packageName = packg.package_name,
                                            packageID = packg.package_id,
                                            packageCode = packg.package_code,
                                            packagecoverpath = packg.cover_path,
                                            actualPrice = packg.actual_price,
                                            sellingPrice = packg.selling_price,
                                            packageDuration = packg.package_duration_days
                                        }).Distinct().ToList();
                    return PurchasedSubject;
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "Product", "GetUserPurchasedSubjects", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }

        }

        /// <summary>
        /// Method For Get Student Purchased Subject Details In DashBoard
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>

        public List<Dashboard> UserDashboardDetails(int userid)
        {

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<Dashboard> studentdashboard = new List<Dashboard>();
                string unitspathapk = ConfigurationManager.AppSettings["SubjectUnitPath"].ToString();

                int[] paystatus = new int[2] {2,4};

                try
                {
                    var student = (from pkgmas in contextsdce.package_master
                                   join dm in contextsdce.department_master on pkgmas.department_id equals dm.department_id
                                   join usbm in contextsdce.user_subscribe_details on pkgmas.package_id equals usbm.package_id
                                   join usb in contextsdce.user_subscribe_master on usbm.user_subscribe_master_id equals usb.user_subscribe_master_id
                                   join sunit in contextsdce.subject_unit_master on pkgmas.subject_id equals sunit.subject_id
                                   where usb.user_id == userid && paystatus.Contains(usb.payment_status) && pkgmas.subject_unit_type == sunit.subject_unit_type && pkgmas.os_type == 2
                                   group new { pkgmas, dm, usbm, usb, sunit } by pkgmas.package_id into pkgmas
                                   select new
                                   {
                                       //deptid = pkgmas.department_id,
                                       //deptName = dm.department_name,
                                       pckgid = pkgmas.Key,
                                       pckvalue = pkgmas
                                       //packgName = pkgmas.package_name,
                                       //purchasedon = usb.created_on,
                                       //packageduration = usbm.package_expiryon,
                                       //Operatingsystemtype=pkgmas.os_type==1? "Windows" :"Android",
                                       //subjectunitpath = pkgmas.os_type == 1 ? "NoPath": (unitspathapk + sunit.subject_unit_path)


                                   }).ToList();

                    //studentdashboard = (from t in student
                    //                    select new Dashboard
                    //                    {
                    //                        departmentId = t.deptid,
                    //                        departmentName = t.deptName,
                    //                        PackagegId = t.pckgid,
                    //                        PackageName = t.packgName,
                    //                        Pusrchasedon = t.purchasedon.ToString("dd-MM-yyyy"),
                    //                        packageDuration = t.packageduration.ToString("dd-MM-yyyy"),
                    //                        operatingsystem= t.Operatingsystemtype,
                    //                        SubjectUnitPath = t.subjectunitpath

                    //                    }).Distinct().ToList();

                    foreach (var studata in student)
                    {
                        Dashboard dboard = new Dashboard();
                        dboard.PackagegId = studata.pckgid;
                        foreach (var result in studata.pckvalue)
                        {
                            dboard.PackageName = result.pkgmas.package_name;
                            dboard.departmentId = result.dm.department_id;
                            dboard.departmentName = result.dm.department_name;
                            dboard.Pusrchasedon = result.usb.payment_on.ToString("dd-MM-yyyy");
                            dboard.packageDuration = result.usbm.package_expiryon.ToString("dd-MM-yyyy");
                            dboard.operatingsystem = result.pkgmas.os_type == 1 ? "Windows" : "Android";
                            dboard.SubjectUnitPath = result.pkgmas.os_type == 1 ? "NoPath" : (unitspathapk + result.sunit.subject_unit_path);

                        }
                        studentdashboard.Add(dboard);
                    }
                    return studentdashboard;
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "Student", "UserDashboardDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// To get user Address details for both new Registered user and logged in user at cart option 
        /// </summary>
        /// <param name="pUserId"></param>
        /// <param name="pAddressType"></param>
        /// <param name="pFullName"></param>
        /// <param name="pMobileNumber"></param>
        /// <param name="pAddress"></param>
        /// <param name="pPincode"></param>
        /// <param name="pCity"></param>
        /// <param name="pState"></param>
        /// <param name="pCountry"></param>
        /// <param name="pLandmark"></param>
        /// <param name="pIsbilling_delivery"></param>
        /// <returns></returns>
        public string UserAddress(int pUserId, int pAddressType, string pFullName, long pMobileNumber, string pAddress, int pPincode, string pCity, string pState, int pCountry, string pLandmark, int pIsbilling_delivery)
        {
            string message = "";
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<Dashboard> studentdashboard = new List<Dashboard>();
                try
                {
                    user_address_details ude = new user_address_details();
                    ude.user_id = pUserId;
                    ude.address_type = pAddressType;
                    ude.full_name = pFullName;
                    ude.mobile_number = pMobileNumber;
                    ude.address = pAddress;
                    ude.pincode = pPincode;
                    ude.city = pCity;
                    ude.state = pState;
                    ude.country = pCountry;
                    ude.landmark = pLandmark;
                    ude.isbilling_delivery = pIsbilling_delivery;
                    ude.created_on = DateTime.Now;
                    contextsdce.user_address_details.Add(ude);
                    contextsdce.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "NewUserRegistration", "UserAddress", ex.Message, "error");
                    throw ex;
                }
                return message;
            }
        }


        /// <summary>
        /// To get verification code(OTP) through mobile and email
        /// </summary>
        /// <param name="MobNo"></param>
        /// <param name="emailID"></param>
        /// <returns></returns>
        public string GenerateVerificationCode(long MobNo, string emailID)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    var userdetails = (from userm in contextsdce.user_master where userm.mobile == MobNo && userm.email_id == emailID select userm).FirstOrDefault();

                    if (userdetails != null)
                    {

                        CallSendSMS obj1 = new CallSendSMS();

                        string sOTP = obj1.CreateRandomPassword(6);

                        //Delete User Id if Already Exsist
                        user_random_pass delurp = (from del in contextsdce.user_random_pass where del.user_id == userdetails.user_id && del.action_type == 1 select del).FirstOrDefault();
                        if (delurp != null)
                        {
                            //contextsdce.user_random_pass.DeleteObject(delurp);
                            contextsdce.user_random_pass.Remove(delurp);
                            contextsdce.SaveChanges();
                        }


                        //Inserting Random password to user_random_pass Generated in verificationcode
                        user_random_pass urp = new user_random_pass();
                        urp.verification_code = sOTP;
                        urp.generated_time = DateTime.Now;
                        urp.action_type = 1;
                        urp.user_id = Convert.ToInt32(userdetails.user_id);
                        //contextsdce.AddTouser_random_pass(urp);
                        contextsdce.user_random_pass.Add(urp);
                        contextsdce.SaveChanges();


                        ////OTP send to Mobile Number
                        //strPostResponse = obj1.SendSMS(MobNo.ToString().Trim(), "Please enter the OTP :  " + sOTP + "  to complete your Installation process, Infoplus learnengg.com Support", emailID);


                        ////OTP send to EMail

                        //MailHelper.SendMail(emailID, "One Time PassWord", "Your ONE TIME PASSWORD is:    " + "<b>" + sOTP + "</b>" + "<br/>" + "  Please enter the OTP To complete Your Installation Process Infoplus learnengg.com support");

                        //MailHelper.SendMail("infoplus.otp@gmail.com", userdetails.collegename.ToString().Trim() + " - One Time PassWord For Registration", "One Time Password For:    " + userdetails.email_id.ToString() + " and his/her mobile number is : " + userdetails.mobile.ToString().Trim() + " and OTP is : " + "<b>" + sOTP + " " + "</b>" + " </br></br></br></br> By </br><b> LearnEngg Team</b>");

                        //XDocument xdoc = new XDocument(new XElement("OneTimePassword", new XElement("OTP",
                        //                                  new XAttribute("OneTimePasswrod", sOTP))));


                        return sOTP;
                    }
                    else
                    {
                        return "";
                    }


                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "NewUserRegistration", "GetVerificationCode", ex.Message, "error");


                    return "";

                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Method For Get Subject Activation OTP To User Purchased Product After Payment succesed
        /// </summary>
        /// <returns></returns>
        public static List<purchase_activationmaster> GetActivationKeys()
        {
            List<purchase_activationmaster> ActivationKeys = new List<purchase_activationmaster>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                try
                {
                    ActivationKeys = (from a in contextsdce.purchase_activationmaster select a).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ActivationKeys;
            }

        }

        //create activation Code
        //6) send SMS and Email once Product Amount Received (Activation Code + Purchase Bill )
        /// <summary>
        /// Method For Send Subject Activation OTP To User Purchased Product After Payment succesed
        /// </summary>
        /// <param name="user_subscribed_masterid"></param>
        /// <param name="created_userid"></param>
        /// <returns></returns>
        public string CreateActivationCode(Int64 user_subscribed_masterid, Int64 created_userid)
        {
            string message = "";
            Int64 buyer_userid, buyer_mobileNo;
            string username, orderid;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<purchase_activationmaster> studentdashboard = new List<purchase_activationmaster>();
                CallSendSMS ob = new CallSendSMS();
                try
                {

                    //get data from user subscribe master

                    var datasub = from a in contextsdce.user_subscribe_master
                                  join b in contextsdce.user_master on a.user_id equals b.user_id
                                  where a.user_subscribe_master_id == user_subscribed_masterid
                                  select new
                                  {
                                      b.user_name,
                                      b.mobile,
                                      a.payment_ref_no,
                                      a.user_id
                                  };

                    buyer_userid = datasub.FirstOrDefault().user_id;
                    buyer_mobileNo = datasub.FirstOrDefault().mobile;
                    username = datasub.FirstOrDefault().user_name;
                    orderid = datasub.FirstOrDefault().payment_ref_no;

                    //create activation code

                    message = ob.CreateActivationKey(8);
                    purchase_activationmaster ude = new purchase_activationmaster();
                    ude.user_subscribed_masterid = user_subscribed_masterid;
                    ude.buyer_userid = buyer_userid;
                    ude.buyer_mobileNo = buyer_mobileNo;
                    ude.activationcode = message;
                    ude.created_date = DateTime.Now;
                    ude.created_userid = created_userid;
                    ude.activationstatus = 0;
                    contextsdce.purchase_activationmaster.Add(ude);
                    contextsdce.SaveChanges();

                    //send SMS to the User With Activation Code
                    ob.SendSMS(buyer_mobileNo + "", ob.SMS_Payment_ActivationCode(buyer_mobileNo + "", message), "");

                    //Send Mail to User About his Activaiton Code
                    //attach bill
                    string mailcontent = MailHelper.EmailBody_ActivationCode("", buyer_mobileNo + "", message, username, orderid);
                    MailHelper.SendMail("TO", "Learnengg - Payment Reseaved / your Activation Code", mailcontent);
                }
                catch (Exception ex)
                {
                    message = "Failed To create Activation Code";
                    throw ex;
                }
                return message;
            }
        }

        /// <summary>
        /// Method For Update Subject Activation Code For User Purchased Product 
        /// </summary>
        /// <param name="Userid"></param>
        /// <param name="Mobilenumber"></param>
        /// <param name="activationcode"></param>
        /// <returns></returns>
        public string UpdateActivationCodeForPurchase(int Userid, long Mobilenumber, string activationcode)
        {
            string message = "Please Enter Valid activation Code";
            List<purchase_activationmaster> ActivationKeys = new List<purchase_activationmaster>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                var ude = (from a in contextsdce.purchase_activationmaster
                           where a.buyer_mobileNo == Mobilenumber && a.activationcode == activationcode.ToUpper()
                           select a).FirstOrDefault();
                if (ude != null)
                {
                    if (ude.activationstatus == 0)
                    {
                        using (var transaction = contextsdce.Database.BeginTransaction())
                        {
                            try
                            {
                                ude.activated_date = DateTime.Now;
                                ude.activated_userid = Userid;
                                ude.activationstatus = 2;
                                int updatecon = contextsdce.SaveChanges();

                                // map subjects once it activated
                                List<saveSubjeDetails> saveSubjct = new List<saveSubjeDetails>();
                                List<saveSubjeDetails> saveSubjct1 = new List<saveSubjeDetails>();
                                saveSubjct = (from usm in contextsdce.user_subscribe_master
                                              join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                              join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                              join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                              join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                              join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                              where usm.user_subscribe_master_id == ude.user_subscribed_masterid
                                                    && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                              select new saveSubjeDetails
                                              {
                                                  subj_ID = sm.subject_id,
                                                  sub_Code = sm.subject_code,
                                                  subj_Name = sm.subject_name,
                                                  subj_CoverParth = sm.subject_cover_path,
                                                  subj_Version = sm.subject_version,
                                                  subjUnit_ID = sbum.unit_id,
                                                  subjUnit_code = sbum.unit_code,
                                                  subjUnit_Name = sbum.unit_name,
                                                  subjUnit_Path = sbum.subject_unit_path,
                                                  subjUnit_version = sbum.subject_unit_version,
                                                  subjUnit_usrVersion = sbum.subject_unit_version,
                                                  deprtId = dm.department_id,
                                                  deprtCode = dm.department_code,
                                                  deprtName = dm.department_name,
                                                  isDemo = sbum.is_demo,
                                                  unit_orIdx = sbum.is_unit_or_index,
                                                  activesubjdays = pm.package_duration_days,
                                                  activDurDate = DateTime.Now,
                                                  released_On = sm.released_on,
                                                  user_ID = Userid,
                                                  is_updated_to_client = 1,
                                                  LastmodifiedOn = DateTime.Now,
                                                  LastClientUpdatedOn = DateTime.Now,
                                                  LastSubunitModifiedOn = DateTime.Now,
                                                  IsUpdatedSubunitToClient = 1,
                                                  LastSubunitClientUpdatedOn = DateTime.Now
                                              }).Distinct().ToList();

                                saveSubjct1 = (from usm in contextsdce.user_subscribe_master
                                               join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                               join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                               join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                               join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                               join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                               join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                               where usm.user_subscribe_master_id == ude.user_subscribed_masterid
                                                     && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1
                                               select new saveSubjeDetails
                                               {
                                                   subj_ID = sm.subject_id,
                                                   sub_Code = sm.subject_code,
                                                   subj_Name = sm.subject_name,
                                                   subj_CoverParth = sm.subject_cover_path,
                                                   subj_Version = sm.subject_version,
                                                   subjUnit_ID = sbum.unit_id,
                                                   subjUnit_code = sbum.unit_code,
                                                   subjUnit_Name = sbum.unit_name,
                                                   subjUnit_Path = sbum.subject_unit_path,
                                                   subjUnit_version = sbum.subject_unit_version,
                                                   subjUnit_usrVersion = sbum.subject_unit_version,
                                                   deprtId = dm.department_id,
                                                   deprtCode = dm.department_code,
                                                   deprtName = dm.department_name,
                                                   isDemo = sbum.is_demo,
                                                   unit_orIdx = sbum.is_unit_or_index,
                                                   activDurDate = DateTime.Now,
                                                   activesubjdays = pm.package_duration_days,
                                                   released_On = sm.released_on,
                                                   user_ID = Userid,
                                                   is_updated_to_client = 1,
                                                   LastmodifiedOn = DateTime.Now,
                                                   LastClientUpdatedOn = DateTime.Now,
                                                   LastSubunitModifiedOn = DateTime.Now,
                                                   IsUpdatedSubunitToClient = 1,
                                                   LastSubunitClientUpdatedOn = DateTime.Now
                                               }).Distinct().ToList();
                                saveSubjct = saveSubjct.Union(saveSubjct1).Distinct().ToList();

                                //    user_subject_mapping delUSM = (from usm in contextsdce.user_subject_mapping
                                //                                   join ss in saveSubjct on usm.user_id equals ss.user_ID
                                //                                   where usm.subject_id == ss.subj_ID && usm.subject_unit_id == ss.subjUnit_ID
                                //                                   select usm).DefaultIfEmpty();
                                //contextsdce.user_subject_mapping.RemoveRange(contextsdce.user_subject_mapping.Where(c => c.user_id == userId));

                                foreach (var k in saveSubjct)
                                {
                                    user_subject_mapping usbm = new user_subject_mapping();

                                    usbm.subject_id = Convert.ToInt32(k.subj_ID);
                                    usbm.subject_code = k.sub_Code;
                                    usbm.subject_name = k.subj_Name;
                                    usbm.subject_cover_path = k.subj_CoverParth;
                                    usbm.subject_version = k.subj_Version;
                                    usbm.subject_unit_version = k.subjUnit_usrVersion;
                                    usbm.subject_unit_user_version = k.subjUnit_usrVersion;
                                    usbm.subject_unit_id = Convert.ToInt32(k.subjUnit_ID);
                                    usbm.subject_unit_code = k.subjUnit_code;
                                    usbm.subject_unit_name = k.subjUnit_Name;
                                    usbm.subject_unit_path = k.subjUnit_Path;
                                    usbm.is_demo = k.isDemo;
                                    usbm.department_code = k.deprtCode;
                                    usbm.department_name = k.deprtName;
                                    usbm.department_id = k.deprtId;
                                    usbm.is_unit_or_index = k.unit_orIdx;
                                    usbm.subject_purchasedon = DateTime.Now;
                                    usbm.downloaded_on = DateTime.Now;
                                    usbm.download_status = 1;
                                    usbm.user_id = k.user_ID;
                                    usbm.is_updated_to_client = 1;
                                    usbm.last_modified_on = k.LastmodifiedOn;
                                    usbm.last_client_updated_on = k.LastClientUpdatedOn;
                                    usbm.is_updated_subunit_to_client = k.IsUpdatedSubunitToClient;
                                    usbm.last_subunit_modified_on = k.LastSubunitModifiedOn;
                                    usbm.last_subunit_client_updated_on = k.LastSubunitClientUpdatedOn;
                                    DateTime actDuration = DateTime.Now.AddDays(k.activesubjdays);
                                    DateTime actSubjdays = DateTime.Now.AddDays(k.activesubjdays);
                                    usbm.subject_unit_expiryon = actSubjdays;
                                    usbm.package_expirydate = actSubjdays;
                                    contextsdce.user_subject_mapping.AddOrUpdate(u => new { u.user_id, u.subject_unit_id }, usbm);
                                }

                                int result = contextsdce.SaveChanges();
                                transaction.Commit();
                                //
                                message = "Your subject is activated. Thanks for purchasing";
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                Log.WriteLogMessage(PageName, "Student", "UpdateActivationCodeForPurchase", ex.Message, "error");
                                return ""; // Failure
                            }
                            finally
                            {
                                transaction.Dispose();
                                contextsdce.Dispose();
                            }
                        }
                    }
                    else
                    {
                        message = "Already your subject activated.Check updates in your client software.";
                    }
                }
                else
                {
                    message = "Please Check your Mobile number & Activation Code";
                }
                return message;
            }
        }

        /// <summary>
        /// Method For Get Activation Code Foom User To Activate Subjects
        /// </summary>
        /// <param name="activate_MobileNo"></param>
        /// <param name="buyer_Mobileno"></param>
        /// <param name="activationcode"></param>
        /// <returns></returns>
        public string UpdatePackageActivation(long activate_MobileNo, long buyer_Mobileno, string activationcode)
        {
            string message = "Please Enter Valid activation Code";
            List<purchase_activationmaster> ActivationKeys = new List<purchase_activationmaster>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                var User = (from um in contextsdce.user_master where um.mobile == activate_MobileNo select new { um.user_id, um.active_status }).First();
                if (User.user_id > 0 && User.active_status > 0)
                {
                    var ude = (from a in contextsdce.purchase_activationmaster
                               where a.buyer_mobileNo == buyer_Mobileno && a.activationcode == activationcode.ToUpper()
                               select a).FirstOrDefault();
                    if (ude != null)
                    {
                        if (ude.activationstatus == 0)
                        {
                            using (var transaction = contextsdce.Database.BeginTransaction())
                            {
                                try
                                {

                                    ude.activated_date = DateTime.Now;
                                    ude.activated_userid = User.user_id;
                                    ude.activationstatus = 2;
                                    int updatecon = contextsdce.SaveChanges();

                                    // map subjects once it activated

                                    /****** Query ****/
                                    //            select sm.subject_id
                                    //           ,subject_code
                                    //           ,subject_name
                                    //           ,subject_version
                                    //           ,subject_cover_path
                                    //           ,getdate()
                                    //           ,8676
                                    //           ,dm.department_id
                                    //           ,dm.department_code
                                    //           ,department_name
                                    //           ,1
                                    //           ,getdate()
                                    //           ,sbum.unit_id
                                    //           ,sbum.unit_code
                                    //           ,sbum.unit_name
                                    //           ,subject_unit_version
                                    //           ,sbum.subject_unit_version
                                    //           ,dateadd(d, pm.package_duration_days, getdate())

                                    //           ,is_demo
                                    //           ,is_unit_or_index
                                    //           ,subject_unit_path
                                    //		   ,1
                                    //           ,getdate()
                                    //           ,getdate()
                                    //           ,1
                                    //           ,getdate()
                                    //           ,1
                                    //           ,dateadd(d, pm.package_duration_days, getdate()) from user_subscribe_master usm
                                    //  join user_subscribe_details usd on usm.user_subscribe_master_id = usd.user_subscribe_master_id
                                    //  join package_master pm on usd.package_id = pm.package_id
                                    //  join department_master dm on pm.department_id = dm.department_id
                                    //  join subject_master sm on pm.subject_id = sm.subject_id
                                    //  join subject_unit_master sbum on sm.subject_id = sbum.subject_id
                                    //  where usm.user_subscribe_master_id = 133
                                    //and sm.active_status = 1 and sbum.active_status = 1 and pm.is_bundle = 0 and usm.payment_status = 1
                                    //and usm.TransactionType = 1


                                    List<saveSubjeDetails> saveSubjct = new List<saveSubjeDetails>();
                                    List<saveSubjeDetails> saveSubjct1 = new List<saveSubjeDetails>();
                                    saveSubjct = (from usm in contextsdce.user_subscribe_master
                                                  join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                  join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                                  join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                                  join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                                  join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                                  where usm.user_subscribe_master_id == ude.user_subscribed_masterid
                                                        && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                                  select new saveSubjeDetails
                                                  {
                                                      subj_ID = sm.subject_id,
                                                      sub_Code = sm.subject_code,
                                                      subj_Name = sm.subject_name,
                                                      subj_CoverParth = sm.subject_cover_path,
                                                      subj_Version = sm.subject_version,
                                                      subjUnit_ID = sbum.unit_id,
                                                      subjUnit_code = sbum.unit_code,
                                                      subjUnit_Name = sbum.unit_name,
                                                      subjUnit_Path = sbum.subject_unit_path,
                                                      subjUnit_version = sbum.subject_unit_version,
                                                      subjUnit_usrVersion = sbum.subject_unit_version,
                                                      deprtId = dm.department_id,
                                                      deprtCode = dm.department_code,
                                                      deprtName = dm.department_name,
                                                      isDemo = sbum.is_demo,
                                                      unit_orIdx = sbum.is_unit_or_index,
                                                      activesubjdays = pm.package_duration_days,
                                                      activDurDate = DateTime.Now,
                                                      released_On = sm.released_on,
                                                      user_ID = (int)User.user_id,
                                                      is_updated_to_client = 1,
                                                      LastmodifiedOn = DateTime.Now,
                                                      LastClientUpdatedOn = DateTime.Now,
                                                      LastSubunitModifiedOn = DateTime.Now,
                                                      IsUpdatedSubunitToClient = 1,
                                                      LastSubunitClientUpdatedOn = DateTime.Now
                                                  }).Distinct().ToList();

                                    saveSubjct1 = (from usm in contextsdce.user_subscribe_master
                                                   join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                   join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                                   join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                                   join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                                   join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                                   join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                                   where usm.user_subscribe_master_id == ude.user_subscribed_masterid
                                                         && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1
                                                   select new saveSubjeDetails
                                                   {
                                                       subj_ID = sm.subject_id,
                                                       sub_Code = sm.subject_code,
                                                       subj_Name = sm.subject_name,
                                                       subj_CoverParth = sm.subject_cover_path,
                                                       subj_Version = sm.subject_version,
                                                       subjUnit_ID = sbum.unit_id,
                                                       subjUnit_code = sbum.unit_code,
                                                       subjUnit_Name = sbum.unit_name,
                                                       subjUnit_Path = sbum.subject_unit_path,
                                                       subjUnit_version = sbum.subject_unit_version,
                                                       subjUnit_usrVersion = sbum.subject_unit_version,
                                                       deprtId = dm.department_id,
                                                       deprtCode = dm.department_code,
                                                       deprtName = dm.department_name,
                                                       isDemo = sbum.is_demo,
                                                       unit_orIdx = sbum.is_unit_or_index,
                                                       activDurDate = DateTime.Now,
                                                       activesubjdays = pm.package_duration_days,
                                                       released_On = sm.released_on,
                                                       user_ID = (int)User.user_id,
                                                       is_updated_to_client = 1,
                                                       LastmodifiedOn = DateTime.Now,
                                                       LastClientUpdatedOn = DateTime.Now,
                                                       LastSubunitModifiedOn = DateTime.Now,
                                                       IsUpdatedSubunitToClient = 1,
                                                       LastSubunitClientUpdatedOn = DateTime.Now
                                                   }).Distinct().ToList();
                                    saveSubjct = saveSubjct.Union(saveSubjct1).Distinct().ToList();
                                    foreach (var k in saveSubjct)
                                    {
                                        user_subject_mapping usbm = new user_subject_mapping();
                                        usbm.subject_id = (int)k.subj_ID;
                                        usbm.subject_code = k.sub_Code;
                                        usbm.subject_name = k.subj_Name;
                                        usbm.subject_cover_path = k.subj_CoverParth;
                                        usbm.subject_version = k.subj_Version;
                                        usbm.subject_unit_version = k.subjUnit_usrVersion;
                                        usbm.subject_unit_user_version = k.subjUnit_usrVersion;
                                        usbm.subject_unit_id = (int)k.subjUnit_ID;
                                        usbm.subject_unit_code = k.subjUnit_code;
                                        usbm.subject_unit_name = k.subjUnit_Name;
                                        usbm.subject_unit_path = k.subjUnit_Path;
                                        usbm.is_demo = k.isDemo;
                                        usbm.department_code = k.deprtCode;
                                        usbm.department_name = k.deprtName;
                                        usbm.department_id = k.deprtId;
                                        usbm.is_unit_or_index = k.unit_orIdx;
                                        usbm.subject_purchasedon = DateTime.Now;
                                        usbm.downloaded_on = DateTime.Now;
                                        usbm.download_status = 1;
                                        usbm.user_id = k.user_ID;
                                        usbm.is_updated_to_client = 1;
                                        usbm.last_modified_on = k.LastmodifiedOn;
                                        usbm.last_client_updated_on = k.LastClientUpdatedOn;
                                        usbm.is_updated_subunit_to_client = k.IsUpdatedSubunitToClient;
                                        usbm.last_subunit_modified_on = k.LastSubunitModifiedOn;
                                        usbm.last_subunit_client_updated_on = k.LastSubunitClientUpdatedOn;
                                        DateTime actDuration = DateTime.Now.AddDays(k.activesubjdays);
                                        DateTime actSubjdays = DateTime.Now.AddDays(k.activesubjdays);
                                        usbm.subject_unit_expiryon = actSubjdays;
                                        usbm.package_expirydate = actSubjdays;
                                        contextsdce.user_subject_mapping.Add(usbm);
                                    }

                                    int result = contextsdce.SaveChanges();
                                    transaction.Commit();
                                    //
                                    message = "Your subject is activated. Thanks for purchasing";
                                }

                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    transaction.Dispose();
                                    contextsdce.Dispose();
                                    Log.WriteLogMessage(PageName, "Student", "UpdateActivationCodeForPurchase", ex.Message, "error");
                                    return ""; // Failure
                                }
                                finally
                                {
                                    transaction.Dispose();
                                    contextsdce.Dispose();
                                }
                            }
                        }
                        else
                        {
                            message = "Already your subject activated.Check updates in your client software.";
                        }
                    }
                    else
                    {
                        message = "Check your Mobile number & Activation Code";
                    }
                }
                else if (User.active_status == 0)
                {
                    message = "Activated Mobile number is not yet activated";
                }
                else
                {
                    message = "Check your Activated Mobile number ";
                }
            }
            return message;
        }

        /// <summary>
        /// Method For Get OTP From User To Register
        /// </summary>
        /// <param name="mobileNo"></param>
        /// <param name="ToEmailID"></param>
        /// <returns></returns>
        public string Registration_Conformation(long mobileNo, string ToEmailID)
        {
            string message = "";
            CallSendSMS ob = new CallSendSMS();
            //generate OTP and Email
            //send SMS to the User With Activation Code
            string OTP = GenerateVerificationCode(mobileNo, ToEmailID);
            ob.SendSMS(mobileNo + "", ob.SMS_RegistrationConformation(OTP), "");

            //Send Mail to User About his Activaiton Code
            string mailcontent = MailHelper.EmailBody_OTP("user Account Detailes", mobileNo + "", OTP, "");
            MailHelper.SendMail(ToEmailID, "Learnengg - User Activation Code (OTP)", mailcontent);
            message = OTP;
            return message;
        }

        /// <summary>
        ///Method To save subjects for new user after verification
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string SaveUserSubjectDetails(int userid)
        {
            List<saveSubjeDetails> saveSubjct = new List<saveSubjeDetails>();
            int result = 0;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    saveSubjct = (from sm in contextsdce.subject_master
                                  join dsm in contextsdce.department_subject_mapping on sm.subject_id equals dsm.subject_id
                                  join um in contextsdce.user_master on sm.UniversityID equals um.univ_id
                                  join dm in contextsdce.department_master on dsm.department_id equals dm.department_id
                                  join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                  join roltyp in contextsdce.user_role on um.role_id equals roltyp.role_id
                                  where um.user_id == userid && sm.active_status == 1 && sbum.active_status == 1
                                  && um.DepartmentID == dm.department_id
                                  select new saveSubjeDetails
                                  {
                                      subj_ID = sm.subject_id,
                                      sub_Code = sm.subject_code,
                                      subj_Name = sm.subject_name,
                                      subj_CoverParth = sm.subject_cover_path,
                                      subj_Version = sm.subject_version,
                                      subjUnit_ID = sbum.unit_id,
                                      subjUnit_code = sbum.unit_code,
                                      subjUnit_Name = sbum.unit_name,
                                      subjUnit_Path = sbum.subject_unit_path,
                                      subjUnit_version = sbum.subject_unit_version,
                                      subjUnit_usrVersion = sbum.subject_unit_version,
                                      deprtId = dm.department_id,
                                      deprtCode = dm.department_code,
                                      deprtName = dm.department_name,
                                      isDemo = sbum.is_demo,
                                      unit_orIdx = sbum.is_unit_or_index,
                                      activDurDate = sm.active_duration_date,
                                      activesubjdays = roltyp.active_subject_days,
                                      released_On = sm.released_on,
                                      user_ID = userid,
                                      is_updated_to_client = 1,
                                      LastmodifiedOn = DateTime.Now,
                                      LastClientUpdatedOn = DateTime.Now,
                                      LastSubunitModifiedOn = DateTime.Now,
                                      IsUpdatedSubunitToClient = 1,
                                      LastSubunitClientUpdatedOn = DateTime.Now
                                  }).Distinct().ToList();

                    foreach (var k in saveSubjct)
                    {
                        user_subject_mapping usbm = new user_subject_mapping();

                        usbm.subject_id = Convert.ToInt32(k.subj_ID);
                        usbm.subject_code = k.sub_Code;
                        usbm.subject_name = k.subj_Name;
                        usbm.subject_cover_path = k.subj_CoverParth;
                        usbm.subject_version = k.subj_Version;
                        usbm.subject_unit_version = k.subjUnit_usrVersion;
                        usbm.subject_unit_user_version = k.subjUnit_usrVersion;
                        usbm.subject_unit_id = Convert.ToInt32(k.subjUnit_ID);
                        usbm.subject_unit_code = k.subjUnit_code;
                        usbm.subject_unit_name = k.subjUnit_Name;
                        usbm.subject_unit_path = k.subjUnit_Path;
                        usbm.is_demo = k.isDemo;
                        usbm.department_code = k.deprtCode;
                        usbm.department_name = k.deprtName;
                        usbm.department_id = k.deprtId;
                        usbm.is_unit_or_index = k.unit_orIdx;
                        usbm.subject_purchasedon = DateTime.Now;
                        usbm.downloaded_on = DateTime.Now;
                        usbm.download_status = 1;
                        usbm.user_id = k.user_ID;
                        usbm.is_updated_to_client = 1;
                        usbm.last_modified_on = k.LastmodifiedOn;
                        usbm.last_client_updated_on = k.LastClientUpdatedOn;
                        usbm.is_updated_subunit_to_client = k.IsUpdatedSubunitToClient;
                        usbm.last_subunit_modified_on = k.LastSubunitModifiedOn;
                        usbm.last_subunit_client_updated_on = k.LastSubunitClientUpdatedOn;

                        DateTime actDuration = k.activDurDate;
                        DateTime actSubjdays = DateTime.Now.AddDays(k.activesubjdays);
                        usbm.package_expirydate = DateTime.Now.AddDays(-1);
                        usbm.subject_unit_expiryon = DateTime.Now.AddDays(-1);
                        usbm.subject_trial_expiryon = DateTime.Now.AddDays(-1);
                        //if (actDuration > actSubjdays)
                        //{
                        //    usbm.subject_unit_expiryon = actSubjdays;
                        //    usbm.package_expirydate = actSubjdays;
                        //}
                        //else
                        //{
                        //    usbm.subject_unit_expiryon = actDuration;
                        //    usbm.package_expirydate = actDuration;
                        //}
                        contextsdce.user_subject_mapping.Add(usbm);
                    }

                    result = contextsdce.SaveChanges();

                    if (result > 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "-1";
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "ManageSubjects", "SaveUserSubjectDetails", ex.Message, "error");
                    contextsdce.Dispose();
                    throw ex;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Method For check the verification code(OTP) from the user using OTP code For Order Placed Conformation
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="otpCode"></param>
        /// <returns></returns>

        public string OTP_CodeVerification(int userId, string otpCode)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var codeVerification = (from randomcode in contextsdce.user_random_pass
                                            where randomcode.user_id == userId && randomcode.verification_code == otpCode
                                            select randomcode);

                    if (codeVerification.Any() == true)
                    {
                        var userUpdate = (from user_update in contextsdce.user_master
                                          where user_update.user_id == userId
                                          select user_update).FirstOrDefault();

                        userUpdate.is_first_login = 1;
                        userUpdate.active_status = 1;
                        contextsdce.SaveChanges();

                        //subject mapping for activated user
                        // SaveUserSubjectDetails(userId);

                        return "1";
                    }
                    else
                    {
                        return "-1";
                    }
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "StudentService", "OTP_CodeVerification", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }


        //3) purchase -> COD time get activation code to get a conformation....
        /// <summary>
        /// Method For Send OTP To User For Order Placed Conformation
        /// </summary>
        /// <param name="buyer_mobileNo"></param>
        /// <param name="ToEmailID"></param>
        /// <returns></returns>

        public string COD_Conformation(long buyer_mobileNo, string ToEmailID)
        {
            string message = "";
            CallSendSMS ob = new CallSendSMS();
            //generate OTP and Email
            //send SMS to the User With Activation Code
            string OTP = GenerateVerificationCode(buyer_mobileNo, ToEmailID);
            ob.SendSMS(buyer_mobileNo + "", ob.SMS_orderConformation(OTP), "");

            //Send Mail to User About his Activaiton Code
            string mailcontent = MailHelper.EmailBody_OTP("Order Conformation", buyer_mobileNo + "", OTP, "");
            MailHelper.SendMail(ToEmailID, "Learnengg - Order confirmation one time password", mailcontent);
            message = OTP;
            return message;
        }


        //5) send SMS and Email once product is couriered

        /// <summary>
        ///  Method For Send Sms And E-Mail Order Shipped Details To User
        /// </summary>
        /// <param name="buyer_mobileNo"></param>
        /// <param name="ToEmailID"></param>
        /// <param name="orderID"></param>
        /// <param name="TrackingID"></param>
        /// <returns></returns>
        public string OrderShipped(string buyer_mobileNo, string ToEmailID, string orderID, string TrackingID)
        {
            string message = "";
            CallSendSMS ob = new CallSendSMS();
            //generate OTP and Email
            //send SMS to the User With Activation Code

            ob.SendSMS(buyer_mobileNo + "", ob.SMS_OrderDelivery(orderID, TrackingID), "");

            //Send Mail to User About his Activaiton Code //changes available
            // attach order copy
            string mailcontent = MailHelper.EmailBody_OrderShipped(orderID, TrackingID);
            MailHelper.SendMail(ToEmailID, "Learnengg - Order Has Shipped", mailcontent);
            return message;
        }

        // 7) send SMS and Email to get OTP for Cancellation process
        /// <summary>
        /// Method For Send OTP To User For Conform Cancellation
        /// </summary>
        /// <param name="buyer_mobileNo"></param>
        /// <param name="ToEmailID"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public string COD_Cancellation(long buyer_mobileNo, string ToEmailID, string OrderID)
        {
            string message = "";
            CallSendSMS ob = new CallSendSMS();
            //generate OTP and Email
            //send SMS to the User With Activation Code
            string OTP = GenerateVerificationCode(buyer_mobileNo, ToEmailID);
            ob.SendSMS(buyer_mobileNo + "", ob.SMS_orderCancellation_otp(OrderID, OTP), "");

            //Send Mail to User About his Activaiton Code
            string mailcontent = MailHelper.EmailBody_OTP("order Cancellation", buyer_mobileNo + "", OTP, "");
            MailHelper.SendMail(ToEmailID, "Learnengg - Order Cancellation one time password", mailcontent);
            message = OTP;
            return message;
        }

        // 7) send SMS and Email to get OTP for Cancellation process

        /// <summary>
        ///  Method For Get OTP Verification from User  
        /// </summary>
        /// <param name="buyer_mobileNo"></param>
        /// <param name="ToEmailID"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public string COD_Cancellation_approved(long buyer_mobileNo, string ToEmailID, string OrderID)
        {
            string message = "";
            CallSendSMS ob = new CallSendSMS();

            //  ob.SendSMS(buyer_mobileNo + "", ob.SMS_orderCancellationApprove(OrderID), "");

            //Send Mail to User About his Activaiton Code
            string mailcontent = MailHelper.EmailBody_Ordercancelled(OrderID);
            MailHelper.SendMail(ToEmailID, "Learnengg - Order Cancellation Approved", mailcontent, ConfigurationManager.AppSettings["CancelOrderBCC"].ToString());
            return message;
        }

        /// <summary>
        ///  Method For Get College List
        /// </summary>
        /// <param name="univId"></param>
        /// <returns></returns>
        public List<UserRegistraion> LoadCollegeList(int univId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<UserRegistraion> collegelist = new List<UserRegistraion>();
                try
                {
                    collegelist = contextsdce.college_master.Where(x => x.university_id == univId)
                        .Select(x => new UserRegistraion
                        {
                            college_Id = x.college_id,
                            college_Name = x.college_name

                        }).ToList();

                    return collegelist;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Student", "LoadCollegeList", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        /// <summary>
        /// Method For Get Department List
        /// </summary>
        /// <param name="univId"></param>
        /// <returns></returns>
        public List<UserRegistraion> LoadDepartmentList(int univId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<UserRegistraion> departmentlist = new List<UserRegistraion>();
                try
                {
                    departmentlist = contextsdce.department_master.Where(x => x.UniversityID == univId && (x.department_id < 15 || x.department_id > 18)
                                  && x.active_status == 1 && x.department_id != 2)
                        .Select(x => new UserRegistraion
                        {
                            department_Id = x.department_id,
                            department_Name = x.department_name

                        }).ToList();
                    return departmentlist;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Student", "LoadDepartmentList", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        /// <summary>
        ///  Method For Update Trial Product To Online Users
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="packageid"></param>
        /// <returns></returns>
        public string UpdateTrailPackageOnline(int userid, int packageid)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {


                    //previous 

                    //List<saveSubjeDetails> saveSubjct = new List<saveSubjeDetails>();

                    //var savedSubjct = (from pm in contextsdce.package_master
                    //                   join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                    //                   join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                    //                   join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                    //                   join usm in contextsdce.user_subject_mapping on sbum.unit_id equals usm.subject_unit_id
                    //                   where sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0 && pm.package_id == packageid
                    //                   && pm.subject_unit_type == sbum.subject_unit_type && usm.user_id == userid
                    //                   select usm
                    //                  ).ToList();
                    //savedSubjct.ForEach(p => p.subject_trial_expiryon = DateTime.Now.AddDays(7));
                    //savedSubjct.ForEach(p => p.is_trial = 1);
                    //int result = 0;
                    //result = contextsdce.SaveChanges();

                    var isExist = (from pm in contextsdce.package_master
                                   join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                   join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                   join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                   join usm in contextsdce.user_subject_mapping on sbum.unit_id equals usm.subject_unit_id
                                   where sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0 && pm.package_id == packageid
                                   && pm.subject_unit_type == sbum.subject_unit_type && usm.user_id == userid && pm.is_offer_package == 1 && usm.is_trial != 1
                                   select usm
                                      ).ToList();

                    //var isExist1 = (from pm in contextsdce.package_master
                    //               join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                    //               join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                    //               join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                    //               join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                    //               join usm in contextsdce.user_subject_mapping on sbum.unit_id equals usm.subject_unit_id
                    //               where sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1 && pm.package_id == packageid
                    //               && pm.subject_unit_type == sbum.subject_unit_type && usm.user_id == userid && usm.is_trial != 1
                    //               select usm
                    //                  ).ToList();
                    //isExist= isExist.Union(isExist1).Distinct().ToList();

                    if (isExist.Any())
                    {
                        isExist.ForEach(p => p.subject_trial_expiryon = DateTime.Now.AddDays(6));
                        isExist.ForEach(p => p.is_trial = 1);
                        isExist.ForEach(p => p.last_subunit_modified_on = DateTime.Now);
                    }
                    else
                    {
                        List<saveSubjeDetails> saveSubjct = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct1 = new List<saveSubjeDetails>();
                        saveSubjct = (from pm in contextsdce.package_master
                                      join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                      join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                      join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                      where pm.package_id == packageid
                                            && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                            && pm.subject_unit_type == sbum.subject_unit_type && pm.is_offer_package == 1
                                      select new saveSubjeDetails
                                      {
                                          subj_ID = sm.subject_id,
                                          sub_Code = sm.subject_code,
                                          subj_Name = sm.subject_name,
                                          subj_CoverParth = sm.subject_cover_path,
                                          subj_Version = sm.subject_version,
                                          subjUnit_ID = sbum.unit_id,
                                          subjUnit_code = sbum.unit_code,
                                          subjUnit_Name = sbum.unit_name,
                                          subjUnit_Path = sbum.subject_unit_path,
                                          subjUnit_version = sbum.subject_unit_version,
                                          subjUnit_usrVersion = sbum.subject_unit_version,
                                          deprtId = dm.department_id,
                                          deprtCode = dm.department_code,
                                          deprtName = dm.department_name,
                                          isDemo = sbum.is_demo,
                                          unit_orIdx = sbum.is_unit_or_index,
                                          activesubjdays = pm.package_duration_days,
                                          activDurDate = DateTime.Now,
                                          released_On = sm.released_on,
                                          user_ID = userid,
                                          is_updated_to_client = 1,
                                          LastmodifiedOn = DateTime.Now,
                                          LastClientUpdatedOn = DateTime.Now,
                                          LastSubunitModifiedOn = DateTime.Now,
                                          IsUpdatedSubunitToClient = 1,
                                          LastSubunitClientUpdatedOn = DateTime.Now,
                                          YearSem = pm.semester
                                      }).Distinct().ToList();


                        var distinctSubjects = saveSubjct.Select(m => new { m.user_ID, m.subj_ID }).Distinct().FirstOrDefault();
                        user_trial_subject uts = new user_trial_subject();
                        uts.user_id = distinctSubjects.user_ID;
                        uts.subject_id = distinctSubjects.subj_ID;
                        uts.created_on = DateTime.Now;
                        uts.trail_expiry_on = DateTime.Now.AddDays(6);
                        contextsdce.user_trial_subject.Add(uts);

                        //saveSubjct1 = (from pm in contextsdce.package_master
                        //               join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                        //               join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                        //               join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                        //               join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                        //               where pm.package_id == packageid
                        //                     && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1
                        //                     && pm.subject_unit_type == sbum.subject_unit_type
                        //               select new saveSubjeDetails
                        //               {
                        //                   subj_ID = sm.subject_id,
                        //                   sub_Code = sm.subject_code,
                        //                   subj_Name = sm.subject_name,
                        //                   subj_CoverParth = sm.subject_cover_path,
                        //                   subj_Version = sm.subject_version,
                        //                   subjUnit_ID = sbum.unit_id,
                        //                   subjUnit_code = sbum.unit_code,
                        //                   subjUnit_Name = sbum.unit_name,
                        //                   subjUnit_Path = sbum.subject_unit_path,
                        //                   subjUnit_version = sbum.subject_unit_version,
                        //                   subjUnit_usrVersion = sbum.subject_unit_version,
                        //                   deprtId = dm.department_id,
                        //                   deprtCode = dm.department_code,
                        //                   deprtName = dm.department_name,
                        //                   isDemo = sbum.is_demo,
                        //                   unit_orIdx = sbum.is_unit_or_index,
                        //                   activDurDate = DateTime.Now,
                        //                   activesubjdays = pm.package_duration_days,
                        //                   released_On = sm.released_on,
                        //                   user_ID = userid,
                        //                   is_updated_to_client = 1,
                        //                   LastmodifiedOn = DateTime.Now,
                        //                   LastClientUpdatedOn = DateTime.Now,
                        //                   LastSubunitModifiedOn = DateTime.Now,
                        //                   IsUpdatedSubunitToClient = 1,
                        //                   LastSubunitClientUpdatedOn = DateTime.Now,
                        //                   YearSem = pm.semester
                        //               }).Distinct().ToList();
                        //saveSubjct = saveSubjct.Union(saveSubjct1).Distinct().ToList();


                        foreach (var k in saveSubjct)
                        {
                            user_subject_mapping usbm = new user_subject_mapping();
                            usbm.subject_id = (int)k.subj_ID;
                            usbm.subject_code = k.sub_Code;
                            usbm.subject_name = k.subj_Name;
                            usbm.subject_cover_path = k.subj_CoverParth;
                            usbm.subject_version = k.subj_Version;
                            usbm.subject_unit_version = k.subjUnit_usrVersion;
                            usbm.subject_unit_user_version = k.subjUnit_usrVersion;
                            usbm.subject_unit_id = (int)k.subjUnit_ID;
                            usbm.subject_unit_code = k.subjUnit_code;
                            usbm.subject_unit_name = k.subjUnit_Name;
                            usbm.subject_unit_path = k.subjUnit_Path;
                            usbm.is_demo = k.isDemo;
                            usbm.department_code = k.deprtCode;
                            usbm.department_name = k.deprtName;
                            usbm.department_id = k.deprtId;
                            usbm.is_unit_or_index = k.unit_orIdx;
                            usbm.subject_purchasedon = DateTime.Now;
                            usbm.downloaded_on = DateTime.Now;
                            usbm.download_status = 1;
                            usbm.user_id = k.user_ID;
                            usbm.is_updated_to_client = 1;
                            usbm.last_modified_on = k.LastmodifiedOn;
                            usbm.last_client_updated_on = k.LastClientUpdatedOn;
                            usbm.is_updated_subunit_to_client = k.IsUpdatedSubunitToClient;
                            usbm.last_subunit_modified_on = k.LastSubunitModifiedOn;
                            usbm.last_subunit_client_updated_on = k.LastSubunitClientUpdatedOn;
                            usbm.subject_unit_expiryon = DateTime.Now.AddDays(-1);
                            usbm.package_expirydate = DateTime.Now.AddDays(-1);
                            usbm.subject_trial_expiryon = DateTime.Now.AddDays(6);
                            usbm.is_trial = 1;
                            usbm.is_purchased = 0;
                            usbm.yearsem = k.YearSem;
                            //  contextsdce.user_subject_mapping.Add(usbm);
                            contextsdce.user_subject_mapping.AddOrUpdate(u => new { u.user_id, u.subject_unit_id }, usbm);
                        }

                    }
                    int result = contextsdce.SaveChanges();
                    if (result > 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "-1";
                    }

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Student", "UpdateTrailPackageOnline", ex.Message, "error");
                    //  throw ex;
                    return "0";
                }
                finally
                {
                    contextsdce.Dispose();
                }

            }
        }


        /// <summary>
        /// QustionAnsAndroidApp based on univeristy 
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        public List<QPAndroidApp> QustionAnsAndroidApp(int universityId, int userId)
        {
            List<QPAndroidApp> androidapp = new List<QPAndroidApp>();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    if (universityId == 0)
                    {
                        var univMaster = (from um in contextsdce.university_master select um).FirstOrDefault();
                        universityId = univMaster.univ_id;
                    }
                    if (userId == 0)
                    {
                        var android = (from pm in contextsdce.package_master
                                       join unvm in contextsdce.university_master on pm.univ_id equals unvm.univ_id
                                       where pm.univ_id == universityId && pm.activestatus == 1 && pm.os_type == 2
                                       group new { unvm, pm } by pm.semester into pack
                                       select new { semes = pack.Key, packageDetail = pack });



                        foreach (var app in android)
                        {
                            QPAndroidApp qp = new QPAndroidApp();
                            qp.Semester = app.semes;

                            List<QPAndroidAppDetails> QouterAlistF = new List<QPAndroidAppDetails>();
                            foreach (var t in app.packageDetail)
                            {
                                qp.UniversityName = t.unvm.university_name;
                                qp.UniversityId = t.unvm.univ_id;

                                QPAndroidAppDetails qpd = new QPAndroidAppDetails();
                                qpd.PackageId = t.pm.package_id;
                                qpd.PackageName = t.pm.package_name;
                                qpd.SellingPrice = t.pm.selling_price == 0 ? "FREE"  : "" + t.pm.selling_price;
                                qpd.ActualPrice = t.pm.actual_price;
                                QouterAlistF.Add(qpd);
                                qp.QPOuterlist = QouterAlistF;
                            }
                            androidapp.Add(qp);
                        }
                    }
                    else
                    {

                        var android = (from pm in contextsdce.package_master
                                       join unvm in contextsdce.university_master on pm.univ_id equals unvm.univ_id
                                       join ucd in contextsdce.user_cart_details on pm.package_id equals ucd.package_id into ucad
                                       from ucdlft in ucad.Where(ucad => ucad.user_id == userId).DefaultIfEmpty()
                                       where pm.univ_id == universityId && pm.activestatus == 1 && pm.os_type == 2
                                       group new { unvm, pm, ucdlft } by pm.semester into pack
                                       select new { semes = pack.Key, packageDetail = pack });



                        foreach (var app in android)
                        {
                            QPAndroidApp qp = new QPAndroidApp();
                            qp.Semester = app.semes;

                            List<QPAndroidAppDetails> QouterAlistF = new List<QPAndroidAppDetails>();
                            foreach (var t in app.packageDetail)
                            {
                                qp.UniversityName = t.unvm.university_name;
                                qp.UniversityId = t.unvm.univ_id;

                                QPAndroidAppDetails qpd = new QPAndroidAppDetails();
                                qpd.PackageId = t.pm.package_id;
                                qpd.PackageName = t.pm.package_name;
                                qpd.SellingPrice = t.pm.selling_price == 0 ? "FREE" : "" + t.pm.selling_price;
                                qpd.ActualPrice = t.pm.actual_price;
                                qpd.IsAddedTocart = t.ucdlft == null ? "no" : t.ucdlft.package_id.ToString() == t.pm.package_id.ToString() ? "yes" : "no";
                                QouterAlistF.Add(qpd);
                                qp.QPOuterlist = QouterAlistF;
                            }
                            androidapp.Add(qp);
                        }

                    }
                    return androidapp;

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "StudentService", "QustionAnsAndroidApp", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }


        public List<yearsemOnDeptID> GetYearSemesterByDepartID(int PDepartID)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<yearsemOnDeptID> semyearbyDept = new List<yearsemOnDeptID>();
                try
                {

                    semyearbyDept = (from yearq in contextsdce.department_master
                                     where yearq.department_id == PDepartID

                                     select new yearsemOnDeptID
                                     {
                                         totyear = yearq.no_of_year,
                                         maxsemester = yearq.max_semester_per_year

                                     }).ToList();
                    return semyearbyDept;

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "Studentservice", "GetYearSemesterByDepartID", ex.Message, "error");

                    // return jsSerializer.Serialize("No Year Semester Available For thsi Department");
                    return semyearbyDept;
                }
            }
        }

        public List<UserDetails> GetUserDetails(int studentId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    List<UserDetails> userDetails = new List<UserDetails>();
                    EncryptionDecryption encrypt = new EncryptionDecryption();
                    userDetails = (from um in contextsdce.user_master
                                   join dm in contextsdce.department_master on um.DepartmentID equals dm.department_id
                                   join usr in contextsdce.user_role on um.role_id equals usr.role_id
                                   join univ in contextsdce.university_master on um.univ_id equals univ.univ_id
                                   where um.user_id == studentId
                                   select new UserDetails
                                   {
                                       userid = um.user_id,
                                       studentName = um.user_name,
                                       DepartmentID = um.DepartmentID,
                                       DeptName = dm.department_name,
                                       studentPasswrod = um.password,
                                       mobileNo = um.mobile,
                                       emailID = um.email_id,
                                       roleType = usr.role_type,
                                       collegeName = um.collegename,
                                       Year = um.currentyear,
                                       semester = um.currentsemester,
                                       collegeID = um.collegeid,
                                       Univname = univ.university_name,
                                       password = um.password,
                                       ProfileImg = um.profileimage
                                   }).ToList();


                    userDetails.ForEach(s => { s.password = encrypt.Decryptpwd(s.password, true); });

                    return userDetails;

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "Student Service", "GetUserDetails", ex.Message, "error");
                    throw ex;
                }
            }
        }
        /// <summary>
        /// save user profile image to database
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ImageName"></param>
        /// <returns></returns>
        public string UpdateUserProfileImage(Int64 UserID, string ImageName)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var userImg = (from um in contextsdce.user_master where um.user_id == UserID select um).FirstOrDefault();
                    userImg.profileimage = ImageName;
                    int result = contextsdce.SaveChanges();
                    return "1";
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "ProfileUpdate", "UpdateUserProfileImage", ex.Message, "error");
                    throw;
                }
            }

        }


        public string UpdatePackagesWithoutPayment(long UserId, long PackageId)
        {
            string message = "0";
            List<purchase_activationmaster> ActivationKeys = new List<purchase_activationmaster>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                using (var transaction = contextsdce.Database.BeginTransaction())
                {
                    try
                    {

                        // map subjects once it activated

                        List<saveSubjeDetails> saveSubjct = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct1 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct2 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct3 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct4 = new List<saveSubjeDetails>();
                        saveSubjct1 = (from
                                        pm in contextsdce.package_master
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where pm.package_id == PackageId
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                             && pm.subject_unit_type == sbum.subject_unit_type && pm.subject_unit_type != 3
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activesubjdays = pm.package_duration_days,
                                           activDurDate = DateTime.Now,
                                           released_On = sm.released_on,
                                           user_ID = (int)UserId,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        string[] subjectunittype = { "1", "2" };
                        saveSubjct2 = (from pm in contextsdce.package_master
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where pm.package_id == PackageId
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                             && pm.subject_unit_type == 3 && subjectunittype.Contains(sbum.subject_unit_type.ToString())
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activesubjdays = pm.package_duration_days,
                                           activDurDate = DateTime.Now,
                                           released_On = sm.released_on,
                                           user_ID = (int)UserId,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        saveSubjct3 = (from pm in contextsdce.package_master
                                       join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where pm.package_id == PackageId
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1
                                             && pm.subject_unit_type == sbum.subject_unit_type && pm.subject_unit_type != 3
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activDurDate = DateTime.Now,
                                           activesubjdays = pm.package_duration_days,
                                           released_On = sm.released_on,
                                           user_ID = (int)UserId,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();


                        saveSubjct4 = (from pm in contextsdce.package_master
                                       join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where pm.package_id == PackageId
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1
                                             && subjectunittype.Contains(sbum.subject_unit_type.ToString()) && pm.subject_unit_type == 3
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activDurDate = DateTime.Now,
                                           activesubjdays = pm.package_duration_days,
                                           released_On = sm.released_on,
                                           user_ID = (int)UserId,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        saveSubjct = saveSubjct.Union(saveSubjct1).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct2).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct3).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct4).Distinct().ToList();
                        foreach (var k in saveSubjct)
                        {
                            user_subject_mapping usbm = new user_subject_mapping();
                            usbm.subject_id = (int)k.subj_ID;
                            usbm.subject_code = k.sub_Code;
                            usbm.subject_name = k.subj_Name;
                            usbm.subject_cover_path = k.subj_CoverParth;
                            usbm.subject_version = k.subj_Version;
                            usbm.subject_unit_version = k.subjUnit_usrVersion;
                            usbm.subject_unit_user_version = k.subjUnit_usrVersion;
                            usbm.subject_unit_id = (int)k.subjUnit_ID;
                            usbm.subject_unit_code = k.subjUnit_code;
                            usbm.subject_unit_name = k.subjUnit_Name;
                            usbm.subject_unit_path = k.subjUnit_Path;
                            usbm.is_demo = k.isDemo;
                            usbm.department_code = k.deprtCode;
                            usbm.department_name = k.deprtName;
                            usbm.department_id = k.deprtId;
                            usbm.is_unit_or_index = k.unit_orIdx;
                            usbm.subject_purchasedon = DateTime.Now;
                            usbm.downloaded_on = DateTime.Now;
                            usbm.download_status = 1;
                            usbm.user_id = k.user_ID;
                            usbm.is_updated_to_client = 1;
                            usbm.last_modified_on = k.LastmodifiedOn;
                            usbm.last_client_updated_on = k.LastClientUpdatedOn;
                            usbm.is_updated_subunit_to_client = k.IsUpdatedSubunitToClient;
                            usbm.last_subunit_modified_on = k.LastSubunitModifiedOn;
                            usbm.last_subunit_client_updated_on = k.LastSubunitClientUpdatedOn;
                            DateTime actDuration = DateTime.Now.AddDays(k.activesubjdays);
                            DateTime actSubjdays = DateTime.Now.AddDays(k.activesubjdays);
                            usbm.subject_unit_expiryon = actSubjdays;
                            usbm.package_expirydate = actSubjdays;
                            usbm.is_purchased = 1;
                            usbm.yearsem = k.YearSem;
                            //  contextsdce.user_subject_mapping.Add(usbm);
                            contextsdce.user_subject_mapping.AddOrUpdate(u => new { u.user_id, u.subject_unit_id }, usbm);
                        }

                        int result = contextsdce.SaveChanges();
                        transaction.Commit();
                        //
                        return "1";

                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message1 = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message1, raise);
                                Log.WriteLogMessage(PageName, "Student", "UpdatePackagesWithoutPayment", message1, "error");
                            }
                        }
                        Log.WriteLogMessage(PageName, "Student", "UpdatePackagesWithoutPayment", raise.Message.ToString(), "error");
                        // throw raise;
                        return "";
                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        contextsdce.Dispose();
                        Log.WriteLogMessage(PageName, "Student", "UpdatePackagesWithoutPayment", ex.Message, "error");
                        return ""; // Failure
                    }

                    finally
                    {
                        transaction.Dispose();
                        contextsdce.Dispose();
                    }
                }
            }
        }


        public string UpdatePackagesWithoutPaymentforSemester(long UserId, long univ_id, int subject_unit_type, int semester, int rule_id)
        {
            string message = "0";
            List<purchase_activationmaster> ActivationKeys = new List<purchase_activationmaster>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                using (var transaction = contextsdce.Database.BeginTransaction())
                {
                    try
                    {

                        // map subjects once it activated

                        List<saveSubjeDetails> saveSubjct = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct1 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct2 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct3 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct4 = new List<saveSubjeDetails>();
                        saveSubjct1 = (from
                                        pm in contextsdce.package_master
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where pm.univ_id == sm.UniversityID && pm.univ_id == univ_id && pm.semester == semester && pm.is_offer_package == 2
                                             && pm.rule_id == sm.rule_id && pm.rule_id == rule_id
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                             && pm.subject_unit_type == sbum.subject_unit_type && pm.subject_unit_type != 3 && pm.subject_unit_type == subject_unit_type
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activesubjdays = pm.package_duration_days,
                                           activDurDate = DateTime.Now,
                                           released_On = sm.released_on,
                                           user_ID = (int)UserId,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        string[] subjectunittype = { "1", "2" };
                        saveSubjct2 = (from pm in contextsdce.package_master
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where pm.univ_id == sm.UniversityID && pm.univ_id == univ_id && pm.semester == semester && pm.is_offer_package == 2
                                             && pm.rule_id == sm.rule_id && pm.rule_id == rule_id
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                             && pm.subject_unit_type == 3 && subjectunittype.Contains(sbum.subject_unit_type.ToString()) && pm.subject_unit_type == subject_unit_type
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activesubjdays = pm.package_duration_days,
                                           activDurDate = DateTime.Now,
                                           released_On = sm.released_on,
                                           user_ID = (int)UserId,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        saveSubjct3 = (from pm in contextsdce.package_master
                                       join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where pm.univ_id == sm.UniversityID && pm.univ_id == univ_id && pm.semester == semester && sm.rule_id == rule_id && pm.is_offer_package == 2
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1
                                             && pm.subject_unit_type == sbum.subject_unit_type && pm.subject_unit_type != 3 && pm.subject_unit_type == subject_unit_type
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activDurDate = DateTime.Now,
                                           activesubjdays = pm.package_duration_days,
                                           released_On = sm.released_on,
                                           user_ID = (int)UserId,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();


                        saveSubjct4 = (from pm in contextsdce.package_master
                                       join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where pm.univ_id == sm.UniversityID && pm.univ_id == univ_id && pm.semester == semester && sm.rule_id == rule_id && pm.is_offer_package == 2
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1
                                             && subjectunittype.Contains(sbum.subject_unit_type.ToString()) && pm.subject_unit_type == 3 && pm.subject_unit_type == subject_unit_type

                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activDurDate = DateTime.Now,
                                           activesubjdays = pm.package_duration_days,
                                           released_On = sm.released_on,
                                           user_ID = (int)UserId,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        saveSubjct = saveSubjct.Union(saveSubjct1).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct2).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct3).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct4).Distinct().ToList();
                        foreach (var k in saveSubjct)
                        {
                            user_subject_mapping usbm = new user_subject_mapping();
                            usbm.subject_id = (int)k.subj_ID;
                            usbm.subject_code = k.sub_Code;
                            usbm.subject_name = k.subj_Name;
                            usbm.subject_cover_path = k.subj_CoverParth;
                            usbm.subject_version = k.subj_Version;
                            usbm.subject_unit_version = k.subjUnit_usrVersion;
                            usbm.subject_unit_user_version = k.subjUnit_usrVersion;
                            usbm.subject_unit_id = (int)k.subjUnit_ID;
                            usbm.subject_unit_code = k.subjUnit_code;
                            usbm.subject_unit_name = k.subjUnit_Name;
                            usbm.subject_unit_path = k.subjUnit_Path;
                            usbm.is_demo = k.isDemo;
                            usbm.department_code = k.deprtCode;
                            usbm.department_name = k.deprtName;
                            usbm.department_id = k.deprtId;
                            usbm.is_unit_or_index = k.unit_orIdx;
                            usbm.subject_purchasedon = DateTime.Now;
                            usbm.downloaded_on = DateTime.Now;
                            usbm.download_status = 1;
                            usbm.user_id = k.user_ID;
                            usbm.is_updated_to_client = 1;
                            usbm.last_modified_on = k.LastmodifiedOn;
                            usbm.last_client_updated_on = k.LastClientUpdatedOn;
                            usbm.is_updated_subunit_to_client = k.IsUpdatedSubunitToClient;
                            usbm.last_subunit_modified_on = k.LastSubunitModifiedOn;
                            usbm.last_subunit_client_updated_on = k.LastSubunitClientUpdatedOn;
                            DateTime actDuration = DateTime.Now.AddDays(k.activesubjdays);
                            DateTime actSubjdays = DateTime.Now.AddDays(k.activesubjdays);
                            usbm.subject_unit_expiryon = actSubjdays;
                            usbm.package_expirydate = actSubjdays;
                            usbm.is_purchased = 1;
                            usbm.yearsem = k.YearSem;
                            //  contextsdce.user_subject_mapping.Add(usbm);
                            contextsdce.user_subject_mapping.AddOrUpdate(u => new { u.user_id, u.subject_unit_id }, usbm);
                        }

                        int result = contextsdce.SaveChanges();
                        transaction.Commit();
                        //
                        return "1";

                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message1 = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message1, raise);
                                Log.WriteLogMessage(PageName, "Student", "UpdatePackagesWithoutPayment", message1, "error");
                            }
                        }
                        Log.WriteLogMessage(PageName, "Student", "UpdatePackagesWithoutPayment", raise.Message.ToString(), "error");
                        // throw raise;
                        return "";
                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        contextsdce.Dispose();
                        Log.WriteLogMessage(PageName, "Student", "UpdatePackagesWithoutPayment", ex.Message, "error");
                        return ""; // Failure
                    }

                    finally
                    {
                        transaction.Dispose();
                        contextsdce.Dispose();
                    }
                }
            }
        }



        public UseageDashBoardViewModel UserUsageDashBoard(int SubjectType, int UserId)
        {
            JavaScriptSerializer Jserializer = new JavaScriptSerializer();
            UseageDashBoardViewModel UseageDashBoardVModel = new UseageDashBoardViewModel();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    var TagIds = new[] { "52", "53", "54", "60", "61", "95", "96", "117", "118", "131", "132" };
                    // Tradewise Usage
                    var TradewiseUsage = (from sub in contextsdce.subject_master
                                          join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id
                                          join dsm in contextsdce.department_subject_mapping on sub.subject_id equals dsm.subject_id
                                          join dm in contextsdce.department_master on dsm.department_id equals dm.department_id
                                          where sub.active_status == 1 && sub.having_questionpaper == SubjectType
                                          && usrh.department_id == dsm.department_id && usrh.user_id == UserId
                                          // && TagIds.Contains(sub.subject_id.ToString())
                                          group new { sub, usrh } by dm.department_name into tradewisegroup
                                          select new
                                          {
                                              //  subjectId=subjectwisegroup.Key,
                                              tradeName = tradewisegroup.Key,//.FirstOrDefault().sub.subject_name,
                                              totalhours = tradewisegroup.Sum(x => x.usrh.total_hours)
                                          }).OrderByDescending(x => x.totalhours);

                    //var FinalTradewiseUsage = from Result in TradewiseUsage
                    //                          union Result2 in TradewiseUsage select Result;

                    List<TradewiseUsage> _TradeUsage = new List<TradewiseUsage>();
                    foreach (var tradgroupobject in TradewiseUsage)
                    {
                        TradewiseUsage SubUsage = new TradewiseUsage();
                        SubUsage.TradeName = tradgroupobject.tradeName;
                        SubUsage.UsageHours = tradgroupobject.totalhours > 1800 ? tradgroupobject.totalhours / 3600 : 0;
                        SubUsage.UsageHoursDeci = tradgroupobject.totalhours > 1800 ? Math.Round(Convert.ToDecimal(tradgroupobject.totalhours / (Decimal)3600), 1) : 0;
                        _TradeUsage.Add(SubUsage);
                    }
                    UseageDashBoardVModel.TradeUsage = _TradeUsage;


                    // ITIwise Usage
                    var CollegewiseUsage = (from um in contextsdce.user_master
                                            join usrh in contextsdce.user_subject_read_history on um.user_id equals usrh.user_id
                                            join sub in contextsdce.subject_master on usrh.subject_id equals sub.subject_id
                                            //  join csm in contextsdce.college_subject_mapping on um.collegeid equals csm.college_id
                                            join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                            where cm.active_status == 1 && sub.having_questionpaper == SubjectType && um.user_id == UserId
                                            group new { cm, usrh } by cm.college_name into collegewisegroup
                                            select new
                                            {
                                                collegeName = collegewisegroup.Key,//.FirstOrDefault().sub.subject_name,
                                                totalhours = collegewisegroup.Sum(x => x.usrh.total_hours)
                                            }).OrderBy(x => x.collegeName);

                    List<ITIwiseUsage> _ITIUsage = new List<ITIwiseUsage>();
                    foreach (var collegegroupobject in CollegewiseUsage)
                    {
                        ITIwiseUsage SubUsage = new ITIwiseUsage();
                        SubUsage.ITIName = collegegroupobject.collegeName;
                        SubUsage.UsageHours = collegegroupobject.totalhours > 1800 ? collegegroupobject.totalhours / 3600 : 0;
                        _ITIUsage.Add(SubUsage);
                    }
                    UseageDashBoardVModel.ITIUsage = _ITIUsage;


                    // Montwise Usage
                    var MonthwiseUsage = (from um in contextsdce.user_master
                                          join usrh in contextsdce.user_subject_read_history on um.user_id equals usrh.user_id
                                          join sub in contextsdce.subject_master on usrh.subject_id equals sub.subject_id
                                          //     join csm in contextsdce.college_subject_mapping on um.collegeid equals csm.college_id
                                          //     join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                          where sub.having_questionpaper == SubjectType && um.user_id == UserId
                                          group new { usrh } by new { usageYear = usrh.last_read_on.Year, usageMonth = SqlFunctions.DateName("month", usrh.last_read_on), monthValue = usrh.last_read_on.Month } into monthwisegroup
                                          orderby monthwisegroup.Key.usageYear, monthwisegroup.Key.monthValue
                                          select new
                                          {
                                              MonthName = (monthwisegroup.Key.usageMonth + "-" + monthwisegroup.Key.usageYear),
                                              totalhours = monthwisegroup.Sum(x => x.usrh.total_hours)
                                          });

                    List<MonthwiseUsage> _MonthUsage = new List<MonthwiseUsage>();
                    foreach (var Monthgroupobject in MonthwiseUsage)
                    {
                        MonthwiseUsage SubUsage = new MonthwiseUsage();
                        SubUsage.MonthName = Monthgroupobject.MonthName;
                        SubUsage.UsageHours = Monthgroupobject.totalhours > 1800 ? Monthgroupobject.totalhours / 3600 : 0;
                        SubUsage.UsageHoursDeci = Monthgroupobject.totalhours > 1800 ? Math.Round(Convert.ToDecimal(Monthgroupobject.totalhours / (Decimal)3600), 1) : 0;
                        _MonthUsage.Add(SubUsage);
                    }
                    UseageDashBoardVModel.MonthUsage = _MonthUsage;

                    return UseageDashBoardVModel;

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "AdminDashBoard", "DashBoardMain", ex.Message, "error");

                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }


        public UserDashBoardViewModel UserDashBoardMain(int UserId)
        {
            JavaScriptSerializer Jserializer = new JavaScriptSerializer();
            UserDashBoardViewModel UserDashBoardVModel = new UserDashBoardViewModel();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    int TotalITIz = (from cm in contextsdce.college_master
                                     where cm.active_status == 1
                                     select cm.college_id).Distinct().Count();
                    UserDashBoardVModel.TotalITI = TotalITIz;

                    int RegisteredUserCount = (from cm in contextsdce.college_master
                                               join um in contextsdce.user_master on cm.college_id equals um.collegeid
                                               where um.active_status == 1 && cm.active_status == 1 && um.role_id < 3
                                               select um.user_id).Distinct().Count();
                    UserDashBoardVModel.TotalRegisteredUsers = RegisteredUserCount;

                    // Total Registered ITI
                    int RegisteredDesktopCount = (from cid in contextsdce.college_installation_details
                                                  join cde in contextsdce.college_installation_expiry on cid.college_install_id equals cde.college_install_id
                                                  where cid.active_status == 1 && cde.installed_on != null
                                                  select cid.college_install_id).Distinct().Count();
                    UserDashBoardVModel.TotalRegisteredDesktops = RegisteredDesktopCount;

                    // Total Test Registered ITI
                    int TestRegisteredUserCount = (from cid in contextsdce.college_test_installation_details
                                                   join cde in contextsdce.college_test_installation_expiry on cid.college_test_install_id equals cde.college_test_install_id
                                                   where cid.active_status == 1 && cde.installed_on != null
                                                   select cid.college_id).Distinct().Count();
                    UserDashBoardVModel.TestRegisteredITI = TestRegisteredUserCount;



                    // Total Theory Registered ITI 
                    int TheoryRegisteredUserCount = (from cid in contextsdce.college_installation_details
                                                     join cde in contextsdce.college_installation_expiry on cid.college_install_id equals cde.college_install_id
                                                     join sub in contextsdce.subject_master on cde.subject_id equals sub.subject_id
                                                     where cid.active_status == 1 && sub.having_questionpaper == 0 && cde.installed_on != null
                                                     select cid.college_id).Distinct().Count();
                    UserDashBoardVModel.TheoryRegisteredITI = TheoryRegisteredUserCount;

                    // Total practical Registered ITI
                    int PracticalRegisteredUserCount = (from cid in contextsdce.college_installation_details
                                                        join cde in contextsdce.college_installation_expiry on cid.college_install_id equals cde.college_install_id
                                                        join sub in contextsdce.subject_master on cde.subject_id equals sub.subject_id
                                                        where cid.active_status == 1 && sub.having_questionpaper == 1 && cde.installed_on != null
                                                        select cid.college_id).Distinct().Count();
                    UserDashBoardVModel.PracticalRegisteredITI = PracticalRegisteredUserCount;


                    UserDashBoardVModel.TotalRegisteredITI = TestRegisteredUserCount + TheoryRegisteredUserCount + PracticalRegisteredUserCount;

                    // Total usage
                    int TotalUsage = 0;
                    TotalUsage = (from sub in contextsdce.subject_master
                                  join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id
                                  where sub.active_status == 1 && usrh.user_id== UserId
                                  select usrh.total_hours).Sum();
                    UserDashBoardVModel.TotalUsageHrs = TotalUsage > 0 ? string.Format("{0:00}:{1:00}:{2:00}", Math.Round((Decimal)TotalUsage / (Decimal)3600, 1), Math.Round(Math.Round(((Decimal)TotalUsage / (Decimal)60),0) % 60,0), TotalUsage % 60) : "0";
                    
                    // Total practical usage
                    int PracticalUsage = 0;
                    PracticalUsage = (from sub in contextsdce.subject_master
                                      join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id
                                      where sub.active_status == 1 && sub.having_questionpaper == 1 && usrh.user_id == UserId
                                      select usrh.total_hours).Sum();
                    UserDashBoardVModel.TotalPracticalUsage = PracticalUsage > 0 ? PracticalUsage / 3600 : 0;

                    // Theory subjectwise Usage
                    var TheorysubjectwiseUsage = (from sub in contextsdce.subject_master
                                                  join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id
                                                  where sub.active_status == 1 && sub.having_questionpaper == 0 && usrh.user_id == UserId
                                                  group new { sub, usrh } by sub.subject_name into subjectwisegroup
                                                  select new
                                                  {
                                                      //  subjectId=subjectwisegroup.Key,
                                                      subjectName = subjectwisegroup.Key,//.FirstOrDefault().sub.subject_name,
                                                      totalhours = subjectwisegroup.Sum(x => x.usrh.total_hours)
                                                  });

                    List<SubjectwiseUsage> _SubjectUsage = new List<SubjectwiseUsage>();
                    foreach (var subgroupobject in TheorysubjectwiseUsage)
                    {
                        SubjectwiseUsage SubUsage = new SubjectwiseUsage();
                        // SubUsage.SubjectId = subgroupobject.subjectId;
                        SubUsage.SubjectName = subgroupobject.subjectName;
                        SubUsage.UsageHours = subgroupobject.totalhours > 1500 ? subgroupobject.totalhours / 3600 : 0;
                        _SubjectUsage.Add(SubUsage);
                    }

                    UserDashBoardVModel.SubjectUsage = _SubjectUsage;

                    return UserDashBoardVModel;

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "AdminDashBoard", "DashBoardMain", ex.Message, "error");

                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }


        public UseageDashBoardViewModel CollegeUsageDashBoard(int SubjectType, int CollegeId)
        {
            JavaScriptSerializer Jserializer = new JavaScriptSerializer();
            UseageDashBoardViewModel UseageDashBoardVModel = new UseageDashBoardViewModel();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    var TagIds = new[] { "52", "53", "54", "60", "61", "95", "96", "117", "118", "131", "132" };
                    // Tradewise Usage
                    var TradewiseUsage = (from sub in contextsdce.subject_master
                                          join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id
                                          join um in contextsdce.user_master on usrh.user_id equals um.user_id
                                          join dsm in contextsdce.department_subject_mapping on sub.subject_id equals dsm.subject_id
                                          join dm in contextsdce.department_master on dsm.department_id equals dm.department_id
                                          where sub.active_status == 1 // && sub.having_questionpaper == SubjectType
                                          && usrh.department_id == dsm.department_id && um.collegeid == CollegeId
                                          // && TagIds.Contains(sub.subject_id.ToString())
                                          group new { sub, usrh } by dm.department_name into tradewisegroup
                                          select new
                                          {
                                              //  subjectId=subjectwisegroup.Key,
                                              tradeName = tradewisegroup.Key,//.FirstOrDefault().sub.subject_name,
                                              totalhours = tradewisegroup.Sum(x => x.usrh.total_hours)
                                          }).OrderByDescending(x => x.totalhours);

                    //var FinalTradewiseUsage = from Result in TradewiseUsage
                    //                          union Result2 in TradewiseUsage select Result;

                    List<TradewiseUsage> _TradeUsage = new List<TradewiseUsage>();
                    foreach (var tradgroupobject in TradewiseUsage)
                    {
                        TradewiseUsage SubUsage = new TradewiseUsage();
                        SubUsage.TradeName = tradgroupobject.tradeName;
                        SubUsage.UsageHoursDeci = tradgroupobject.totalhours > 1800 ? Math.Round(Convert.ToDecimal(tradgroupobject.totalhours / (Decimal)3600),1) : 0;
                        _TradeUsage.Add(SubUsage);
                    }
                    UseageDashBoardVModel.TradeUsage = _TradeUsage;


                    // ITIwise Usage
                    var CollegewiseUsage = (from um in contextsdce.user_master
                                            join usrh in contextsdce.user_subject_read_history on um.user_id equals usrh.user_id
                                            join sub in contextsdce.subject_master on usrh.subject_id equals sub.subject_id
                                            //  join csm in contextsdce.college_subject_mapping on um.collegeid equals csm.college_id
                                            join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                            where cm.active_status == 1 && um.collegeid == CollegeId // && sub.having_questionpaper == SubjectType 
                                            group new { cm, usrh } by cm.college_name into collegewisegroup
                                            select new
                                            {
                                                collegeName = collegewisegroup.Key,//.FirstOrDefault().sub.subject_name,
                                                totalhours = collegewisegroup.Sum(x => x.usrh.total_hours)
                                            }).OrderBy(x => x.collegeName);

                    List<ITIwiseUsage> _ITIUsage = new List<ITIwiseUsage>();
                    foreach (var collegegroupobject in CollegewiseUsage)
                    {
                        ITIwiseUsage SubUsage = new ITIwiseUsage();
                        SubUsage.ITIName = collegegroupobject.collegeName;
                        SubUsage.UsageHoursDeci = collegegroupobject.totalhours > 1800 ? Math.Round(Convert.ToDecimal(collegegroupobject.totalhours / (Decimal)3600),1) : 0;
                        _ITIUsage.Add(SubUsage);
                    }
                    UseageDashBoardVModel.ITIUsage = _ITIUsage;


                    // Montwise Usage
                    var MonthwiseUsage = (from um in contextsdce.user_master
                                          join usrh in contextsdce.user_subject_read_history on um.user_id equals usrh.user_id
                                          join sub in contextsdce.subject_master on usrh.subject_id equals sub.subject_id
                                          //     join csm in contextsdce.college_subject_mapping on um.collegeid equals csm.college_id
                                          //     join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                          where  um.collegeid == CollegeId // && sub.having_questionpaper == SubjectType 
                                          group new { usrh } by new { usageYear = usrh.last_read_on.Year, usageMonth = SqlFunctions.DateName("month", usrh.last_read_on), monthValue = usrh.last_read_on.Month } into monthwisegroup
                                          orderby monthwisegroup.Key.usageYear, monthwisegroup.Key.monthValue
                                          select new
                                          {
                                              MonthName = (monthwisegroup.Key.usageMonth + "-" + monthwisegroup.Key.usageYear),
                                              totalhours = monthwisegroup.Sum(x => x.usrh.total_hours)
                                          });

                    List<MonthwiseUsage> _MonthUsage = new List<MonthwiseUsage>();
                    foreach (var Monthgroupobject in MonthwiseUsage)
                    {
                        MonthwiseUsage SubUsage = new MonthwiseUsage();
                        SubUsage.MonthName = Monthgroupobject.MonthName;
                        SubUsage.UsageHoursDeci = Monthgroupobject.totalhours > 1800 ? Math.Round(Convert.ToDecimal(Monthgroupobject.totalhours / (Decimal)3600),1) : 0;
                        _MonthUsage.Add(SubUsage);
                    }
                    UseageDashBoardVModel.MonthUsage = _MonthUsage;

                    return UseageDashBoardVModel;

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "AdminDashBoard", "DashBoardMain", ex.Message, "error");

                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }


        public UserDashBoardViewModel CollegeDashBoardMain(int CollegeId)
        {
            JavaScriptSerializer Jserializer = new JavaScriptSerializer();
            UserDashBoardViewModel UserDashBoardVModel = new UserDashBoardViewModel();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    int TotalITIz = (from cm in contextsdce.college_master
                                     where cm.active_status == 1
                                     select cm.college_id).Distinct().Count();
                    UserDashBoardVModel.TotalITI = TotalITIz;

                    int RegisteredUserCount = (from cm in contextsdce.college_master
                                               join um in contextsdce.user_master on cm.college_id equals um.collegeid
                                               where um.active_status == 1 && cm.active_status == 1 && um.role_id < 3
                                               select um.user_id).Distinct().Count();
                    UserDashBoardVModel.TotalRegisteredUsers = RegisteredUserCount;

                    // Total Registered ITI
                    int RegisteredDesktopCount = (from cid in contextsdce.college_installation_details
                                                  join cde in contextsdce.college_installation_expiry on cid.college_install_id equals cde.college_install_id
                                                  where cid.active_status == 1 && cde.installed_on != null
                                                  select cid.college_install_id).Distinct().Count();
                    UserDashBoardVModel.TotalRegisteredDesktops = RegisteredDesktopCount;

                    // Total Test Registered ITI
                    int TestRegisteredUserCount = (from cid in contextsdce.college_test_installation_details
                                                   join cde in contextsdce.college_test_installation_expiry on cid.college_test_install_id equals cde.college_test_install_id
                                                   where cid.active_status == 1 && cde.installed_on != null
                                                   select cid.college_id).Distinct().Count();
                    UserDashBoardVModel.TestRegisteredITI = TestRegisteredUserCount;



                    // Total Theory Registered ITI 
                    int TheoryRegisteredUserCount = (from cid in contextsdce.college_installation_details
                                                     join cde in contextsdce.college_installation_expiry on cid.college_install_id equals cde.college_install_id
                                                     join sub in contextsdce.subject_master on cde.subject_id equals sub.subject_id
                                                     where cid.active_status == 1 && sub.having_questionpaper == 0 && cde.installed_on != null
                                                     select cid.college_id).Distinct().Count();
                    UserDashBoardVModel.TheoryRegisteredITI = TheoryRegisteredUserCount;

                    // Total practical Registered ITI
                    int PracticalRegisteredUserCount = (from cid in contextsdce.college_installation_details
                                                        join cde in contextsdce.college_installation_expiry on cid.college_install_id equals cde.college_install_id
                                                        join sub in contextsdce.subject_master on cde.subject_id equals sub.subject_id
                                                        where cid.active_status == 1 && sub.having_questionpaper == 1 && cde.installed_on != null
                                                        select cid.college_id).Distinct().Count();
                    UserDashBoardVModel.PracticalRegisteredITI = PracticalRegisteredUserCount;


                    UserDashBoardVModel.TotalRegisteredITI = TestRegisteredUserCount + TheoryRegisteredUserCount + PracticalRegisteredUserCount;

                    // Total usage
                    int TotalUsage = 0;
                    TotalUsage = (from sub in contextsdce.subject_master
                                  join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id
                                  join um in contextsdce.user_master on usrh.user_id equals um.user_id
                                  where sub.active_status == 1 && um.collegeid == CollegeId
                                  select usrh.total_hours).Sum();
                    UserDashBoardVModel.TotalUsageHrs = TotalUsage > 0 ? string.Format("{0:00}:{1:00}:{2:00}", Math.Round(Convert.ToDecimal(TotalUsage / 3600)), Math.Round(Convert.ToDecimal(TotalUsage / 60)) % 60, TotalUsage % 60) : "0";

                    // Total practical usage
                    int PracticalUsage = 0;
                    PracticalUsage = (from sub in contextsdce.subject_master
                                      join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id
                                      join um in contextsdce.user_master on usrh.user_id equals um.user_id
                                      where sub.active_status == 1 && sub.having_questionpaper == 1 && um.collegeid == CollegeId
                                      select usrh.total_hours).Sum();
                    UserDashBoardVModel.TotalPracticalUsage = PracticalUsage > 0 ? PracticalUsage / 3600 : 0;

                    // Theory subjectwise Usage
                    var TheorysubjectwiseUsage = (from sub in contextsdce.subject_master
                                                  join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id
                                                  join um in contextsdce.user_master on usrh.user_id equals um.user_id
                                                  where sub.active_status == 1 && sub.having_questionpaper == 0 && um.collegeid == CollegeId
                                                  group new { sub, usrh } by sub.subject_name into subjectwisegroup
                                                  select new
                                                  {
                                                      //  subjectId=subjectwisegroup.Key,
                                                      subjectName = subjectwisegroup.Key,//.FirstOrDefault().sub.subject_name,
                                                      totalhours = subjectwisegroup.Sum(x => x.usrh.total_hours)
                                                  });

                    List<SubjectwiseUsage> _SubjectUsage = new List<SubjectwiseUsage>();
                    foreach (var subgroupobject in TheorysubjectwiseUsage)
                    {
                        SubjectwiseUsage SubUsage = new SubjectwiseUsage();
                        // SubUsage.SubjectId = subgroupobject.subjectId;
                        SubUsage.SubjectName = subgroupobject.subjectName;
                        SubUsage.UsageHours = subgroupobject.totalhours > 1500 ? subgroupobject.totalhours / 3600 : 0;
                        _SubjectUsage.Add(SubUsage);
                    }

                    UserDashBoardVModel.SubjectUsage = _SubjectUsage;

                    return UserDashBoardVModel;

                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "AdminDashBoard", "DashBoardMain", ex.Message, "error");

                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }



       
    }
}