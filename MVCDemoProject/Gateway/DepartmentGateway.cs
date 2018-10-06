using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class DepartmentGateway : Gateway
    {
        public int SaveDepartment(Department department)
        {
            string code = department.DepartmentCode;
            string name = department.DepartmentName;
            //Query = "INSERT INTO Departments VALUES ('"+code+"','"+name+"')";

            Query = "INSERT INTO Departments (DepartmentCode,DepartmentName) VALUES (@code, @name)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("code", code);
            Command.Parameters.AddWithValue("name", name);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public Department IsExist(Department department)
        {
            Query = "SELECT * FROM Departments WHERE DepartmentCode='" + department.DepartmentCode + "' AND DepartmentName='" + department.DepartmentName + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Department aDepartment = null;
            while (Reader.Read())
            {
                aDepartment = new Department();
                aDepartment.DepartmentID = (int)Reader["DepartmentID"];
                aDepartment.DepartmentCode = Reader["DepartmentCode"].ToString();
                aDepartment.DepartmentName = Reader["DepartmentName"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aDepartment;
        }


        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Departments";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department department = new Department
                {
                    DepartmentID =(int) Reader["DepartmentID"],
                    DepartmentCode = Reader["DepartmentCode"].ToString(),
                    DepartmentName = Reader["DepartmentName"].ToString()
                };
                departments.Add(department);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }

        public Department IsExistCode(Department department)
        {
            Query = "SELECT * FROM Departments WHERE DepartmentCode='" + department.DepartmentCode + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Department aDepartment = null;
            while (Reader.Read())
            {
                aDepartment = new Department();
                aDepartment.DepartmentID = (int)Reader["DepartmentID"];
                aDepartment.DepartmentCode = Reader["DepartmentCode"].ToString();
                aDepartment.DepartmentName = Reader["DepartmentName"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aDepartment;
        }

        public Department IsExistName(Department department)
        {
            Query = "SELECT * FROM Departments WHERE  DepartmentName='" + department.DepartmentName + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Department aDepartment = null;
            while (Reader.Read())
            {
                aDepartment = new Department();
                aDepartment.DepartmentID = (int)Reader["DepartmentID"];
                aDepartment.DepartmentCode = Reader["DepartmentCode"].ToString();
                aDepartment.DepartmentName = Reader["DepartmentName"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aDepartment;
        }






        public string GetDepartmentCodeByDepartmentId(int department)
        {
            Query = "SELECT DepartmentCode FROM Departments WHERE DepartmentID='" + department+ "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            string code="";
            Department aDepartment = null;
            while (Reader.Read())
            {
                aDepartment = new Department();
                //aDepartment.DepartmentID = (int)Reader["DepartmentID"];
                aDepartment.DepartmentCode = Reader["DepartmentCode"].ToString();
                //aDepartment.DepartmentName = Reader["DepartmentName"].ToString();
                code = aDepartment.DepartmentCode;
            }
            Reader.Close();
            Connection.Close();
            
            return code;
        }




    }
}