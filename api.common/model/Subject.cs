using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class Subject
    {
        public int subjectId { get; set; }
        public string subjectCode { get; set; }
        public string subjectName { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updateDate { get; set; }
    }
}
