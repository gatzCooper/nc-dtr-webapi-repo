using api.common.Interface;
using api.common.model;
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

        public ScheduleController(ILogger<ScheduleController> logger, IScheduleBusinessLayer scheduleBusinessLayer)
        {
            _logger = logger;
            _scheduleBusinessLayer = scheduleBusinessLayer;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedulesAsync()
        {
            try
            {
                var schedules = await _scheduleBusinessLayer.GetScheduleListAsync();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetScheduleByUserIdAsync(int userId)
        {
            try
            {
                var schedule = await _scheduleBusinessLayer.GetScheduleByUserIdAsync(userId);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateScheduleByUserIdAsync(int userId, [FromBody] Schedule schedule)
        {
            try
            {
                var sched = await _scheduleBusinessLayer.GetScheduleByUserIdAsync(userId);
                if(sched == null)
                {
                    return NotFound();
                }
                schedule.UserId = userId;
                await _scheduleBusinessLayer.UpdateScheduleAsync(schedule);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError()
                {
                    Exception = ex,
                    StatusCode = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
