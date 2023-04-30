using api.common.Interface;
using api.common.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NC_Attendance_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ILogger<AttendanceController> _logger;
        private readonly IAttendanceBusinessLayer _attendanceBusinessLayer;

        public AttendanceController(ILogger<AttendanceController> logger, IAttendanceBusinessLayer attendanceBusinessLayer)
        {
            _attendanceBusinessLayer = attendanceBusinessLayer;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendanceAsync()
        {
            try
            {
                var attendance = await _attendanceBusinessLayer.GetAllAttendanceAsync();

                return Ok(attendance);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
