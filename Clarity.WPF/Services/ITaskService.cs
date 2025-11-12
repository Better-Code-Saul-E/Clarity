using System.Collections.Generic;
using Clarity.WPF.Models.DTOs;
using Clarity.WPF.ViewModels;
using Clarity.WPF.Models;

namespace Clarity.WPF.Services
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