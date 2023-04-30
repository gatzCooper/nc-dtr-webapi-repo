using api.common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.Interface
{
    public interface IUserBusinessLayer
    {
        Task<User> GetUserLoginCredentials(string email, string password);
        Task<bool> ValidateUser(User user);
        string GenerateJwtToken(int id, string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> Save(User user);
        Task<User> CreateUserAsync(User user);
    }
}
