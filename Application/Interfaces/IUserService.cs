using ChatAll.Application.Dtos;
using ChatAll.Domain.Entities;

namespace ChatAll.Application.Interfaces
{

    // Defines what the user servie should do but not how it should do it
    public interface IUserService
    {

        // Create a new user with a password
        Task<User> CreateAsync(User user, string password);
        // Get the user email
        Task<User> GetEmailAsync(string email);

        // This need to be implemented
        string GenerateJwtToken(User user);

        // Update the verification code for a user identified by email
        Task<User> updateVerificationCode(int code, string email);

        // Verify the verification code
        Task<bool> VerifyCodeAsync(int code, string email);

        // Login a user with email and password
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
