using Microsoft.AspNetCore.Mvc;
using Taskei.API.DTOs;
using Taskei.API.Services;

namespace Taskei.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks([FromQuery]FilterTaskDto filter)
        {
            var tasks = await _service.GetAllAsync(filter);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _service.FindAsync(id);
            if (task == null)
                return NotFound("Task not found.");
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            var task = await _service.CreateAsync(dto);
            return Created("Task created successfully.", task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody]UpdateTaskDto dto)
        {
            var task = await _service.UpdateAsync(id, dto);
            if (task == null)
                return NotFound("Task not found.");

            //return StatusCode(201, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result == null)
                return NotFound("Task not found.");
                
            return Ok("Task deleted successfully.");
        }
    }
}