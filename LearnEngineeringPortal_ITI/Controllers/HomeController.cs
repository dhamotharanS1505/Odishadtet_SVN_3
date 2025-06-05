
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odishadtet.DAL;
using Odishadtet.Models;
using Odishadtet.General;
using LearnEngineeringPortalService_ITI;
using LearnEnggPaymentPortal;
using System.Data.Entity;
using Odishadtet.DAL;

namespace Odishadtet.Controllers
{
    /// <summary>
    /// Using this class navigating the home page action related to other pages
    /// </summary>
    /// 
    
    public class HomeController : Controller
    {
        private learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities();

        static IStudentService _repository;

        //static IAdminService _AdminRepository;

        public HomeController(IStudentService repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public ActionResult LoadFirst()

        {
            string userrole = null;
            if (HttpContext.Session["loginUserRoleID"] != null)
            {
                userrole = Convert.ToInt32(HttpContext.Session["loginUserRoleID"]).ToString();
            }

        
            return View("~/Views/Index.cshtml");

        }


        //public RedirectResult LoadFirst()
        //{
        //    return Redirect("~/index.html");

        //}

        public ActionResult Index()
        {
            string userrole = null;
            if (HttpContext.Session["loginUserRoleID"] != null)
            {
                userrole = Convert.ToInt32(HttpContext.Session["loginUserRoleID"]).ToString();
            }

            return RedirectToAction("LoadFirst");
        }

        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult Department()
        {
            return View();
        }


        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {


            return View();
        }

        public ActionResult ViewProfile()
        {
            proLoginUserDefaultValues ap = new proLoginUserDefaultValues();
            if (ap.loginUserRoleID == "1")
            {
                ViewBag.LayoutModel = "~/Views/Shared/_LearnEnggLayout.cshtml";
            }
            else
            {
                ViewBag.LayoutModel = "~/Views/Shared/_LearnEnggAdminLayout.cshtml";
            }

            return View();
        }

        public ActionResult ImageCrop()
        {
            return View();
        }

        public ActionResult CropImageUpload()
        {
            var file = Request.Form["avatarData"];
            proLoginUserDefaultValues obj = new proLoginUserDefaultValues();
            return Json(Common.CroppedImageserverUpload_New(file, obj.loginUserID + ""), JsonRequestBehavior.AllowGet);
        }


        public ActionResult CheckLogininProcess(checkLogin obj)
        {


            //APIUserDashBoardController webApi = new APIUserDashBoardController(_data);
            checkLogin gLoginDetailes = _repository.CheckLoginDetails(obj.FirstName, obj.Password);
            //  if (gLoginDetailes.role_type_code != 3)
            {
                if (gLoginDetailes.userId != 0 && gLoginDetailes.message == "")
                    LoginModels.SaveUserSessionDetails(gLoginDetailes);
            }
            return Json(gLoginDetailes);

        }

        public ActionResult ForgetPassword(string MobileNumber)
        {


            ForgetPasswordModel gLoginDetailes = _repository.ForgetPassword(Convert.ToInt64(MobileNumber));
            return Json(gLoginDetailes);
        }

        public ActionResult GetResetPasswords(string mobileNo, string otpCode, string newPassword)
        {


            ForgetPasswordModel gLoginDetailes = _repository.ResetPassword(Convert.ToInt64(mobileNo), otpCode, newPassword);
            return Json(gLoginDetailes);
        }

        public ActionResult checkOTPisValid(int userid, string OTP)
        {
            return Json(_repository.OTP_CodeVerification(userid, OTP));
        }



        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return Json("");
        }

