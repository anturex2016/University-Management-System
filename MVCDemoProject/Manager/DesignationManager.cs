using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class DesignationManager
    {
        DesignationGateway designationGateway=new DesignationGateway();

        public List<Designation> GetAllDesignations()
        {
            return designationGateway.GetAllDesignations();
        }
    }
}