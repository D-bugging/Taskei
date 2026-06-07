using Microsoft.EntityFrameworkCore;
using Taskei.API.Data;
using Taskei.API.DTOs;
using Taskei.API.Entities;

namespace Taskei.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem> CreateAsync(CreateTaskDto dto)
        {
            var taskItem = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority
            };

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return taskItem;
        }
    }
}