        public JsonResult CheckAlreadyLogined()
        {
            string loginuserid = Session["loginUserID"] == null ? "" : Session["loginUserID"].ToString();

            if (loginuserid != null)
            {
                if (loginuserid != "")
                {
                    string UserName = HttpContext.Session["loginUserFullName"].ToString();
                    return Json(new
                    {
                        Valid = true,
                        ReturnUrl = UserName + '~' + loginuserid
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        Valid = false,
                        ReturnUrl = ""
                    });
                }
            }
            else
            {
                return Json(new
                {
                    Valid = false,
                    ReturnUrl = ""
                });

            }
        }
        /// <summary>
        /// Load Registrtaion form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StudentRegistration()
        {
            ViewBag.role_id = contextsdce.user_role.Where(x => x.role_type == 1);
            ViewBag.univ_id = contextsdce.university_master.Where(x => x.university_type == 1);
            ViewBag.state_id = contextsdce.state_master;
            ViewBag.country_id = contextsdce.country_master;
            return View();
        }


        /// <summary>
        /// To Save User Details 
        /// </summary>
        /// <param name="user_master"></param>
        /// <returns>StudentRegistration.cshtml</returns>
        [HttpPost]
        public ActionResult StudentRegistration(user_master user_master)
        {


            if (ModelState.IsValidField("user_name") && ModelState.IsValidField("password") && ModelState.IsValidField("role_id")
            && ModelState.IsValidField("email_id") && ModelState.IsValidField("mobile") && ModelState.IsValidField("univ_id")
            && ModelState.IsValidField("collegeid") && ModelState.IsValidField("DepartmentID") && ModelState.IsValidField("currentyear")
            && ModelState.IsValidField("currentsemester"))
            {

                //if (ModelState.IsValid)
                {
                    user_master.created_on = DateTime.Now;
                    user_master.Bulk_mail = true;
                    user_master.is_first_login = 2;
                    user_master.active_status = 0;
                    user_master.registered_from = 3;
                    user_master.user_first_name = user_master.user_name;
                    user_master.primary_imei = "notsavedyet";
                    user_master.primary_mac = "notsavedyet";
                    user_master.primary_andriod_mac = "notsavedyet";

                    if (user_master.dob != null)
                    {
                        user_master.dob = Convert.ToDateTime(user_master.dob.Value.ToString("yyyy-MM-dd")).Date;
                    }
                    EncryptionDecryption encrypt = new EncryptionDecryption();
                    var pwd = encrypt.encrptpwd(user_master.password, true);
                    user_master.password = pwd;

                    var usermail = (from usm in contextsdce.user_master where (usm.email_id == user_master.email_id || usm.mobile == user_master.mobile) select usm).FirstOrDefault();
                    if (usermail == null)
                    {
                        contextsdce.user_master.Add(user_master);
                        contextsdce.SaveChanges();
                        _repository.GetVerificationCodeByMobile(user_master.mobile, user_master.email_id);
                        long userid = user_master.user_id;

                        //saving Address for Registered User.
                        if (ModelState.IsValidField("address") == true)
                        {
                            _repository.UserAddress(Convert.ToInt32(userid), 1, user_master.user_first_name, user_master.mobile, user_master.user_name + "," + user_master.address, 99, user_master.city, Convert.ToString(user_master.state_id), 1, "-", 1);
                        }
                        else
                        {
                            _repository.UserAddress(Convert.ToInt32(userid), 1, user_master.user_first_name, user_master.mobile, user_master.user_name, 99, user_master.city, Convert.ToString(user_master.state_id), 1, "-", 1);
                        }
                        return RedirectToAction("OTPVerification", new { lastuserId = userid });
                    }
                    else
                    {
                        ViewBag.role_id = contextsdce.user_role.Where(x => x.role_type == 1);
                        ViewBag.univ_id = contextsdce.university_master;
                        ViewBag.state_id = contextsdce.state_master;
                        ViewBag.country_id = contextsdce.country_master;

                        if ((usermail.email_id == user_master.email_id) && (usermail.mobile == user_master.mobile))
                        {
                            TempData["success"] = "Your Email And Mobile is Already Registered with Us.";
                        }
                        else if (usermail.mobile == user_master.mobile)
                        {
                            TempData["success"] = "Your Mobile is Already Registered with Us.";
                        }
                        else if (usermail.email_id == user_master.email_id)
                        {
                            TempData["success"] = "Your Email id is Already Registered with Us.";
                        }
                    }

                }
            }
            return View(user_master);

        }


