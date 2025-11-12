using Clarity.WPF.Models.Enums;

namespace Clarity.WPF.Models.DTOs
{
    // this will pass information from the taskview to the taskservice
    // collects only the nessaecary dta
    public class TaskCreateViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.None;
        public TaskCategory? Category { get; set; }
        public DateTime? DueDate { get; set; }
    }
}