using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoProject.Manager;
using MVCDemoProject.Models;

namespace MVCDemoProject.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
        StudentManager studentManager=new StudentManager();
        CourseManager courseManager=new CourseManager();
        GradeManager gradeManager=new GradeManager();
       
     
        public ActionResult SaveStudent()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
            ViewBag.LastStudent = studentManager.LastSaveStuden();
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudent(Student student)
        {
            ViewBag.Message = studentManager.SaveStudent(student);
            ViewBag.LastStudent = studentManager.LastSaveStuden();
            ViewBag.Departments = departmentManager.GetAllDepartments();
          
            return View();
        }

        public ActionResult Enroll()
        {
            ViewBag.Students = studentManager.GetAllStudents();
          
            return View();
        }

        [HttpPost]
        public ActionResult Enroll(Enrollment enrollment)
        {
            ViewBag.EnrollmentMessage = studentManager.SaveStudentEnroll(enrollment);
            ViewBag.Students = studentManager.GetAllStudents();
           
            return View();
        }

        public JsonResult GetStudentByStudentId(Student student)
        {
            var studentList =studentManager.GetStudentByStudentId(student.StudentId);
            return Json(studentList);
        }

        public JsonResult GetCourseByStudentId(Student student)
        {
            var courseList = courseManager.GetAllCoursesByStudentId(student.StudentId);
            return Json(courseList);
        }

        public ActionResult SaveStudentResult()
        {
            ViewBag.Students = studentManager.GetAllStudents();
            ViewBag.Grades = gradeManager.GetAllgrGrades();
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudentResult(Result result)
        {
            ViewBag.ResultMessage = studentManager.SaveStudentResult(result);
            ViewBag.Students = studentManager.GetAllStudents();
            ViewBag.Grades = gradeManager.GetAllgrGrades();
            return View();
        }

        public JsonResult GetCourseFromEnrollByStudentId(Student student)
        {
            var courseList = courseManager.GetCourseFromEnrollByStudentId(student.StudentId);
            return Json(courseList);
        }

        public ActionResult ViewStudentResult()
        {
            ViewBag.Students = studentManager.GetAllStudents();
            return View();
        }




        public JsonResult GetResultByStudentId(Student student)
        {
            var studentList = studentManager.GetResultByStudentId(student.StudentId);
            return Json(studentList);
        }


	}
}