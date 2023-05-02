using api.common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NC_Attendance_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<SubjectController> _logger;
        private readonly ISubjectBusinessLayer _subjectBusinessLayer;

        public SubjectController(ILogger<SubjectController> logger, ISubjectBusinessLayer subjectBusinessLayer)
        {
            _logger = logger;
            _subjectBusinessLayer = subjectBusinessLayer;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjectsAsync()
        {
            try
            {
                var subjects = await _subjectBusinessLayer.GetSubjectsListAsync();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            try
            {
                var subject = await _subjectBusinessLayer.GetSubjectByIdAsync(id);
                return Ok(subject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
        
}
