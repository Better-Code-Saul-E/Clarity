using Clarity.WPF.Models;
using System.Collections.Generic;

namespace Clarity.WPF.Services
{
    // the shit the database HAS TO DO!
    public interface ITaskRepo : ITaskReader, ITaskWriter
    {
        int SaveChanges();
    }
}