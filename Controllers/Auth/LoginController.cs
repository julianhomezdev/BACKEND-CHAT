using ChatAll.Application.Dtos;
using ChatAll.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatAll.Controllers.Auth
{
    [Route("api/[controller]")]

    // ControllerBase -> Is a base class in ASP.NET Core that provides the fundamental functionality for handling HTTP requests

    public class LoginController : ControllerBase
    {

        private readonly IUserService _userService;

        // The logger is a function that provides me with a log of debug
        private readonly ILogger<LoginController> _logger;



        public LoginController(IUserService userService, ILogger<LoginController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("login")]
        // [FromBody] Takes the JSON and convert in a LoginRequest instance(request.email, request.password)
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _userService.LoginAsync(request.email, request.password);

            if (response != null)
            {
                return Ok(response); // 200 ok with the loginresponse created
            } else
            {
                return Unauthorized(new { message = "Invalid email or password" });// 401 unauthorized
            }


        }

    }
}
