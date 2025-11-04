using Todo.Model.Models;

namespace Todo.Model.Interfaces
{
    public interface ITaskReader
    {
        TaskTodo? GetById(int id);
        IEnumerable<TaskTodo> GetAll();
    }
}