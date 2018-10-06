using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class StudentGateway:Gateway
    {
        DepartmentGateway departmentGateway=new DepartmentGateway();
        public int SaveStudent(Student student)
        {
            student.RegistrationNumber = GetStudentRegistrationNumber(student.DepartmentID, student.RegistrationDate);
            //Query = "INSERT INTO Departments VALUES ('"+code+"','"+name+"')";

            Query = "INSERT INTO Students (StudentName,StudentEmail,StudentContactNo,RegistrationDate,StudentAddress,DepartmentID,RegistrationNumber) VALUES (@name, @email,@contactNo,@registrationDate,@studentAddress,@departmentId,@registrationNumber)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("name",student.StudentName);
            Command.Parameters.AddWithValue("email",student.StudentEmail);
            Command.Parameters.AddWithValue("contactNo",student.StudentContactNo);
            Command.Parameters.AddWithValue("registrationDate",student.RegistrationDate);
            Command.Parameters.AddWithValue("studentAddress",student.StudentAddress);
            Command.Parameters.AddWithValue("departmentId",student.DepartmentID);
            Command.Parameters.AddWithValue("registrationNumber",student.RegistrationNumber);
          


            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public string GetStudentRegistrationNumber(int departmentId, DateTime date)
        {
          
            string departmentCode = departmentGateway.GetDepartmentCodeByDepartmentId(departmentId);
            DateTime registrationDate = date;
            List<Student> studentList = StudentNumber(departmentId);
            int count = studentList.Count()+1;
            int noOfZeroToBeAdded = 3 - count.ToString().Length;

            string noOfZero = "";
            for (int i = 0; i < noOfZeroToBeAdded; i++)
            {

                noOfZero += "0";


            }

            string registrationNo = departmentCode + "-" + registrationDate.Year + "-" + noOfZero+count;
            return registrationNo;
        }




        public List<Student> StudentNumber(int departmentId)
        {
            Query = "SELECT StudentName FROM Students WHERE DepartmentID='" + departmentId + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            //string code = "";
            List<Student>students=new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student();
                
                student.StudentName = Reader["StudentName"].ToString();
                //student.DepartmentID = (int)Reader["DepartmentID"];
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();

            return students;
        }


        public Student IsExist(Student student)
        {
            Query = "SELECT * FROM Students WHERE StudentEmail='" +student.StudentEmail+ "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Student aStudent = null;
            while (Reader.Read())
            {
                aStudent = new Student();
                aStudent.StudentId = (int)Reader["StudentID"];
                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.StudentContactNo = Reader["StudentContactNo"].ToString();
                aStudent.RegistrationDate =(DateTime) Reader["RegistrationDate"];
                //aTeacher.TeacherContactNo = (int)Reader["TeacherCoantactNo"];
                aStudent.StudentAddress = Reader["StudentAddress"].ToString();
                aStudent.DepartmentID = (int)Reader["DepartmentID"];
               
            }
            Reader.Close();
            Connection.Close();
            return aStudent;
        }



        public int SaveStudentEnroll(Enrollment enrollment)
        {
            enrollment.EnrollStatus = 1;

            Query = "INSERT INTO Enrollments (StudentID,CourseID,EnrollDate,EnrollStatus) VALUES (@studentId, @courseId,@date,@status)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("studentId", enrollment.StudentId);
            Command.Parameters.AddWithValue("courseId", enrollment.CourseId);
            Command.Parameters.AddWithValue("date",enrollment.EnrollDate);
            Command.Parameters.AddWithValue("status", enrollment.EnrollStatus);




            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public Enrollment IsExistStudentEnroll(Enrollment enrollment)
        {
            Query = "SELECT * FROM  Enrollments WHERE CourseID='" + enrollment.CourseId + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Enrollment aEnrollment = null;
            while (Reader.Read())
            {
                aEnrollment = new Enrollment();
                aEnrollment.EnrollmentId = (int)Reader["EnrollmentID"];
               aEnrollment.StudentId = (int)Reader["StudentID"];
                aEnrollment.CourseId = (int)Reader["CourseID"];
                aEnrollment.EnrollDate = (DateTime)Reader["EnrollDate"];

            }
            Reader.Close();
            Connection.Close();
            return aEnrollment;
        }

        public List<Student> GetAllStudents()
        {
            Query = "SELECT * FROM Students";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student
                {
                    StudentId = (int)Reader["StudentID"],
                    StudentName = Reader["StudentName"].ToString(),
                    StudentEmail = Reader["StudentEmail"].ToString(),
                    StudentContactNo=Reader["StudentContactNo"].ToString(),
                    RegistrationDate = (DateTime)Reader["RegistrationDate"],
                    StudentAddress = Reader["StudentAddress"].ToString(),
                    DepartmentID = (int)Reader["DepartmentID"],
                    RegistrationNumber = Reader["RegistrationNumber"].ToString()
                };
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }

        public List<Student> GetStudentByStudentId(int studentId)
        {
            Query = "Select Students.StudentName,Students.StudentEmail,Departments.DepartmentName,Students.DepartmentID from Students inner join Departments on Departments.DepartmentID=Students.DepartmentID where Students.StudentID ='" + studentId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student
                {
                    StudentName = Reader["StudentName"].ToString(),
                    StudentEmail= Reader["StudentEmail"].ToString(),
                     DepartmentID = (int)Reader["DepartmentID"],
                    DepartmentName = Reader["DepartmentName"].ToString()
                   
                    ////TeacherId  =(int)Reader["TeacherID"],
                    //TeacherName = Reader["TeacherName"].ToString(),
                    ////DepartmentId = (int)Reader["DepartmentID"]

                };
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }


        public int SaveStudentResult(Result result)
        {
            Query = "INSERT INTO Results (StudentID,CourseID,GradeID) VALUES (@studentId, @courseId,@gradeId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("studentId", result.StudentId);
            Command.Parameters.AddWithValue("courseId",result.CourseId);
            Command.Parameters.AddWithValue("gradeId",result.GradeId);




            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }


        public Result IsExistStudentResult(Result result)
        {
            Query = "SELECT StudentID,CourseID FROM  Results WHERE CourseID='" + result.CourseId+ "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Result aResult = null;
            while (Reader.Read())
            {
                aResult = new Result();
              
                aResult.StudentId = (int)Reader["StudentID"];
                aResult.CourseId = (int)Reader["CourseID"];
               
            }
            Reader.Close();
            Connection.Close();
            return aResult;
        }

        public int UpdateResult(Result result)
        {
            Query = "Update Results Set GradeID='" + result.GradeId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }



        public List<Result> GetResultByStudentId(int studentId)
        {
            Query = "Select Courses.CourseCode,Courses.CourseName,Grades.LetterGrade from Results inner join Grades on Grades.GradeID=Results.GradeID right join Enrollments on Enrollments.CourseID=Results.CourseID inner join Courses on Courses.CourseID=Enrollments.CourseID where Enrollments.StudentID ='" + studentId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Result> results = new List<Result>();
            while (Reader.Read())
            {
                Result result = new Result
                {
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    LetterGrade = Reader["LetterGrade"].ToString()

                    ////TeacherId  =(int)Reader["TeacherID"],
                    //TeacherName = Reader["TeacherName"].ToString(),
                    ////DepartmentId = (int)Reader["DepartmentID"]

                };
                results.Add(result);
            }
            Reader.Close();
            Connection.Close();
            return results;
        }

        public List<Student> GetStudentByRegNo(string regNo)
        {
            Query = "Select StudentName,StudentEmail,StudentContactNo,RegistrationDate,StudentAddress,Departments.DepartmentName,RegistrationNumber from Students inner join Departments on Departments.DepartmentID=Students.DepartmentID where RegistrationNumber ='" + regNo + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student
                {
                     StudentName = Reader["StudentName"].ToString(),
                     StudentEmail = Reader["StudentEmail"].ToString(),
                     StudentContactNo = Reader["StudentContactNo"].ToString(),
                     RegistrationDate = (DateTime) Reader["RegistrationDate"],
                     StudentAddress = Reader["StudentAddress"].ToString(),
                     DepartmentName = Reader["DepartmentName"].ToString(),
                     RegistrationNumber = Reader["RegistrationNumber"].ToString()

                };
               
                ////TeacherId  =(int)Reader["TeacherID"],
                //TeacherName = Reader["TeacherName"].ToString(),
                ////DepartmentId = (int)Reader["DepartmentID"]
                students.Add(student);

            }
            Reader.Close();
            Connection.Close();
            return students;
        }


        public Student LastSaveStudent()
        {
            Query = "SELECT * FROM Students WHERE StudentID=(SELECT max(StudentID) FROM Students) ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Student aStudent = null;
            while (Reader.Read())
            {
                aStudent = new Student();
                aStudent.StudentId = (int)Reader["StudentID"];
                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.StudentEmail = Reader["StudentEmail"].ToString();
                aStudent.StudentContactNo = Reader["StudentContactNo"].ToString();
                aStudent.RegistrationDate = (DateTime)Reader["RegistrationDate"];               
                aStudent.StudentAddress = Reader["StudentAddress"].ToString();
                aStudent.DepartmentID = (int)Reader["DepartmentID"];
                aStudent.RegistrationNumber = Reader["RegistrationNumber"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aStudent;
        }

        public Enrollment IsExistEnrollStatus(Enrollment enrollment)
        {
            Query = "SELECT EnrollStatus FROM Enrollments WHERE CourseID='" +enrollment.CourseId + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Enrollment aEnrollment = null;
            while (Reader.Read())
            {
                aEnrollment = new Enrollment();
                aEnrollment.EnrollStatus = (int)Reader["EnrollStatus"];

            }
            Reader.Close();
            Connection.Close();
            return aEnrollment ;
        }

        public int UpdateEnrollCourse(Enrollment enrollment,int status)
        {
            Query = "Update  Enrollments Set  EnrollStatus='"+status+"' where CourseID='"+enrollment.CourseId+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

        public int UpdateEnrollStatus()
        {
            Query = "Update Enrollments Set EnrollStatus='"+0+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }

    }
}