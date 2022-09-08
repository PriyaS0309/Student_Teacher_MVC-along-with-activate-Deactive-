using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Student_Teacher_MVC.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual int  Teacher_ID { get; set; }
        [ForeignKey("Teacher_ID")]
        public virtual Teacher Teacher { get; set; }

        public bool IsActive { get; set; }
    }
}