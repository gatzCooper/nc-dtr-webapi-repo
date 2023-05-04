using api.common.Interface;
using api.common.model;
using api.dataaccess.entityframework.data;
using api.dataaccess.entityframework.model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmsClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace api.dataaccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly FaceAttendanceDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserDataAccess(FaceAttendanceDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper; ;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            
            var userData = await _dbContext.Set<TblUser>().AddAsync(_mapper.Map<TblUser>(user));
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<User>(userData.Entity);

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _dbContext.TblUsers
                   .AsNoTracking() 
                   .ToListAsync();
            return _mapper.Map<IEnumerable<User>>(users);
        }

        public async Task<User> GetUserByemail(string email, string password)
        {
            var user = await _dbContext.TblUsers
                .Where(u => u.Username == email && u.Password == password)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<User>(user);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _dbContext.TblUsers
                .Where(u => u.Username == username)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<User>(user);
        }

        public async Task<User> Save(User user)
        {
           var updateUser = _dbContext.Update(_mapper.Map<TblUser>(user));
           await _dbContext.SaveChangesAsync();

           return _mapper.Map<User>(updateUser.Entity);
        }

        public async Task<bool> IsNumberValid(string number)
        {
            var user = await _dbContext.TblUsers
                        .Where(u => u.Contact == number)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

            return user?.Contact != null;
        }

   
        public async Task<UserOtp> UpsertUserOtpAsync(string number, int otpCode)
        {
            try
            {

                var id = await GetUserIdByContactNumberAsync(number);

                var userId = id;

                var userOtp = await _dbContext.TblUserOtp
                    .Where(u => u.UserId == userId)
                    .FirstOrDefaultAsync();

                var otp = new UserOtp()
                {
                    UserId = userId,
                    OtpCode = otpCode
                };

                if (userOtp == null)
                {
                    var entity = await _dbContext.Set<TblUserOtp>().AddAsync(_mapper.Map<TblUserOtp>(otp));
                    await _dbContext.SaveChangesAsync();
                    return _mapper.Map<UserOtp>(entity.Entity);
                }

                _mapper.Map(otp, userOtp); // Map the properties from otp to userOtp
                _dbContext.Update(userOtp);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<UserOtp>(userOtp);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<int> GetUserOtp(int userId)
        {
            var otpData = await _dbContext.TblUserOtp
                            .Where(o => o.UserId == userId)
                            .FirstOrDefaultAsync();
            var otp = otpData.OtpCode;

            return otp;
        }

        private async Task<int> GetUserIdByContactNumberAsync(string number)
        {
            var user = await _dbContext.TblUsers
                    .Where(u => u.Contact == number)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

            return user.Id;


        }


    }
}
