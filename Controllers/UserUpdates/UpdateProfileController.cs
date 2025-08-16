using ChatAll.Application.Dtos;
using ChatAll.Application.Interfaces;
using ChatAll.Controllers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ChatAll.Controllers.UserUpdates
{

    [ApiController]
    [Route("api/[controller]")]
    public class UpdateProfileController: ControllerBase
    {

        private readonly IUserService _userService;

        // The logger is a function that provides me with a log of debug
        private readonly ILogger<UpdateProfileController> _logger;

        public UpdateProfileController (IUserService userService, ILogger<UpdateProfileController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileSetRequest request)
        {
            var result = await _userService.UpdateProfile (request);

            if (result)
            {
                return Ok(new { message = "Profile updated" });
            }


            return BadRequest(new { message = "Update failed" });
        }
    }
}
