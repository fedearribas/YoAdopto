using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using YoAdopto.API.Models;
using Microsoft.EntityFrameworkCore;
using YoAdopto.API.Contracts;
using CryptoHelper;

namespace YoAdopto.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        public AuthRepository(DataContext context)
        {
            this.context = context;

        }
        public async Task<User> Login(string email, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return null;

            if (!VerifyPassword(user.Password, password))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            user.Password = HashPassword(password);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        // Method to verify the password hash against the given password
        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }

        public async Task<bool> UserExists(string username, string email)
        {
            if (await context.Users.AnyAsync(x => x.Username == username || x.Email == email))
                return true;
            return false;
        }
    }
}