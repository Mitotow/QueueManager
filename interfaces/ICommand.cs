using QueueManager.models;
using QueueManager.views;

namespace QueueManager.interfaces;

public interface ICommand
{
    string Name { get; set; }
    QueueModel Manager { get; set; }
    Display Display { get; set; }
    
    void OnCommand();
}