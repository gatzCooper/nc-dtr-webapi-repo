using api.common.Interface;
using api.common.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NC_Attendance_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserBusinessLayer _userBusinessLayer;

        public UserController(ILogger<UserController> logger, IUserBusinessLayer userBusinessLayer)
        {
            _logger = logger;
            _userBusinessLayer = userBusinessLayer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var users = await _userBusinessLayer.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userName}")]
        public async Task<IActionResult> UpdateUser(string userName, [FromBody] User user)
        {
            try
            {
                var userData = await _userBusinessLayer.GetUserByUsernameAsync(userName);

                if (userData == null)
                    return NotFound();

                user.Username = userName;

                await _userBusinessLayer.Save(userData);
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

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userBusinessLayer.GetUserByUsernameAsync(userName);
                if (user == null) return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
