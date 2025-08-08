using ChatAll.Application.Dtos;
using ChatAll.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatAll.Controllers.Auth
{

    [Route("api/[controller]")]
    public class VerifyController : ControllerBase
    {

        // The nomenclature with i means that it is an interface
        private readonly IUserService _userService;

        // The logger is a function that provides me with a log of debug
        private readonly ILogger<VerifyController> _logger;


        public VerifyController(IUserService userService, ILogger<VerifyController> logger)
        {
            // The _ indicates that it is private
            _userService = userService;
            _logger = logger;
        }


        [HttpPost("verify")]
        public async Task<IActionResult> VerifyCode([FromBody] VerificationRequest dto)
        {
            var result = await _userService.VerifyCodeAsync(dto.LastCode, dto.Email);


            if (result)
            {
                return Ok(new { message = "Verification successful" });
            }



            return BadRequest(new { message = "Verification failed" });
        }
    }
}
