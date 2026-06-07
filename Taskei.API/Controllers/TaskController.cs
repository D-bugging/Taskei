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
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            var task = await _service.CreateAsync(dto);
            return Ok(task);
        }
    }
}