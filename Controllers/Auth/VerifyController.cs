using ChatAll.Application.Dtos;
using ChatAll.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatAll.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
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


        /// <summary>
        /// Verifies the provided code for a user's email address.
        /// </summary>
        /// <remarks>This method expects a valid <see cref="VerificationRequest"/> object in the request
        /// body.  Ensure that the <c>LastCode</c> and <c>Email</c> properties are correctly populated.</remarks>
        /// <param name="dto">The verification request containing the code to verify and the associated email address.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the verification.  Returns <see
        /// cref="OkObjectResult"/> with a success message if the code is valid;  otherwise, returns <see
        /// cref="BadRequestObjectResult"/> with an error message.</returns>

        [HttpPost]
        public async Task<IActionResult> VerifyCode([FromBody] VerificationRequest dto)
        {
            var result = await _userService.VerifyCodeAsync(dto.LastCode, dto.Email);


            if (result)
            {
                return Ok(new { message = "Verification successful" });
            }


            return BadRequest(new { message = "Wrong code" });
        }
    }
}
