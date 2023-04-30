using System;
using System.Collections.Generic;

#nullable disable

namespace api.dataaccess.entityframework.model
{
    public partial class TblAttendance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? ClockIn { get; set; }
        public TimeSpan? LunchStart { get; set; }
        public TimeSpan? LunchEnd { get; set; }
        public TimeSpan? ClockOut { get; set; }
        public TimeSpan? TotalHours { get; set; }
        public TimeSpan? Undertime { get; set; }
        public TimeSpan? Overtime { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
