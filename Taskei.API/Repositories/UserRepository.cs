using Microsoft.EntityFrameworkCore;
using Taskei.API.Data;
using Taskei.API.Entities;

namespace Taskei.API.Repositories : IUserRepository
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}