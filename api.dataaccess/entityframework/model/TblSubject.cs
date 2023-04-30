using System;
using System.Collections.Generic;

#nullable disable

namespace api.dataaccess.entityframework.model
{
    public partial class TblSubject
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
