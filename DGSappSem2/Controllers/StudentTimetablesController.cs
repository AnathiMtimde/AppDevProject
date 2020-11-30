using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGSappSem2.Models;
using DGSappSem2.Models.Students;

namespace DGSappSem2.Controllers
{
    public class StudentTimetablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentTimetables
        public ActionResult Index()
        {
            return View(db.StudentTimetables.ToList());
        }

        // GET: StudentTimetables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTimetable studentTimetable = db.StudentTimetables.Find(id);
            if (studentTimetable == null)
            {
                return HttpNotFound();
            }
            return View(studentTimetable);
        }

        // GET: StudentTimetables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentTimetables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create(StudentTimetable studentTimetable)
        {
           
                db.StudentTimetables.Add(studentTimetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: StudentTimetables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTimetable studentTimetable = db.StudentTimetables.Find(id);
            if (studentTimetable == null)
            {
                return HttpNotFound();
            }
            return View(studentTimetable);
        }

        // POST: StudentTimetables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit( StudentTimetable studentTimetable)
        {
            
                db.Entry(studentTimetable).State = EntityState.Modified;
               // db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: StudentTimetables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTimetable studentTimetable = db.StudentTimetables.Find(id);
            if (studentTimetable == null)
            {
                return HttpNotFound();
            }
            return View(studentTimetable);
        }

        // POST: StudentTimetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentTimetable studentTimetable = db.StudentTimetables.Find(id);
            db.StudentTimetables.Remove(studentTimetable);
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
