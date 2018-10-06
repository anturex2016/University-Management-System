using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoProject.Models
{
    public class CourseStatistic
    {
      
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string SemesterName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int DepartmentId { get; set; }


    }
}