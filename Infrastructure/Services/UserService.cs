using ChatAll.Application.Interfaces;
using ChatAll.Domain.Entities;
using ChatAll.Infraestructure.DbData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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

        public async Task<User> updateVerificationCode(int code, string email)
        {

            var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (userToUpdate != null)
            {
                userToUpdate.LastCode = code;
                _context.Users.Update(userToUpdate);
                await _context.SaveChangesAsync();

            }


            return userToUpdate;
        }


        public async Task<bool> VerifyCodeAsync(int code, string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null && user.LastCode == code)
            {
                return true;
            }
            return false;
        }
    }
}
