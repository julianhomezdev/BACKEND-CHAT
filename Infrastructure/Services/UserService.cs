using ChatAll.Application.Interfaces;
using ChatAll.Domain.Entities;
using ChatAll.Infraestructure.DbData;
using Microsoft.EntityFrameworkCore;

namespace ChatAll.Infraestructure.Services
{

    // In this service we implement the logic of what the interface tell us to do
    public class UserService : IUserService

    {

        private readonly ChatDb _context;
       

        public UserService(ChatDb context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user, string password)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public string GenerateJwtToken(User user)
        {
            return "Fake token";
            
        }

        public async Task<User> GetEmailAsync(string email)
        {
           return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
