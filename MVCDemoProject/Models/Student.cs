using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoProject.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentContactNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string StudentAddress { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string RegistrationNumber { get; set; }
       

    }
}