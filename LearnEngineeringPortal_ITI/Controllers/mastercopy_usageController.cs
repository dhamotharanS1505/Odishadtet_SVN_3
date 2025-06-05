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

namespace Odishadtet.Controllers
{
    public class mastercopy_usageController : Controller
    {
        private learnengg_payment_portal_entities db = new learnengg_payment_portal_entities();

        // GET: mastercopy_usage
        public ActionResult Index()
        {
            return View(db.mastercopy_usage_details.ToList());
        }

        // GET: mastercopy_usage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mastercopy_usage_details mastercopy_usage_details = db.mastercopy_usage_details.Find(id);
            if (mastercopy_usage_details == null)
            {
                return HttpNotFound();
            }
            return View(mastercopy_usage_details);
        }

        // GET: mastercopy_usage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mastercopy_usage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mastercopy_usage_id,user_name,email_id,mobile,department_name,semester,requested_on,otp_code,is_otp_verified")] mastercopy_usage_details mastercopy_usage_details)
        {
            if (ModelState.IsValid)
            {
                db.mastercopy_usage_details.Add(mastercopy_usage_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mastercopy_usage_details);
        }

        // GET: mastercopy_usage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mastercopy_usage_details mastercopy_usage_details = db.mastercopy_usage_details.Find(id);
            if (mastercopy_usage_details == null)
            {
                return HttpNotFound();
            }
            return View(mastercopy_usage_details);
        }

        // POST: mastercopy_usage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mastercopy_usage_id,user_name,email_id,mobile,department_name,semester,requested_on,otp_code,is_otp_verified")] mastercopy_usage_details mastercopy_usage_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mastercopy_usage_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mastercopy_usage_details);
        }

        // GET: mastercopy_usage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mastercopy_usage_details mastercopy_usage_details = db.mastercopy_usage_details.Find(id);
            if (mastercopy_usage_details == null)
            {
                return HttpNotFound();
            }
            return View(mastercopy_usage_details);
        }

        // POST: mastercopy_usage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mastercopy_usage_details mastercopy_usage_details = db.mastercopy_usage_details.Find(id);
            db.mastercopy_usage_details.Remove(mastercopy_usage_details);
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
    }
}
