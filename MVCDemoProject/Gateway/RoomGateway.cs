using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCDemoProject.Models;

namespace MVCDemoProject.Gateway
{
    public class RoomGateway:Gateway
    {
        public List<Room> GetAllRoom()
        {
            Query = "SELECT * FROM Rooms";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (Reader.Read())
            {
                Room room = new Room
                {
                    RoomId = (int)Reader["RoomID"],
                    RoomNo = Reader["RoomNo"].ToString()
                };
                rooms.Add(room);
            }
            Reader.Close();
            Connection.Close();
            return rooms;
        }

        public List<Day> GetAllDay()
        {
            Query = "SELECT * FROM Days";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Day> days = new List<Day>();
            while (Reader.Read())
            {
                Day day = new Day
                {
                    DayId = (int)Reader["DayID"],
                    DayName = Reader["DayName"].ToString()
                };
                days.Add(day);
            }
            Reader.Close();
            Connection.Close();
            return days;
        }


    }
}