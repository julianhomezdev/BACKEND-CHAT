using ChatAll.Application.Dtos;
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


        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {

            string emailTrimmed = request.Email.Trim().ToLower();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == emailTrimmed && u.Password == request.Password);

            if (user != null)
            {
                return new LoginResponse
                {
                    Email = user.Email,
                    FirstName = user.FirstName
                };
            } else
            {
                throw new Exception("Invalid email or password");
            }
            
        }


        public async Task<bool> UpdateProfile(ProfileSetRequest request)
        {
            string emailTrimmed = request.Email;

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == emailTrimmed);

            if (user != null) { 
            
                user.ProfilePhotoUrl = request.ProfilePhotoUrl;
                user.Description = request.Description;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }


            return false;
        }
    }
}
