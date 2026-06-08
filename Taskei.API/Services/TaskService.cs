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

        public async Task<PagedResult<TaskItem>> GetAllAsync(FilterTaskDto filter)
        {
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
            filter.PageSize = filter.PageSize > 100 ? 100 : filter.PageSize;

            var query = _context.TaskItems.AsQueryable();

            // By Status
            if (filter.IsCompleted.HasValue)
                query = query.Where(t => t.IsCompleted == filter.IsCompleted.Value);

            // By Priority
            if (filter.Priority.HasValue)
                query = query.Where(t => t.Priority == filter.Priority.Value);

            // By Search
            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(t => t.Title.Contains(filter.Search) || t.Description.Contains(filter.Search));

            var totalRecords = await query.CountAsync();
            var tasks = await query
                .OrderBy(t => t.Id)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<TaskItem>
            {
                Data = tasks,
                TotalRecords = totalRecords,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }

        public async Task<TaskItem?> FindAsync(int id)
        {
            return await _context.TaskItems.FindAsync(id);
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

        public async Task<TaskItem?> UpdateAsync(int id, UpdateTaskDto dto)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
                return null;

            taskItem.Title = dto.Title;
            taskItem.Description = dto.Description;
            taskItem.IsCompleted = dto.IsCompleted;
            taskItem.Priority = dto.Priority;

            if (taskItem.IsCompleted && string.IsNullOrWhiteSpace(taskItem.Title))
                throw new Exception("Completed tasks must have a title.");

            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<TaskItem?> DeleteAsync(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
                return null;

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }
    }
}