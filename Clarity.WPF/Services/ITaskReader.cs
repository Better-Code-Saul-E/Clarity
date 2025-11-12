using Clarity.WPF.Models;

namespace Clarity.WPF.Services
{
    public interface ITaskReader
    {
        TaskTodo? GetById(int id);
        IEnumerable<TaskTodo> GetAll();
    }
}