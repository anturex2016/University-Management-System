using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class CourseGateway:Gateway
    {
        public int SaveCourse(Course course)
        {
           
            //Query = "INSERT INTO Departments VALUES ('"+code+"','"+name+"')";

            Query = "INSERT INTO Courses (CourseCode,CourseName,CourseCredit,CourseDescription,DepartmentID,SemesterID) VALUES (@code, @name,@credit,@description,@departmentId,@semesterId)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("code",course.CourseCode);
            Command.Parameters.AddWithValue("name",course.CourseName);
            Command.Parameters.AddWithValue("credit", course.CourseCredit);
            Command.Parameters.AddWithValue("description", course.CourseDescription);
            Command.Parameters.AddWithValue("departmentId", course.DepartmentID);
            Command.Parameters.AddWithValue("semesterId", course.SemesterID);

            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public Course IsExist(Course course)
        {
            Query = "SELECT * FROM Courses WHERE CourseCode='" +course.CourseCode+ "' AND CourseName='" +course.CourseName+ "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Course aCourse = null;
            while (Reader.Read())
            {
                aCourse = new Course();
                aCourse.CourseID = (int)Reader["CourseID"];
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseDescription = Reader["CourseDescription"].ToString();
                aCourse.CourseCredit = (decimal) Reader["CourseCredit"];
                aCourse.DepartmentID = (int) Reader["DepartmentID"];
                aCourse.SemesterID = (int) Reader["SemesterID"];
            }
            Reader.Close();
            Connection.Close();
            return aCourse;
        }



        public Course IsExistCode(Course course)
        {
            Query = "SELECT * FROM Courses WHERE CourseCode='" + course.CourseCode + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Course aCourse = null;
            while (Reader.Read())
            {
                aCourse = new Course();
                aCourse.CourseID = (int)Reader["CourseID"];
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseDescription = Reader["CourseDescription"].ToString();
                aCourse.CourseCredit = (decimal)Reader["CourseCredit"];
                aCourse.DepartmentID = (int)Reader["DepartmentID"];
                aCourse.SemesterID = (int)Reader["SemesterID"];
            }
            Reader.Close();
            Connection.Close();
            return aCourse;
        }

        public Course IsExistName(Course course)
        {
            Query = "SELECT * FROM Courses WHERE CourseName='" + course.CourseName + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Course aCourse = null;
            while (Reader.Read())
            {
                aCourse = new Course();
                aCourse.CourseID = (int)Reader["CourseID"];
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseDescription = Reader["CourseDescription"].ToString();
                aCourse.CourseCredit = (decimal)Reader["CourseCredit"];
                aCourse.DepartmentID = (int)Reader["DepartmentID"];
                aCourse.SemesterID = (int)Reader["SemesterID"];
            }
            Reader.Close();
            Connection.Close();
            return aCourse;
        }
        public List<Course> GetAllCoursesByDepartments(int departmentId)
        {
            Query = "SELECT * FROM Courses WHERE DepartmentID='"+departmentId+"'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                  
                CourseID = (int)Reader["CourseID"],
                CourseCode = Reader["CourseCode"].ToString(),
                CourseName = Reader["CourseName"].ToString(),
                CourseDescription = Reader["CourseDescription"].ToString(),
                CourseCredit = (decimal) Reader["CourseCredit"],
                DepartmentID = (int) Reader["DepartmentID"],
                SemesterID = (int) Reader["SemesterID"]
                };
             courseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }

        public List<Course> GetAllCoursesByCourseId(int courseId)
        {
            Query = "SELECT * FROM Courses WHERE CourseID='" +courseId+ "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {

                    CourseID = (int)Reader["CourseID"],
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseDescription = Reader["CourseDescription"].ToString(),
                    CourseCredit = (decimal)Reader["CourseCredit"],
                    DepartmentID = (int)Reader["DepartmentID"],
                    SemesterID = (int)Reader["SemesterID"]
                };
                courseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }


        public List<CourseStatistic> GetCourseStatistics(int departmentId)
        {
            Query = "SELECT Courses.CourseCode, Courses.CourseName,Semesters.SemesterName, Teachers.TeacherName FROM Courses LEFT JOIN CourseAssigns ON CourseAssigns.CourseID = Courses.CourseID LEFT JOIN Semesters On Courses.SemesterID=Semesters.SemesterID LEFT JOIN Teachers on Teachers.TeacherID=CourseAssigns.TeacherID Where Courses.DepartmentID  ='"+departmentId+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseStatistic> statistics = new List<CourseStatistic>();
            while (Reader.Read())
            {
                CourseStatistic statistic = new CourseStatistic
                {
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    SemesterName = Reader["SemesterName"].ToString(),
                    //TeacherId  =(int)Reader["TeacherID"],
                    TeacherName = Reader["TeacherName"].ToString(),
                    //DepartmentId = (int)Reader["DepartmentID"]
                 
                };
                statistics.Add(statistic);
            }
            Reader.Close();
            Connection.Close();
            return statistics;
        }

        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM Courses ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {

                    CourseID = (int)Reader["CourseID"],
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseDescription = Reader["CourseDescription"].ToString(),
                    CourseCredit = (decimal)Reader["CourseCredit"],
                    DepartmentID = (int)Reader["DepartmentID"],
                    SemesterID = (int)Reader["SemesterID"]
                };
                courseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }


        public List<Course> GetAllCoursesByStudentId(int studentId)
        {
            Query = "Select courseID,CourseName from Courses inner join Students on Students.DepartmentId=Courses.DepartmentID  where StudentID='" + studentId + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    CourseID = (int)Reader["CourseID"],
                   
                    CourseName = Reader["CourseName"].ToString(),
                  
                };
                courseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }


        public List<Course> GetCourseFromEnrollByStudentId(int studentId)
        {
            Query = "Select Courses.CourseID,Courses.CourseName from Enrollments inner join Courses on Courses.CourseID=Enrollments.CourseID where StudentID='" + studentId + "'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    CourseID = (int)Reader["CourseID"],

                    CourseName = Reader["CourseName"].ToString(),

                };
                courseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courseList;
        }




        //public Teacher GetTeacherNameBydepartmentId(int departmentId)
        //{
        //    Query = "Select Teachers.TeacherName from  CourseAssigns inner join Courses on CourseAssigns.CourseID=Courses.CourseID inner join Teachers on Teachers.TeacherID=CourseAssigns.TeacherId where CourseAssigns.DepartmentID='" + departmentId + "'";
        //    Command = new SqlCommand(Query, Connection);

        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    Teacher aTeacher = null;
        //    while (Reader.Read())
        //    {

        //        aTeacher = new Teacher
        //        {
        //            TeacherName = Reader["TeacherName"].ToString()
                    
                   
        //        };


        //        //aTeacher.Add(teacher);

        //    }
        //    Reader.Close();
        //    Connection.Close();


        //    return aTeacher;
        //}

        //public List<Course> GetCoursesForCourseStatisticBydepartmentId(int departmentId)
        //{
        //    Query = "Select CourseCode,CourseName,Semesters.SemesterName from Courses inner join Semesters on Semesters.SemesterID=Courses.SemesterID Where DepartmentID='" + departmentId + "'";
        //    Command = new SqlCommand(Query, Connection);

        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<Course> courseList = new List<Course>();
        //    while (Reader.Read())
        //    {
        //        Course aCourse = new Course
        //        {

        //            CourseCode = Reader["CourseCode"].ToString(),
        //            CourseName = Reader["CourseName"].ToString(),
        //            SemesterName = Reader["SemesterName"].ToString()

        //        };
        //        courseList.Add(aCourse);
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return courseList;
        //}






    }
}