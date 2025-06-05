using Odishadtet.DAL;
using Odishadtet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odishadtet.Controllers
{
    [CustomAuthorization]
    public class AdminDashBoardController : Controller
    {

        static IAdminReportService _AdminRepository;

        public AdminDashBoardController(IAdminReportService Productrepository)
        {
            if (Productrepository == null)
            {
                throw new ArgumentNullException("Productrepository");
            }

            _AdminRepository = Productrepository;
        }

        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashBoard/Details/5
        public ActionResult DashBoardMain()
        {
            int CollegeGrpId = Convert.ToInt32(Session["logincollegegrpId"].ToString());
            UserDashBoardViewModel UserDashBoardMain = _AdminRepository.DashBoardMain(CollegeGrpId);
            return View(UserDashBoardMain);
        }


        // GET: DashBoard/Details/5
        public ActionResult UsageDashBoard(int SubType=1)
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


        public ActionResult ITIUsageReport(int SubType = 1)
        {
            //UseageDashBoardViewModel UserDashBoardMain = _AdminRepository.UsageDashBoard(SubType);
            // return View(UserDashBoardMain);
            return View();
        }


        public JsonResult UniversityReadHistory( int DepartmentID, string collegeID, JqSearchIn si)
        {
            var QCGridData = new JQGrid();

            //  QCGridData = _AdminRepository.TotalUsageITI(si);
            QCGridData = _AdminRepository.UniversityUserReadHistory(si, DepartmentID, collegeID);

            //  return univreadhistry;
            return Json(QCGridData, JsonRequestBehavior.AllowGet);
        }



    }
}
