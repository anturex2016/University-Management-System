using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoProject.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherContactNo { get; set; }
        public int DesignationID { get; set; }
        public int DepartmentID { get; set; }
        public decimal TeacherCredit { get; set; }
        public decimal TeacherRemainingCredit { get; set; }

        


    }
}