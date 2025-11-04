using Todo.Model.Models;
using Todo.Model.Interfaces;

namespace Todo.DataAccess
{
    // IDEA: use guid instead of int for IDs
    // IDEA: initialze the lists inside the constructor
    public class FileTaskRepo: ITaskRepo
    {
        private readonly List<TaskTodo> _database = new List<TaskTodo>();

        private readonly List<TaskTodo> _pendingAdds = new List<TaskTodo>();
        private readonly List<TaskTodo> _pendingUpdates = new List<TaskTodo>();
        
        private readonly List<int> _pendingDeletes = new List<int>();
        private int _nextId = 1;

        public FileTaskRepo()
        {
        }

        public int SaveChanges()
        {
            int itemsChanged = 0;
            foreach (int id in _pendingDeletes)
            {
                var removedAmount = _database.RemoveAll(t => t.Id == id);
                itemsChanged += removedAmount;
            }

            foreach (var task in _pendingUpdates)
            {
                var index = _database.FindIndex(t => t.Id == task.Id);
                if (index != -1)
                {
                    _database[index] = task;
                    itemsChanged++;
                }
            }

            foreach (var task in _pendingAdds)
            {
                task.Id = _nextId++;
                _database.Add(task);
                itemsChanged++;
            }

            _pendingAdds.Clear();
            _pendingUpdates.Clear();
            _pendingDeletes.Clear();

            return itemsChanged;
        }

        public IEnumerable<TaskTodo> GetAll()
        {
            return _database;
        }

        public TaskTodo? GetById(int id)
        {
            return _database.FirstOrDefault(task => task.Id == id);
        }

        public void Create(TaskTodo task)
        {
            _pendingAdds.Add(task);
        }
        public void Update(TaskTodo taskToUpdate)
        {
            _pendingUpdates.Add(taskToUpdate);
        }

        public void Delete(int id)
        {
            _pendingDeletes.Add(id);
        }
    }
}