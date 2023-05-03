using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class UserOtp
    {
        public int UserId { get; set; }
        public int OtpCode { get; set; }
    }
}
