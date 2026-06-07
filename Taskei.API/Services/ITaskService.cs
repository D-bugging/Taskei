using Taskei.API.DTOs;
using Taskei.API.Entities;

namespace Taskei.API.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem> CreateAsync(CreateTaskDto dto);
    }
}