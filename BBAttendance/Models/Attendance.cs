#nullable disable
using System;
using System.Collections.Generic;

namespace BBAttendance
{
    public class Attendance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LongLat { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
        public int? Status { get; set; }
        public User User { get; set; }

    }
}
