/*
using Todo.Controller.Service;
using Todo.DataAccess;
using Todo.Model.Interfaces;
using Todo.Model.Models;
using Todo.Model.ViewModels;

namespace Todo.Test
{
    [TestClass]
    public class TaskServiceTest
    {
        [TestMethod]
        public void AddingATask()
        {
            ITaskRepo testRepo = new FileTaskRepo();
            ITaskService taskService = new TaskService(testRepo);

            var taskDueDate = DateTime.Now.AddDays(3);
            var task = new TaskCreateViewModel
            {
                Title = "Test Title",
                Description = "Test Description",
                Priority = TaskPriority.Urgent,
                Category = TaskCategory.Projects,
                DueDate = taskDueDate
            };
            taskService.AddTask(task);

            var databaseTasks = taskService.GetAllTasks().ToList();
            Assert.AreEqual(1, databaseTasks.Count(), "Database should have 1 task.");

            var savedTask = databaseTasks.First();
            Assert.AreEqual("Test Title", savedTask.Title);
            Assert.AreEqual("Test Description", savedTask.Description, "description was not addec correctly ");
            Assert.AreEqual(TaskPriority.Urgent, savedTask.Priority, "priority is not correct!");
            Assert.AreEqual(TaskCategory.Projects, savedTask.Category, "Category is not corrert");
            Assert.IsFalse(savedTask.IsCompleted, "New task should be incomplete!");
            Assert.AreEqual(1, savedTask.Id, "ID should be 1");
        }

        [TestMethod]
        public void MarkingTasksAsComplete()
        {
            ITaskRepo testRepo = new FileTaskRepo();
            ITaskService taskService = new TaskService(testRepo);

            var task = new TaskCreateViewModel { Title = "Task Completed" };
            taskService.AddTask(task);

            int taskIdCompleted = taskService.GetAllTasks().First().Id;
            Assert.AreEqual(1, taskIdCompleted);

            taskService.MarkTaskComplete(taskIdCompleted, true);

            var updatedTask = taskService.GetTaskById(taskIdCompleted);
            Assert.IsNotNull(updatedTask, "Could not find the updated task");
            Assert.IsTrue(updatedTask.IsCompleted, "Task was not marked as completed");
        }

        [TestMethod]
        public void DeletingATask()
        {
            ITaskRepo testRepo = new FileTaskRepo();
            ITaskService taskService = new TaskService(testRepo);

            var vm = new TaskCreateViewModel { Title = "Task to be deleted" };
            taskService.AddTask(vm);

            var tasksBeforeDelete = taskService.GetAllTasks().ToList();
            Assert.AreEqual(1, tasksBeforeDelete.Count(), "Setup failed: Task was not added.");
            int idToDelete = tasksBeforeDelete.First().Id;

            taskService.DeleteTask(idToDelete);
            var tasksAfterDelete = taskService.GetAllTasks().ToList();
            var deletedTask = taskService.GetTaskById(idToDelete);
            Assert.AreEqual(0, tasksAfterDelete.Count(), "Task was not removed from the list.");
            Assert.IsNull(deletedTask, "GetById should return null for a deleted task.");
        }

        [TestMethod]
        public void GetNonExistentID()
        {
            ITaskRepo testRepo = new FileTaskRepo();
            ITaskService taskService = new TaskService(testRepo);

            int wrongId = 123412341;
            var result = taskService.GetTaskById(wrongId);

            Assert.IsNull(result, "Task service should return null for indexing a non existent ID");

        }
    }
}
*/