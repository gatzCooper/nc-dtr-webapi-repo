using api.common.Interface;
using api.common.model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace NC_Attendance_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       private readonly ILogger<AuthController> _logger;
       private readonly IUserBusinessLayer _userBusinessLayer;


        public AuthController(ILogger<AuthController> logger, IUserBusinessLayer userBusinessLayer)
        {
            _logger = logger;
            _userBusinessLayer = userBusinessLayer;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login request)
        {
            try
            {
                var userData = await _userBusinessLayer.GetUserLoginCredentials(request.UserName, request.Password);

                if (userData == null)
                {
                    return Unauthorized();
                }
                var token = _userBusinessLayer.GenerateJwtToken(userData.Id, request.UserName);

                var user = new
                {
                    authToken = token,
                    user = userData
                };

                var response = JsonConvert.SerializeObject(user);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }       
            
        }

        //[HttpGet("generateotp/{number}")]
        //public async Task<IActionResult> GenerateOtp(int number)
        //{
            
        //}

    }
}
