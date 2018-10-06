using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class CourseAssignGeteway:Gateway
    {
        public int SaveCourseAssign(CourseAssign courseAssign)
        {
            Query = "INSERT INTO CourseAssigns (DepartmentID,TeacherID,CourseID) VALUES (@departmentId, @teacherId,@courseId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("departmentId",courseAssign.DepartmentID);
            Command.Parameters.AddWithValue("teacherId",courseAssign.TeacherID);
            Command.Parameters.AddWithValue("courseId", courseAssign.CourseID);
            



            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }


        public CourseAssign IsExist(CourseAssign courseAssign)
        {
            Query = "SELECT * FROM CourseAssigns WHERE CourseID='" +courseAssign.CourseID + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            CourseAssign aCourseAssign = null;
            while (Reader.Read())
            {
                aCourseAssign = new CourseAssign();
                aCourseAssign.CourseAssignID = (int) Reader["CourseAssignID"];
                aCourseAssign.DepartmentID = (int)Reader["DepartmentID"];
                aCourseAssign.TeacherID = (int) Reader["TeacherID"];
                aCourseAssign.CourseID = (int)Reader["CourseID"];
                
            }
            Reader.Close();
            Connection.Close();
            return aCourseAssign;
        }

        public int CourseUnassign()
        {
            Query = "Delete CourseAssigns";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

    }
}