using System.ComponentModel.DataAnnotations;

namespace Taskei.Domain.Entities
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}