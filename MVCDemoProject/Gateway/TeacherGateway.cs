using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class TeacherGateway : Gateway
    {
        public int SaveTeacher(Teacher teacher)
        {
            decimal remainingCredit = teacher.TeacherCredit;
            //Query = "INSERT INTO Departments VALUES ('"+code+"','"+name+"')";

            Query = "INSERT INTO Teachers (TeacherName,TeacherAddress,TeacherEmail,TeacherContactNo,DesignationID,DepartmentID,TeacherCredit,TeacherRemainingCredit) VALUES (@name, @address,@email,@contactNo,@designationId,@departmentId,@teacherCredit,@remainingCredit)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("name", teacher.TeacherName);
            Command.Parameters.AddWithValue("address", teacher.TeacherAddress);
            Command.Parameters.AddWithValue("email", teacher.TeacherEmail);
            Command.Parameters.AddWithValue("contactNo", teacher.TeacherContactNo);
            Command.Parameters.AddWithValue("designationId", teacher.DesignationID);
            Command.Parameters.AddWithValue("departmentId", teacher.DepartmentID);
            Command.Parameters.AddWithValue("teacherCredit", teacher.TeacherCredit);
            Command.Parameters.AddWithValue("remainingCredit", remainingCredit);


            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }


        public Teacher IsExist(Teacher teacher)
        {
            Query = "SELECT * FROM Teachers WHERE TeacherEmail='" + teacher.TeacherEmail + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Teacher aTeacher = null;
            while (Reader.Read())
            {
                aTeacher = new Teacher();
                aTeacher.TeacherID = (int)Reader["TeacherID"];
                aTeacher.TeacherName = Reader["TeacherName"].ToString();
                aTeacher.TeacherAddress = Reader["TeacherAddress"].ToString();
                aTeacher.TeacherEmail = Reader["TeacherEmail"].ToString();
                //aTeacher.TeacherContactNo = (int)Reader["TeacherCoantactNo"];
                aTeacher.DesignationID = (int)Reader["DesignationID"];
                aTeacher.DepartmentID = (int)Reader["DepartmentID"];
                aTeacher.TeacherCredit = (decimal)Reader["TeacherCredit"];
                aTeacher.TeacherRemainingCredit = (decimal) Reader["TeacherRemainingCredit"];
            }
            Reader.Close();
            Connection.Close();
            return aTeacher;
        }

        public List<Teacher> GetAllTeacherByDepartment(int departmentId)
        {
            Query = "SELECT * FROM Teachers WHERE DepartmentID='" + departmentId + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teacherList = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.TeacherID = (int)Reader["TeacherID"];
                aTeacher.TeacherName = Reader["TeacherName"].ToString();
                aTeacher.TeacherAddress = Reader["TeacherAddress"].ToString();
                aTeacher.TeacherEmail = Reader["TeacherEmail"].ToString();
                //aTeacher.TeacherContactNo = (int)Reader["TeacherCoantactNo"];
                aTeacher.DesignationID = (int)Reader["DesignationID"];
                aTeacher.DepartmentID = (int)Reader["DepartmentID"];
                aTeacher.TeacherCredit = (decimal)Reader["TeacherCredit"];
                aTeacher.TeacherRemainingCredit = (decimal)Reader["TeacherRemainingCredit"];

                teacherList.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return teacherList;
        }

        public List<Teacher> GetAllTeacherByTeacherId(int teacherId)
        {
            Query = "SELECT * FROM Teachers WHERE TeacherID='" + teacherId + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teacherList = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.TeacherID = (int)Reader["TeacherID"];
                aTeacher.TeacherName = Reader["TeacherName"].ToString();
                aTeacher.TeacherAddress = Reader["TeacherAddress"].ToString();
                aTeacher.TeacherEmail = Reader["TeacherEmail"].ToString();
                //aTeacher.TeacherContactNo = (int)Reader["TeacherCoantactNo"];
                aTeacher.DesignationID = (int)Reader["DesignationID"];
                aTeacher.DepartmentID = (int)Reader["DepartmentID"];
                aTeacher.TeacherCredit = (decimal)Reader["TeacherCredit"];
                aTeacher.TeacherRemainingCredit = (decimal)Reader["TeacherRemainingCredit"];

                teacherList.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return teacherList;
        }

        public int UpdateTeacherRemainingCredit(decimal teacherRemainingCredit,int teacherId)
        {
            Query = "Update Teachers Set TeacherRemainingCredit ='"+teacherRemainingCredit+ "' Where TeacherID='"+ teacherId+"'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int UpdateTeacherRemainingCreditWhenUnassign()
        {
            Query = "Update Teachers Set TeacherRemainingCredit=TeacherCredit";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

    }
}