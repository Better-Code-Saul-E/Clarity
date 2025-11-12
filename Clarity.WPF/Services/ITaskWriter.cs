using Clarity.WPF.Models;

namespace Clarity.WPF.Services
{
    public interface ITaskWriter
    {
        void Create(TaskTodo task);
        void Update(TaskTodo taskToUpdate);
        void Delete(int id);
    }
}