using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway=new TeacherGateway();
        public string saveTeacher(Teacher teacher)
        {

            Teacher aTeacher = teacherGateway.IsExist(teacher);
            if (aTeacher == null)
            {
                int rowsAffected = teacherGateway.SaveTeacher(teacher);

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
                return "Email must be Unique";
            }

        }

       public List<Teacher>GetAllTeacherByDepartment(int departmentId)
        {

            return teacherGateway.GetAllTeacherByDepartment(departmentId);

        }

        public List<Teacher> GetAllTeacherByTeacherId(int teacherId)
        {
            return teacherGateway.GetAllTeacherByTeacherId(teacherId);
        }


        public int UpdateTeacherRemainingCredit(decimal teacherRemaingingCredit,int teacherId)
        {
          
                int rowsAffected = teacherGateway.UpdateTeacherRemainingCredit(teacherRemaingingCredit,teacherId);
                if (rowsAffected > 0)
                {
                    return rowsAffected;

                }
                else
                {
                    return rowsAffected;
                }
            
         
          
        }

        public int UpdateTeacherRemainingCreditWhenUnassign()
        {
            int rowsAffected = teacherGateway.UpdateTeacherRemainingCreditWhenUnassign();
            if (rowsAffected > 0)
            {
                return rowsAffected;

            }
            else
            {
                return rowsAffected;
            }
        }

    }
}