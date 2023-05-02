using api.common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.Interface
{
    public interface IUserDataAccess
    {
        Task<User> GetUserByemail(string email, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> Save(User user);
        Task<User> CreateUserAsync(User user);
        Task<bool> IsNumberValid(string number);
        Task<int> GetUserIdByContactNumberAsync(string number);
        Task<UserOtp> UpsertUserOtpAsync(string number, int otpCode);
        Task<int> GetUserOtp(int userId);
    }
}
