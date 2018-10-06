using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MVCDemoProject.Manager;
using MVCDemoProject.Models;

namespace MVCDemoProject.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/

        private DesignationManager designationManager = new DesignationManager();
        private DepartmentManager departmentManager = new DepartmentManager();
        private TeacherManager teacherManager = new TeacherManager();
        private CourseManager courseManager = new CourseManager();
        private CourseAssignManager courseAssignManager=new CourseAssignManager();

      
        [HttpGet]
        public ActionResult Assign()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Assign(CourseAssign courseAssign)
        {
            ViewBag.Message = courseAssignManager.SaveCourseAssign(courseAssign);
            ViewBag.Departments = departmentManager.GetAllDepartments();
         
            //ViewBag.Message1 = teacherManager.UpdateTeacherRemainingCredit(courseAssign.TeacherRemainingCredit);
            return View();
        }


        public JsonResult GetTeacherByDepartmentId(Department department)
        {

            var teacherList = teacherManager.GetAllTeacherByDepartment(department.DepartmentID);
            return Json(teacherList);
        }

        public JsonResult GetCourseByDepartmentId(Department department)
        {
            var courseList = courseManager.GetAllCourseByDepartment(department.DepartmentID);
            return Json(courseList);
        }

        public JsonResult GetTeacherByTeacherId(Teacher teacher)
        {
            var teacherList = teacherManager.GetAllTeacherByTeacherId(teacher.TeacherID);
            return Json(teacherList);
        }

        public JsonResult GetCourseByCourseId(Course course)
        {
            var courseList = courseManager.GetAllCourseByCourseId(course.CourseID);
            return Json(courseList);
        }


        public ActionResult SaveTeacher()
        {
            ViewBag.Designations = designationManager.GetAllDesignations();
            ViewBag.Departments = departmentManager.GetAllDepartments();
            return View();
        }


        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            ViewBag.Message = teacherManager.saveTeacher(teacher);
            ViewBag.Designations = designationManager.GetAllDesignations();
            ViewBag.Departments = departmentManager.GetAllDepartments();
            return View();
        }

       [HttpGet]
        public ActionResult Unassign()
        {
            
            return View();
        }

        [HttpPost]
       public ActionResult Unassign(int? id)
        {
           
           ViewBag.Message = courseAssignManager.CourseUnassign();
          
            return View();
        }





    }
}