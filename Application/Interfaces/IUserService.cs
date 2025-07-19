using WikiAll.Models;

namespace ChatAll.Application.Interfaces
{

    // Defines what the user servie should do but not how it should do it
    public interface IUserService
    {


        Task<User> CreateAsync(User user, string password);
        Task<User> GetEmailAsync(string email);
        string GenerateJwtToken(User user);
    }
}
