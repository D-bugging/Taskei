using System.ComponentModel.DataAnnotations;

namespace Taskei.API.DTOs
{
    public class UpdateTaskDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; } = string.Empty;
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        [Range(1, 3, ErrorMessage = "Priority must be between 1 and 3.")]
        public int Priority { get; set; } = 1;
    }
}