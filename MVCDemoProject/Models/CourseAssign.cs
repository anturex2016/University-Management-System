using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoProject.Models
{
    public class CourseAssign
    {
        public int CourseAssignID { get; set; }
        public int DepartmentID { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
        public decimal TeacherRemainingCredit { get; set; }
        public string TeacherName { get; set; }


    }
}