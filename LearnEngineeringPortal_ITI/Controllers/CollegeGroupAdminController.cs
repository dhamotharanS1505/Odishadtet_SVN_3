using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odishadtet.DAL;
using Odishadtet.Models;

namespace Odishadtet.Controllers
{
    [CustomAuthorization]
    public class CollegeGroupAdminController : Controller
    {

        static ICollegeGroupAdminReportService _AdminRepository;

        public CollegeGroupAdminController(ICollegeGroupAdminReportService Productrepository)
        {
            if (Productrepository == null)
            {
                throw new ArgumentNullException("Productrepository");
            }

            _AdminRepository = Productrepository;
        }

        // GET: CollegeGroupAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DashBoardMain()
        {
            int LoginId = 0; int LoginGrpId = 0;
            if (HttpContext.Session["loginUserID"] != null)            
            {
                LoginId = Convert.ToInt32(HttpContext.Session["loginUserID"].ToString());
            }

            if (HttpContext.Session["logincollegegrpId"] != null)
            {
                LoginGrpId = Convert.ToInt32(HttpContext.Session["logincollegegrpId"].ToString());
            }

            UserDashBoardViewModel UserDashBoardMain = _AdminRepository.DashBoardMain(LoginGrpId);
            return View(UserDashBoardMain);
        }


        // GET: DashBoard/Details/5
        public ActionResult UsageDashBoard(int SubType = 1)
        {
            //UseageDashBoardViewModel UserDashBoardMain = _AdminRepository.UsageDashBoard(SubType);
            // return View(UserDashBoardMain);
            return View();
        }


        public ActionResult RegistrationDashBoard(int SubType = 1)
        {
            //UseageDashBoardViewModel UserDashBoardMain = _AdminRepository.UsageDashBoard(SubType);
            // return View(UserDashBoardMain);
            return View();
        }

        public ActionResult CollegeGroupMappingList()
        {
            return View();
        }
    }
}
