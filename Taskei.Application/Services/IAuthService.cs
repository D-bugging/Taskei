using Taskei.Application.DTOs;

namespace Taskei.Application.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDto dto);
    }
}