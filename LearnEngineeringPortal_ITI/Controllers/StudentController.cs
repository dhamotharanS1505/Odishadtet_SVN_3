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
using System.Web.Http;
using System.Text.RegularExpressions;

namespace Odishadtet.Controllers
{
    //[StudentCustomAuthorization]
    public class StudentController : Controller
    {
        private learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities();
        static IStudentUserService _repository;



        public StudentController(IStudentUserService repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        //[HttpGet] //Student
        [StudentCustomAuthorization]
        public string StudentSubjectMasterUploadGrid(int Department, int Semester)
        {
            string subjectUploadGrid = _repository.StudentSubjectMasterUploadGrid(Department, Semester);

            return subjectUploadGrid;
        }
        [StudentCustomAuthorization]
        public string StudentsemesterMasterUploadGrid(int Department, int Semester)
        {
            string subjectUploadGrid = _repository.StudentsemesterMasterUploadGrid(Department, Semester);

            return subjectUploadGrid;
        }

        [StudentCustomAuthorization]
        public ActionResult PrivatePage(string fileName)
        {
            string htmlfile = "index.html";

            string filePath = Server.MapPath("~/odskills/"+ fileName + "/" + htmlfile);

            //strat time capture
            var userid = Convert.ToInt16(HttpContext.Session["stdloginUserID"]);
            var DepartmentID = Convert.ToInt16(HttpContext.Session["loginUserDepartmentID"]);
            Student_subject_read_history user_Subject_Read = _repository.StudentSubjectTimeSave(userid, DepartmentID, fileName);

            //if (System.IO.File.Exists(filePath))
            //{
            //    return File(filePath, "text/html");
            //}

            if (System.IO.File.Exists(filePath))
            {
                string content = System.IO.File.ReadAllText(filePath);

                // 🔹 Fix missing folder paths for images, CSS, and JS
                content = content.Replace("src=\"images/", "src=\"/odskills/" + fileName + "/images/");
                content = content.Replace("href=\"css/", "href=\"/odskills/" + fileName + "/css/");
                content = content.Replace("src=\"js/", "src=\"/odskills/" + fileName + "/js/");
                //content = content.Replace("url: \"xml/ ", "url: \"/odskills/OD-CO-VLS-24-001/xml/");
                content = content.Replace("url: \"xml/Lesson.xml\"", "url: \"/odskills/" + fileName + "/xml/Lesson.xml\"");


                content = content.Replace("images/pre.png", "/odskills/" + fileName + "/images/pre.png");
                content = content.Replace("images/nex.png", "/odskills/" + fileName + "/images/nex.png");
                content = content.Replace("images/previous.png", "/odskills/" + fileName + "/images/previous.png");
                content = content.Replace("images/next.png", "/odskills/" + fileName + "/images/next.png");

                

                content = content.Replace(
      "document.getElementById('myloader').src = turl;",
      "document.getElementById('myloader').src = '/odskills/" + fileName + "/' + turl;"
  );
                

                return Content(content, "text/html", System.Text.Encoding.UTF8);
                //return Content(content, "text/html");
            }




            return HttpNotFound();
        }

        //[StudentCustomAuthorization]
        public ActionResult checksubject(string fileName)
        {
            string htmlfile = "index.html";

            string filePath = Server.MapPath("~/odskills/" + fileName + "/" + htmlfile);
            var data = new { Message = "Failed" };
            if (System.IO.File.Exists(filePath))
            {

                data = new { Message = "Success"};
                return Json(data, JsonRequestBehavior.AllowGet);
            }                       
            return Json(data, JsonRequestBehavior.AllowGet);
        }




        //        [StudentCustomAuthorization]
        //        public ActionResult PrivatePage(string fileName)
        //        {
        //            string filePath = Server.MapPath("~/odskills/OD-CO-VLS-24-004/" + fileName);

        //            //if (System.IO.File.Exists(filePath))
        //            //{
        //            //    return File(filePath, "text/html");
        //            //}

        //            if (System.IO.File.Exists(filePath))
        //            {
        //                string content = System.IO.File.ReadAllText(filePath);

        //                // 🔹 Fix missing folder paths for images, CSS, and JS
        //                content = content.Replace("src=\"images/", "src=\"/odskills/OD-CO-VLS-24-004/images/");
        //                content = content.Replace("href=\"css/", "href=\"/odskills/OD-CO-VLS-24-004/css/");
        //                content = content.Replace("src=\"js/", "src=\"/odskills/OD-CO-VLS-24-004/js/");
        //                //content = content.Replace("url: \"xml/ ", "url: \"/odskills/OD-CO-VLS-24-001/xml/");
        //                content = content.Replace("url: \"xml/Lesson.xml\"", "url: \"/odskills/OD-CO-VLS-24-004/xml/Lesson.xml\"");


        //                content = content.Replace("images/pre.png", "/odskills/OD-CO-VLS-24-004/images/pre.png");
        //                content = content.Replace("images/nex.png", "/odskills/OD-CO-VLS-24-004/images/nex.png");
        //                content = content.Replace("images/previous.png", "/odskills/OD-CO-VLS-24-004/images/previous.png");
        //                content = content.Replace("images/next.png", "/odskills/OD-CO-VLS-24-004/images/next.png");

        //                //// Define the old and new content
        //                //string oldText1 = "$.each(lessonitems, function(i, lesItem){";
        //                //string newText1 = @"$.each(lessonitems, function(i, lesItem){
        //                //let path = lesItem.url || lesItem; // Ensure path is extracted correctly
        //                //path = '/odskills/OD-CO-VLS-24-004/' + path;";

        //                //// Replace the content
        //                //content = content.Replace(oldText1, newText1);

        //                //// Define the old and new content
        //                //string oldText = "$.each(chaptersitems, function(i, chapItem){";
        //                //string newText = @"$.each(chaptersitems, function(i, chapItem){
        //                //let path = chapItem.url || chapItem; // Ensure path is extracted correctly
        //                //path = '/odskills/OD-CO-VLS-24-004/' + path;";

        //                //// Replace the content
        //                //content = content.Replace(oldText, newText);

        ////                content = content.Replace(
        ////    "chapItemL.setAttribute('url', $(chapItem).attr(\"url\"));",
        ////    "chapItemL.setAttribute('url', '/odskills/OD-CO-VLS-24-004/' + $(chapItem).attr(\"url\"));"
        ////);


        //                //              content = content.Replace(
        //                //    "mya.setAttribute('onclick', \"myidclick('\" + $(chapItem).attr(\"url\") + \"',\" + myid + \" )\");",
        //                //    "mya.setAttribute('onclick', \"myidclick('/odskills/OD-CO-VLS-24-004/' + $(chapItem).attr(\"url\") + \"',\" + myid + \" )\");"
        //                //);


        //                //                content = Regex.Replace(
        //                //    content,
        //                //    @"onclick=\""myidclick\('([^']+)'\s*,\s*(\d+)\s*\)\""",
        //                //    "onclick=\"myidclick('/odskills/OD-CO-VLS-24-004/$1', $2)\""
        //                //);


        //                //                content = Regex.Replace(
        //                //    content,
        //                //    @"onclick=""myidclick\('([^']+)'\s*,\s*(\d+)\s*\)""",
        //                //    "onclick=\"myidclick('/odskills/OD-CO-VLS-24-004/$1', $2)\""
        //                //);


        //                //         content = Regex.Replace(
        //                //    content,
        //                //    @"onclick=""myidclick\('([^']+)'\s*,\s*([\d]+)\s*\)""",
        //                //    @"onclick=""myidclick('/odskills/OD-CO-VLS-24-004/$1', $2)"""
        //                //);


        //                //        content = Regex.Replace(
        //                //    content,
        //                //    @"mya\.setAttribute\('onclick',\s*""myidclick\('"" \+ \s*\$\(chapItem\)\.attr\(""url""\) \+ ""',"" \+ myid \+ "" \)""\);",
        //                //    "mya.setAttribute('onclick', \"myidclick('/odskills/OD-CO-VLS-24-004/\" + $(chapItem).attr(\"url\") + \"',\" + myid + \" )\");"
        //                //);


        //                //        content = Regex.Replace(
        //                //    content,
        //                //    @"onclick=""myidclick\('([^']+)'\s*,\s*(\d+)\s*\)""",
        //                //    @"onclick=""myidclick('/odskills/OD-CO-VLS-24-004/$1', $2)"""
        //                //);

        //                content = content.Replace(
        //      "document.getElementById('myloader').src = turl;",
        //      "document.getElementById('myloader').src = '/odskills/OD-CO-VLS-24-004/' + turl;"
        //  );

        //                //               content = content.Replace(
        //                //    "mya.setAttribute('onclick', \"myidclick('\" + $(chapItem).attr(\"url\") + \"',\" + myid + \" )\");",
        //                //    "mya.setAttribute('onclick', \"myidclick('/odskills/OD-CO-VLS-24-004/\" + $(chapItem).attr(\"url\") + \"',\" + myid + \" )\");"
        //                //);

        //                //              content = content.Replace(
        //                //    "var chaptersitems = $('Chapters', lesItem);",
        //                //    "var chaptersitems = $('Chapters', lesItem).map(function() { return '/odskills/OD-CO-VLS-24-004/' + $(this).attr('url'); }).get();"
        //                //);

        //                //content = content.Replace("$.each(subjectitems, function(i, subItem){",
        //                //  "$.each(subjectitems, function(i, subItem){ subItem = '/odskills/OD-CO-VLS-24-004/' + subItem;");

        //                //   content = content.Replace("$.each(lessonitems, function(i, lesItem){",
        //                //"$.each(lessonitems, function(i, lesItem){ lesItem = '/odskills/OD-CO-VLS-24-004/' + lesItem;");

        //                //content = content.Replace("$.each(chaptersitems, function(i, chapItem){",
        //                //    "$.each(chaptersitems, function(i, chapItem){ chapItem = '/odskills/OD-CO-VLS-24-004/' + chapItem;");





        //                //            content = Regex.Replace(content,
        //                //@"\$\.\s*each\s*\(\s*subjectitems\s*,\s*function\s*\(\s*i\s*,\s*subItem\s*\)\s*\{",
        //                //"$.each(subjectitems, function(i, subItem){ subItem = '/odskills/OD-CO-VLS-24-004/' + subItem;");

        //                //            content = Regex.Replace(content,
        //                //@"\$\.\s*each\s*\(\s*lessonitems\s*,\s*function\s*\(\s*i\s*,\s*lesItem\s*\)\s*\{",
        //                //"$.each(lessonitems, function(i, lesItem){ lesItem = '/odskills/OD-CO-VLS-24-004/' + lesItem;");


        //                //        content = Regex.Replace(content,
        //                //@"\$\.\s*each\s*\(\s*chaptersitems\s*,\s*function\s*\(\s*i\s*,\s*chapItem\s*\)\s*\{",
        //                //"$.each(chaptersitems, function(i, chapItem){ chapItem = '/odskills/OD-CO-VLS-24-004/' + chapItem;");


        //                //content = content.Replace("images/pre.png", "/odskills/OD-CO-VLS-24-004/images/pre.png");
        //                //content = content.Replace("images/nex.png", "/odskills/OD-CO-VLS-24-004/images/nex.png");
        //                //content = content.Replace("images/previous.png", "/odskills/OD-CO-VLS-24-004/images/previous.png");
        //                //content = content.Replace("images/next.png", "/odskills/OD-CO-VLS-24-004/images/next.png");

        //                //// 🔹 Fix missing folder paths for images, CSS, and JS
        //                //content = content.Replace("src=\"images/", "src=\"/odskills/OD-CO-VLS-24-004/images/");
        //                //content = content.Replace("href=\"css/", "href=\"/odskills/OD-CO-VLS-24-004/css/");
        //                //content = content.Replace("src=\"js/", "src=\"/odskills/OD-CO-VLS-24-004/js/");
        //                ////content = content.Replace("url: \"xml/ ", "url: \"/odskills/OD-CO-VLS-24-001/xml/");
        //                //content = content.Replace("url: \"xml/Lesson.xml\"", "url: \"/odskills/OD-CO-VLS-24-004/xml/Lesson.xml\"");

        //                //string basePath = "/odskills/OD-CO-VLS-24-004/";
        //                //string content = System.IO.File.ReadAllText(filePath);
        //                //content = Regex.Replace(content, @"\b(images|xml|css|js|videos|fonts)/([\w\-/\.]*)", basePath + "$1/$2");


        //                //string xmlFilePath = Server.MapPath("~/odskills/OD-CO-VLS-24-004/xml/Lesson.xml");

        //                //////string content1 = System.IO.File.ReadAllText(newBasePath);
        //                //////// Replace URL dynamically
        //                //////content = Regex.Replace(content1, @"\b(images|xml|css|js|videos|fonts)/([\w\-/\.]*)", basePath + "$1/$2");

        //                //string content1 = System.IO.File.ReadAllText(xmlFilePath);
        //                ////content1 = Regex.Replace(content1, @"\b(images|xml|css|js|videos|fonts)/([\w\-/\.]*)", Server.MapPath(basePath) + "$1/$2");
        //                //string basePathxml = "/odskills/OD-CO-VLS-24-004/applied_chemistry/";
        //                ////content1 = Regex.Replace(content1, @"url="s"applied_chemistry/html/([^""]+\.html)""", $"url=\"{basePath}applied_chemistry/html/$1\"");
        //                //content1 = Regex.Replace(content1, @"\bapplied_chemistry/([\w\-/\.]*)", basePathxml + "$1");
        //                ////content1 = Regex.Replace(content1, @"\b([\w\-/\.]*)", basePath + "$1");
        //                ////content1 = Regex.Replace(content1, @"\bapplied_chemistry/(images|xml|css|js|videos|fonts)/([\w\-/\.]*)", basePathxml + "$1/$2");

        //                //content += "\n<!-- XML Content Below -->\n" + content1;

        //                //ViewBag.HtmlContent = content;applied_chemistry
        //                //return Content(content, "text/html");

        //                //ViewBag.HtmlContent = content;

        //                return Content(content, "text/html", System.Text.Encoding.UTF8);
        //                //return Content(content, "text/html");
        //            }




        //            return HttpNotFound();
        //        }


        public ActionResult GetServerUrl()
        {
            string serverUrl = $"{Request.Url?.Scheme}://{Request.Url?.Authority}"; // Gets "https://yourdomain.com"
            serverUrl = serverUrl + "/odskills/OD-CO-VLS-24-004/";
            return Json(new { url = serverUrl });
        }


        //private readonly IStudentUserService _repository;

        //public StudentController(IStudentUserService repository)
        //{
        //    this._repository = repository;
        //}




        //private IStudentUserService _repository;

        // GET: Student
        public ActionResult Index()


        {
            return View();
        }
        [StudentCustomAuthorization]
        public ActionResult Dashboard()
        {
            return View();
        }
        [StudentCustomAuthorization]
        public ActionResult Subjects(string fileName)
        {
            ViewBag.HtmlContent = fileName;
            return View();
        }

        [StudentCustomAuthorization]
        public ActionResult ViewProfile()
        {
            return View();
        }




        //public ActionResult CheckStudentLogininProcess(checkLogin obj)
        //{


        //    //APIUserDashBoardController webApi = new APIUserDashBoardController(_data);
        //    checkLogin gLoginDetailes = _repository.CheckStudentLoginDetails(obj.FirstName, obj.Password);
        //    //  if (gLoginDetailes.role_type_code != 3)
        //    {
        //        if (gLoginDetailes.userId != 0 && gLoginDetailes.message == "")
        //            LoginModels.SaveUserSessionDetails(gLoginDetailes);
        //    }
        //    return Json(gLoginDetailes);

        //}



        public ActionResult CheckStudentLogininProcess(StudentcheckLogin obj)
        {

            AesDecryption encryptAec = new AesDecryption();
            obj.Password = encryptAec.DecryptCryptoJsAes(obj.Password, "YourSecretKey123!");
            

            //APIUserDashBoardController webApi = new APIUserDashBoardController(_data);
            StudentcheckLogin gLoginDetailes = _repository.CheckStudentLoginDetails(obj.FirstName, obj.Password);

            
            //  if (gLoginDetailes.role_type_code != 3)
            {
                if (gLoginDetailes.userId != 0 && gLoginDetailes.message == "")
                    LoginModels.StudentSaveUserSessionDetails(gLoginDetailes);
            }
            return Json(gLoginDetailes);

        }

        public ActionResult CheckWorkingStatus()
        {
            StudentcheckLogin getdata = new StudentcheckLogin();
            int data = 0;
            string loginUserEmailID =Convert.ToString(HttpContext.Session["loginUserEmailID"]);
            if (loginUserEmailID != null)
            {
                //string uid = loginUserEmailID;
                //getdata = _repository.CheckStudentSession(loginUserEmailID);
                data = 1;
            }
            else
            {
                data = -1;
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
       

        public int GetVerificationCodeByMobile(long MobNo, string emailID)
        {

            int gVerificationCodeByMobile = _repository.GetVerificationCodeByMobile(MobNo, emailID);

            return gVerificationCodeByMobile;

        }



        //public ActionResult ForgetPassword(string MobileNumber)
        //{


        //    ForgetPasswordModel gLoginDetailes = _repository.ForgetPassword(Convert.ToInt64(MobileNumber));

        //    // Generate secure token and store it with timestamp
        //    //bool showModal = false;
        //    //if (gLoginDetailes.userID > 0)
        //    //{
        //    //    ViewBag.ShowModal = true;
        //    //}
        //    //else {
        //    //    ViewBag.ShowModal = false;
        //    //}
        //    return Json(gLoginDetailes);
        //}


        public ActionResult ForgetPassword(string MobileNumber)
        {

            var result = new ForgetPasswordModel();
            //ForgetPasswordModel gLoginDetailes = _repository.ForgetPassword(Convert.ToInt64(MobileNumber));


            try
            {
                ForgetPasswordModel gLoginDetailes = _repository.ForgetPassword(Convert.ToInt64(MobileNumber));

                // Set success as false by default
                result.Success = false;
                result.code = 0;
                //if (gLoginDetailes.userID > 0)
                //{
                //    // Proceed with OTP logic here
                //    // _otpService.SendOtp(gLoginDetailes.MobileNumber); // Example
                //    result.Success = true;
                //}

                if (gLoginDetailes != null && gLoginDetailes.userID > 0)
                {
                    result.Success = true;
                }

                // Always return the same message regardless of success or failure
                result.message = "An OTP has been sent to the registered phone number if the user is present in our system.";
            }
            catch
            {
                result.message = "Something went wrong. Please try again.";
            }

            return Json(result, JsonRequestBehavior.AllowGet);




           // return Json(gLoginDetailes);
        }

        public ActionResult GetResetPasswords(string mobileNo, string otpCode, string newPassword)
        {
           
            var result = new ForgetPasswordModel();
            //ForgetPasswordModel gLoginDetailes = _repository.ForgetPassword(Convert.ToInt64(MobileNumber));


            try
            {
               
                ForgetPasswordModel gLoginDetailes = _repository.ResetPassword(Convert.ToInt64(mobileNo), otpCode, newPassword);
                ////return Json(gLoginDetailes);

                // Set success as false by default
                result.Success = false;
                result.code = 0;
                result.message = gLoginDetailes.message;
                //if (gLoginDetailes.userID > 0)
                //{
                //    // Proceed with OTP logic here
                //    // _otpService.SendOtp(gLoginDetailes.MobileNumber); // Example
                //    result.Success = true;
                //}

                if (gLoginDetailes != null && gLoginDetailes.userID > 0)
                {
                    result.Success = true;
                }

                // Always return the same message regardless of success or failure
                //result.message = "An OTP has been sent to the registered phone number if the user is present in our system.";
            }
            catch
            {
                result.message = "Something went wrong. Please try again.";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
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
            string loginuserid = HttpContext.Session["stdloginUserID"] == null ? "" : HttpContext.Session["stdloginUserID"].ToString();

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

        #region End time save
        [StudentCustomAuthorization]
        public ActionResult StudentSaveEndTime()
        {
            int history_ID = Convert.ToInt16(HttpContext.Session["last_read_on"]);
            int subject_id = Convert.ToInt16(HttpContext.Session["subject_id"]);

            var userid = Convert.ToInt16(HttpContext.Session["stdloginUserID"]);
            var DepartmentID = Convert.ToInt16(HttpContext.Session["loginUserDepartmentID"]);

            Student_subject_read_history user_Subject_Read = _repository.StudentSubjectEndTimeSave(userid, subject_id, history_ID, DepartmentID);

            return RedirectToAction("Dashboard");

        }

        #endregion

    }
}