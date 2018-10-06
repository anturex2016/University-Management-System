using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway = new DepartmentGateway();

        public string saveDepartment(Department department)
        {

            Department aDepartment = departmentGateway.IsExistCode(department);
            if (aDepartment == null)
            {
               Department bDepartment = departmentGateway.IsExistName(department);
                if (bDepartment==null)
                {
                    int rowsAffected = departmentGateway.SaveDepartment(department);

                    if (rowsAffected > 0)
                    {
                        return "Saved Successful";

                    }
                    else
                    {
                        return "Saved Failed";
                    }
                    
                }
                else
                {
                    return "Department  Name must be Unique";
                }
             
            }
            else
            {
                return "Department Code  must be Unique";
            }

        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = departmentGateway.GetAllDepartments();
            //if (departments==null)
            //{
                
            //}
            
            
            return departments;
        }

     

    }
}