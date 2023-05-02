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
        private readonly string _apiKey;
        public SemaphoreSmsClient()
        {
            //_apiKey = 
        }

        public Task<OtpResponse> SendOtpAsync(string number)
        {
            throw new NotImplementedException();
        }
    }
}
