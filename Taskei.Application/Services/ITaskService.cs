using Taskei.Application.DTOs;
using Taskei.Domain.Entities;
using Taskei.Application.Common;

namespace Taskei.Application.Services
{
    public interface ITaskService
    {
        Task<PagedResult<TaskItem>> GetAllAsync(FilterTaskDto filter);
        Task<TaskItem?> FindAsync(int id);
        Task<TaskItem> CreateAsync(CreateTaskDto dto, int userId);
        Task<TaskItem?> UpdateAsync(int id, UpdateTaskDto dto);
        Task<TaskItem?> DeleteAsync(int id);
    }
}