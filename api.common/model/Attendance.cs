using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class Attendance
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public TimeSpan? clockIn { get; set; }
        public TimeSpan? clockOut { get; set; }
        public TimeSpan? totalHours { get; set; }
        public TimeSpan? underTime { get; set; }
        public TimeSpan? overTime { get; set; }
        public DateTime createdAt { get; set; }
    }
}
