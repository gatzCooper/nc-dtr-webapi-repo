using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class ChangePassRequest
    {
        public string number { get; set; }
        public int otpcode { get; set; }
        public string newPassword { get; set; }
    }
}
