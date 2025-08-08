using ChatAll.Domain.Entities;

namespace ChatAll.Application.Interfaces
{

    // Defines what the user servie should do but not how it should do it
    public interface IUserService
    {


        Task<User> CreateAsync(User user, string password);
        Task<User> GetEmailAsync(string email);
        string GenerateJwtToken(User user);

        // Update the verification code for a user identified by email
        Task<User> updateVerificationCode(int code, string email);

        // Verify the verification code
        Task<bool> VerifyCodeAsync(int code, string email); 
    }
}
