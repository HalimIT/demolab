using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo1.Models;

namespace Demo1.Controllers
{
    public class LabInfoesController : Controller
    {
        private Entities db = new Entities();

        // GET: LabInfoes
        public ActionResult Index()
        {
            return View(db.LabInfoes.ToList());
        }

        // GET: LabInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabInfo labInfo = db.LabInfoes.Find(id);
            if (labInfo == null)
            {
                return HttpNotFound();
            }
            return View(labInfo);
        }

        // GET: LabInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Objective,ProblemStatement")] LabInfo labInfo)
        {
            if (ModelState.IsValid)
            {
                db.LabInfoes.Add(labInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labInfo);
        }

        // GET: LabInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabInfo labInfo = db.LabInfoes.Find(id);
            if (labInfo == null)
            {
                return HttpNotFound();
            }
            return View(labInfo);
        }

        // POST: LabInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Objective,ProblemStatement")] LabInfo labInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(labInfo);
        }

        // GET: LabInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabInfo labInfo = db.LabInfoes.Find(id);
            if (labInfo == null)
            {
                return HttpNotFound();
            }
            return View(labInfo);
        }

        // POST: LabInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabInfo labInfo = db.LabInfoes.Find(id);
            db.LabInfoes.Remove(labInfo);
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
