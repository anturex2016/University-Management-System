using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoProject.Manager;
using MVCDemoProject.Models;

namespace MVCDemoProject.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        SemesterManager semesterManager=new SemesterManager();
        CourseManager couseManager=new CourseManager();
     
        public ActionResult CourseStatistic()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
            return View();
        }


        public JsonResult GetCourseStatisticByDepartmentId(Department department)
        {
            var statisticList = couseManager.GetCourseStatistics(department.DepartmentID);
            List<object> courseStatistic = new List<object>();

            foreach (var statis in statisticList)
            {
                var option = statis.TeacherName;
                
                if (option==" ")
                {
                  
                    option = "Not Yet Assigned";
                   
                }
             
                var course = new CourseStatistic
                {
                    CourseCode = statis.CourseCode,
                    CourseName = statis.CourseName,
                    SemesterName = statis.SemesterName,
                    TeacherName = option
                };
                courseStatistic.Add(course);

            }

            return Json(courseStatistic);

        }

        public ActionResult SaveCourse()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
            ViewBag.Semesters = semesterManager.GetAllSemester();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            ViewBag.Message = couseManager.saveCourse(course);
            ViewBag.Departments = departmentManager.GetAllDepartments();
            ViewBag.Semesters = semesterManager.GetAllSemester();
            return View();
        }

    }
}