        public ActionResult OTPVerification(int lastuserId)
        {
            checkLogin userdetails = (from usm in contextsdce.user_master
                                      where usm.user_id == lastuserId
                                      select new checkLogin
                                      {
                                          FirstName = usm.user_name,
                                          mobileNumber = usm.mobile,
                                          emailId = usm.email_id

                                      }).FirstOrDefault();
            ViewBag.userid = lastuserId;

            return View(userdetails);
        }



        public ActionResult IndexAndroidApp()
        {
            return View();
        }

        public ActionResult SpecialOfferPackage(string srcURI)
        {
            return View();
        }


        public ActionResult VTUSpecialOffer(string srcURI)
        {
            return View();
        }


        public ActionResult JNTUHSpecialOffer(string srcURI)
        {
            return View();
        }

        public ActionResult WestBengalSpecialOffer(string srcURI)
        {
            return View();
        }


        [HttpPost]
        public string StudentRegistrationPopUp(user_master user_master)
        {
            string result = "";

            if (ModelState.IsValidField("user_name") && ModelState.IsValidField("password") && ModelState.IsValidField("role_id")
            && ModelState.IsValidField("email_id") && ModelState.IsValidField("mobile") && ModelState.IsValidField("univ_id")
            && ModelState.IsValidField("collegeid") && ModelState.IsValidField("DepartmentID") && ModelState.IsValidField("currentyear")
            && ModelState.IsValidField("currentsemester"))
            {

                user_master.created_on = DateTime.Now;
                user_master.Bulk_mail = true;
                user_master.is_first_login = 2;
                user_master.active_status = 0;
                if (user_master.registered_from != null || user_master.registered_from > 0)
                {
                    user_master.registered_from = user_master.registered_from;
                }
                else
                {
                    user_master.registered_from = 8;
                }
                user_master.user_first_name = user_master.user_name;
                user_master.primary_imei = "notsavedyet";
                user_master.primary_mac = "notsavedyet";
                user_master.primary_andriod_mac = "notsavedyet";

                if (user_master.dob != null)
                {
                    user_master.dob = Convert.ToDateTime(user_master.dob.Value.ToString("yyyy-MM-dd")).Date;
                }
                EncryptionDecryption encrypt = new EncryptionDecryption();
                var pwd = encrypt.encrptpwd(user_master.password, true);
                user_master.password = pwd;

                var usermail = (from usm in contextsdce.user_master where (usm.email_id == user_master.email_id || usm.mobile == user_master.mobile) select usm).FirstOrDefault();
                if (usermail == null)
                {
                    contextsdce.user_master.Add(user_master);
                    contextsdce.SaveChanges();
                    _repository.GetVerificationCodeByMobile(user_master.mobile, user_master.email_id);
                    long userid = user_master.user_id;

                    //saving Address for Registered User.
                    if (ModelState.IsValidField("address") == true)
                    {
                        _repository.UserAddress(Convert.ToInt32(userid), 1, user_master.user_first_name, user_master.mobile, user_master.user_name + "," + user_master.address, 99, user_master.city, Convert.ToString(user_master.state_id), 1, "-", 1);
                    }
                    else
                    {
                        _repository.UserAddress(Convert.ToInt32(userid), 1, user_master.user_first_name, user_master.mobile, user_master.user_name, 99, user_master.city, Convert.ToString(user_master.state_id), 1, "-", 1);
                    }
                    result = "1_" + userid;
                }
                else
                {


                    if ((usermail.email_id == user_master.email_id) && (usermail.mobile == user_master.mobile))
                    {
                        result = "Your Email And Mobile is Already Registered with Us.";
                    }
                    else if (usermail.mobile == user_master.mobile)
                    {
                        result = "Your Mobile is Already Registered with Us.";
                    }
                    else if (usermail.email_id == user_master.email_id)
                    {
                        result = "Your Email id is Already Registered with Us.";
                    }

                }
            }
            return result;

        }


    }
}