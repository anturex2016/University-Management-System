using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoProject.Manager;
using MVCDemoProject.Models;

namespace MVCDemoProject.Controllers
{
    public class RoomAllocationController : Controller
    {

        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        RoomManager roomManager=new RoomManager();
        RoomAllocationManager roomAllocationManager=new RoomAllocationManager();
        
        public ActionResult AllocateRoom()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
            ViewBag.Courses = courseManager.GetAllCourses();
            ViewBag.Rooms = roomManager.GetAllRoom();
            ViewBag.Days = roomManager.GetAllDays();
            return View();
        }

        [HttpPost]
        public ActionResult AllocateRoom(AllocationRoom allocationRoom)
        {
            ViewBag.SaveRooms= roomAllocationManager.SaveRoomAllocation(allocationRoom);
            ViewBag.Departments = departmentManager.GetAllDepartments();
            ViewBag.Courses = courseManager.GetAllCourses();
            ViewBag.Rooms = roomManager.GetAllRoom();
            ViewBag.Days = roomManager.GetAllDays();
            return View();
        }




        public JsonResult GetCourseByDepartmentId(Department department)
        {
            var courseList = courseManager.GetAllCourseByDepartment(department.DepartmentID);
            return Json(courseList);
        }


        public ActionResult ViewClassScheduleAndRoomAllocation()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
            return View();
        }

        public JsonResult ClassScheduleByDepartmentId(int departmentId)
        {
            var courses = courseManager.GetAllCourseByDepartment(departmentId);
            List<object> clsSches = new List<object>();

            foreach (var course in courses)
            {
                var scheduleInfo = roomAllocationManager.GetClassScheduleByDepartmentId(departmentId, course.CourseID);
                if (scheduleInfo == "")
                {
                    scheduleInfo = "Not sheduled yet";
                }


                var clsSch = new
                {
                    CourseCode = course.CourseName,
                    CourseName = course.CourseCode,
                    ScheduleInfo = scheduleInfo
                };
                clsSches.Add(clsSch);
            }

            return Json(clsSches);
        }

        public ActionResult UnAllocateRooms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnAllocateRooms(int?id)
        {
            //ViewBag.UnallocateRoom = roomAllocationManager.UnalloacteRooms();
            return View();
        }
	}
}