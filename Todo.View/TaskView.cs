using Todo.Model;
using Todo.Model.Models;
using Todo.Model.ViewModels;

namespace Todo.View
{
    // FIX: catch input errors 

    /// <summary>
    /// Handles console based UI for the todo application
    /// </summary>
    
    // IDEA: replace the console with react

    public class TaskView
    {

        public string ShowMainMenu()
        {
            List<string> actions = new List<string>{
                "View All Tasks",
                "Add a New Task",
                "Mark a Task as Complete",
                "Delete a Task",
                "Quit" };

            printBanner("TODO APP");
            for (int i = 1; i <= actions.Count; i++)
            {
                print($"{i}) {actions[i - 1]}");
            }
            string choice = question("Enter your choice: ");

            return choice?.ToUpper() ?? string.Empty;
        }

        public void ShowAllTasks(IEnumerable<TaskTodo> tasks)
        {
            printBanner("All Tasks");
            if (!tasks.Any())
            {
                print("No tasks found!!!!");
            }
            else
            {
                foreach (var task in tasks)
                {
                    string status = task.IsCompleted ? "[X]" : "[ ]";
                    print($"{task.Id}. {status} {task.Title} (Priority: {task.Priority})");

                    if (task.DueDate.HasValue)
                    {
                        print($"    -> Due: {task.DueDate.Value.ToShortDateString()}");
                    }
                    if (task.Category.HasValue)
                    {
                        print($"    -> Category: {task.Category}");
                    }
                }
            }
            printDivder();
            WaitForAnyKey();
        }

        public TaskCreateViewModel ShowAddTaskScreen()
        {
            printBanner("Add New Task");
            var viewModel = new TaskCreateViewModel();

            while (true)
            {
                viewModel.Title = question("Title (required): ");
                if (!string.IsNullOrWhiteSpace(viewModel.Title))
                {
                    break;
                }
                print("Title cannot be empty. Please try again");
            }

            viewModel.Description = question("Description (optional): ");

            if (DateTime.TryParse(question("Due Date (optional, yyyy-mm--dd): "), out DateTime dueDate))
            {
                viewModel.DueDate = dueDate;
            }

            viewModel.Priority = GetTaskPriority();
            viewModel.Category = GetTaskCategory();

            return viewModel;
        }
        private TaskPriority GetTaskPriority()
        {
            return GetEnumFromUser<TaskPriority>("Priority (None, Low, Medium, High, Urgent) [default: None]: ", TaskPriority.None);
        }
        private TaskCategory GetTaskCategory()
        {
            return GetEnumFromUser<TaskCategory>("Category (None, General, Work, Personal, School, Projects, Admin, Miscellaneous) [default: None]: ", TaskCategory.None);
        }
        private T GetEnumFromUser<T>(string message, T defaultValue) where T : struct, Enum
        {
            while (true)
            {
                string? input = question(message);
                if (string.IsNullOrWhiteSpace(input))
                {
                    return defaultValue;
                }

                if (Enum.TryParse<T>(input, true, out T result))
                {
                    return result;
                }
                print("Invalid value. Please try again.");
            }
        }
        public int GetTaskIdToMarkComplete()
        {
            return GetIdFromUser("Enter the ID of the task to mark as complete: ");
        }

        public int GetTaskIdToDelete()
        {
            return GetIdFromUser("Enter the ID of the task to delete: ");
        }

        private int GetIdFromUser(string message)
        {
            while (true)
            {
                if (int.TryParse(question(message), out int id))
                {
                    return id;
                }
                print("Invalid input. Please enter a number!");
            }
        }




        public void WaitForAnyKey()
        {
            print("\nPress any key to continue...");
            Console.ReadKey();
        }
        public void ShowMessage(string message)
        {
            print($"\n->-> {message} <-<-");
            WaitForAnyKey();
        }
        private string question(string message)
        {
            print(message);
            return Console.ReadLine() ?? string.Empty;
        }
        private void print(string message)
        {
            Console.WriteLine(message);
        }
        private void printBanner(string title)
        {
            Console.Clear();
            Console.WriteLine("==========" + $" {title}" + "==========");
        }
        private void printDivder()
        {
            Console.WriteLine("===========================");
        }
    }
}