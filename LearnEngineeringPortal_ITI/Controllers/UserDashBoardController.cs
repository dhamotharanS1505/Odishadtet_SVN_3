using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odishadtet.Models;

namespace Odishadtet.Controllers
{
    [CustomAuthorization]
    public class UserDashBoardController : Controller
    {
        // GET: UserDashBoard
        public ActionResult UserDashboard()
        {
            return View();
        }

        public ActionResult UserUsageDashboard()
        {
            if (HttpContext.Session["loginUserRoledescription"].ToString() == "Students" || HttpContext.Session["loginUserRoledescription"].ToString() == "Instructor")
            {
                return View(@"~\Views\UserDashBoard\UsageDashBoardNew.cshtml");
                            
            }           
            else
            {
                return View(@"~\Views\UserDashBoard\CollegeAdminUsageDashBoardNew.cshtml");
            }
        }

        public ActionResult UserUsageReadHistory()
        {
            return View(@"~\Views\UserDashBoard\UsersReadHistory.cshtml");
        }

        public ActionResult Profile()
        {

            return View();
        }



        public ActionResult Help()
        {

            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }


        // GET: UserDashBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserDashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDashBoard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserDashBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserDashBoard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserDashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserDashBoard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
