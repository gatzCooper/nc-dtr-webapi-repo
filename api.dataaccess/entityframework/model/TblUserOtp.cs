using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.dataaccess.entityframework.model
{
    public partial class TblUserOtp
    {
        public int UserOtpId { get; set; }
        public int UserId { get; set; }
        public int OtpCode { get; set; }
    }
}
