using SmsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsClient.Services
{
    public interface ISemaphoreSmsClient
    {
        Task<OtpResponse> SendOtpAsync(string number);
    }
}
