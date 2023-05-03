using Newtonsoft.Json;
using SmsClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SmsClient.Services
{
    public class SemaphoreSmsClient : ISemaphoreSmsClient
    {
        private const string _ApiKey = "6ad148b42faaff5fd6af0619b317e41b";
        private const string _Url = "https://api.semaphore.co/api/v4/otp";

        private readonly HttpClient _httpClient;

        public SemaphoreSmsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<OtpResponse> SendOtpAsync(string phoneNumber)
        {
            try
            {

                var otpmessage = "Your OTP Code is {otp}. DO NOT SHARE THIS TO ANYONE.";
                var request = new
                {
                    apikey = _ApiKey,
                    number = phoneNumber,
                    message = otpmessage
                };
                var requestBody = JsonConvert.SerializeObject(request);
                var response = await _httpClient.PostAsync(_Url, new StringContent(requestBody, Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();

                var otpResponse = JsonConvert.DeserializeObject<IEnumerable<OtpResponse>>(responseBody);
                return otpResponse.FirstOrDefault();
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
