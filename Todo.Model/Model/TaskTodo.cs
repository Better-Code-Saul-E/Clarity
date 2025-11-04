namespace Todo.Model.Models
{

    // just the plain task object
    public class TaskTodo
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public string Title { get; set; } = string.Empty;


        public string? Description { get; set; }
        public TaskPriority? Priority { get; set; } = TaskPriority.None;
        public TaskCategory? Category { get; set; }
        public DateTime? DueDate { get; set; }
    }
}