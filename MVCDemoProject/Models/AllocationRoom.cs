using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoProject.Models
{
    public class AllocationRoom
    {
        public int RoomAllocationId { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DayId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }

        public string Time { get; set; }
        public int SheduleStatus { get; set; }

    }
}