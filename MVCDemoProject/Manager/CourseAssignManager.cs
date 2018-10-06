using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class CourseAssignManager
    {
        CourseAssignGeteway courseAssignGeteway=new CourseAssignGeteway();
        TeacherManager techerManager=new TeacherManager();
     StudentGateway studentGateway=new StudentGateway();
        public string SaveCourseAssign(CourseAssign courseAssign)
        {
            CourseAssign aCourseAssign = courseAssignGeteway.IsExist(courseAssign);
            if (aCourseAssign==null)
            {
                //decimal remainingCredit = courseAssign.TeacherRemainingCredit;
                //if (remainingCredit>=0)
                //{ 
                     techerManager.UpdateTeacherRemainingCredit(courseAssign.TeacherRemainingCredit,courseAssign.TeacherID);
                    int rowsAffected = courseAssignGeteway.SaveCourseAssign(courseAssign);

                    if (rowsAffected > 0)
                    {
                        return "Saved Successful";

                    }
                    else
                    {
                        return "Saved Failed";
                    }
                //}
                //else
                //{
                //    return "Teacher credit can not be smaller than course credit";
                //}


            }
            else
            {
                return " Course can not be Assign Again & One course for only one teacher ";
            }

         
        }

        public string CourseUnassign()
        {
            int rowsAffected = courseAssignGeteway.CourseUnassign();

            if (rowsAffected > 0)
            {
                techerManager.UpdateTeacherRemainingCreditWhenUnassign();
                studentGateway.UpdateEnrollStatus();
                return "Saved Successful";

            }
            else
            {
                return "Saved Failed";
            }
        }
        
    }
}