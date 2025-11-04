using System;
using Todo.Model.Interfaces;

namespace Todo.View
{
    public class App
    {
        private readonly ITaskService _service;
        private readonly TaskView _view;


        public App(ITaskService service, TaskView view)
        {
            _service = service;
            _view = view;
        }


        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                string choice = _view.ShowMainMenu();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var tasks = _service.GetAllTasks();
                            _view.ShowAllTasks(tasks);
                            break;
                        case "2": // Add a New Task
                            var viewModel = _view.ShowAddTaskScreen();
                            _service.AddTask(viewModel);
                            _view.ShowMessage("Task added successfully!");
                            break;

                        case "3":
                            int completeId = _view.GetTaskIdToMarkComplete();
                            _service.MarkTaskComplete(completeId, true);
                            _view.ShowMessage("Task marked as complete!");
                            break;

                        case "4":
                            int deleteId = _view.GetTaskIdToDelete();
                            _service.DeleteTask(deleteId);
                            _view.ShowMessage("Task deleted successfully!");
                            break;

                        case "5":
                            isRunning = false;
                            break;

                        default:
                            _view.ShowMessage("Invalid choise, please try again");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _view.ShowMessage("Invalid choise, please try again");
                }
            }

            Console.WriteLine("Quitting the Todo App!");
        }
    }
}