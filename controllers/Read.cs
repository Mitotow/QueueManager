using QueueManager.interfaces;
using QueueManager.models;
using QueueManager.views;

namespace QueueManager.controllers;

public class Read : ICommand
{
    public string Name { get; set; } = "Read";
    public QueueModel Manager { get; set; }
    public Display Display { get; set; }

    public Read(Display disp)
    {
        Manager = QueueModel.GetInstance();
        Display = disp;
    }
    
    public void OnCommand()
    {
        var queue = Manager.GetQueue();
        if (queue.ElementAtOrDefault(0) is null)
        {
            Display.Print("Nobody in queue.");
            return;
        }
        Display.Print("===== Actual Queue =====\\n");
        Display.PrintQueue(queue);
    }
}