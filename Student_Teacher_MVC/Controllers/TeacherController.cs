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
    //[Authorize(Roles = "admin")]
    public class TeacherController : Controller
    {
        TeacherDbContext db = new TeacherDbContext();
        // GET: Teacher
        public ActionResult Index(int? page)
        {
            var PageNumber = page ?? 1;
            var PageSize = 3;
            var TeacherList = db.Teachers.OrderByDescending(model => model.ID).ToPagedList(PageNumber, PageSize);
            return View(TeacherList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            db.Teachers.Add(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var editedTeacher = db.Teachers.Where(model => model.ID == id).FirstOrDefault();
            return View(editedTeacher);
        }

        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            db.Entry(teacher).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deletedTeacher = db.Teachers.Where(model => model.ID== id).FirstOrDefault();
            return View(deletedTeacher);
        }

        [HttpPost]
        public ActionResult Delete(int id, Teacher teacher)
        {
            // var deletedTeacher = db.Teachers.Where(model => model.ID == id).FirstOrDefault();
            db.Entry(teacher).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            var act = db.Teachers.Single(c => c.ID == id);
            act.IsActiveOrNot = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
        public ActionResult Deactive(int id)
        {
            var deact = db.Teachers.Single(c => c.ID == id);
            deact.IsActiveOrNot = false;
            db.SaveChanges();

            return RedirectToAction("Index", "Student");

        }


        //[HttpPost]
        //public ActionResult TeacherIsActive(int id)
        //{
        //    var Teachers = db.Teachers.FirstOrDefault(model => model.ID == id);
        //    var Students = db.Students.Where(model => model.ID == Teachers.ID).ToList();
        //    foreach (var item in Students)
        //    {
        //        item.IsActive = false;
        //    }

        //    return View();
        //}

    }
}