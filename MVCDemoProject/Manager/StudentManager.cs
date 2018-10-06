using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway=new StudentGateway();
        public string SaveStudent(Student student)
        {
            Student aStudent = studentGateway.IsExist(student);
            if (aStudent==null)
            {
                int rowsAffected = studentGateway.SaveStudent(student);

                if (rowsAffected > 0)
                {  string regnum=studentGateway.GetStudentRegistrationNumber(student.DepartmentID,student.RegistrationDate);
                    //Student astudent1 = studentGateway.GetStudentByRegNo(regnum);
                    //astudent1.StudentName=studentGateway.

                    return "Saved Successful";

                }
                else
                {
                    return "Save Successful ";
                }
                
            }

            else
            {
                return "Email must be unique ";
            }
             
        }



        public string SaveStudentEnroll(Enrollment enrollment)
        {
            Enrollment aEnrollment = studentGateway.IsExistStudentEnroll(enrollment);
            if (aEnrollment==null)
            {
                int rowsAffected = studentGateway.SaveStudentEnroll(enrollment);
                if (rowsAffected>0)
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
                Enrollment enrollment1 = studentGateway.IsExistEnrollStatus(enrollment);
                if (enrollment1.EnrollStatus==0)
                {
                    int status = 1;
                    studentGateway.UpdateEnrollCourse(enrollment,status);
                    return "Enroll Successful";
                }
                else
                {
                    return "One Student can enroll in a course only once";
                }
                
            }


            
        }

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }

        public List<Student> GetStudentByStudentId(int studentId)
        {
            return studentGateway.GetStudentByStudentId(studentId);
        }


        public string SaveStudentResult(Result result)
        {
            Result aResult = studentGateway.IsExistStudentResult(result);
            if (aResult==null)
            {
                int rowAffected = studentGateway.SaveStudentResult(result);
                if (rowAffected > 0)
                {
                    return "Save Result";
                }
                else
                {
                    return "Result Save Failed";
                }
            }
            else
            {
               int rowAffected= studentGateway.UpdateResult(result);
                if (rowAffected>0)
                {
                    return "Result update";
                }
                else
                {
                    return "Result update fail";
                }
            }
          
        }

        public List<Result> GetResultByStudentId(int studentId)
        {
            return studentGateway.GetResultByStudentId(studentId);
        }

        public Student GetStudentsByRegNo(Student student)
        {
            string regnum = studentGateway.GetStudentRegistrationNumber(student.DepartmentID, student.RegistrationDate);
            List<Student> tuStudents = studentGateway.GetStudentByRegNo(regnum);

            Student aStudent=new Student();
            foreach (Student students in tuStudents)
            {
                aStudent.StudentName = students.StudentName;
                aStudent.DepartmentName = students.DepartmentName;
            }
            return aStudent;
        }



        public Student LastSaveStuden()
        {
            return studentGateway.LastSaveStudent();
        }


    }
}