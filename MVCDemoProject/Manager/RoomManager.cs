using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemoProject.Gateway;
using MVCDemoProject.Models;

namespace MVCDemoProject.Manager
{
    public class RoomManager
    {
        RoomGateway roomGateway=new RoomGateway();
        public List<Room> GetAllRoom()
        {
            return roomGateway.GetAllRoom();
        }

        public List<Day> GetAllDays()
        {
            return roomGateway.GetAllDay();
        }

    }
}