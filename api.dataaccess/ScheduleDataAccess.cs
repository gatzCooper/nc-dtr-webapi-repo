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

namespace api.dataaccess
{
    public class ScheduleDataAccess : IScheduleDataAccess
    {
        private readonly FaceAttendanceDbContext _dbContext;
        private readonly IMapper _mapper;

        public ScheduleDataAccess(FaceAttendanceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            var sched = await _dbContext.TblSchedules.AddAsync(_mapper.Map<TblSchedule>(schedule));
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Schedule>(sched);
        }

        public void DeleteScheduleAsync(Schedule schedule)
        {
            _dbContext.Remove(_mapper.Map<TblSchedule>(schedule));
            _dbContext.SaveChangesAsync();
        }

        public async Task<Schedule> GetScheduleByUserIdAsync(int userId)
        {
            var sched = await _dbContext.TblSchedules
                        .Where(s => s.UserId == userId)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

            return _mapper.Map<Schedule>(sched);
        }

        public async Task<IEnumerable<Schedule>> GetScheduleListAsync()
        {
            var schedules = await _dbContext.TblSchedules
                            .AsNoTracking()
                            .ToListAsync();
            return _mapper.Map<IEnumerable<Schedule>>(schedules);
        }

        public async Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            var updateSched = _dbContext.Update(_mapper.Map<Schedule>(schedule));
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Schedule>(updateSched.Entity);
        }
    }
}
