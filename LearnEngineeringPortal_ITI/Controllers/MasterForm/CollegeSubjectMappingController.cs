using Odishadtet.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Odishadtet.DAL;
using Odishadtet.Models;

namespace Odishadtet.Controllers.MasterForm
{
    [CustomAuthorization]
    public class CollegeSubjectMappingController : Controller
    {
        private learnengg_payment_portal_entities db = new learnengg_payment_portal_entities();

        // GET: CollegeSubjectMapping
        public ActionResult Index()
        {
            var college_subject_mapping = db.college_subject_mapping.Include(c => c.college_master).Include(c => c.subject_master).Include(c => c.department_master);
            return View(college_subject_mapping.ToList());
        }

        // GET: CollegeSubjectMapping/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            college_subject_mapping college_subject_mapping = db.college_subject_mapping.Find(id);
            if (college_subject_mapping == null)
            {
                return HttpNotFound();
            }
            return View(college_subject_mapping);
        }

        // GET: CollegeSubjectMapping/Create
        public ActionResult Create()
        {
            ViewBag.college_id = new SelectList(db.college_master, "college_id", "college_code");
            ViewBag.subject_id = new SelectList(db.subject_master, "subject_id", "subject_code");
            ViewBag.department_id = new SelectList(db.department_master, "department_id", "department_code");
            return View();
        }

        // POST: CollegeSubjectMapping/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "college_subject_mapping_id,university_id,college_id,department_id,subject_id,rule_id,map_year,semester,active_status,created_by,created_on,active_duration_days,active_duration_date,total_license")] college_subject_mapping college_subject_mapping)
        {
            if (ModelState.IsValid)
            {
                db.college_subject_mapping.Add(college_subject_mapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.college_id = new SelectList(db.college_master, "college_id", "college_code", college_subject_mapping.college_id);
            ViewBag.subject_id = new SelectList(db.subject_master, "subject_id", "subject_code", college_subject_mapping.subject_id);
            ViewBag.department_id = new SelectList(db.department_master, "department_id", "department_code", college_subject_mapping.department_id);
            return View(college_subject_mapping);
        }

        // GET: CollegeSubjectMapping/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            college_subject_mapping college_subject_mapping = db.college_subject_mapping.Find(id);
            if (college_subject_mapping == null)
            {
                return HttpNotFound();
            }
            ViewBag.college_id = new SelectList(db.college_master, "college_id", "college_code", college_subject_mapping.college_id);
            ViewBag.subject_id = new SelectList(db.subject_master, "subject_id", "subject_code", college_subject_mapping.subject_id);
            ViewBag.department_id = new SelectList(db.department_master, "department_id", "department_code", college_subject_mapping.department_id);
            return View(college_subject_mapping);
        }

        // POST: CollegeSubjectMapping/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "college_subject_mapping_id,university_id,college_id,department_id,subject_id,rule_id,map_year,semester,active_status,created_by,created_on,active_duration_days,active_duration_date,total_license")] college_subject_mapping college_subject_mapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(college_subject_mapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.college_id = new SelectList(db.college_master, "college_id", "college_code", college_subject_mapping.college_id);
            ViewBag.subject_id = new SelectList(db.subject_master, "subject_id", "subject_code", college_subject_mapping.subject_id);
            ViewBag.department_id = new SelectList(db.department_master, "department_id", "department_code", college_subject_mapping.department_id);
            return View(college_subject_mapping);
        }

        // GET: CollegeSubjectMapping/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            college_subject_mapping college_subject_mapping = db.college_subject_mapping.Find(id);
            if (college_subject_mapping == null)
            {
                return HttpNotFound();
            }
            return View(college_subject_mapping);
        }

        // POST: CollegeSubjectMapping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            college_subject_mapping college_subject_mapping = db.college_subject_mapping.Find(id);
            db.college_subject_mapping.Remove(college_subject_mapping);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult CreateCollegeSubjectMapping()
        {
            return View();
        }
    }
}
