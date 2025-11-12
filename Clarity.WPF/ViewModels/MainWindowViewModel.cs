using Clarity.WPF.Services;
using Clarity.WPF.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Clarity.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ITaskService _taskService;

        public ObservableCollection<TaskTodo> Tasks { get; set; }



        public MainWindowViewModel(ITaskService taskService)
        {
            _taskService = taskService;

            var allTasks = _taskService.GetAllTasks().ToList();
            Tasks = new ObservableCollection<TaskTodo>(allTasks);
        }
    }
}