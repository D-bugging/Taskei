using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taskei.Application.DTOs;
using Taskei.Domain.Entities;
using Taskei.Domain.Interfaces;
using Taskei.Application.Common;

namespace Taskei.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TaskItem>> GetAllAsync(FilterTaskDto filter)
        {
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
            filter.PageSize = filter.PageSize > 100 ? 100 : filter.PageSize;

            var query = (await _repository.GetAllAsync()).AsQueryable();

            // By Status
            if (filter.IsCompleted.HasValue)
                query = query.Where(t => t.IsCompleted == filter.IsCompleted.Value);

            // By Priority
            if (filter.Priority.HasValue)
                query = query.Where(t => t.Priority == filter.Priority.Value);

            // By Search
            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(t => t.Title.Contains(filter.Search) || t.Description.Contains(filter.Search));

            var totalRecords = query.Count();
            var tasks = query
                .OrderBy(t => t.Id)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

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
            return await _repository.GetByIdAsync(id);
        }
        public async Task<TaskItem> CreateAsync(CreateTaskDto dto, int userId)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new Exception("Title is required for creating a task.");
            var taskItem = _mapper.Map<TaskItem>(dto);
            taskItem.UserId = userId;
            return await _repository.AddAsync(taskItem);
        }

        public async Task<TaskItem?> UpdateAsync(int id, UpdateTaskDto dto)
        {
            var taskItem = await _repository.GetByIdAsync(id);
            if (taskItem == null)
                return null;

            _mapper.Map(dto, taskItem);

            if (taskItem.IsCompleted && string.IsNullOrWhiteSpace(taskItem.Title))
                throw new Exception("Completed tasks must have a title.");

            await _repository.UpdateAsync(taskItem);
            return taskItem;
        }

        public async Task<TaskItem?> DeleteAsync(int id)
        {
            var taskItem = await _repository.GetByIdAsync(id);
            if (taskItem == null)
                return null;

            await _repository.DeleteByIdAsync(id);
            return taskItem;
        }
    }
}