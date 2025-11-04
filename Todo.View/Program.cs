using Todo.Controller.Service;
using Todo.DataAccess;
using Todo.Model.Interfaces;    

namespace Todo.View
{
    class Program
    {
        static void Main(string[] args)
        {

            ITaskRepo database = new FileTaskRepo();
            ITaskService service = new TaskService(database);
            TaskView view = new TaskView();

            App app = new App(service, view);
            app.Run();
        }
    }
}