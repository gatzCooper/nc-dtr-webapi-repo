using System;
using System.Collections.Generic;

#nullable disable

namespace api.dataaccess.entityframework.model
{
    public partial class TblConstant
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
        public string SubValue { get; set; }
    }
}
