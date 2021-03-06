﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssessmentBusiness;
using DGSappSem2.Models;
using DGSappSem2.Models.ViewModel;

namespace DGSappSem2.Controllers
{
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.ClassRoom);
            return View(subjects.ToList());
        }
    
        public ActionResult CourseMaterial(string sortOrder, string searchString)
        {
            ViewBag.Grade = String.IsNullOrEmpty(sortOrder) ? "Grade" : "";
            ViewBag.Subject = String.IsNullOrEmpty(sortOrder) ? "Subject" : "";
            ViewBag.Subject = String.IsNullOrEmpty(sortOrder) ? "Name_orderby" : "";



            //ViewBag.PublisherSortParm = String.IsNullOrEmpty(sortOrder) ? "pub_desc" : "";
            //ViewData["CurrentFilter"] = searchString;
            var subject = from s in db.Subjects
                        select s;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                subject = subject.Where(s => s.ClassRoom.GradeName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Grade":
                    subject = subject.OrderByDescending(s => s.ClassRoom.GradeName);
                    break;

                case "Name_orderby":
                    subject = subject.OrderBy(s => s.SubjectName);
                    break;
                case "Subject":
                    subject = subject.OrderByDescending(s => s.SubjectName);
                    break;
                default:
                    subject = subject.OrderBy(s => s.ClassRoom.GradeName);
                    break;

                    // ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", books.CategoryId);

            }

            return View(subject.ToList());
        }

        public ActionResult SubjectList(int classRoomId, string gradeName)
        {
            ViewBag.gradeName = gradeName;
            ViewBag.classRoomId = classRoomId;
            var subjects = db.Subjects.Include(s => s.ClassRoom).Where(c=>c.ClassRoomID == classRoomId);
            var subjectList = new List<SubjectVM>();
            var termList = db.Terms.ToList();
            foreach (var subject in subjects)
            {
                var subjectVM = new SubjectVM();
                subjectVM.SubjectID = subject.SubjectID;
                subjectVM.SubjectName = subject.SubjectName;
                subjectVM.RequirementPercentage = subject.RequiredPercentage;
                subjectVM.termLists = termList;
                subjectList.Add(subjectVM);
            }
            return View(subjectList);
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create(int classRoomId)
        {
            ViewBag.classRoomId = classRoomId;
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectID,SubjectName,RequiredPercentage,ClassRoomID,Upload")] Subject subject, HttpPostedFileBase Upload)
        {
            Upload.SaveAs(Server.MapPath("/") + "/Content/" + Upload.FileName);
            subject.Upload = Upload.FileName;

            db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassRoomID = new SelectList(db.ClassRooms, "ClassRoomID", "GradeName", subject.ClassRoomID);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectID,SubjectName,RequiredPercentage,ClassRoomID,Upload")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassRoomID = new SelectList(db.ClassRooms, "ClassRoomID", "GradeName", subject.ClassRoomID);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
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
