using api.common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.Interface
{
    public interface IAttendanceDataAccess
    {
        Task<IEnumerable<Attendance>> GetAllAttendanceAsync();
        Task<IEnumerable<Attendance>> GetAttendanceByUserIdAsync(int userId);
        Task<Attendance> CreateAttendanceAsync(Attendance attendance);
    }
}
