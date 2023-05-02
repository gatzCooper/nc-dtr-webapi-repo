using SmsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsClient.Services
{
    public class SemaphoreSmsClient : ISemaphoreSmsClient
    {
        private readonly string _apiKey = "a5abd33c5ee98cc1b2a3e0372e9d7e76";

        public Task<OtpResponse> SendOtpAsync(string number)
        {
            throw new NotImplementedException();
        }
    }
}
