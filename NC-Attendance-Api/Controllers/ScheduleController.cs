using api.businesslayer;
using api.common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NC_Attendance_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IScheduleBusinessLayer _scheduleBusinessLayer;

        public ScheduleController(ILogger<ScheduleController> logger, IScheduleBusinessLayer scheduleBusinesslayer)
        {
            _logger = logger;
            _scheduleBusinessLayer = scheduleBusinesslayer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllScheduleAsync()
        {
            try
            {
                var schedList = await _scheduleBusinessLayer.GetScheduleListAsync();
                return Ok(schedList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetScheduleByUserNameAsync(int userId)
        {
            try
            {
                var sched = await _scheduleBusinessLayer.GetScheduleByUserIdAsync(userId);
                return Ok(sched);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
