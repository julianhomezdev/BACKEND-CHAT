using ChatAll.Application.Dtos;
using ChatAll.Application.Interfaces;
using ChatAll.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        // The front sends a Form not a body, thats why FromForm
        public async Task<IActionResult> UpdateProfile([FromForm] ProfileSetRequest request)
        {
            try
            {
                var result = await _userService.UpdateProfile(request);
                return Ok(new { message = "Profile updated successfully" });
            }

            catch (Domain.Exceptions.ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            catch(NotFoundException ex)
            {

                return BadRequest(new {message = ex.Message});
            }

            catch(FileValidationException ex)
            {
                return BadRequest(new { message = ex.Message});
            }

            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Internal error" });
            }
        }
    }
}
