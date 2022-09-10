using Student_Teacher_MVC.DbContextDB;
using Student_Teacher_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Student_Teacher_MVC.Controllers
{
    public class StudentController : Controller
    {
        TeacherDbContext db = new TeacherDbContext();
        // GET: Student
        public ActionResult Index(int ? page)
        {
            var PageNumber = page ?? 1;
            var PageSize = 3;
            var StudentList = db.Students.OrderBy(model => model.ID).ToPagedList(PageNumber, PageSize);
            return View(StudentList);
        }

        public ActionResult Create()
        {
            ViewBag.Teachers = db.Teachers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Teacher_ID = new SelectList(db.Teachers, "ID", "Name");
            var editedStudent = db.Students.Where(model => model.ID == id).FirstOrDefault();
            return View(editedStudent);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deletedStudent = db.Students.Where(model => model.ID == id).FirstOrDefault();
            return View(deletedStudent);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            //var deletedStudent = db.Students.Where(model => model.ID == id).FirstOrDefault();
            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}