using api.common.Interface;
using api.common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.businesslayer
{
    public class ScheduleBusinessLayer : IScheduleBusinessLayer
    {
        private readonly IScheduleDataAccess _scheduleDataAccess;
        public ScheduleBusinessLayer(IScheduleDataAccess scheduleDataAccess)
        {
            _scheduleDataAccess = scheduleDataAccess;
        }
        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            return await _scheduleDataAccess.CreateScheduleAsync(schedule);
        }

        public void DeleteScheduleAsync(Schedule schedule)
        {
            _scheduleDataAccess.DeleteScheduleAsync(schedule);
        }

        public async Task<Schedule> GetScheduleByUserIdAsync(int userId)
        {
            var schedule = await _scheduleDataAccess.GetScheduleByUserIdAsync(userId); 
            return schedule;
        }

        public Task<IEnumerable<Schedule>> GetScheduleListAsync()
        {
            var schedules = _scheduleDataAccess.GetScheduleListAsync();
            return schedules;
        }

        public async Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            return await _scheduleDataAccess.UpdateScheduleAsync(schedule);
        }
    }
}
