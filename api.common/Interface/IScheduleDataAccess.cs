using api.common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.Interface
{
    public interface IScheduleDataAccess
    {
        Task<IEnumerable<Schedule>> GetScheduleListAsync();
        Task<Schedule> GetScheduleByUserIdAsync(int userId);
        Task<Schedule> CreateScheduleAsync(Schedule schedule);
        Task<Schedule> UpdateScheduleAsync(Schedule schedule);
        void DeleteScheduleAsync(Schedule schedule);
    }
}
