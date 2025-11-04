using System.Collections.Generic;
using Todo.Model.ViewModels;
using Todo.Model.Models;

namespace Todo.Model.Interfaces
{
    // The shit that app itsself has to do
    public interface ITaskService
    {
        void AddTask(TaskCreateViewModel newTask);


        TaskTodo? GetTaskById(int id);
        IEnumerable<TaskTodo> GetAllTasks();


        void UpdateTask(TaskTodo task);

        void DeleteTask(int id);

        void MarkTaskComplete(int id, bool isComplete);
    }
}