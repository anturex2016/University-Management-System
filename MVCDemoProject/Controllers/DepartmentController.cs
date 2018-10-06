using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemoProject.Manager;
using MVCDemoProject.Models;

namespace MVCDemoProject.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();


        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            ViewBag.Message = departmentManager.saveDepartment(department);
            return View();
        }

        public ActionResult ShowAllDepartment()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            return View(departments);
        }
       
	}
}