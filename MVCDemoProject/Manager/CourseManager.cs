using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class CourseManager
    {
        CourseGateway courseGateway=new CourseGateway();
        public string saveCourse(Course course)
        {

            Course aCourse = courseGateway.IsExistCode(course);
            if (aCourse == null)
            {
                Course bCourse = courseGateway.IsExistName(course);
                if (bCourse==null)
                {
                    int rowsAffected = courseGateway.SaveCourse(course);

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
                    return "Course Name  must be Unique";
                }
            
            }
            else
            {
                return "Course Code  must be Unique";
            }

        }

        public List<Course> GetAllCourseByDepartment(int departmentId)
        {
            return courseGateway.GetAllCoursesByDepartments(departmentId);
        }

        public List<Course> GetAllCourseByCourseId(int courseId)
        {
            return courseGateway.GetAllCoursesByCourseId(courseId);
        }

        public List<CourseStatistic> GetCourseStatistics(int departmentId)
        {
            return courseGateway.GetCourseStatistics(departmentId);
        }

        public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }

        public List<Course> GetAllCoursesByStudentId(int studentId)
        {
            return courseGateway.GetAllCoursesByStudentId(studentId);
        }

        public List<Course> GetCourseFromEnrollByStudentId(int studentId)
        {
            return courseGateway.GetCourseFromEnrollByStudentId(studentId);
        }

        //public string GetTeacherNameByDepartmentId(int departmentId)
        //{
        //    Teacher allTeacherss = courseGateway.GetTeacherNameBydepartmentId(departmentId);
             
        //     string output = allTeacherss.TeacherName;
        //    //foreach (var teacherList in allTeacherss)
        //    //{
        //    //    if (teacherList == null)
        //    //    {
        //    //        output = "Not Assined";
        //    //    }
        //    //    teacherList.TeacherName;
        //    //}
        //    ////if (allTeacherss == null)
        //    //{
        //    //    allTeacherss.TeacherName = "Not assigned";
        //    //}
        //    ;

        //    return  output;
        //}

        //public List<Course> GetCoursesFroCourseStatisticBydepartmentId(int departmentId)
        //{
        //    return courseGateway.GetCoursesForCourseStatisticBydepartmentId(departmentId);
        //}
    }
}