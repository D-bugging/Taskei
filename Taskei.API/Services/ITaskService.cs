using Taskei.API.DTOs;
using Taskei.API.Entities;

namespace Taskei.API.Services
{
    public interface ITaskService
    {
        Task<PagedResult<TaskItem>> GetAllAsync(FilterTaskDto filter);
        Task<TaskItem?> FindAsync(int id);
        Task<TaskItem> CreateAsync(CreateTaskDto dto);
        Task<TaskItem?> UpdateAsync(int id, UpdateTaskDto dto);
        Task<TaskItem?> DeleteAsync(int id);
    }
}