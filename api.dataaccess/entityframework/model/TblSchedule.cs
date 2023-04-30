using System;
using System.Collections.Generic;

#nullable disable

namespace api.dataaccess.entityframework.model
{
    public partial class TblSchedule
    {
        public int ScheduleId { get; set; }
        public int SubjectId { get; set; }
        public int UserId { get; set; }
        public string WorkDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
