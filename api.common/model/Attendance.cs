using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class Attendance
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
