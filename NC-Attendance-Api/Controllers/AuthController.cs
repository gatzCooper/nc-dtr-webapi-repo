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
                var userData = await _userBusinessLayer.GetUserLoginCredentials(request.userName, request.password);

                if (userData == null)
                {
                    return Unauthorized();
                }
                Random random = new Random();
                int randomNumber = random.Next(50);
                var token = _userBusinessLayer.GenerateJwtToken(randomNumber, request.userName);

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
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> GenerateOtp([FromBody] OtpRequest request)
        {
            try
            {
                 if (await _userBusinessLayer.IsNumberValid(request.code))
                {
                  var otp = _userBusinessLayer.UpsertUserOtpAsync(request.code);

                  return Ok(otp);
                }
                return NoContent();
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

        //[HttpPost("updatePassword")] 
        //public async Task<IActionResult> UpdatePassword([FromBody] ChangePassRequest request)
        //{
        //    try
        //    {
        //        var userId = await _userBusinessLayer.GetUserIdByContactNumberAsync(request.number);
        //        var otpCodeFromDb = await _userBusinessLayer.GetUserOtp(userId);

        //        if(request.otpcode == otpCodeFromDb)
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError()
        //        {
        //            Exception = ex,
        //            StatusCode = StatusCodes.Status500InternalServerError
        //        });
        //    }           
        //}
       
    }
}
