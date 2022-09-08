using Student_Teacher_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Student_Teacher_MVC.DbContextDB
{
    public class TeacherDbContext:DbContext
    {
        public TeacherDbContext():base("MyConnectionString")
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}