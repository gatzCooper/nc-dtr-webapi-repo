using api.common.Interface;
using api.common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.businesslayer
{
    public class AttendanceBusinessLayer : IAttendanceBusinessLayer
    {
        private readonly IAttendanceDataAccess _attendanceDataAccess;
        public AttendanceBusinessLayer(IAttendanceDataAccess attendanceDataAccess)
        {
            _attendanceDataAccess = attendanceDataAccess;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceAsync()
        {
            var attendance = await _attendanceDataAccess.GetAllAttendanceAsync();

            return attendance;
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceByUserIdAsync(int userId)
        {
            var attendance = await _attendanceDataAccess.GetAttendanceByUserIdAsync(userId);
            return attendance;
        }

        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            return await _attendanceDataAccess.CreateAttendanceAsync(attendance);
        }
    }
}
