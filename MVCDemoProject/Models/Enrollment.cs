using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoProject.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public int EnrollStatus { get; set; }


    }
}