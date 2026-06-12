using Taskei.Domain.Entities;

namespace Taskei.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}