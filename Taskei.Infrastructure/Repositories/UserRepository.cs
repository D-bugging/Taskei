using Microsoft.EntityFrameworkCore;
using Taskei.Infrastructure.Data;
using Taskei.Domain.Entities;
using Taskei.Domain.Interfaces;

namespace Taskei.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
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