using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class RoomAllocationManager
    {
        RoomAllocationGateway roomAllocationGateway=new RoomAllocationGateway();

        public string SaveRoomAllocation(AllocationRoom allocationRoom)
        {

            if (allocationRoom.FromTime > allocationRoom.ToTime)
            {
                return "Start time can't be smaller ";
            }

            bool isTimeScheduleValid = IsTimeScheduleValid(allocationRoom.RoomId, allocationRoom.DayId,allocationRoom.FromTime,allocationRoom.ToTime);
            if (isTimeScheduleValid!=true)
            {
                int rowsAffected = roomAllocationGateway.SaveRoomAlloaction(allocationRoom);

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



                return "Overlap time schedule";
            }
         
        }


        private bool IsTimeScheduleValid(int roomId, int dayId, DateTime startTime, DateTime endTime)
        {
            List<AllocationRoom> schedule = roomAllocationGateway.GetClassSchedulByStartAndEndingTime(roomId, dayId, startTime, endTime);
            foreach (var sd in schedule)
            {
                if ((sd.DayId == dayId && roomId == sd.RoomId) &&
                                 (startTime < sd.FromTime && endTime > sd.FromTime)
                                 || (startTime < sd.FromTime && endTime > sd.FromTime) ||
                                 (startTime == sd.FromTime) || (sd.FromTime < startTime && sd.ToTime > startTime)
                                 )
                {
                    return true;
                }

            }
            return false;

        }

        public string GetClassScheduleByDepartmentId(int departmentId, int courseId)
        {
            List<ClassRoomSchedule> classRoomSchedules = roomAllocationGateway.GetClassRoomSchedulesByDepartmentId(departmentId, courseId);
            string output = "";
            foreach (var schedules in classRoomSchedules)
            {
                output += "R No." + schedules.RoomNo + "," + schedules.DayName + "," + schedules.Time+",</br>";
            }
            return output;
        }

        public string UnalloacteRooms()
        {
            int rowsAffected = roomAllocationGateway.UnalloacteRooms();
            if (rowsAffected>0)
            {
                return "Unallocate all classromms";
            }
            else
            {
                return "Unallocate Failed";
            }
        }
         
    }
}