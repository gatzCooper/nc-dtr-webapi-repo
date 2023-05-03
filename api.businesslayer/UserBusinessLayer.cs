using api.common.Interface;
using api.common.model;
using api.dataaccess.entityframework.data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SmsClient.Model;
using SmsClient.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace api.businesslayer
{
    public class UserBusinessLayer : IUserBusinessLayer
    {
        private readonly IUserDataAccess _userDataAccess;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private const string _ApiKey = "6ad148b42faaff5fd6af0619b317e41b";
        private const string _Url = "https://api.semaphore.co/api/v4/otp";
        private readonly HttpClient _httpClient;
        public UserBusinessLayer(IUserDataAccess userDataAccess,
            IServiceScopeFactory serviceScopeFactory,
            HttpClient httpClient)
        {
            _userDataAccess = userDataAccess;
            _serviceScopeFactory = serviceScopeFactory;
            _httpClient = httpClient;
        }
        public async Task<User> GetUserLoginCredentials(string email, string password)
        {

            byte[] passwordHash;
            byte[] passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = await _userDataAccess.GetUserByemail(email, password);

            if(!VerifyPasswordHash(password, passwordHash, passwordSalt))
            {
                return null;
            }

            return user;
        }

        public Task<bool> ValidateUser(User user)
        {
            throw new NotImplementedException();
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public string GenerateJwtToken(int id, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("uV07Q~3mkk3-VVt~joAcuDoXMsRxgA5V3~mmI");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userDataAccess.GetAllUsersAsync();
            return users;
        }

        public async  Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await  _userDataAccess.GetUserByUsernameAsync(username);

            return user;
        }

        public async Task<User> Save(User user)
        {
            return await _userDataAccess.Save(user);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userDataAccess.CreateUserAsync(user);
        }

        public Task<bool> IsNumberValid(string number)
        {           
            return _userDataAccess.IsNumberValid(number);
        }

        public Task<int> GetUserOtp(int userId)
        {
            return _userDataAccess.GetUserOtp(userId);
        }


        public async Task<UserOtp> UpsertUserOtpAsync(string number)
        {
            try
            {

                var otpCode = await SendOtpAsync(number).ConfigureAwait(false);
                //var otpCode = 234234;

                return await _userDataAccess.UpsertUserOtpAsync(number, otpCode);
       

            }
            catch (Exception ex) {
                return null;
            }       
            
        }

        private async Task<int> SendOtpAsync(string phoneNumber)
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    var message = "Your OTP Code is {otp}. DO NOT SHARE THIS TO ANYONE.";
                    var request = new
                    {
                        apikey = _ApiKey,
                        number = phoneNumber,
                        message = message
                    };
                    var requestBody = JsonConvert.SerializeObject(request);
                    var response = await httpClient.PostAsync(_Url, new StringContent(requestBody, Encoding.UTF8, "application/json"));
                    var responseBody = await response.Content.ReadAsStringAsync();

                    var otpResponse = JsonConvert.DeserializeObject<IEnumerable<OtpResponse>>(responseBody);
                    return otpResponse.FirstOrDefault().code;
                }
            }

            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
