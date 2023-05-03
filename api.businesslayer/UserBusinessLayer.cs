using api.common.Interface;
using api.common.model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace api.businesslayer
{
    public class UserBusinessLayer : IUserBusinessLayer
    {
        private readonly IUserDataAccess _userDataAccess;
        public UserBusinessLayer(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
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
    }
}
