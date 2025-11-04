using Todo.Model.Models;
using System.Collections.Generic;

namespace Todo.Model.Interfaces
{
    // the shit the database HAS TO DO!
    public interface ITaskRepo : ITaskReader, ITaskWriter
    {
        int SaveChanges();
    }
}