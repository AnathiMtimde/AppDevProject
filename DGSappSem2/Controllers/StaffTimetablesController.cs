using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models;
using DGSappSem2.Models.Staffs;

namespace DGSappSem2.Controllers
{
    public class StaffTimetablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StaffTimetables
        public ActionResult Index()
        {
            var staffTimetables = db.StaffTimetables.Include(s => s.Staff);
            return View(staffTimetables.ToList());
        }

        // GET: StaffTimetables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTimetable staffTimetable = db.StaffTimetables.Find(id);
            if (staffTimetable == null)
            {
                return HttpNotFound();
            }
            return View(staffTimetable);
        }

        // GET: StaffTimetables/Create
        public ActionResult Create()
        {
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Name");
            return View();
        }

        // POST: StaffTimetables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create( StaffTimetable staffTimetable)
        {
            
                db.StaffTimetables.Add(staffTimetable);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: StaffTimetables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTimetable staffTimetable = db.StaffTimetables.Find(id);
            if (staffTimetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "Name", staffTimetable.StaffId);
            return View(staffTimetable);
        }

        // POST: StaffTimetables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit( StaffTimetable staffTimetable)
        {
           
                db.Entry(staffTimetable).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: StaffTimetables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffTimetable staffTimetable = db.StaffTimetables.Find(id);
            if (staffTimetable == null)
            {
                return HttpNotFound();
            }
            return View(staffTimetable);
        }

        // POST: StaffTimetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffTimetable staffTimetable = db.StaffTimetables.Find(id);
            db.StaffTimetables.Remove(staffTimetable);
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
