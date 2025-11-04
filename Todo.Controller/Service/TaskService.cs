using Todo.Model;
using Todo.Model.Interfaces;
using Todo.Model.ViewModels;
using Todo.Model.Models;

namespace Todo.Controller.Service
{
    /// <summary>
    /// This class will handle all communcation with the database
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo _taskRepo;

        public TaskService(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public void AddTask(TaskCreateViewModel newTask)
        {
            var task = new TaskTodo
            {
                Title = newTask.Title,
                Description = newTask.Description,
                DueDate = newTask.DueDate,
                Priority = newTask.Priority,
                Category = newTask.Category,
                IsCompleted = false,
                CreatedDate = DateTime.Now
            };

            _taskRepo.Create(task);
            _taskRepo.SaveChanges();
        }

        public TaskTodo? GetTaskById(int id)
        {
            return _taskRepo.GetById(id);
        }

        public IEnumerable<TaskTodo> GetAllTasks()
        {
            return _taskRepo.GetAll();
        }
        public void MarkTaskComplete(int id, bool isComplete)
        {
            var task = _taskRepo.GetById(id);

            if( task != null){
                task.IsCompleted = isComplete;
                _taskRepo.Update(task);
                _taskRepo.SaveChanges();
            }
        }

        public void UpdateTask(TaskTodo task)
        {
            _taskRepo.Update(task);
            _taskRepo.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            _taskRepo.Delete(id);
            _taskRepo.SaveChanges();
        }
    }
}