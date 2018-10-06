using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class SemesterGateway:Gateway
    {
        public List<Semester> GetAllSemester()
        {
            Query = "SELECT * FROM Semesters";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (Reader.Read())
            {
                Semester semester = new Semester
                {
                    SemesterID = (int)Reader["SemesterId"],
                    SemesterName = Reader["SemesterName"].ToString()
                };
                semesters.Add(semester);
            }
            Reader.Close();
            Connection.Close();
            return semesters;
        }
    }
}