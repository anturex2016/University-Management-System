using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class GradeGateway:Gateway
    {
        public List<Grade> GetAllGrades()
        {
            Query = "SELECT * FROM Grades";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            while (Reader.Read())
            {
                Grade grade = new Grade
                {
                    GradeId = (int)Reader["GradeID"],
                    LetterGrade = Reader["LetterGrade"].ToString()
                };
                grades.Add(grade);
            }
            Reader.Close();
            Connection.Close();
            return grades;
        }
    }
}