using System.Linq;
using System.Threading.Tasks;
using CityApi.Core.Entities;
using CityApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CityApi.Services.CityService
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context=context;
        }
        public async Task<ServiceResponse<int>> Register(UserEntity user, string password)
        {
            CreatePasswordHash(password,out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash=passwordHash;
            user.PasswordSalt=passwordSalt;
            _context.UserEntities.Add(user);
            await _context.SaveChangesAsync();
            ServiceResponse<int> service=new ServiceResponse<int>();
            service.Data=user.Id;
            return service;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.UserEntities.FirstOrDefaultAsync(x => 
                x.Username.ToLower().Equals(username.ToLower()));
            if (user==null)
            {
                response.Success = false;
                response.Message = "User not found!";
            }
            else if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incorrect password";
            }
            else
            {
                response.Data = user.Id.ToString();
            }
            return response;
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(passwordSalt))
            {
                var computeHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
