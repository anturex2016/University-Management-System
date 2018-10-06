using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway=new SemesterGateway();

        public List<Semester> GetAllSemester()
        {
            return semesterGateway.GetAllSemester();
        }
    }
}