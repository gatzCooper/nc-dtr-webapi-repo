using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class Schedule
    {
        public int scheduleId { get; set; }
        public int subjectId { get; set; }
        public int userId { get; set; }
        public string workDay { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
    }
}
