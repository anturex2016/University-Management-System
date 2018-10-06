using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class RoomAllocationGateway:Gateway
    {
        public int SaveRoomAlloaction(AllocationRoom allocationRoom)
        {


            allocationRoom.Time = Time(allocationRoom.FromTime, allocationRoom.ToTime);
            //allocationRoom.SheduleStatus = 1;

            Query = "INSERT INTO RoomAllocations (DepartmentID,CourseID,RoomID,DayID,FromTime,ToTime,Time) VALUES (@departmentId, @courseId,@roomId,@dayId,@fromTime,@toTime,@time)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("departmentId", allocationRoom.DepartmentId);
            Command.Parameters.AddWithValue("courseId",allocationRoom.CourseId);
            Command.Parameters.AddWithValue("roomId", allocationRoom.RoomId);
            Command.Parameters.AddWithValue("dayId", allocationRoom.DayId);
            Command.Parameters.AddWithValue("fromTime", allocationRoom.FromTime);
            Command.Parameters.AddWithValue("toTime", allocationRoom.ToTime);
            Command.Parameters.AddWithValue("time", allocationRoom.Time);
            //Command.Parameters.AddWithValue("scheduleStatus", allocationRoom.SheduleStatus);
         

            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }


        public List<AllocationRoom> GetClassSchedulByStartAndEndingTime(int roomId, int dayId, DateTime startTime,DateTime endTime)
        {
            Query = "Select * from RoomAllocations where RoomID='" + roomId + "' and DayID='"+dayId+"' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AllocationRoom> roomAllocatinListList = new List<AllocationRoom>();
            while (Reader.Read())
            {
                AllocationRoom allocationRoom = new AllocationRoom
                {

                    RoomAllocationId = (int)Reader["RoomAllocationID"],
                    DepartmentId = (int)Reader["DepartmentID"],
                    CourseId =(int) Reader["CourseID"],
                    RoomId = (int)Reader["RoomID"],
                    DayId = (int)Reader["DayID"],
                    FromTime = (DateTime)Reader["FromTime"],
                    ToTime = (DateTime)Reader["ToTime"],
                    Time=Reader["Time"].ToString()
                };
                roomAllocatinListList.Add(allocationRoom);
            }
            Reader.Close();
            Connection.Close();
            return roomAllocatinListList;

        }


        public string Time(DateTime from, DateTime to)
        {
            string time = from.ToString("h:ss tt") + "-" + to.ToString("h:ss tt");
            return time;
        }


        public List<ClassRoomSchedule> GetClassRoomSchedulesByDepartmentId(int departmentId, int courseId)
        {
            Query = "Select Rooms.RoomNo,Days.DayName,RoomAllocations.Time from RoomAllocations inner join Rooms on Rooms.RoomID=RoomAllocations.RoomID inner join Days on Days.DayID=RoomAllocations.DayID where RoomAllocations.DepartmentID='" + departmentId + "' and RoomAllocations.CourseID='" + courseId + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ClassRoomSchedule> classRoomScheduetList = new List<ClassRoomSchedule>();
            while (Reader.Read())
            {
                ClassRoomSchedule schedule = new ClassRoomSchedule
                {

                    RoomNo = Reader["RoomNo"].ToString(),
                    DayName = Reader["DayName"].ToString(),
                    Time = Reader["Time"].ToString()
                };
                classRoomScheduetList.Add(schedule);
            }
            Reader.Close();
            Connection.Close();
            return classRoomScheduetList;
        }

        public int UnalloacteRooms()
        {
            Query = "Update RoomAllocations Set SheduleStatus='" + 0 + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected;
        }
    }
}