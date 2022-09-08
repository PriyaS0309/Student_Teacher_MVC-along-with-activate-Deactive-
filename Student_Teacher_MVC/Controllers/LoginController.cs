using Student_Teacher_MVC.DbContextDB;
using Student_Teacher_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Student_Teacher_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TeacherDbContext db = new TeacherDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u,string ReturnUrl)
        {
            if (IsValid(u)==true)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                Session["User"] = u.Username.ToString();

                if (ReturnUrl!=null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Teacher");
                }

               
            }
            else
            {
                return View();
            }
           
        }


        public bool IsValid(User u)
        {
            var result = db.Users.Where(model => model.Username == u.Username && model.Password == u.Password && model.Role==u.Role).FirstOrDefault();
            return (u.Username == result.Username && u.Password == result.Password && u.Role==result.Role);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("Index", "Teacher");
        }
    }
}