using QueueManager.models;
using QueueManager.views;

namespace QueueManager.interfaces;

public interface ICommand
{
    string Name { get; set; }
    Queue<Person> Queue { get; set; }
    Display Display { get; set; }
    
    void OnCommand();
}