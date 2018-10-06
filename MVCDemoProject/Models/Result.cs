using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoProject.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int GradeId { get; set; }
        public string LetterGrade { get; set; }

    }
}