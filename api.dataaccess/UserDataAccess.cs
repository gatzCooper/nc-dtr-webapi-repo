using api.common.Interface;
using api.common.model;
using api.dataaccess.entityframework.data;
using api.dataaccess.entityframework.model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            _mapper = mapper;
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
                .Where(u => u.email == email && u.Password == password)
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
    }
}
