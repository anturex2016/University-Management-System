using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoProject.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public decimal CourseCredit { get; set; }
        public string CourseDescription { get; set; }
        public int DepartmentID { get; set; }
        public int SemesterID { get; set; }
        public string SemesterName { get; set; }
    }
}