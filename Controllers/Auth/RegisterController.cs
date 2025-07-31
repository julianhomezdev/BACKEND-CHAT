using Azure.Core;
using ChatAll.Application.Dtos;
using ChatAll.Application.Interfaces;
using ChatAll.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatAll.Controllers.Auth
{

    [Route("api/[controller]")]
    // ControllerBase -> Is a base class in ASP.NET Core that provides the fundamental functionality for handling HTTP requests
    public class RegisterController : ControllerBase
    {

        // The nomenclature with i means that it is an interface
        private readonly IUserService _userService;

        // The logger is a function that provides me with a log of debug
        private readonly ILogger<RegisterController> _logger;




        public RegisterController(IUserService userService, ILogger<RegisterController> logger)
        {

            // The _ indicates that it is private
            _userService = userService;
            _logger = logger;


        }


        [HttpPost("register")]
        public async Task <IActionResult> Register([FromBody] RegisterRequest request)
        {

            _logger.LogInformation("Received RegisterRequest: {@request}", request);


            try
            {
                // Model validation
                if (!ModelState.IsValid)
                {

                    return BadRequest(new
                    {
                        message = "Invalid data",
                        errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                    });

                }


                // Verify if the email already exists
                var existingUser = await _userService.GetEmailAsync(request.Email);

                if (existingUser != null)

                {

                    return BadRequest(new { message = "The email is already registered" });

                }

                // Create the User object
                var user = new User

                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.Phone,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true

                };

                var createdUser = await _userService.CreateAsync(user, request.Password);


                // Generate the JWT token
                var token = _userService.GenerateJwtToken(createdUser);

                return Ok(new
                {

                    message = "User created succesfully",
                    user = new
                    {
                        
                        firstName = createdUser.FirstName,
                        lastName = createdUser.LastName,
                        email = createdUser.Email,
                        phone = createdUser.Phone
                    },

                    _token = token

                });

            }

            catch (Exception ex) {

                _logger.LogError(ex, "Error creating user");
                return StatusCode(500, new { message = "Internal server error" });
            
            }

        }



    }
}
