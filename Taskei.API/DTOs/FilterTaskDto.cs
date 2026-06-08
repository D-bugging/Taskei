namespace Taskei.API.DTOs
{
    public class FilterTaskDto
    {
        public bool? IsCompleted { get; set; }
        public int? Priority { get; set; }
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}