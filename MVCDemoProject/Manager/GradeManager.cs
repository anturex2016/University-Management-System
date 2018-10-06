using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    
    public class GradeManager
    {
        GradeGateway gradeGateway=new GradeGateway();
        public List<Grade> GetAllgrGrades()
        {
            return gradeGateway.GetAllGrades();
        }
    }
}