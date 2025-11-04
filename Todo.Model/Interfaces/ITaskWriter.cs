using Todo.Model.Models;

namespace Todo.Model.Interfaces
{
    public interface ITaskWriter
    {
        void Create(TaskTodo task);
        void Update(TaskTodo taskToUpdate);
        void Delete(int id);
    }
}