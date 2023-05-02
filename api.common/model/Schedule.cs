using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public string WorkDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
