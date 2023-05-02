using Newtonsoft.Json;
using SmsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SmsClient.Services
{
    public class SemaphoreSmsClient : ISemaphoreSmsClient
    {
        private readonly string _apiKey = "a5abd33c5ee98cc1b2a3e0372e9d7e76";

        public async Task<OtpResponse> SendOtpAsync(string contactNumber)
        {
            var requestBody = new
            {
                apiKey = _apiKey,
                number = contactNumber,
                message = "Your OTP Code is {otp}. DO NOT SHARE THIS TO ANYONE."
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var url = "https://api.semaphore.co/api/v4/otp";

                using (var response = await httpClient.PostAsync(url, content))
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var otpResponse = JsonConvert.DeserializeObject<OtpResponse>(responseContent);

                    return otpResponse;
                }
            }
        }
    }
}
