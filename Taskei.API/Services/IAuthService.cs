using Taskei.API.DTOs;

namespace Taskei.API.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDto dto);
    }
}